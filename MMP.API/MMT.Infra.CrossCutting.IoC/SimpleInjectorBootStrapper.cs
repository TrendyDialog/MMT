using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MMT.Domain.CommandHandlers.CellCommandHandlers;
using MMT.Domain.Commands.Cell;
using MMT.Domain.Core.Bus;
using MMT.Domain.Core.Events;
using MMT.Domain.Core.Notifications;
using MMT.Domain.Interfaces;
using MMT.Infra.CrossCutting.Bus;
using MMT.Infra.Data.Context;
using MMT.Infra.Data.EventSourcing;
using MMT.Infra.Data.Repository;
using MMT.Infra.Data.Repository.EventSourcing;
using MMT.Infra.Data.UoW;
using MMT.Service.Interfaces;
using MMT.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMT.Infra.CrossCutting.IoC
{
    public class SimpleInjectorBootStrapper
    {
        /// <summary>
        /// Register Services for Dependency Injection
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddAutoMapper(GetAutoMapperProfilesFromAllAssemblies().ToArray());

            //Services
            services.AddScoped<ICellService, CellService>();
            services.AddScoped<IDamageTypeService, DamageTypeService>();
            services.AddScoped<IBagReplacementService, BagReplacementService>();

            //Repositories
            services.AddScoped<ICellChangesRepository, CellChangesRepository>();
            services.AddScoped<ICellRepository, CellRepository>();
            services.AddScoped<IDamageTypeRepository, DamageTypeRepository>();
            services.AddScoped<IBagReplacementRepository, BagReplacementRepository>();

            // Infrastructure
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MMTContext>();

            services.AddScoped<IBus, InMemoryBus>();
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreContext>();

            // Domain - Notifications
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Commands & Handlers
            services.AddScoped<IHandler<AddCellCommand>, CellCommandHandler>();
            services.AddScoped<IHandler<UpdateCellCommand>, CellCommandHandler>();                       
        }

        /// <summary>
        /// See article below
        /// https://stackoverflow.com/questions/40275195/how-to-set-up-automapper-in-asp-net-core
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Type> GetAutoMapperProfilesFromAllAssemblies()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var aType in assembly.GetTypes())
                {
                    if (aType.IsClass && !aType.IsAbstract && aType.IsSubclassOf(typeof(Profile)))
                        yield return aType;
                }
            }
        }
    }
}
