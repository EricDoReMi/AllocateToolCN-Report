using System.Configuration;
using AllocateTool.dao;
using AllocateTool.Entity;
using AllocateTool.utils;
using System.Data.OleDb;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AllocateTool.AllocateToolException;
using System.IO;

namespace AllocateTool.control
{
    public partial class TransferDataControl
    {
        
        private RecordDAO recordDao = new RecordDAO();
        private RecordSumDAO recordSumDao = new RecordSumDAO();
        private MailStoneDao mailStoneDao = new MailStoneDao();


        /// <summary>
        /// 转移数据库的Record表，用于合并数据库
        /// </summary>
        /// <param name="DesDataBase">被合并到的总库</param>
        /// <param name="SourceDataBases">要合并的原数据库</param>
        public  void TransferRecordDataBases(string DesDataBase,string SourceDataBases)
        {
          
            List<RecordSum> recordSumList = new List<RecordSum>();
 
           OLDBHelper.dataSourceStr = SourceDataBases;
                List<Record> sourceDataRecords = FindSourceCompletedAndIncompletedRecords();
                 for (int i = 0; i < sourceDataRecords.Count; i++)
                {

                    sourceDataRecords[i].M_isupload = "Y";
                    RecordSum sumRecord = new RecordSum();


                        string shipmentConsolNo= RegexHelper.GetFirstStrByRegex(@"(S|C){1}[0-9]{10}", sourceDataRecords[i].M_subject.Trim());

                    if (shipmentConsolNo.Length>0) {
                        sumRecord.M_subject =   shipmentConsolNo;
                    }

                    sumRecord.M_requestID = sourceDataRecords[i].M_requestID;

                    sumRecord.M_mailincometime= sourceDataRecords[i].M_mailincometime;

                    sumRecord.M_importance = sourceDataRecords[i].M_importance;

                    sumRecord.M_dbName = SourceDataBases;

                    sumRecord.M_Branch= RegexHelper.GetFirstStrByRegex(@"[A-Za-z]{3}A[0-9]{5}", sourceDataRecords[i].M_importance.Trim());

                if (sumRecord.M_Branch == "" && sourceDataRecords[i].M_requestID.Trim().Length >= 3)
                {

                    sumRecord.M_Branch = RegexHelper.GetFirstStrByRegex(@"[A-Za-z]{3}", sourceDataRecords[i].M_requestID.Trim().Substring(0, 3));
                }

                if (sumRecord.M_Branch.Length >= 3)
                {
                    sumRecord.M_Branch = sumRecord.M_Branch.Substring(0, 3).ToUpper();
                }


                recordSumList.Add(sumRecord);
                    
                }

           

            
            if (recordSumList.Count > 0) {
                BathUpdateRecordsToDB(sourceDataRecords);
                OLDBHelper.DisposeDB();
                OLDBHelper.dataSourceStr = DesDataBase;
                BathAddRecordSumToDB(recordSumList);
            }

            OLDBHelper.DisposeDB();

        }

        public void GetReport(string sourceDateBaseStr,DateTime startDate,DateTime stopDate,string wbPath)
        {
            string msgStr = "";
            Dictionary<string, HashSet<string>> wbDic = mailStoneDao.FindMailRequestDic(wbPath,out msgStr);


            OLDBHelper.dataSourceStr = sourceDateBaseStr;
            OleDbConnection con = recordSumDao.Begin();

            DateTime inputDate=startDate;

            string outputPath = @".\resultDatas\";

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            while (DateTime.Compare(inputDate, stopDate) < 0)
            {
                List<RecordSum> listsRecordSum = recordSumDao.FindRecordSumDur(con, inputDate, inputDate.AddDays(1));
                HashSet<string> uniqueSub = recordSumDao.GetUniqueSubject(con, inputDate);
                //写入CSV文件
                
                using (StreamWriter sw = new StreamWriter(outputPath + inputDate.ToString
                ("yyyyMMdd") + ".csv",false,Encoding.Default))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("shipment,console,Branch,MailIncomeDate,stationCode, ASNLink,DBName");
                    
                    sw.WriteLine(sb.ToString());

                    for (int i = 0; i < listsRecordSum.Count; i++)
                    {
                        RecordSum recordSum = listsRecordSum[i];

                        string subjectStr = recordSum.M_subject.ToUpper().Trim();

                        if (!uniqueSub.Contains(subjectStr))
                        {
                            uniqueSub.Add(subjectStr);
                            HashSet<string> shipmentSet = new HashSet<string>();
                            if (wbDic.ContainsKey(subjectStr))
                            {
                                shipmentSet = wbDic[subjectStr];
                            }
                            else
                            {
                                if (subjectStr.ToUpper().StartsWith("S"))
                                {
                                    shipmentSet.Add(subjectStr);
                                }
                                else
                                {
                                    shipmentSet.Add("");
                                }
                            }

                            foreach (string shipmentStr in shipmentSet)
                            {
                                StringBuilder sbTmp = new StringBuilder();
                                sbTmp.Append("\""+ shipmentStr + "\"");
                                sbTmp.Append(",");

                                sbTmp.Append("\"" + subjectStr + "\"");
                                sbTmp.Append(",");

                                sbTmp.Append("\"" + recordSum.M_Branch + "\"");
                                sbTmp.Append(",");

                                sbTmp.Append("\"" + recordSum.M_mailincometime.ToString() + "\"");
                                sbTmp.Append(",");

                                sbTmp.Append("\"" + recordSum.M_requestID + "\"");
                                sbTmp.Append(",");

                                sbTmp.Append("\"" + recordSum.M_importance + "\"");
                                sbTmp.Append(",");

                                sbTmp.Append("\"" + recordSum.M_dbName + "\"");
                                sbTmp.Append(",");

                                sw.WriteLine(sbTmp.ToString());


                            }
                        }



                    }
                }

                

                inputDate = inputDate.AddDays(1);

            }






