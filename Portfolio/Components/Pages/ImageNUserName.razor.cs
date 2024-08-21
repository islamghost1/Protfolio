using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;
using Portfolio.Data;

namespace Portfolio.Components.Pages
{
    public partial class ImageNUserName : ComponentBase
    {
        int UserID = 1;
        //instances
        GetData Get = new();
        UpdateData update = new();
        Users? Users = new Users();

        //models
        PhoneNumberModel PhoneModel = new();
        EmailModel EmailModel = new();
        AddressModel AddressModel = new();
        //vars 
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
                PhoneModel.PhoneNumber = Users?.phone ?? "+0(000) 000-0000";
                EmailModel.Email = Users?.email ?? "email@email.com";
                AddressModel.Address = Users?.address ?? "AAAA,AA,AAAA";

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
            update.UpdatePhoneNum(PhoneModel.PhoneNumber, UserID);
        }
        private void EditEmail()
        {
            isEditingEmail = !isEditingEmail;
        }
        private void SaveEmail()
        {
            EditEmail();
            update.UpdateEmail(EmailModel.Email, UserID);
        }
        private void EditAddress()
        {
            isEditingAddress = !isEditingAddress;
        }

        private void SaveAddress()
        {
            EditAddress();
            update.UpdateAddress(AddressModel.Address, UserID);
        }

        private void EditDescription()
        {
            isEditingDescription = !isEditingDescription;
        }

        private void SaveDescription(string desc)
        {
            EditDescription();
            update.UpdateDescription(desc, UserID);
        }
    }
}
