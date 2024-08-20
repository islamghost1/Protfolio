using Portfolio.Client.Models;
using Portfolio.Data.Interfaces;
namespace Portfolio.Data
{
    public class DeleteData : IDeleteData
    {
        public void DeleteExperience(Projects experience)
        {
            using(var db = new DbContextPortfolio())
            {
                try
                {
                    var project = db.Projects
                               .Where(x => x.id == experience.id)
                               .FirstOrDefault();
                    if (project != null)
                    {
                        db.Remove(project);
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

        public void DeleteStep(ProjectSteps step)
        {
            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var Step = db.Project_steps
                               .Where(x => x.id == step.id)
                               .FirstOrDefault();
                    if (Step != null)
                    {
                        db.Remove(Step);
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
        public void DeleteSkill(Skills skill)
        {
            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var _skill = db.Skills
                               .Where(x => x.id == skill.id)
                               .FirstOrDefault();
                    if (_skill != null)
                    {
                        db.Remove(_skill);
                        db.SaveChanges();

                    }
                    else
                    {
                        throw new Exception("skill not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            }

        }

        public void DeleteEducation(Education education)
        {
            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var _education = db.Education
                               .Where(x => x.id == education.id)
                               .FirstOrDefault();
                    if (_education != null)
                    {
                        db.Remove(_education);
                        db.SaveChanges();

                    }
                    else
                    {
                        throw new Exception("education not found");
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
