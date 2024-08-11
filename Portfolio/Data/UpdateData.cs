using Portfolio.Client.Models;
using Portfolio.Data.Interfaces;

namespace Portfolio.Data
{
    public class UpdateData:IUpdateData
    {
        public Task UpdateWorkTitle(int id , int user_id , string workTitle)
        {

            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var userDetails = db.Projects
                               .Where(x => x.id == id  && x.user_id == user_id)
                               .FirstOrDefault();
                    if (userDetails != null) 
                    {
                        userDetails.work_title = workTitle;
                        db.SaveChanges();
                        return Task.CompletedTask;
                    }
                    else
                    {
                        throw new Exception("Project not found");
                    }
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            }
        }
        public Task UpdateCompanyName(int id , int user_id , string companyName)
        {

            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var userDetails = db.Projects
                               .Where(x => x.id == id  && x.user_id == user_id)
                               .FirstOrDefault();
                    if (userDetails != null) 
                    {
                        userDetails.company_name = companyName;
                        db.SaveChanges();
                        return Task.CompletedTask;
                    }
                    else
                    {
                        throw new Exception("Project not found");
                    }
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            }
        }
        public Task UpdateProjectName(int id, int user_id, string projectName)
        {

            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var userDetails = db.Projects
                               .Where(x => x.id == id && x.user_id == user_id)
                               .FirstOrDefault();
                    if (userDetails != null)
                    {
                        userDetails.project_name = projectName;
                        db.SaveChanges();
                        return Task.CompletedTask;
                    }
                    else
                    {
                        throw new Exception("Project not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            }
        }
        public Task UpdateProjectDetails(int id, int user_id, string projectDetails)
        {

            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var userDetails = db.Projects
                               .Where(x => x.id == id && x.user_id == user_id)
                               .FirstOrDefault();
                    if (userDetails != null)
                    {
                        userDetails.project_details = projectDetails;
                        db.SaveChanges();
                        return Task.CompletedTask;
                    }
                    else
                    {
                        throw new Exception("Project not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            }
        }
        public Task UpdateStartDate(int id, int user_id, DateTime startDate)
        {

            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var userDetails = db.Projects
                               .Where(x => x.id == id && x.user_id == user_id)
                               .FirstOrDefault();
                    if (userDetails != null)
                    {
                        userDetails.start_date = startDate;
                        db.SaveChanges();
                        return Task.CompletedTask;
                    }
                    else
                    {
                        throw new Exception("Project not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            }
        }
        public Task UpdateEndDate(int id, int user_id, DateTime endDate)
        {

            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var userDetails = db.Projects
                               .Where(x => x.id == id && x.user_id == user_id)
                               .FirstOrDefault();
                    if (userDetails != null)
                    {
                        userDetails.end_date = endDate;
                        db.SaveChanges();
                        return Task.CompletedTask;
                    }
                    else
                    {
                        throw new Exception("Project not found");
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
