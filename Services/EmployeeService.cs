using InterviewTest.Models;
using InterviewTest.RequestModels;
using InterviewTest.ResponseModels;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace InterviewTest.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ServiceParam Param;
        private string selectQuery;
        public EmployeeService(ServiceParam param)
        {
            this.Param = param;
            this.selectQuery = @"SELECT ROWID, Name, Value FROM Employees";
        }

        private ServiceResult<GetEmployeesResponse> ExecuteCommand(
            ServiceResult<GetEmployeesResponse> result, string stmt, List<KeyValuePair<string,object>> param)
        {
            using (var connection = new SqliteConnection(Param.ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = stmt;

                    param.ForEach(x => { 
                        cmd.Parameters.AddWithValue(x.Key,x.Value);
                    });

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }

                result = this.GetEmployees(result, connection);
            }

            return result;
        }

        private ServiceResult<GetEmployeesResponse> GetEmployees(
            ServiceResult<GetEmployeesResponse> result, SqliteConnection connection)
        {
            var queryCmd = connection.CreateCommand();
            queryCmd.CommandText = selectQuery;
            using (var reader = queryCmd.ExecuteReader())
            {
                List<Employee> employees = new List<Employee>();

                while (reader.Read())
                {
                    employees.Add(new Models.Employee (reader,Param));
                }

                result = new ServiceResult<GetEmployeesResponse>(
                    new GetEmployeesResponse(employees, Param));
            }

            return result;
        }

        public ServiceResult<GetEmployeesResponse> GetEmployees()
        {
            ServiceResult<GetEmployeesResponse> result = new ServiceResult<GetEmployeesResponse>();

            using (var connection = new SqliteConnection(Param.ConnectionString))
            {
                connection.Open();
                result = this.GetEmployees(result,connection);
            }

            return result;
        }
        public ServiceResult<GetEmployeesResponse> CreateEmployee(CreateEmployeeRequest request)
        {
            ServiceResult<GetEmployeesResponse> result = new ServiceResult<GetEmployeesResponse>();

            var createStmt = $@"INSERT INTO Employees VALUES (@Name, @Value)";

            result = ExecuteCommand(result,createStmt,
            new List<KeyValuePair<string, object>> {
                    new KeyValuePair<string, object>("@Name", request.Name),
                    new KeyValuePair<string, object>("@Value", request.Value)});

            return result;
        }
        public ServiceResult<GetEmployeesResponse> UpdateEmployee(UpdateEmployeeRequest request)
        {
            ServiceResult<GetEmployeesResponse> result = new ServiceResult<GetEmployeesResponse>();

            var updateStmt = $@"UPDATE Employees SET Name=@Name, Value=@Value WHERE ROWID=@Id";

            result = ExecuteCommand(result, updateStmt,
                new List<KeyValuePair<string, object>> { 
                    new KeyValuePair<string, object>("@Id", request.Id),
                    new KeyValuePair<string, object>("@Name", request.Name),
                    new KeyValuePair<string, object>("@Value", request.Value)});

            return result;
        }
        public ServiceResult<GetEmployeesResponse> DeleteEmployee(int Id)
        {
            ServiceResult<GetEmployeesResponse> result = new ServiceResult<GetEmployeesResponse>();

            var deleteStmt = $@"DELETE FROM Employees WHERE ROWID = @Id";

            result = ExecuteCommand(result, deleteStmt, 
                new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("@Id", Id) });

            return result;
        }
    }
}
