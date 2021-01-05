using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUOW : IDisposable
    {

        IAppointmentRepository Appointment { get; }

        IUserRepository User { get; }

        void Commit();
        
    }
}
