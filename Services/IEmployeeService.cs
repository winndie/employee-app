using InterviewTest.RequestModels;
using InterviewTest.ResponseModels;

namespace InterviewTest.Services
{
    public interface IEmployeeService
    {
        ServiceResult<GetEmployeesResponse> GetEmployees();
        ServiceResult<GetEmployeesResponse> CreateEmployee(CreateEmployeeRequest request);
        ServiceResult<GetEmployeesResponse> UpdateEmployee(UpdateEmployeeRequest request);
        ServiceResult<GetEmployeesResponse> DeleteEmployee(int Id);
    }
}
