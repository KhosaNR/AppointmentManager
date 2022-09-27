using Microsoft.AspNetCore.Components;
using BlazorserverApp.Data;
using AppointmentPersons.Command;
using Slot.DTOs;
using Domain.Interfaces.Persistence;
using Domain.Services;
using Domain.Entities;
using Application.Appointments.Queries;
using Application.AppointmentsPersons.Queries;

namespace BlazorserverApp.Components
{
    public partial class CreateAppointmentClient : ComponentBase
    {
        // check: https://www.pragimtech.com/blog/blazor/pass-data-from-child-to-parent-component-in-blazor/

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public EventCallback<string> OnCreateClient { get; set; }

        [Inject]
        public IUnitOfWork uow { get; set; }

        [Inject]
        public IAppointmentPersonService appointmentPersonService { get; set; }

        [Parameter]
        public string AppointmentDateTimeString { get; set; }

        protected AppointmentClientModel appointemntClient = new AppointmentClientModel();

        protected AppointmentPersonDto appointmentPerson { get; set; } = new AppointmentPersonDto();

        private string HideModal = "";

        protected async Task Continue_Click()
        {
            //Save to database and go to ThankYouPage
            await OnCreateClient.InvokeAsync(AppointmentDateTimeString);
        }

        protected async Task SubmitAppointmentForm_Click()
        {
            SetHideModal();
            SaveAppointment();
            if (ClientHasPendingAppointment()) {
                //Ridirect to pending appointment
            }
            RedirectToThankYouPage();
        }

        private void RedirectToThankYouPage()
        {
            var temp_AppointmentDate = DateTime.Parse(AppointmentDateTimeString);
            AppointmentDateTimeString = temp_AppointmentDate.ToString("dd MM yyyy HH:mm");
            NavigationManager.NavigateTo($"/ThankYou/{AppointmentDateTimeString}", true);
        }

        private bool ClientHasPendingAppointment()
        {
            AppointmentClientQueries appointmentClientQueries = new(uow);
            return appointmentClientQueries.PhoneNoHasPendingAppointment(appointmentPerson.PhoneNo);
        }

        private async Task SaveAppointment()
        {
            var temp_AppointmentDate = DateTime.Parse(AppointmentDateTimeString);
            CreateAppointmentCommand createAppointmentPersonCommand = new(uow, appointmentPersonService);
            appointmentPerson.Slots.Add(new SlotDto() { SlotDate = temp_AppointmentDate });
            createAppointmentPersonCommand.Execute(appointmentPerson);
        }

        private void SetHideModal()
        {
            HideModal = "modal";
        }
        protected override void OnInitialized()
        {
            if (string.IsNullOrEmpty(AppointmentDateTimeString))
            {
                AppointmentDateTimeString = DateTime.Now.ToString();
            }
        }

    }
}
