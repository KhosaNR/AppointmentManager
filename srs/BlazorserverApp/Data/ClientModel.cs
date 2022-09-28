namespace BlazorserverApp.Data
{
    public class ClientModel
    {
        public string FirstNames { get; set; }
        public string LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime AppointmentTime { get;set; }

    }
}
