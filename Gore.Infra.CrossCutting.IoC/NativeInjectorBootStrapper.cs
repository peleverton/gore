using Gore.Domain.Core.Bus;
using Microsoft.Extensions.DependencyInjection;
using Gore.Infra.CrossCutting.Bus;
using Gore.Domain.Interfaces;
using Gore.Infra.Data.Context;
using MediatR;
using Gore.Domain.Core.Notifications;
using Gore.Domain.Events.BloodType;
using Gore.Domain.EventHandlers;
using Gore.Domain.Commands.BloodType;
using Gore.Domain.CommandHandlers;
using Gore.Application.Interfaces;
using Gore.Application.Services;
using Microsoft.AspNetCore.Http;
using Gore.Infra.Data.Repository;
using Gore.Infra.Data.Repository.EventSourcing;
using Gore.Domain.Core.Events;
using Gore.Infra.Data.EventSourcing;
using Gore.Infra.Data.UoW;
using Gore.Domain.Events.Person;
using Gore.Domain.Commands.Person;
using Gore.Domain.Events.Adress;
using Gore.Domain.Commands.Adress;
using Gore.Domain.Events.Doctor;
using Gore.Domain.Commands.Doctor;
using System.Net.Http;
using System;

namespace Gore.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {

        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();
               //_httpClient.BaseAddress = new System.Uri($"{uri}{cep}{format}");
          
            //var httpClient = new HttpClient
            //{
            //    BaseAddress = new Uri($"https://viacep.com.br/ws/03657030/json/")
            //};
            //services.AddSingleton(httpClient);
            // Application
            services.AddScoped<IBloodTypeAppService, BloodTypeAppService>();
            services.AddScoped<IPersonAppService, PersonAppService>();
            services.AddScoped<IDoctorAppService, DoctorAppService>();
            services.AddScoped<IAddressAppService, AddressAppService>();
            services.AddScoped<IApiClientService, ApiClientService>();

            #region Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
           
            // Domain - Events - BloodType
            services.AddScoped<INotificationHandler<BloodTypeRegisteredEvent>, BloodTypeEventHandler>();
            services.AddScoped<INotificationHandler<BloodTypeUpdatedEvent>, BloodTypeEventHandler>();
            services.AddScoped<INotificationHandler<BloodTypeRemovedEvent>, BloodTypeEventHandler>();
            
            // Domain - Events - Person
            services.AddScoped<INotificationHandler<PersonRegisteredEvent>, PersonEventHandler>();
            services.AddScoped<INotificationHandler<PersonUpdatedEvent>, PersonEventHandler>();
            services.AddScoped<INotificationHandler<PersonRemovedEvent>, PersonEventHandler>();

            // Domain - Events - Adress
            services.AddScoped<INotificationHandler<AdressRegisteredEvent>, AdressEventHandler>();
            services.AddScoped<INotificationHandler<AdressUpdatedEvent>, AdressEventHandler>();
            services.AddScoped<INotificationHandler<AdressRemovedEvent>, AdressEventHandler>();

            // Domain - Events - Doctor
            services.AddScoped<INotificationHandler<DoctorRegisteredEvent>, DoctorEventHandler>();
            services.AddScoped<INotificationHandler<DoctorUpdatedEvent>, DoctorEventHandler>();
            services.AddScoped<INotificationHandler<DoctorRemovedEvent>, DoctorEventHandler>();

            #endregion

            #region Domain - Commands
            // Domain - Commands - BloodType
            services.AddScoped<IRequestHandler<RegisterNewBloodTypeCommand>, BloodTypeCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveNewBloodTypeCommand>, BloodTypeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateBloodTypeCommand>, BloodTypeCommandHandler>();

            // Domain - Commands - Person
            services.AddScoped<IRequestHandler<RegisterNewPersonCommand>, PersonCommandHandler>();
            services.AddScoped<IRequestHandler<RemovePersonCommand>, PersonCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePersonCommand>, PersonCommandHandler>();

            // Domain - Commands - Adress
            services.AddScoped<IRequestHandler<RegisterNewAdressCommand>, AdressCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveAdressCommand>, AdressCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateAdressCommand>, AdressCommandHandler>();
            
            // Domain - Commands - Doctor
            services.AddScoped<IRequestHandler<RegisterNewDoctorCommand>, DoctorCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveDoctorCommand>, DoctorCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateDoctorCommand>, DoctorCommandHandler>();

            #endregion

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBloodTypeRepository, BloodTypeRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IAdressRepository, AdressRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<GoreContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<IEventStore, EventStore>();
            services.AddScoped<EventStoreContext>();

        }
    }
}
