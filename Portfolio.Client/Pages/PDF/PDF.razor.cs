using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;
using Portfolio.Client.Services;
using static Portfolio.Client.Models.ControllersModels;

namespace Portfolio.Client.Pages.PDF
{
    [AllowAnonymous]
    public partial class PDF : ComponentBase
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
                Url = MyNavigationManager.BaseUri;
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
