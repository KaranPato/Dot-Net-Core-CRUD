using Microsoft.AspNetCore.Http;
using RecepiCRUD.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecepiCRUD.Service.Interfaces
{
    public interface IRecepiService
    {
        ResponseVM GetRecepi();
        ResponseVM GetRecepiById(int Id);
        ResponseVM AddRecepi(RecepiVM recepiVM);
        ResponseVM DeleteRecepi(int Id);
    }
}
