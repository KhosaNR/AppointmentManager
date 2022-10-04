using Domain.Enums;

namespace BlazorserverApp.Data
{
    public class SlotModel
    {
        public string Id { get; set; } 
        public DateTime SlotDate { get; set; }
        public Guid ClientId { get; set; }

        public AppointmentStatus Status { get; set; }
        public string? CancellationReason { get; set; }
    }
}
