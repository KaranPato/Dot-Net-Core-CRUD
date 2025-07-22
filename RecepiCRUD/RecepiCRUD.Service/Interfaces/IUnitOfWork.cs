using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecepiCRUD.Service.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRecepiService RecepiService { get; }
        /// <summary>
        /// It will call the SaveChanges() method.
        /// </summary>
        void Complete();
    }
}
