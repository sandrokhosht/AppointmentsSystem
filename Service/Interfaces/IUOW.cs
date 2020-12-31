using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IUOW : IDisposable
    {

        IAppointmentRepository Appointment { get; }

        void Commit();
    }
}
