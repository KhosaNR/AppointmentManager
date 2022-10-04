using AutoMapper;
using BlazorserverApp.Data;
using Domain.Entities;
using Domain.Interfaces.Persistence;
using Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.WebRequestMethods;
using Application.Clients.Queries;
using Application.Clients.Commands;
using System.Linq;

using Application.DTOs;
using System.Drawing;
using Domain.Enums;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorserverApp.Pages
{
    public partial class ClientList : ComponentBase
    {

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IUnitOfWork uow { get; set; }

        [Inject]
        private IClientService ClientService { get; set; }

        [Inject]
        private IMapper Mapper { get; set; }

        public List<ClientModel> ClientsMaster = new();
        public List<ClientModel> ClientsMasterSortedAndFiltered = new();

        ClientModel stdmst = new ClientModel();

        public List<string> StatusList = new();

        int ids = 0;
        int studentIDs = 0;
        public string ImageSortname = "Images/sortAsc.png";

        private string SortColumn { get; set; } = "";
        private bool SortAscending { get; set; } = false;
        private bool ChangeSortingOrder = true;

        public ClientFilter Filter { get; set; } = new();
        public ClientSorting Sorting { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            PopulateStatusList();
            await GetClientsAsync();
            SortColumn = "AppointmentTime";
            SortAscending = true;
            ClientsMasterSortedAndFiltered = ClientsMaster;
            await ClientSorting("AppointmentTime");
            //stdMaster = await Http.GetJsonAsync<ClientMasters[]>("/api/ClientMasters/");
        }



        private async Task GetClientsAsync()
        {
            ClientQueries ClientQueries = new(uow, Mapper);
            var allClients = await ClientQueries.GetAll();
            var clientModelList = Mapper.Map<IEnumerable<ClientModel>>(allClients);
            ClientsMaster = clientModelList.ToList();
        }

        private void PopulateStatusList()
        {
            foreach (string name in Enum.GetNames(typeof(AppointmentStatus)))
            {
                StatusList.Add(name);
            }
        }

        //Sorting
        public async Task ClientSorting(string SortColumn)
        {
            ChangeSorting(SortColumn);

            //await GetClientsAsync();
            //stdMaster = await Http.GetJsonAsync<ClientMasters[]>("/api/ClientMasters/");


            if (SortAscending)
            {
                ImageSortname = "Images/sortDec.png";
                //ChangeSorting=true;

                switch (SortColumn)
                {
                    case "LastName":
                        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.OrderBy(x => x.LastName).ToList();
                        break;
                    case "FirstName":
                        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.OrderBy(x => x.FirstName).ToList();
                        break;
                    case "StdLastName":
                        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.OrderBy(x => x.LastName).ToList();
                        break;

                    case "Email":
                        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.OrderBy(x => x.EmailAddress).ToList();
                        break;
                    case "Phone":
                        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.OrderBy(x => x.PhoneNo).ToList();
                        break;
                    case "AppointmentTime":
                        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.OrderBy(x => x.Slots.Min(s => s.SlotDate)).ToList();
                        break;
                    case "AppointmentStatus":
                        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.OrderBy(x => x.Slots.Min(s => s.Status)).ToList();
                        break;
                }
            }
            else
            {
                ImageSortname = "Images/sortAsc.png";
                //ids = 0;

                switch (SortColumn)
                {
                    case "FirstName":
                        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.OrderByDescending(x => x.FirstName).ToList();
                        break;
                    case "LastName":
                        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.OrderByDescending(x => x.LastName).ToList();
                        break;

                    case "Email":
                        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.OrderByDescending(x => x.EmailAddress).ToList();
                        break;
                    case "Phone":
                        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.OrderByDescending(x => x.PhoneNo).ToList();
                        break;
                    case "AppointmentTime":
                        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.OrderByDescending(x => x.Slots.Max(s => s.SlotDate)).ToList();
                        break;
                    case "AppointmentStatus":
                        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.OrderByDescending(x => x.Slots.Max(s => s.Status)).ToList();
                        break;
                }
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task TestMethodAsync(string value, string columnName)
        {
            switch (columnName)
            {
                case "FirstName":
                    Filter.FirstName = value.ToString();
                    break;
                case "LastName":
                    Filter.LastName = value.ToString();
                    break;
                case "Email":
                    Filter.Email = value.ToString();
                    break;
                case "Phone":
                    Filter.PhoneNo = value.ToString();
                    break;
                case "AppointmentTime":
                    Filter.AppointmentTime = value.ToString();
                    break;
                case "Status":
                    Filter.Status = value.ToString();
                    break;
                default:
                    break;
            }
            await clientFilteringList(value.ToString(), columnName);
        }

        // For Filtering by First Names
        public async Task OnFirstNameChangedAsync(ChangeEventArgs args)
        {
            string values = args.Value.ToString();
            await TestMethodAsync(values, "FirstName");
            //await clientFilteringList(values, "FirstName");
        }

        public async Task OnLastNameChangedAsync(ChangeEventArgs args)
        {
            string values = args.Value.ToString();
            await TestMethodAsync(values, "LastName");
        }

        // For Filtering by Email
        public async Task OnEmailChangedAsync(ChangeEventArgs args)
        {
            string values = args.Value.ToString();
            await TestMethodAsync(values, "Email");
        }


        // For Filtering by Phone
        public async Task OnPhoneChangedAsync(ChangeEventArgs args)
        {
            string values = args.Value.ToString();
            await TestMethodAsync(values, "Phone");
        }


        // For Filtering by Adress
        public async Task OnAppointmentTimeChangedAsync(ChangeEventArgs args)
        {
            string values = args.Value.ToString();
            await TestMethodAsync(values, "AppointmentTime");
        }

        // For Filtering by Adress
        public async Task OnStatusSelectedChangedAsync(ChangeEventArgs args)
        {
            string values = args.Value.ToString();
            await TestMethodAsync(values, "Status");
        }

        private void ChangeSorting(string sortColumn)
        {
            if (ChangeSortingOrder)
                SortAscending = SortColumn == sortColumn ? !SortAscending : true;
            SortColumn = sortColumn;
            ChangeSortingOrder = true;
            Sorting.ChangeSortingColumn(sortColumn, SortAscending);
        }



        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //Filtering
        public async Task clientFilteringList(string filterValue, string columnName)
        {
            await GetClientsAsync();
            //ClientsMaster = await Http.GetJsonAsync<ClientMasters[]>("/api/ClientMasters/");
            //if (filterValue.Trim().Length > 0)
            {
                ClientsMasterSortedAndFiltered = ClientsMaster.Where(x =>
                        x.FirstName.ToLower().Contains(Filter.FirstName.ToLower())
                        && x.LastName.ToLower().Contains(Filter.LastName.ToLower())
                        && x.EmailAddress.ToLower().Contains(Filter.Email.ToLower())
                        && x.PhoneNo.ToLower().Contains(Filter.PhoneNo.ToLower())
                        ).ToList();

                if (!string.IsNullOrEmpty(Filter.AppointmentTime))
                {
                    ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.Where(x =>
                            x.Slots.Any(s => DateTime.Compare(s.SlotDate.Date,DateTime.Parse(Filter.AppointmentTime).Date) == 0)
                            ).ToList();
                }


                if (!string.IsNullOrEmpty(Filter.Status) && Filter.Status.ToLower() != "all")
                {
                    ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.Where(x =>
                            x.Slots.Any(s => s.Status == (AppointmentStatus)Enum.Parse(typeof(AppointmentStatus), Filter.Status))
                            ).ToList();
                }

                ChangeSortingOrder = false;
                await ClientSorting(SortColumn);

                //switch (columnName)
                //{
                //    case "FirstName":
                //        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.Where(x => x.FirstName.ToLower().Contains(filterValue.ToLower())).ToList();
                //        break;
                //    case "LastName":
                //        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.Where(x => x.LastName.ToLower().Contains(filterValue.ToLower())).ToList();
                //        break;

                //    case "Email":
                //        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.Where(x => x.EmailAddress.ToLower().Contains(filterValue.ToLower())).ToList();
                //        break;
                //    case "Phone":
                //        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.Where(x => x.PhoneNo.ToLower().Contains(filterValue.ToLower())).ToList();
                //        break;
                //    case "AppointmentTime":
                //        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.Where(x => x.Slots.Any(s=> DateTime.Compare(s.SlotDate.Date, DateTime.Parse(filterValue).Date) ==0)).ToList();
                //        break;
                //    case "Status":
                //        if (filterValue.ToLower() == "all")
                //            break;
                //        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered.Where(x => x.Slots.Any(s => s.Status== (AppointmentStatus) Enum.Parse(typeof(AppointmentStatus),filterValue))).ToList();
                //        break;
                //    default:
                //        ClientsMasterSortedAndFiltered = ClientsMasterSortedAndFiltered;
                //        //await GetClientsAsync();
                //        //ClientsMaster = await Http.GetJsonAsync<ClientMasters[]>("/api/ClientMasters/");
                //        break;
                //}
            }
                //else
                //{
                //    await GetClientsAsync();
                //    //ClientsMaster = await Http.GetJsonAsync<ClientMasters[]>("/api/ClientMasters/");
                //}
            }
        }
    }

