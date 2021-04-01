using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yampugo.API.Common.Data
{
   public class SqlExecuteProcedureHelper : ISqlExecuteProcedureHelper
    {
        private readonly ApplicationContext _applicationContext;
        //private readonly FlightlApplicationContext _flightContext;
        public SqlExecuteProcedureHelper(ApplicationContext applicationContext)
        {

            this._applicationContext = applicationContext;

        }

        public SqlExecuteProcedureHelper()
        {

        }

        public async Task ExcecuteProcedure(string procedureName, List<KeyValuePair<string, object>> allParams)
        {
            //var allParams = new List<KeyValuePair<string, object>>();
            //allParams.Add(CreateParameter("authid", 1));

            using (var context = new ApplicationContext())
            {
                var cmd = context.LoadStoredProc(procedureName);
                foreach (var param in allParams)
                {
                    cmd.WithSqlParam(param.Key, param.Value);
                }
                await cmd.ExecuteNonQueryStoredProc();
                //T = context.LoadStoredProc("dbo.sp_getbookdetailswithauthor")
                //           .WithSqlParam("authid", 1)
                //           .ExecuteStoredProc<T>();
            }


        }


        public async Task<string> ExcecuteProcedureOutPut(string procedureName, List<KeyValuePair<string, object>> allParams, string outPut)
        {
            //var allParams = new List<KeyValuePair<string, object>>();
            //allParams.Add(CreateParameter("authid", 1));

            using (var context = new ApplicationContext())
            {
                var cmd = context.LoadStoredProc(procedureName);
                foreach (var param in allParams)
                {
                    if (outPut != null)
                    {
                        if (outPut == param.Key)
                        {
                            cmd.WithSqlParamOut(param.Key, param.Value);
                        }
                        else
                        {
                            cmd.WithSqlParam(param.Key, param.Value);
                        }

                    }
                    else
                    {
                        cmd.WithSqlParam(param.Key, param.Value);
                    }

                }
                await cmd.ExecuteNonQueryStoredProc();
                return cmd.Parameters[outPut].Value.ToString();

            }


        }

        public async Task<string> ExcecuteProcedureNoOutput(string procedureName, List<KeyValuePair<string, object>> allParams)
        {
            return null;
        }
    }
}
