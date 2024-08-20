using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;
using Portfolio.Data;

namespace Portfolio.Components.Pages
{

    public partial class UserSkills : ComponentBase
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
        private List<Skills> userSkills = new();
        protected override async Task OnInitializedAsync()
        {
            userSkills = await Get.GetSkillsAsync(UserID);
        }
        void AddSkill(object skillCategory)
        {
            Skills skill = new Skills
            {
                user_id = UserID,
                skill_name = "skill name",
                skill_desc = "skill desc",
                category = (int)Enum.Parse(typeof(Client.Models.SkillCategory), skillCategory.ToString())

            };
            Put.AddSkill(skill);
            userSkills.Add(skill);
        }
        void UpdateSkill(Skills skill) 
        { 
            Update.UpdateSkill(skill);
        }
        void DeleteSkill(Skills skill) 
        {
            Delete.DeleteSkill(skill);
            userSkills.Remove(skill);
        }
    }
}
