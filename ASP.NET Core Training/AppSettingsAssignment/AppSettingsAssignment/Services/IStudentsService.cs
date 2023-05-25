using AppSettingsAssignment.DataModels;
using AppSettingsAssignment.ViewModels.Response;

namespace AppSettingsAssignment
{
    public interface IStudentsService
    {
        Task<List<StudentResponse>> GetStudentsData();
        Task<StudentResponse> GetStudentsDataById(int id);
        Task<IEnumerable<StudentResponse>> GetStudentsDataEf();
        Task<StudentResponse> GetStudentsDataByIdEf(int id);
    }
}