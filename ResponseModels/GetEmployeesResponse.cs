using InterviewTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.ResponseModels
{
    public class GetEmployeesResponse
    {
        private int _sum, _displaySum;

        public GetEmployeesResponse() { }
        public GetEmployeesResponse(List<Employee> employees, int pageSize, int displaySum) {
            Employees = employees;
            PageSize = pageSize;
            _displaySum = displaySum;
            _sum = Employees
                    .Where(x => x.Name.StartsWith("A") || x.Name.StartsWith("B") || x.Name.StartsWith("C"))
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
