using Blazorise;
using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;
using Portfolio.Data;
using System.Runtime.CompilerServices;

namespace Portfolio.Components.Pages
{
    public partial class WorkExperience : ComponentBase
    {
        //instances
        GetData Get = new();
        PutData Put = new();
        //vars
        private List<Experience> Experiences = new();


        protected override async Task OnInitializedAsync()
        {
            Experiences = await Get.GetProjects(1);
        }
        private void AddExperience()
        {
            var newProject = new Projects
            {
                user_id = 1,
                work_title = "work title",
                company_name = "company name",
                project_name = "project name",
                project_details = "project details",
                start_date = DateTime.Now,
                ProjectSteps = new List<ProjectSteps>
                         {
                             new ProjectSteps {
                              step = "step",
                               id = 1,
                             }
                         }
            };
            Experiences.Add(
                new Experience
                {
                    experience = new List<Projects> {
                         newProject
                     }
                });
            Put.CreateProject(newProject);
        }
        private void AddStepToExperience(Projects experience)
        {
            experience.ProjectSteps.Add(new ProjectSteps
            {
                step = "Another step"
            });
        }
        private void RemoveStep(Projects experience, ProjectSteps step)
        {
            experience.ProjectSteps.Remove(step);
        }
        private void RemoveExperience(Experience experience)
        {
            Experiences.Remove(experience);
        }

        private void EditWorkTitle(Projects experience)
        {
            experience.IsEditingWorkTitle = !experience.IsEditingWorkTitle;
        }
        private void SaveWorkTitle(Projects experience)
        {
            EditWorkTitle(experience);
        }
        private void EditCompanyName(Projects experience)
        {
            experience.IsEditingCompanyName = !experience.IsEditingCompanyName;
        }
        private void SaveCompanyName(Projects experience)
        {
            EditCompanyName(experience);
        }
        private void EditExperienceDesc(Projects experience)
        {
            experience.IsEditingExperienceDesc = !experience.IsEditingExperienceDesc;
        }
        private void SaveExperienceDesc(Projects experience)
        {
            EditExperienceDesc(experience);
        }
        private void EditProjectStep(ProjectSteps step)
        {
            step.IsEditingStep = !step.IsEditingStep;
        }
        private void SaveProjectStep(ProjectSteps step)
        {
            EditProjectStep(step);
        }
    }

}
