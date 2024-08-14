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

    }
}
