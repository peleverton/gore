using Gore.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Gore.Application.Interfaces
{
    public interface IDoctorAppService : IDisposable
    {
        void Register(DoctorViewModel doctorViewModel);
        IEnumerable<DoctorViewModel> GetAll();
        DoctorViewModel GetById(int id);
        void Update(DoctorViewModel doctorViewModel);
        void Remove(int id);
    }
}
