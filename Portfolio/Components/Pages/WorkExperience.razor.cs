using Blazorise;
using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;
using Portfolio.Data;
using Blazorise.Markdown;
using System.Linq.Expressions;
using System.Reflection;
using Mysqlx.Crud;

namespace Portfolio.Components.Pages
{
    public partial class WorkExperience : ComponentBase
    {
        //instances
        GetData Get = new();
        PutData Put = new();
        UpdateData Update = new();
        DeleteData Delete = new();
        //vars
        private List<Experience> Experiences = new();


        protected override async Task OnInitializedAsync()
        {
            Experiences = await Get.GetProjects(1);
        }
        //add || remove 
        private void AddExperience()
        {
            var newProject = new Projects
            {
                //id = Experiences.Select(x=>x.experience.MaxBy(y=>y.id).id).FirstOrDefault()+1,
                user_id = 1,
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
            var step = new ProjectSteps
            {
                project_id = experience.id,
                user_id = experience.user_id,
                step = "Another step"
            };
            experience.ProjectSteps.Add(step);
            AddStepToProject(step);
        }
        private void RemoveStep(Projects experience, ProjectSteps step)
        {
            experience.ProjectSteps.Remove(step);
            Delete.DeleteStep(step);

        }
        private void RemoveExperience(List<Projects> experiences , Projects experience)
        {
            experiences.Remove(experience);
            Delete.DeleteExperience(experience);
        } 
        private void AddStepToProject(ProjectSteps step)
        {
            Put.AddStepToProject(step);
        }
        //edit && save 
        private void EditWorkTitle(Projects experience)
        {
            experience.IsEditingWorkTitle = !experience.IsEditingWorkTitle;
        }
        private void SaveWorkTitle(Projects experience)
        {
            EditWorkTitle(experience);
            Update.UpdateWorkTitle(experience.id, experience.user_id, experience.work_title);
        }
        private void EditCompanyName(Projects experience)
        {
            experience.IsEditingCompanyName = !experience.IsEditingCompanyName;
        }
        private async void SaveCompanyName(Projects experience)
        {
            EditCompanyName(experience);
            await MarkDownPropertyAsync(experience, e => e.company_name);
            Update.UpdateCompanyName(experience.id, experience.user_id, experience.company_name);
            await InvokeAsync(StateHasChanged);
        }
        private void EditExperienceDesc(Projects experience)
        {
            experience.IsEditingExperienceDesc = !experience.IsEditingExperienceDesc;
        }
        private async void SaveExperienceDesc(Projects experience)
        {
            EditExperienceDesc(experience);
            await MarkDownPropertyAsync(experience, e => e.project_details);
            Update.UpdateProjectDetails(experience.id, experience.user_id, experience.project_details);

            await InvokeAsync(StateHasChanged);
        }
        private void EditProjectStep(ProjectSteps step)
        {
            step.IsEditingStep = !step.IsEditingStep;
        }
        private async void SaveProjectStep(ProjectSteps step)
        {
            EditProjectStep(step);
            await MarkDownPropertyAsync(step, e => e.step);
            Update.UpdateProjectStep(step.id, step.user_id,step.project_id, step.step);

            await InvokeAsync(StateHasChanged);
        }
        //onChange
        private async Task MarkDownPropertyAsync<T>(T obj, Expression<Func<T, string>> propertySelector)
        {
            var propertyInfo = (PropertyInfo)((MemberExpression)propertySelector.Body).Member;
            var currentValue = (string)propertyInfo.GetValue(obj);
            var markdownValue = await Task.Run(() => Markdig.Markdown.ToHtml(currentValue ?? string.Empty));
            propertyInfo.SetValue(obj, markdownValue);
        }

    }

}
