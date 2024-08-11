using Portfolio.Client.Models;

namespace Portfolio.Data.Interfaces
{
    public interface IGetData
    {
        Task<Users?> GetUserDetailsAsync(int id);

    }
}