            recordSumDao.Close();
            OLDBHelper.DisposeDB();

            



        }





        public List<RecordSum> FindRecordSumListByDate(DateTime startDate,DateTime endDate,string dataSourceStr)
        {
            List<RecordSum> recordSumList = null;
            try
            {
                OLDBHelper.dataSourceStr = dataSourceStr;
                OleDbConnection con = recordSumDao.Begin();
                recordSumList = recordSumDao.FindRecordSumDur(con, startDate, endDate);
                recordSumDao.Commit();
                return recordSumList;
            }
            catch (Exception)
            {
                recordSumDao.RollBack();
                throw;
            }
            finally
            {
                recordSumDao.Close();
            }
        }
    
        /// <summary>
        /// 寻找所有的Completed和Incompleted的case
        /// </summary>
        /// <returns></returns>
        private List<Record> FindSourceCompletedAndIncompletedRecords()
        {
            List<Record> records = null;
            try
            {
                OleDbConnection con = recordDao.Begin();
                records = recordDao.FindRecordsCompletedAndIncompleted(con);
                recordDao.Commit();
                return records;
            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }

        }
        private void UpdateRecordToDB(Record record)
        {
            try
            {
                OleDbConnection con = recordDao.Begin();
                recordDao.UpdateRecordItemDAO(con, record);
                recordDao.Commit();

            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }
        }



        private void BathUpdateRecordsToDB(List<Record> records)
        {
            try
            {
                OleDbConnection con = recordDao.Begin();
                foreach (Record record in records)
                {
                    recordDao.UpdateRecordItemDAO(con, record);
                }

                recordDao.Commit();

            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }
        }

       

    

      
        /// <summary>
        /// 向数据库添加单条Record的记录 
        /// </summary>
        /// <param name="record"></param>
        private void AddRecordToDB(Record record)
        {
            try
            {
                OleDbConnection con = recordDao.Begin();
                recordDao.AddRecordItemDAO(con, record);
                recordDao.Commit();

            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }
        }

        private void BathAddRecordsToDB(List<Record> records)
        {
            try
            {
                OleDbConnection con = recordDao.Begin();
                foreach (Record record in records)
                {
                    recordDao.AddRecordItemDAO(con, record);
                }

                recordDao.Commit();

            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }
        }

        private void AddRecordSumToDB(RecordSum recordSum)
        {
            try
            {
                OleDbConnection con = recordSumDao.Begin();
                recordSumDao.AddRecordSumItemDAO(con, recordSum);
                recordSumDao.Commit();

            }
            catch (Exception)
            {
                recordSumDao.RollBack();
                throw;
            }
            finally
            {
                recordSumDao.Close();
            }
        }

        private void BathAddRecordSumToDB(List<RecordSum> recordSumList)
        {
            try
            {
                OleDbConnection con = recordSumDao.Begin();
                foreach (RecordSum recordSum in recordSumList)
                {
                    recordSumDao.AddRecordSumItemDAO(con,recordSum);
                }

                recordSumDao.Commit();

            }
            catch (Exception)
            {
                recordSumDao.RollBack();
                throw;
            }
            finally
            {
                recordSumDao.Close();
            }
        }


    }
}
