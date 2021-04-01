using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yampugo.API.Common.Data
{
   public interface ISqlExecuteProcedureHelper
    {
        Task ExcecuteProcedure(string procedureName, List<KeyValuePair<string, object>> allParams);

        Task<string> ExcecuteProcedureOutPut(string procedureName, List<KeyValuePair<string, object>> allParams, string outPut);

        Task<string> ExcecuteProcedureNoOutput(string procedureName, List<KeyValuePair<string, object>> allParams);
    }
}
