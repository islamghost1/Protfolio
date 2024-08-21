using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;

namespace Portfolio.Client.Pages
{
    [AllowAnonymous]
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
