using Microsoft.EntityFrameworkCore.Internal;
using Portfolio.Client.Models;
using Portfolio.Data.Interfaces;

namespace Portfolio.Data
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
        public Task<List<Experience>> GetProjects(int id)
        {

            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var Projects = db.Projects
                               .Where(x => x.user_id == id)
                               .Join(db.Project_steps,
                               project => project.id,
                               Steps => Steps.id,
                               (project, steps) => new Projects
                               {
                                   work_title = project.work_title,
                                   company_name = project.company_name,
                                   project_name = project.project_name,
                                   project_details = project.project_details,
                                   start_date = project.start_date,
                                   ProjectSteps = new List<ProjectSteps>
                                        {
                                            new ProjectSteps
                                            {
                                                step = steps.step
                                            }
                                        }
                               }
                               ).ToList();

                    List<Experience> experiences = new List<Experience>();
                    experiences.Add(new Experience { experience = Projects });
                    return Task.FromResult(experiences);
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
