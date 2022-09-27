using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot.DTOs
{
    public class SlotDto
    {
        public Guid Id { get; set; }  
        //public string SlotCode { get; set; }
        public DateTime SlotDate { get; set; }
        public Guid PersonId { get; set; }

        public AppointmentStatus Status { get; set; }
        public string? CancellationReason { get; set; }
    }
}
