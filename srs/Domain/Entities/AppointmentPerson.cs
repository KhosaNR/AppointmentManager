using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppointmentPerson : User
    {
        private List<Appointment> _Appointments = new List<Appointment>();
        public void AddAppointment(Appointment appointment)
        {
            _Appointments.Add(appointment);
        }
        public ICollection<Appointment> Appointments{ get{return _Appointments;} }
        //public AppointmentPerson(string firstName, string LastName, string phoneNo, IEnumerable<Appointment> appointments): base(firstName, LastName, phoneNo)
        //{
        //    Appointments = appointments;
        //}

        //bool CreateAppointment()
        //{
        //    var newAppointment = new Appointment
        //    {
        //        AppointmentDate = DateTime.Now,
        //        AppointmentPerson_Id = this.ID,
        //        Status = Enums.AppointmentStatus.Booked
        //    };
        //    //GetAppAppointments and validate time.
        //    if(appointments == null)
        //        appointments = new List<Appointment>();
        //    appointments.Add(appointment);
        //}
    }
}
