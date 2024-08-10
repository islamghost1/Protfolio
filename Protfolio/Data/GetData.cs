using Protfolio.Client.Models;
using Protfolio.Data.Interfaces;

namespace Protfolio.Data
{
    public class GetData : IGetData
    {

        public Task<Users?> GetUserDetailsAsync(int id)
        {

            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var userDetails = db.Users
                               .Where(x => x.id == id)
                               .FirstOrDefault();
                    return Task.FromResult(userDetails);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            }
        }
    }
}
