using Portfolio.Client.Models;

namespace Portfolio.Data.Interfaces
{
    public interface IGetData
    {
        Task<Users?> GetUserDetailsAsync(int id);
        Task<List<Skills>> GetSkillsAsync(int userId);
        Task<List<Experience>> GetProjectsAsync(int id);
        Task<List<Education>> GetEducationAsync(int userId);

    }
}
