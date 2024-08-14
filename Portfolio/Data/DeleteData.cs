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
    }
}
