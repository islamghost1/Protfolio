using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;

namespace Portfolio.Client.Pages
{
    public partial class UserSkills : ComponentBase
    {
        [Parameter]
        public List<Skills> userSkills { get; set; }

    }
}
