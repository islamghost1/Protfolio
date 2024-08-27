using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;

namespace Portfolio.Client.Pages
{
    public partial class WorkExperience : ComponentBase
    {
        [Parameter]
        public List<Experience> Experiences { get; set; }

    }
}
