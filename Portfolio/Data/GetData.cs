using Microsoft.EntityFrameworkCore.Internal;
using Portfolio.Client.Models;
using Portfolio.Data.Interfaces;
using Portfolio.Helpers;

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
        //work experience
        public Task<List<Experience>> GetProjectsAsync(int id)
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
                                }).OrderBy(j => j.id).ToList()
                            })
                            .ToList();


                    List<Experience> experiences = new List<Experience>();
                    foreach (var project in Projects)
                    {
                        experiences.Add(new Experience
                        {
                            experience = new List<Projects>
                            {
                                project
                            }
                        });
                    }

                    return Task.FromResult(experiences);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            }
        }
        // skills 
        public Task<List<Skills>> GetSkillsAsync(int userId)
        {

            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var skills = db.Skills
                            .Where(x => x.user_id == userId)
                            .ToList();
                    return Task.FromResult(skills);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            }
        }
        //Education 
        public Task<List<Education>> GetEducationAsync(int userId)
        {

            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var educations = db.Education
                            .Where(x => x.user_id == userId)
                            .ToList();
                    return Task.FromResult(educations);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            }
        }

        // get user Role 
        public Task<Admins> GetUserRole(string email, int skip, int take)
        {

            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var usersDetails = db.Admins.Skip(skip).Take(take).ToList();
                    if (usersDetails.Count > 0)
                    {
                        foreach (var user in usersDetails)
                        {
                            bool isHashFound = CryptPass.VerifyHash(email, user.email_hash);
                            if (isHashFound)
                            {
                                return Task.FromResult(user);
                            }
                        }
                        //recursive call until there is not data in db 
                        return GetUserRole(email, skip + take, take + take);
                    }
                    else
                    {
                        throw new Exception("user not found");

                    }


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