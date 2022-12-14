using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SlotDto
    {
        public Guid Id { get; set; }  
        public DateTime SlotDate { get; set; }
        public Guid ClientId { get; set; }

        public AppointmentStatus Status { get; set; }
        public string? CancellationReason { get; set; }
    }
}
