using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;
using Portfolio.Client.Services;
using System;
using static Portfolio.Client.Models.ControllersModels;

namespace Portfolio.Client.Pages
{
    [AllowAnonymous]
    public partial class Home : ComponentBase
    {
        //injection 
        [Inject] public NavigationManager MyNavigationManager { get; set; } = default!;

        //vars 
        Users? Users;
        string? error;
        string Url;
        AllUserDetails userDetails;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await base.OnInitializedAsync();
                Url = MyNavigationManager.Uri;
                GetUserDetailsService service = new GetUserDetailsService();
                userDetails = await service.GetUserDetails(Url);
                await InvokeAsync(StateHasChanged);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
           
        }
    }
}
