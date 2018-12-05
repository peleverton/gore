﻿using Gore.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Gore.Application.Interfaces
{
    public interface IPersonAppService : IDisposable
    {
        void Register(PersonViewModel personViewModel);
        IEnumerable<PersonViewModel> GetAll();
        PersonViewModel GetById(int id);
        void Update(PersonViewModel personViewModel);
        void Remove(int id);
    }
}
