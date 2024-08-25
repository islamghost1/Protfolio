using Blazorise;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Client.Models;
using Portfolio.Data;
using System.Data;
using System.Security.Claims;

namespace Portfolio.Components.Pages
{

    public partial class ModificationEnabled : ComponentBase
    {
        //instances
        GetData Get = new();

        //vars
        Admins UserRole;
        private ClaimsPrincipal User;
        private string GivenName;
        private string Email;
        private string Surname;
        private string Avatar;
        private string authMessage = "The user is NOT authenticated.";
        private string role;

        //Cascading Parameter
        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (authenticationState is not null)
            {
                var authState = await authenticationState;
                User = authState?.User;

                if (User?.Identity is not null && User.Identity.IsAuthenticated)
                {
                    authMessage = $"{User.Identity.Name} is authenticated.";

                    try
                    {
                        var email = User.FindFirst(ClaimTypes.Email);
                        Email = email != null ? email.Value : "";
                        UserRole = await Get.GetUserRole(Email, 0, 10);

                        // Update the role claim
                        await UpdateRoleClaim(UserRole);
                    }
                    catch
                    {
                        // Handle any exceptions that occur during claim retrieval
                    }
                }
            }
        }
        private async Task UpdateRoleClaim(Admins userRole)
        {
            var authState = await authenticationState;
            var identity = authState.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                // Remove existing role claim
                var existingClaim = identity.FindFirst(ClaimTypes.Role);
                if (existingClaim != null)
                {
                    identity.RemoveClaim(existingClaim);
                }

                // Add new role claim
                string roleName = userRole?.auth_level.ToString(); // Convert enum to string
                identity.AddClaim(new Claim(ClaimTypes.Role, roleName));

                // Force a refresh of the authentication state
                //await authenticationState.Task;
            }
        }

        // callback
        //vars
        bool IsPreview = true;
        //funcs
        // preview 
        private void Preview()
        {
            IsPreview = !IsPreview;
        }

    }
}
