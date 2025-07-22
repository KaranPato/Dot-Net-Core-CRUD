using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecepiCRUD.Service.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(string username, string role);
    }
}
