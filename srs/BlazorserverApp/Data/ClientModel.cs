namespace BlazorserverApp.Data
{
    public class ClientModel
    {
        public string Id { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public string PhoneNo { get; set; } = "";
        public string PaymentMethod { get; set; } = "";
        public List<SlotModel> Slots { get; set; } = new();

    }
}
