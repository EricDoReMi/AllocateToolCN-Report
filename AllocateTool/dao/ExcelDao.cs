using AllocateTool.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace AllocateTool.dao
{
    public abstract partial class ExcelDao
    {
       

        /**//// <summary>   
            /// 根据SQL命令返回数据OleDbDataReader数据表,   
            /// </summary> 
            /// <param name="conn">数据库连接</param> 
            /// <param name="sqlStr">sql语句</param>  
            /// <param name="paras">参数,默认值null</param>   
            /// <returns>OleDbDataReader</returns>  
        protected OleDbDataReader SelectToDataReader(OleDbConnection conn, string sqlStr, params OleDbParameter[] paras)
        {
            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
         

            if (paras.Length > 0)
            {
                cmd.Parameters.AddRange(paras);
            }


            OleDbDataReader reader = cmd.ExecuteReader();
            return reader;
        }


        /**//// <summary>   
            /// 根据SQL命令返回数据DataTable数据表,   
            /// 可直接作为dataGridView的数据源   
            /// </summary> 
            /// <param name="conn">数据库连接</param> 
            /// <param name="sqlStr">sql语句</param>   
            /// <param name="paras">参数,默认值null</param>   
            /// <returns>DataTable</returns>   
        protected DataTable SelectToDataTable(OleDbConnection conn, string sqlStr, params OleDbParameter[] paras)
        {
            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
          

            if (paras.Length > 0)
            {
                cmd.Parameters.AddRange(paras);
            }


            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        /**//// <summary>   
            /// 根据SQL命令返回OleDbDataAdapter，   
            /// 使用前请在主程序中添加命名空间System.Data.OleDb   
            /// </summary>   
            /// <param name="conn">数据库连接</param> 
            /// <param name="sqlStr">sql语句</param>   
            /// <param name="paras">参数,默认值null</param>  
            /// <returns>OleDbDataAdapter</returns>   
        protected OleDbDataAdapter SelectToOleDbDataAdapter(OleDbConnection conn, string sqlStr, params OleDbParameter[] paras)
        {
            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
          

            if (paras.Length > 0)
            {
                cmd.Parameters.AddRange(paras);
            }


            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            return adapter;
        }

        public OleDbConnection Begin(string conStr)
        {
            OleDbConnection conn = OleDBExcelHelper.GetConnection(conStr);
            conn.Open();
            //trans = conn.BeginTransaction();
            return conn;

        }

   

        public void Close()
        {
            OleDBExcelHelper.CloseConnection();
        }


      
      

    }
}
