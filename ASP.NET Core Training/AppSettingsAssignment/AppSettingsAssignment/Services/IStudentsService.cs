using AppSettingsAssignment.DataModels;
using AppSettingsAssignment.ViewModels.Request;
using AppSettingsAssignment.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace AppSettingsAssignment
{
    public interface IStudentsService
    {
        Task<List<StudentResponse>> GetStudentsData();
        Task<StudentResponse> GetStudentsDataById(int id);
        Task<IEnumerable<StudentResponse>> GetStudentsDataEf();
        Task<StudentResponse> GetStudentsDataByIdEf(int id);
        Task<IActionResult> CreateStudent(AddStudentRequest studentRequest);
        Task<StudentResponse> UpdateStudent(UpdateStudentRequest studentRequest);
        Task<StudentResponse> DeleteStudent(int id);
    }
}