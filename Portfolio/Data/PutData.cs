using Portfolio.Client.Models;
using Portfolio.Data.Interfaces;

namespace Portfolio.Data
{
    public class PutData : IPutData
    {
        // work experience 
        public async Task CreateProject(Projects project)
        {
            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var Projects = db.Projects
                        .Add(project);
                    await db.SaveChangesAsync();

                    foreach (var step in project.ProjectSteps)
                    {
                        step.project_id = project.id;
                        step.user_id = project.user_id;
                        db.Project_steps.Add(step);
                    }
                    db.SaveChanges();
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            }

        }
        public Task AddStepToProject(ProjectSteps step)
        {
            using (var db = new DbContextPortfolio())
            {
                try
                {
                    var Projects = db.Project_steps
                        .Add(step);
                    db.SaveChanges();
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            }

        }
        //Skills
        public Task AddSkill(Skills skill)
        {
            using (var db = new DbContextPortfolio())
            {
                try
                {
                    db.Skills.Add(skill);
                    db.SaveChanges();
                    return Task.CompletedTask;
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
