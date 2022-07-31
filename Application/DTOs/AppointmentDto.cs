using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AppointmentDto
    {
        public string Id { get; set; }  
        public string AppointmentCode { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string AppointmentPersonId { get; set; }

        public AppointmentStatus Status { get; set; }
        public String CancellationReason { get; set; }
    }
}
