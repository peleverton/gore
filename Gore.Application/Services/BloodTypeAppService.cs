using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gore.Application.Interfaces;
using Gore.Application.ViewModels;
using Gore.Domain.Commands.BloodType;
using Gore.Domain.Core.Bus;
using Gore.Domain.Interfaces;
using Gore.Infra.Data.Repository.EventSourcing;

namespace Gore.Application.Services
{
    public class BloodTypeAppService : IBloodTypeAppService
    {
        private readonly IMapper _mapper;
        private readonly IBloodTypeRepository _bloodRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public BloodTypeAppService(IMapper mapper, IBloodTypeRepository bloodRepository, IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _bloodRepository = bloodRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<BloodTypeViewModel> GetAll()
        {
            return _bloodRepository.GetAll().ProjectTo<BloodTypeViewModel>();
        }

        public BloodTypeViewModel GetById(int id)
        {
            return _mapper.Map<BloodTypeViewModel>(_bloodRepository.GetById(id));
        }

        public void Register(BloodTypeViewModel bloodTypeViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewBloodTypeCommand>(bloodTypeViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveNewBloodTypeCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(BloodTypeViewModel bloodTypeViewModel)
        {
            var updateCommand = _mapper.Map<UpdateBloodTypeCommand>(bloodTypeViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
