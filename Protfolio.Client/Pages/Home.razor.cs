using Microsoft.AspNetCore.Components;
using Protfolio.Client.Models;

namespace Protfolio.Client.Pages
{
    public partial class Home : ComponentBase
    {
        //instances
       // GetData Get = new();
        //vars 
        Users? Users;
        string? error;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                //Users = await Get.GetUserDetailsAsync(1);
            }
            catch (Exception ex)
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
