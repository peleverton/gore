using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gore.Application.Interfaces;
using Gore.Application.ViewModels;
using Gore.Domain.Commands.Doctor;
using Gore.Domain.Core.Bus;
using Gore.Domain.Interfaces;
using Gore.Infra.Data.Repository.EventSourcing;

namespace Gore.Application.Services
{
    public class DoctorAppService : IDoctorAppService
    {
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public DoctorAppService(IMapper mapper, IDoctorRepository doctorRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler bus)
        {
            _mapper = mapper;
            _doctorRepository = doctorRepository;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<DoctorViewModel> GetAll()
        {
            return _doctorRepository.GetAll().ProjectTo<DoctorViewModel>();
        }

        public DoctorViewModel GetById(int id)
        {
            return _mapper.Map<DoctorViewModel>(_doctorRepository.GetById(id));
        }

        public void Register(DoctorViewModel doctorViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewDoctorCommand>(doctorViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveDoctorCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(DoctorViewModel doctorViewModel)
        {
            var updateCommand = _mapper.Map<UpdateDoctorCommand>(doctorViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
