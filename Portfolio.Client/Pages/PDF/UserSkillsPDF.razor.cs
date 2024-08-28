using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;

namespace Portfolio.Client.Pages.PDF
{
    public partial class UserSkillsPDF : ComponentBase
    {
        [Parameter]
        public List<Skills> userSkills { get; set; }

    }
}
