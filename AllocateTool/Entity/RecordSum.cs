using AllocateTool.utils;
using System;
using System.Data.OleDb;

namespace AllocateTool.Entity
{
    public partial class RecordSum
    {

        public RecordSum()
        {

            //数据库要求必须提供的默认值
            M_subject = "";
            M_requestID = "";

            M_Branch = "";
            M_dbName = "";

        }
        public long M_id { get; set; }

        public string M_subject { get; set; }


        public string M_requestID { get; set; }

        public string M_importance { get; set; }


        public DateTime? M_mailincometime { get; set; }
        
        public string M_Branch { get; set; }

        public string M_dbName { get; set; }


        public OleDbParameter[] ToInsertByParamArray()
        {
            OleDbParameter[] param = {
                 
                    new OleDbParameter("@M_subject",EntityUtils.SqlNull(M_subject)),
                    new OleDbParameter("@M_requestID",EntityUtils.SqlNull(M_requestID)),
                    new OleDbParameter("@M_importance",EntityUtils.SqlNull(M_importance)),
                    new OleDbParameter("@M_mailincometime",EntityUtils.SqlNull(M_mailincometime)),
                    new OleDbParameter("@M_Branch",EntityUtils.SqlNull(M_Branch)),
                    new OleDbParameter("@M_dbName",EntityUtils.SqlNull(M_dbName))


            };

            for (int i = 0; i < param.Length; i++)
            {
                param[i].IsNullable = true;
            }



            return param;

        }

        public OleDbParameter[] ToUpdateByParamArray()
        {
            OleDbParameter[] param = {

                    new OleDbParameter("@M_subject",EntityUtils.SqlNull(M_subject)),
                    new OleDbParameter("@M_requestID",EntityUtils.SqlNull(M_requestID)),
                    new OleDbParameter("@M_importance",EntityUtils.SqlNull(M_importance)),
                    new OleDbParameter("@M_mailincometime",EntityUtils.SqlNull(M_mailincometime)),
                    new OleDbParameter("@M_Branch",EntityUtils.SqlNull(M_Branch)),
                    new OleDbParameter("@M_dbName",EntityUtils.SqlNull(M_dbName)),
                    new OleDbParameter("@M_id",EntityUtils.SqlNull(M_id))

            };

            for (int i = 0; i < param.Length; i++)
            {
                param[i].IsNullable = true;
            }



            return param;

        }


        /// <summary>
        /// Record类的浅拷贝
        /// </summary>
        /// <returns></returns>
        public Record QainClone()
        {
            return MemberwiseClone() as Record;
        }
    }
}