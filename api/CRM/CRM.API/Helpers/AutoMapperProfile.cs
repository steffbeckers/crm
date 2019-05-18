using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.API.Framework;
using CRM.API.Models;
using CRM.API.ViewModels;
using CRM.API.ViewModels.Identity;

namespace CRM.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User
            CreateMap<User, UserVM>();
            CreateMap<UserVM, User>();

            // Account
            CreateMap<Account, AccountVM>();
            CreateMap<AccountVM, Account>();

            // Address
            CreateMap<Address, AddressVM>();
            CreateMap<AddressVM, Address>();

            // Contact
            CreateMap<Contact, ContactVM>();
            CreateMap<ContactVM, Contact>();

            // Country
            CreateMap<Country, CountryVM>();
            CreateMap<CountryVM, Country>();

            // Relation type
            CreateMap<AccountRelationType, AccountRelationTypeVM>();
            CreateMap<AccountRelationTypeVM, AccountRelationType>();

            // Exceptions
            CreateMap<CrmException, CrmExceptionVM>();
        }
    }
}
