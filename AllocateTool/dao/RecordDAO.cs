using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AllocateTool.utils;
using AllocateTool.Entity;

namespace AllocateTool.dao
{
    public partial class RecordDAO : BaseDAO<Record>
    {
        /**//// <summary>   
            /// 根据id查找对应员工
            /// </summary>   
            /// <param name="conn">数据库连接</param> 
            /// <param name="sqlStr">sql语句</param>   
            /// <param name="paras">参数,默认值null</param>  
            /// <returns>OleDbDataAdapter</returns>   
        public Record FindRecordByIdDAO(OleDbConnection conn, long id)
        {

            string sqlStr = @"SELECT * FROM records WHERE m_id=@M_id";
            OleDbParameter[] paras = { new OleDbParameter("@M_id", id) };
            List<Record> list = queryEntity(conn, sqlStr, paras);

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
        /// 查找所有的Completed和Incompleted的数据
        /// </summary>
        /// <param name="conn">连接名</param>
        /// <returns></returns>
        public List<Record> FindRecordsCompletedAndIncompleted(OleDbConnection conn) {
            string sqlStr = @"SELECT * FROM records WHERE (m_statu='1' OR m_statu='2') AND m_isupload=@M_isupload;";
            OleDbParameter[] paras = { new OleDbParameter("@M_isupload", "N") };
            List<Record> list = queryEntity(conn, sqlStr,paras);
            return list;
        }
       
        public void AddRecordItemDAO(OleDbConnection conn, Record record)
        {

            string sqlStr = @"INSERT INTO records (JOBID,T1,UserName,m_subject,m_requestID,m_importance,m_actiontype,m_sender,m_acceptby,m_asign,m_accepttime,m_completetime,m_incompletetime,m_mailincometime,m_incompleteStatue,m_priority,m_text,m_statu,m_asnlink,m_shift,m_isupload) VALUES(@JOBID,@T1,@UserName,@M_subject,@M_requestID,@M_importance,@M_actiontype,@M_sender,@M_acceptby,@M_asign,@M_accepttime,@M_completetime,@M_incompletetime,@M_mailincometime,@M_incompleteStatue,@M_priority,@M_text,@M_statu,@M_asnlink,@M_shift,@M_isupload)";
            OleDbParameter[] paras = record.ToInsertByParamArray();
           
            ExecuteSQLNonquery(conn, sqlStr, paras);

        }

        public void UpdateRecordItemDAO(OleDbConnection conn, Record record)
        {

            string sqlStr = @"UPDATE records SET JOBID=@JOBID,T1=@T1,UserName=@UserName,m_subject=@M_subject,m_requestID=@M_requestID,m_importance=@M_importance,m_actiontype=@M_actiontype,m_sender=@M_sender,m_acceptby=@M_acceptby,m_asign=@M_asign,m_accepttime=@M_accepttime,m_completetime=@M_completetime,m_incompletetime=@M_incompletetime,m_mailincometime=@M_mailincometime,m_incompleteStatue=@M_incompleteStatue,m_priority=@M_priority,m_text=@M_text,m_statu=@M_statu,m_asnlink=@M_asnlink,m_shift=@M_shift,m_isupload=@M_isupload WHERE m_id=@M_id;";
            OleDbParameter[] paras = record.ToUpdateByParamArray();

            ExecuteSQLNonquery(conn, sqlStr, paras);

        }

      
       

        public override Record ToEntity(object reader)
        {
            Record record = new Record();
            EntityUtils.FillEntity<Record>((OleDbDataReader)reader, record);
            return record;
        }

    }
}
