using Gore.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Gore.Application.Interfaces
{
    public interface IAddressAppService : IDisposable
    {
        int Register(AddressViewModel addressViewModel);
        IEnumerable<AddressViewModel> GetAll();
        AddressViewModel GetById(int id);
        void Update(AddressViewModel addressViewModel);
        void Remove(int id);
    }
}
