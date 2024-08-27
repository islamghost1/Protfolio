using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;

namespace Portfolio.Client.Pages
{
    public partial class UserEducation : ComponentBase
    {
        [Parameter]
        public List<Education> userEducation { get; set; }

    }
}
