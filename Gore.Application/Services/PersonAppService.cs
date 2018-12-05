using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gore.Application.Interfaces;
using Gore.Application.ViewModels;
using Gore.Domain.Commands.Person;
using Gore.Domain.Core.Bus;
using Gore.Domain.Interfaces;
using Gore.Infra.Data.Repository.EventSourcing;

namespace Gore.Application.Services
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;
               
        public PersonAppService(IMapper mapper, IPersonRepository personRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler bus)
        {
            _mapper = mapper;
            _personRepository = personRepository;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<PersonViewModel> GetAll()
        {
            

            return _personRepository.GetAll().ProjectTo<PersonViewModel>();
        }

        public PersonViewModel GetById(int id)
        {
            return _mapper.Map<PersonViewModel>(_personRepository.GetById(id));
        }

        public void Register(PersonViewModel personViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewPersonCommand>(personViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemovePersonCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(PersonViewModel personViewModel)
        {
            var updateCommand = _mapper.Map<UpdatePersonCommand>(personViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
