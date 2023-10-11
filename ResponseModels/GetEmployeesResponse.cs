using InterviewTest.Models;
using InterviewTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.ResponseModels
{
    public class GetEmployeesResponse
    {
        private int _sum, _displaySum;

        public GetEmployeesResponse() { }
        public GetEmployeesResponse(List<Employee> employees, ServiceParam serviceParam) {

            Employees = employees;
            PageSize = serviceParam.PageSize;
            _displaySum = serviceParam.DisplaySum;
            _sum = Employees
                    .Where(x => x.Name.Length > 0 && serviceParam.SumValueOfNames.Contains(x.Name.ElementAt<char>(0)))
                    .Sum(x => x.Value);
        }
        public List<Employee> Employees { get; } = new List<Employee>();

        public int PageSize { get; }
        public int Sum { get {
                return _sum;
            } }

        public int LastPage { get {
                return (int)Math.Ceiling((decimal)Employees.Count / PageSize);
            } }

        public bool IsDisplaySum { get { 
                return _sum >= _displaySum;
            } }
    }
}
