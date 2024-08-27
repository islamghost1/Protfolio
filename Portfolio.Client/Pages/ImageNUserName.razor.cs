using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;

namespace Portfolio.Client.Pages
{
    public partial class ImageNUserName : ComponentBase
    {
        [Parameter]
        public Users Users { get; set; }
    }
}
