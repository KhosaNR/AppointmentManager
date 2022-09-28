using Microsoft.AspNetCore.Components;
using BlazorserverApp.Data;
using Application.DTOs;
using Domain.Interfaces.Persistence;
using Domain.Services;
using Domain.Entities;
using Application.Slot.Queries;
using Application.Client.Queries;
using Application.Client.Commands;

namespace BlazorserverApp.Components
{
    public partial class CreateClient : ComponentBase
    {
        // check: https://www.pragimtech.com/blog/blazor/pass-data-from-child-to-parent-component-in-blazor/

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public EventCallback<string> OnCreateClient { get; set; }

        [Inject]
        public IUnitOfWork uow { get; set; }

        [Inject]
        public IClientService ClientService { get; set; }

        [Parameter]
        public string AppointmentDateTimeString { get; set; }

        protected ClientModel appointemntClient = new ClientModel();

        protected ClientDto Client { get; set; } = new ClientDto();

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
            //if (ClientHasPendingAppointment()) {
            //    //Redirect to pending appointment
            //}
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
            ClientQueries ClientQueries = new(uow);
            return ClientQueries.PhoneNoHasPendingAppointment(Client.PhoneNo);
        }

        private async Task SaveAppointment()
        {
            var temp_AppointmentDate = DateTime.Parse(AppointmentDateTimeString);
            CreateAppointmentCommand createClientCommand = new(uow, ClientService);
            Client.Slots.Add(new SlotDto() { SlotDate = temp_AppointmentDate });
            createClientCommand.Execute(Client);
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

        public Guid Guid = Guid.NewGuid();
        public string ModalDisplay = "none;";
        public string ModalClass = "";
        public bool ShowBackdrop = false;

        public void Open(string selectedTime)
        {
            AppointmentDateTimeString = selectedTime;
            ModalDisplay = "block;";
            ModalClass = "Show";
            ShowBackdrop = true;
            StateHasChanged();
        }

        public void Close()
        {
            ModalDisplay = "none";
            ModalClass = "";
            ShowBackdrop = false;
            StateHasChanged();
        }

    }
}
