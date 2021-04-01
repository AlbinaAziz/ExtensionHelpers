using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yampugo.API.Common.Data
{
  public class SqlProcedureHelper<T> : ISqlProcedureHelper<T> where T : class
    {
        private readonly ApplicationContext _context;


        public SqlProcedureHelper(ApplicationContext context)
        {
            this._context = context;


        }
        public async Task<IList<T>> ExcecuteProcedure(string procedureName, List<KeyValuePair<string, object>> allParams)
        {
            //var allParams = new List<KeyValuePair<string, object>>();
            //allParams.Add(CreateParameter("authid", 1));
            IList<T> T = new List<T>();
            using (var context = new ApplicationContext())
            {
                var cmd = context.LoadStoredProc(procedureName);
                foreach (var param in allParams)
                {
                    cmd.WithSqlParam(param.Key, param.Value);
                }
                T = await cmd.ExecuteStoredProcAsync<T>();

            }

            return T;
        }

        public async Task<IList<T>> ExcecuteProcedureAsync(string procedureName, List<KeyValuePair<string, object>> allParams)
        {
            //var allParams = new List<KeyValuePair<string, object>>();
            //allParams.Add(CreateParameter("authid", 1));
            IList<T> T = new List<T>();
            using (var context = new ApplicationContext())
            {
                var cmd = await Task.Run(() => context.LoadStoredProc(procedureName));
                foreach (var param in allParams)
                {
                    cmd.WithSqlParam(param.Key, param.Value);
                }
                T = await cmd.ExecuteStoredProcAsync<T>();
                //T = context.LoadStoredProc("dbo.sp_getbookdetailswithauthor")
                //           .WithSqlParam("authid", 1)
                //           .ExecuteStoredProc<T>();
            }

            return T;
        }


    }
}
