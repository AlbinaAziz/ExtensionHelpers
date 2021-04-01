using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yampugo.API.Common.Data
{
   public interface ISqlProcedureHelper<T> where T : class
    {
        Task<IList<T>> ExcecuteProcedure(string procedureName, List<KeyValuePair<string, object>> allParams);

        Task<IList<T>> ExcecuteProcedureAsync(string procedureName, List<KeyValuePair<string, object>> allParams);

    }
}
