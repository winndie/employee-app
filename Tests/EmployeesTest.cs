using InterviewTest.Models;
using InterviewTest.ResponseModels;
using InterviewTest.Services;
using Moq;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Xunit;

namespace InterviewTest.Tests
{
    public class EmployeesTest
    {
        private ServiceParam serviceParam;

        public EmployeesTest() {
            serviceParam = new ServiceParam(
                "connectionString", 5, 11171,
                new List<char> { 'A', 'B', 'C' },
                new Dictionary<string, int>() { { "E", 1 }, { "G", 10 } }
                );
        }
        private List<Employee> SetData(List<KeyValuePair<string,int>> data, List<Employee> employees)
        {
            long i = 1;

            foreach (var item in data)
            {
                var reader = new Mock<IDataReader>();

                reader.Setup(x => x.GetInt64(0)).Returns((int)i++);
                reader.Setup(x => x.GetString(1)).Returns((string)item.Key);
                reader.Setup(x => x.GetInt32(2)).Returns((int)item.Value);

                employees.Add(new Employee(reader.Object, serviceParam));
            };

            return employees;
        }

        [Theory]
        [InlineData("Emily", 1000)]
        [InlineData("Gary", 1000)]
        [InlineData("Amy", 1000)]
        [InlineData("¬!£$%^&*()_+-=`||<>,.?/:@~\"\\", 1000)]
        public void CheckEmployeeValues(string name, int value)
        {
            var data = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string,int> (name, value)
            };

            var employees = SetData(data,new List<Employee>());

            Assert.NotNull(employees);
            Assert.Equal(1, employees[0].Id);
            Assert.Equal(name, employees[0].Name);

            if (name.StartsWith("E"))
            {
                Assert.Equal(1001, employees[0].Value);
            }
            else if (name.StartsWith("G"))
            {
                Assert.Equal(1010, employees[0].Value);
            }
            else
            {
                Assert.Equal(1100, employees[0].Value);
            }
        }

        [Theory]
        [InlineData("Emily", 20000)]
        [InlineData("Gary", 20000)]
        [InlineData("Amy", 20000)]
        [InlineData("¬!£$%^&*()_+-=`||<>,.?/:@~\"\\", 20000)]
        public void GetEmployeesResponse_DisplaySum(string name, int value)
        {
            var data = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string,int> (name, value)
            };

            var result = new GetEmployeesResponse(SetData(data, new List<Employee>()), serviceParam);

            Assert.NotNull(result);

            if (name.Length>0 &&  serviceParam.SumValueOfNames.Contains(name.ElementAt<char>(0)))
            {
                Assert.Equal(20100, result.Sum);
                Assert.True(result.IsDisplaySum);
            }
            else
            {
                Assert.Equal(0, result.Sum);
                Assert.False(result.IsDisplaySum);
            }
        }
    }
}
