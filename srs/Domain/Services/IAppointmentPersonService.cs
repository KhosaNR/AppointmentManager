using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IAppointmentPersonService: IUserService
    {
        void CreateAppointment(Guid appoinmentPerson_Id, DateTime appointmentTime);
    }
}
