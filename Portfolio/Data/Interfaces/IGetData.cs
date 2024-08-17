using Portfolio.Client.Models;

namespace Portfolio.Data.Interfaces
{
    public interface IGetData
    {
        Task<Users?> GetUserDetailsAsync(int id);
        Task<List<Skills>> GetSkills(int userId);
        Task<List<Experience>> GetProjects(int id);

    }
}
