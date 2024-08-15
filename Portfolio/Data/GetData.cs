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
                            .GroupJoin(
                                db.Project_steps,
                                project => project.id,
                                steps => steps.project_id,
                                (project, steps) => new { project, steps }
                            )
                            .Select(x => new Projects
                            {
                                id = x.project.id,
                                user_id = x.project.user_id,
                                work_title = x.project.work_title,
                                company_name = x.project.company_name,
                                project_name = x.project.project_name,
                                project_details = x.project.project_details,
                                start_date = x.project.start_date,
                                ProjectSteps = x.steps.Select(s => new ProjectSteps
                                {
                                    id = s.id,
                                    project_id = s.project_id,
                                    user_id = s.user_id,
                                    step = s.step
                                }).ToList()
                            })
                            .ToList();


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
