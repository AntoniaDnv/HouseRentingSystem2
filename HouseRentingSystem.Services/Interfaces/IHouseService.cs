using HouseRentingSystem.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services.Interfaces
{
    public interface IHouseService
    {
        Task< IEnumerable<HouseViewModel>> GetHouseServices(string userId);
    }
}
