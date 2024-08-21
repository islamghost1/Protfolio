using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Portfolio.Client.Models;
using Portfolio.Data;

namespace Portfolio.Components.Pages
{
    public partial class ModificationEnabled : ComponentBase
    {

        
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
