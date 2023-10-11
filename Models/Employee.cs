using InterviewTest.Services;
using System.Data;
using System.Linq;

namespace InterviewTest.Models
{
    public class Employee
    {
        public Employee() { }
        public Employee(IDataReader reader, ServiceParam serviceParam) {
            this.Id = reader.GetInt64(0);
            this.Name = reader.GetString(1);

            var _value = reader.GetInt32(2);

            if (Name.Length > 0 && serviceParam.AddValueByNames.ContainsKey(Name.ElementAt<char>(0)))
            {
                Value = _value + serviceParam.AddValueByNames[Name.ElementAt<char>(0)];
            }
            else
            {
                Value = _value + serviceParam.DefaultValueAdded;
            }

        }
        public long Id { get; }
        public string Name { get; }
        public int Value { get; }
    }
}
