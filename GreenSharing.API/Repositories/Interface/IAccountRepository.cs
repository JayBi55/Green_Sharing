﻿using GreenSharing.API.Dtos;
using GreenSharing.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API.Repositories.Interface
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account> LoginAsync(LoginDTO loginDto);
    }
}