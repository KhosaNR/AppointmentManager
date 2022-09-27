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

        protected AppointmentClientModel Client;
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async Task CreateClient()
        {
            Console.WriteLine("Test xxx");
            Debug.Print("Text debug");
            Debug.WriteLine("Text debug writeline");

            //Navigate to the Add time 
            //Employees = (await EmployeeService.GetEmployees()).ToList();
            NavigationManager.NavigateTo("/");
            //return RedirectToPage("/Index");

        }

        protected async Task BookAppointment_Click()
        {
            NavigationManager.NavigateTo("/Calendar");
        }
    }
}

