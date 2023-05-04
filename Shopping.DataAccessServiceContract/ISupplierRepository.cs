using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.DataAccess;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Model;

namespace Shopping.DataAccessServiceContract
{
    public interface ISupplierRepository:IBaseSearchRepository<int ,Supplier , SupplierSearchModel , SupplierListItem , SupplierAddModel , SupplierUpdateModel>
    {
        bool HasProduct(int supplierId);
        bool HasSupplierNameExist(string supplierName);
        bool HasSupplierNameExist(string supplierName , int supplierId);
        List<SupplierListItem> GetAllRoots();
    }
}