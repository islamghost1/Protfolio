using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;

namespace Portfolio.Client.Pages.PDF
{
    public partial class UserEducationPDF : ComponentBase
    {
        [Parameter]
        public List<Education> userEducation { get; set; }

    }
}
