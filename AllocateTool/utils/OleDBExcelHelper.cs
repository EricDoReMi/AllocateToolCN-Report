using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace AllocateTool.utils
{
    public partial class OleDBExcelHelper
    {
        private static string driverNameStr;
        private static string persistSecurityStr;
        private static string extendStr;
        private static string connStr;//connectStr
        private static OleDbConnection conn;

        static OleDBExcelHelper()
        {


            driverNameStr = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=";

          

            extendStr = ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";
        }

        public static OleDbConnection GetConnection(string dataSourcePath)
        {



            connStr = driverNameStr  + dataSourcePath + extendStr;
            

            if (conn == null)
            {

                 conn = new OleDbConnection(connStr);



            }

            return conn;
        }

        public static void CloseConnection()
        {

            if (conn != null && conn.State.Equals(ConnectionState.Open))
            {
                conn.Close();


            }
        }


        //释放数据库连接的资源
        public static void DisposeDB()
        {

            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;

            }
        }

        ~OleDBExcelHelper()
        {

            DisposeDB();
        }

    }
}
