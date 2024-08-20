using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;
using Portfolio.Data;

namespace Portfolio.Components.Pages
{
    public partial class UserEducation : ComponentBase
    {
        //instances
        GetData Get = new();
        PutData Put = new();
        UpdateData Update = new();
        DeleteData Delete = new();

        //params
        [Parameter]
        public bool IsPreview { get; set; }
        //vars
        int UserID = 1;
        private List<Education> userEducation = new();
        protected override async Task OnInitializedAsync()
        {
            userEducation = await Get.GetEducationAsync(UserID);
        }
        void AddEducation()
        {
            Education education = new Education
            {
                user_id = UserID,
                diploma = "diploma",
                establishment = "establishment",
                icon = "icon",
                Description = "desc"
            };
            Put.AddEducation(education);
            userEducation.Add(education);
        }
        void UpdateEducation(Education education)
        {
            Update.UpdateEducation(education);
        }
        void DeleteEducation(Education education)
        {
            Delete.DeleteEducation(education);
            userEducation.Remove(education);
        }
    }
}
