using AppSettingsAssignment.Model;

namespace AppSettingsAssignment
{
    public interface IStudentsService
    {
        Task<List<Students>> GetStudentsDataSp();
    }
}