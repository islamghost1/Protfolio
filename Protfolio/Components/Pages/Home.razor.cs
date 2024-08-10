using Microsoft.AspNetCore.Components;
using Protfolio.Client.Models;
using Protfolio.Data;

namespace Protfolio.Components.Pages
{
    public partial class Home : ComponentBase
    {
        //instances
        GetData Get = new();
        //vars 
        Users? Users;
        string? error;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Users = await Get.GetUserDetailsAsync(1);
            }
            catch(Exception ex) 
            {
                error = ex.Message;
            }
            finally 
            {
                await base.OnInitializedAsync();

            }
        }
    }
}
