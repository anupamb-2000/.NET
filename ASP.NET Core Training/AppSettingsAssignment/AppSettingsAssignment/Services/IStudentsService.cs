using AppSettingsAssignment.Model;

namespace AppSettingsAssignment
{
    public interface IStudentsService
    {
        Task<List<Students>> GetStudentsData();
        Task<Students> GetStudentsDataById(int id);
    }
}