using System.Data;

namespace InterviewTest.Models
{
    public class Employee
    {
        private int _value;

        public Employee() { }
        public Employee(IDataReader reader) {
            this.Id = reader.GetInt64(0);
            this.Name = reader.GetString(1);
            this._value = reader.GetInt32(2);
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public int Value { 
            get {
                if (Name.StartsWith('E'))
                {
                    return _value + 1;
                }
                else if (Name.StartsWith('G'))
                {
                    return _value + 10;
                }
                else
                {
                    return _value + 100;
                }
            }
        }
    }
}
