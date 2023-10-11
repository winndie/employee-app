using InterviewTest.Services;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace InterviewTest.Models
{
    public class Employee
    {
        private int _value;
        private Dictionary<char, int> _addValueByNames;

        public Employee() { }
        public Employee(IDataReader reader, ServiceParam serviceParam) {
            this.Id = reader.GetInt64(0);
            this.Name = reader.GetString(1);
            this._value = reader.GetInt32(2);
            this._addValueByNames = serviceParam.AddValueByNames;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public int Value { 
            get {
                if (Name.Length > 0 && _addValueByNames.ContainsKey(Name.ElementAt<char>(0)))
                {
                    return _value + _addValueByNames[Name.ElementAt<char>(0)];
                }
                else
                {
                    return _value + 100;
                }
            }
        }
    }
}
