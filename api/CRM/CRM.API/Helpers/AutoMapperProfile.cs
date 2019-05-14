using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.API.Models;
using CRM.API.ViewModels;

namespace CRM.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
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
            CreateMap<RelationType, RelationTypeVM>();
            CreateMap<RelationTypeVM, RelationType>();
        }
    }
}
