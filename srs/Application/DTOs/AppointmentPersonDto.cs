using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot.DTOs
{
    public class AppointmentPersonDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public List<SlotDto> Slots { get; set; }  = new List<SlotDto>();
    }
}
