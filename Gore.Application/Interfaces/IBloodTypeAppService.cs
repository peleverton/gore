using Gore.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Gore.Application.Interfaces
{
    public interface IBloodTypeAppService : IDisposable
    {
        void Register(BloodTypeViewModel bloodTypeViewModel);
        IEnumerable<BloodTypeViewModel> GetAll();
        BloodTypeViewModel GetById(int id);
        void Update(BloodTypeViewModel bloodTypeViewModel);
        void Remove(int id);
    }
}
