using Blazorise;
using Google.Protobuf.WellKnownTypes;
using Portfolio.Client.Models;
using Portfolio.Data.Interfaces;

namespace Portfolio.Data
{
    public class UpdateData : IUpdateData
    {
        public void UpdateWorkTitle(int id, int user_id, string workTitle)
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
                        userDetails.work_title = workTitle;
                        db.SaveChanges();

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
        public void UpdateCompanyName(int id, int user_id, string companyName)
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
                        userDetails.company_name = companyName;
                        db.SaveChanges();

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
        public void UpdateProjectName(int id, int user_id, string projectName)
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
        public void UpdateProjectDetails(int id, int user_id, string projectDetails)
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
        public void UpdateStartDate(int id, int user_id, DateTime startDate)
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
        public void UpdateEndDate(int id, int user_id, DateTime endDate)
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

        public void UpdateProjectStep(int id, int user_id, int project_id, string step)
        {
            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var projectStep = db.Project_steps
                               .Where(x => x.id == id && x.user_id == user_id && x.project_id == project_id)
                               .FirstOrDefault();
                    if (projectStep != null)
                    {
                        projectStep.step = step;
                        db.SaveChanges();

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

        public void UpdateSkill(Skills skill)
        {
            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var skill_ = db.Skills
                               .Where(x => x.id == skill.id && x.user_id == skill.user_id)
                               .FirstOrDefault();
                    if (skill_ != null)
                    {
                        skill_.skill_name = skill.skill_name;
                        skill_.skill_desc = skill.skill_desc;
                        skill_.category = skill.category;
                        db.SaveChanges();

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

        public void UpdateEducation(Education education)
        {
            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var skill_ = db.Education
                    .Where(x => x.id == education.id && x.user_id == education.user_id)
                               .FirstOrDefault();
                    if (skill_ != null)
                    {
                        skill_.establishment = education.establishment;
                        skill_.diploma = education.diploma;
                        skill_.icon = education.icon;
                        skill_.start_date = education.start_date;
                        skill_.end_date = education.end_date;
                        skill_.Description = education.Description;
                        db.SaveChanges();

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

        // user details
        public void UpdatePhoneNum(string phoneNum, int userId)
        {
            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var userDetails = db.Users
                    .Where(x => x.id == userId).FirstOrDefault();

                    if (userDetails != null)
                    {
                        userDetails.phone = phoneNum;
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("User not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
        }
        public void UpdateAddress(string address, int userId)
        {
            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var userDetails = db.Users
                    .Where(x => x.id == userId).FirstOrDefault();

                    if (userDetails != null)
                    {
                        userDetails.address = address;
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("User not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
        }  
        public void UpdateEmail(string email, int userId)
        {
            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var userDetails = db.Users
                    .Where(x => x.id == userId).FirstOrDefault();

                    if (userDetails != null)
                    {
                        userDetails.email = email;
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("User not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
        }
        public void UpdateDescription(string desc, int userId)
        {
            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var userDetails = db.Users
                    .Where(x => x.id == userId).FirstOrDefault();

                    if (userDetails != null)
                    {
                        userDetails.description = desc;
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("User not found");
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
