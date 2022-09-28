using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlazorserverApp.Data;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System;

namespace RazorWebApp.Pages
{
    public partial class Home: ComponentBase
    {
        public void OnGet()
        {
        }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async Task BookAppointment_Click()
        {
            NavigationManager.NavigateTo("/Calendar");
        }
    }
}

