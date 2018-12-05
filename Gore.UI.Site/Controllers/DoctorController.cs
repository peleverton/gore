using Gore.Application.Interfaces;
using Gore.Application.ViewModels;
using Gore.Domain.Core.Notifications;
using Gore.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gore.UI.Site.Controllers
{
    public class DoctorController : BaseController
    {
        private readonly IDoctorAppService _doctorAppService;
        private readonly IPersonAppService _personAppService;
        private readonly IAddressAppService _addressAppService;
        private readonly IBloodTypeAppService _bloodTypeAppService;
        private readonly IApiClientService _apiClientService;


        public DoctorController(IDoctorAppService doctorAppService,
            IPersonAppService personAppService,
            IAddressAppService addressAppService,
            IBloodTypeAppService bloodTypeAppService,
            IApiClientService apiClientService,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _doctorAppService = doctorAppService;
            _personAppService = personAppService;
            _addressAppService = addressAppService;
            _bloodTypeAppService = bloodTypeAppService;
            _apiClientService = apiClientService;
        }

        [HttpGet]
        [Route("Doctor/ListAll")]
        public IActionResult Index()
        {            
            IEnumerable<DoctorViewModel> all = _doctorAppService.GetAll();
            return View(all);
        }

        //Get: Doctor/Create
        public IActionResult Create()
        {
            DoctorViewModel doc = new DoctorViewModel();
            doc.personViewModel = new PersonViewModel {
                AddressView = new AddressViewModel()
            };
            doc.personViewModel.AddressView = _apiClientService.GetCepAsync("03657065").Result;
            ViewBag.bloodTypes = new SelectList(_bloodTypeAppService.GetAll(), "BloodTypeId", "BloodTypeDescription");
            return View(doc);
        }

        // POST: Doctor/Create
        [HttpPost]
        public IActionResult Create(DoctorViewModel doctorViewModel)
        {
            Address NewAdress = GetAddress(doctorViewModel);

            var _bloodType = _bloodTypeAppService.GetById(doctorViewModel.personViewModel.BloodTypeView);

            GetPerson(doctorViewModel, NewAdress, _bloodType);

            if (!ModelState.IsValid) return View(doctorViewModel);
            {
                _doctorAppService.Register(doctorViewModel);
            }

            if (IsValidOperation())
            {
                ViewBag.bloodTypes = new SelectList(_bloodTypeAppService.GetAll(), "BloodTypeId", "BloodTypeDescription");
                ViewData["Sucesso"] = "Dados cadastrados!";
            }

            return View();
        }

        private static void GetPerson(DoctorViewModel doctorViewModel, Address NewAddress, BloodTypeViewModel bloodType)
        {
            var blood = new BloodType(bloodType.BloodTypeId, bloodType.BloodTypeDescription);

            doctorViewModel.Person = new Person
            (
            doctorViewModel.personViewModel.FirstName,
            doctorViewModel.personViewModel.LastName,
            doctorViewModel.personViewModel.CPF,
            doctorViewModel.personViewModel.Email,
            doctorViewModel.personViewModel.DateOfBirth,
            doctorViewModel.personViewModel.Phone,
            NewAddress,
            doctorViewModel.personViewModel.Gender,
            true,
            blood
            );
        }

        private static Address GetAddress(DoctorViewModel doctorViewModel)
        {
            return new Address
                        (
                            doctorViewModel.personViewModel.AddressView.Street,
                            doctorViewModel.personViewModel.AddressView.Number,
                            doctorViewModel.personViewModel.AddressView.Cep,
                            doctorViewModel.personViewModel.AddressView.Complement,
                            doctorViewModel.personViewModel.AddressView.City,
                            doctorViewModel.personViewModel.AddressView.State
                        );
        }
    }
}