using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AllocateTool.utils;
using AllocateTool.Entity;
using System.Data;

namespace AllocateTool.dao
{
    public partial class RecordSumDAO : BaseDAO<RecordSum>
    {
        /**//// <summary>   
            /// 根据id查找对应员工
            /// </summary>   
            /// <param name="conn">数据库连接</param> 
            /// <param name="sqlStr">sql语句</param>   
            /// <param name="paras">参数,默认值null</param>  
            /// <returns>OleDbDataAdapter</returns>   
        public RecordSum FindRecordSumByIdDAO(OleDbConnection conn, long id)
        {

            string sqlStr = @"SELECT * FROM recordSum WHERE m_id=@M_id";
            OleDbParameter[] paras = { new OleDbParameter("@M_id", id) };
            List<RecordSum> list = queryEntity(conn, sqlStr, paras);

            if (list.Count() > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据时间区间查找RecordSum
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<RecordSum> FindRecordSumDur(OleDbConnection conn, DateTime? startDate, DateTime? endDate)
        {
            string sql = "Select * from recordSum WHERE m_mailincometime BETWEEN @startDate AND @endDate";

            OleDbParameter[] ps = {
                new OleDbParameter("@startDate", EntityUtils.SqlNull(startDate)),
                new OleDbParameter("@endDate", EntityUtils.SqlNull(endDate)),
            };

            List<RecordSum> list = queryDataTableEntity(conn, sql, ps);


            return list;

        }

        /// <summary>
        /// 查找前一天去重后的Subject
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="beforeDate"></param>
        /// <returns></returns>
        public HashSet<string> GetUniqueSubject(OleDbConnection conn, DateTime? beforeDate)
        {

            HashSet<string> uniqueSub = null;
            string sql = "Select distinct m_subject from recordSum WHERE m_mailincometime<@beforeDate";

            OleDbParameter p = new OleDbParameter("@beforeDate", EntityUtils.SqlNull(beforeDate));
            //调用query返回结果集
            DataTable tb = SelectToDataTable(conn, sql, p);

            if (tb.Rows.Count > 0)
            {
                uniqueSub = new HashSet<string>();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    uniqueSub.Add(tb.Rows[i]["m_subject"].ToString().Trim());
                }
            }

            return uniqueSub;

        }

        /// <summary>
        /// 查找并去重，性能太慢了，弃用
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<RecordSum> FindRecordSumRemoveDup(OleDbConnection conn,DateTime? startDate,DateTime? endDate)
        {
            string sql = "Select * from recordSum WHERE m_mailincometime BETWEEN @startDate AND @endDate  and m_subject not in( SELECT distinct m_subject  from recordSum where m_mailincometime<@endDate);";

            OleDbParameter[] ps = {
                new OleDbParameter("@startDate", EntityUtils.SqlNull(startDate)),
                new OleDbParameter("@endDate", EntityUtils.SqlNull(endDate)),
            };

            List<RecordSum> list = queryDataTableEntity(conn, sql, ps);


            return list;

        }

        
        public void AddRecordSumItemDAO(OleDbConnection conn, RecordSum recordSum)
        {

            string sqlStr = @"INSERT INTO recordSum (m_subject,m_requestID,m_importance,m_mailincometime,m_Branch,m_dbName) VALUES(@M_subject,@M_requestID,@M_importance,@M_mailincometime,@M_Branch,@M_dbName)";
            OleDbParameter[] paras = recordSum.ToInsertByParamArray();

            ExecuteSQLNonquery(conn, sqlStr, paras);

        }



        public override RecordSum ToEntity(object row)
        {
            RecordSum recordSum = new RecordSum();
            DataRow dataRow = row as DataRow;

            recordSum.M_id = Convert.ToInt32(dataRow["m_id"].ToString());
            recordSum.M_importance = dataRow["m_importance"].ToString();
            recordSum.M_mailincometime = Convert.ToDateTime(dataRow["m_mailincometime"]);
            recordSum.M_dbName = dataRow["m_dbName"].ToString();
            recordSum.M_requestID = dataRow["m_requestID"].ToString();
            recordSum.M_subject = dataRow["m_subject"].ToString();
            recordSum.M_Branch = dataRow["m_Branch"].ToString();


            return recordSum;
        }

    }
}
