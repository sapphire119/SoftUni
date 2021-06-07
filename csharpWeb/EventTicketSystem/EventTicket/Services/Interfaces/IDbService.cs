using EventTicket.Data;
using EventTicket.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTicket.Services.Interfaces
{
    public interface IDbService
    {
        Task SeetheData();
    }
}
