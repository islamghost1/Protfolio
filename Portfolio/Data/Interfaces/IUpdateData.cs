using Portfolio.Client.Models;

namespace Portfolio.Data.Interfaces
{
    public interface IUpdateData
    {
        void UpdateWorkTitle(int id, int user_id, string workTitle);

        void UpdateCompanyName(int id, int user_id, string companyName);

        void UpdateProjectName(int id, int user_id, string projectName);

        void UpdateProjectDetails(int id, int user_id, string projectDetails);

        void UpdateStartDate(int id, int user_id, DateTime startDate);

        void UpdateEndDate(int id, int user_id, DateTime endDate);

        void UpdateProjectStep(int id, int user_id, int project_id, string step);
        void UpdateSkill(Skills skill);
        void UpdateEducation(Education education);
        void UpdatePhoneNum(string phoneNum, int userId);
        void UpdateAddress(string phoneNum, int userId);
        void UpdateEmail(string phoneNum, int userId);
        void UpdateDescription(string phoneNum, int userId);
    }
}
