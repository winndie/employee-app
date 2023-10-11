using InterviewTest.Models;
using InterviewTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.ResponseModels
{
    public class GetEmployeesResponse
    {
        public GetEmployeesResponse() { }
        public GetEmployeesResponse(List<Employee> employees, ServiceParam serviceParam) {

            Employees = employees;
            PageSize = serviceParam.PageSize;
            Sum = Employees
                    .Where(x => x.Name.Length > 0 && serviceParam.SumValueOfNames.Contains(x.Name.ElementAt<char>(0)))
                    .Sum(x => x.Value);
            IsDisplaySum = Sum >= serviceParam.DisplaySum;
            LastPage = (int)Math.Ceiling((decimal)Employees.Count / PageSize);
        }
        public List<Employee> Employees { get; } = new List<Employee>();

        public int PageSize { get; }
        public int Sum { get; }

        public int LastPage { get; }

        public bool IsDisplaySum { get; }
    }
}
