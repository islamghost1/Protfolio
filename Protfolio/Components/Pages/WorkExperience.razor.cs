using Blazorise;
using Microsoft.AspNetCore.Components;
using Protfolio.Client.Models;
using System.Runtime.CompilerServices;

namespace Protfolio.Components.Pages
{
    public partial class WorkExperience:ComponentBase
    {
        //vars
        private List<Experience> Experiences = new();
        

        protected override Task OnInitializedAsync()
        {
           
            return base.OnInitializedAsync();
        }
        private void AddExperience()
        {
            Experiences.Add(
                new Experience
                {
                    experience = new List<Projects> {
                      new Projects {
                         work_title = "work title",
                         company_name = "company name",
                         project_name = "project name",
                         project_details = "project details",
                         start_date = DateTime.Now,
                         ProjectSteps = new List<ProjectSteps> 
                         { 
                             new ProjectSteps { 
                              step = "step"
                             }
                         }
                      }
                     }
                });
        }
        private void AddStepToExperience(Projects experience) 
        {
            experience.ProjectSteps.Add(new ProjectSteps
            {
                 step = "Another step"
            });
        }
        private void RemoveStep(Projects experience , ProjectSteps step)
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
            step.IsEditingStep = !step.IsEditingStep ;
        }
        private void SaveProjectStep(ProjectSteps step)
        {
            EditProjectStep(step);
        }
    }

}
