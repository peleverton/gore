using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gore.Application.Interfaces;
using Gore.Application.ViewModels;
using Gore.Domain.Commands.Adress;
using Gore.Domain.Core.Bus;
using Gore.Domain.Interfaces;
using Gore.Infra.Data.Repository.EventSourcing;

namespace Gore.Application.Services
{
    public class AddressAppService : IAddressAppService
    {
        private readonly IMapper _mapper;
        private readonly IAdressRepository _addressRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public AddressAppService(IMapper mapper, IAdressRepository addressRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler bus)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<AddressViewModel> GetAll()
        {
            return _addressRepository.GetAll().ProjectTo<AddressViewModel>();
        }

        public AddressViewModel GetById(int id)
        {
            return _mapper.Map<AddressViewModel>(_addressRepository.GetById(id));
        }

        public int Register(AddressViewModel addressViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewAdressCommand>(addressViewModel);
            Bus.SendCommand(registerCommand);
            return registerCommand.AddressId;
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveAdressCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(AddressViewModel addressViewModel)
        {
            var updateCommand = _mapper.Map<UpdateAdressCommand>(addressViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
