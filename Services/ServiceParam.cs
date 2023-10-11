using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Services
{
    public class ServiceParam
    {
        public ServiceParam(string connectionString,
            int pageSize,
            int displaySum,
            List<char> sumValueOfNames,
            Dictionary<string,int> addValueByNames) {

            ConnectionString = connectionString;
            PageSize = pageSize;
            DisplaySum = displaySum;
            SumValueOfNames = sumValueOfNames;
            AddValueByNames = addValueByNames.ToDictionary(x => x.Key.ElementAt<char>(0), x => x.Value);
        }
        public readonly string ConnectionString;
        public readonly int PageSize;
        public readonly int DisplaySum;
        public readonly List<char> SumValueOfNames;
        public readonly Dictionary<char,int> AddValueByNames;
    }
}
