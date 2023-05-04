using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Model;

namespace Shopping.BusinessServiceContract
{
    public interface ISupplierBuss
    {
        OperationResult Remove(int id);
        OperationResult Register(SupplierAddModel model);
        OperationResult Updater(SupplierUpdateModel model);
        List<SupplierListItem> Search(SupplierSearchModel sm , out int recordCount);
        List<SupplierListItem> GetAllRoots();
        Supplier GetSupplier(int id);
    }
}