using Microsoft.EntityFrameworkCore.Internal;
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
        public Task<List<Projects>> GetProjects(int id)
        {

            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var Projects = db.Projects
                               .Where(x => x.user_id == id)
                               .LeftJoin(db.Project_steps,
                               project => project.id,
                               Steps => Steps.id,
                               (project, steps) => new Projects
                               {
                                   work_title = project.work_title,
                                   company_name = project.company_name,
                                   project_name = project.project_name,
                                   project_details = project.project_details,
                                   ProjectSteps = new List<ProjectSteps>
                                        {
                                            new ProjectSteps
                                            {
                                                step = steps.step
                                            }
                                        }
                               }
                               ).ToList();
                    return Task.FromResult(Projects);
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
