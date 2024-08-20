using Portfolio.Client.Models;

namespace Portfolio.Data.Interfaces
{
    public interface IDeleteData
    {
        void DeleteExperience(Projects experience);
        void DeleteStep(ProjectSteps step);
        void DeleteSkill(Skills skill);
        void DeleteEducation(Education education);
    }
}
