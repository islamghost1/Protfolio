using Protfolio.Client.Models;

namespace Protfolio.Data.Interfaces
{
    public interface IGetData
    {
        Task<Users?> GetUserDetailsAsync(int id);

    }
}
