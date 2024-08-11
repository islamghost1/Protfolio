using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;
using Portfolio.Data;

namespace Portfolio.Components.Pages
{
    public partial class ImageNUserName : ComponentBase
    {
        //instances
        GetData Get = new();
        //vars 
        Users? Users = new Users();
        string? error;
        bool isEditingName;
        bool isEditingPhone;
        bool isEditingEmail;
        bool isEditingAddress;
        bool isEditingDescription;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Users = await Get.GetUserDetailsAsync(1);
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

        private void EditPhone()
        {
            isEditingPhone = !isEditingPhone;
        } 
        private void SavePhone()
        {
            EditPhone();
        }
        private void EditEmail()
        {
            isEditingEmail = !isEditingEmail;
        } 
        private void SaveEmail()
        {
            EditEmail();
        }
        private void EditAddress()
        {
            isEditingAddress = !isEditingAddress;
        }

        private void SaveAddress()
        {
            EditAddress();
        }

        private void EditDescription()
        {
            isEditingDescription = !isEditingDescription;
        }

        private void SaveDescription()
        {
            EditDescription();
        }
    }
}
