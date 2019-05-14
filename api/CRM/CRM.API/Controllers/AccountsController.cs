using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.API.DAL;
using CRM.API.Models;
using CRM.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CRM.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class AccountsController : ControllerBase
    //{
    //    private readonly ILogger logger;
    //    private readonly UnitOfWork unitOfWork;
    //    private readonly IMapper mapper;

    //    public AccountsController(
    //        ILogger<AccountsController> logger,
    //        IMapper mapper
    //    )
    //    {
    //        this.logger = logger;
    //        this.unitOfWork = new UnitOfWork();
    //        this.mapper = mapper;
    //    }

    //    public async Task<List<AccountVM>> Get()
    //    {
    //        return mapper.Map<List<Account>, List<AccountVM>>(await unitOfWork.AccountRepository.GetAsync() as List<Account>);
    //    }

    //    public async Task<AccountVM> Get(Guid id)
    //    {
    //        return mapper.Map<Account, AccountVM>(await unitOfWork.AccountRepository.GetByIdAsync(id));
    //    }
    //}
}