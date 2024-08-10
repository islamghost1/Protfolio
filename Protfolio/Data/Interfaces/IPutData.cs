using Protfolio.Client.Models;

namespace Protfolio.Data.Interfaces
{
    public interface IPutData
    {
        Task<bool> CreateUser(Users user);

    }
}
