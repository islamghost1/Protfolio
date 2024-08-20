using Portfolio.Client.Models;

namespace Portfolio.Data.Interfaces
{
    public interface IPutData
    {
        Task CreateProject(Projects project);
        Task AddStepToProject(ProjectSteps step);
        Task AddSkill(Skills skill);
        Task AddEducation(Education education);


    }
}
