using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlazorserverApp.Data;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

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

