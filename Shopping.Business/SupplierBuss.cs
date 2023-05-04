using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork;
using Shopping.BusinessServiceContract;
using Shopping.DataAccessServiceContract;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Model;

namespace Shopping.Business
{
    public class SupplierBuss:ISupplierBuss
    {
        private ISupplierRepository repo;

        public SupplierBuss(ISupplierRepository repo)
        {
            this.repo = repo;
        }
        public OperationResult Remove(int id)
        {
            if (repo.HasProduct(id))
            {
                return new OperationResult("Remove", "Supplier").ToFail("This Supplier Has Related Product");
            }

            return repo.Delete(id);
        }

        public OperationResult Register(SupplierAddModel model)
        {
            if (repo.HasSupplierNameExist(model.SupplierName))
            {
                return new OperationResult("Register", "Supplier").ToFail("This Supplier Name Already Exist");
            }

            return repo.Add(model);
        }

        public OperationResult Updater(SupplierUpdateModel model)
        {
            if (repo.HasSupplierNameExist(model.SupplierName , model.SupplierId))
            {
                return new OperationResult("Update","Supplier").ToFail("This Supplier Name Has been Assigned to Another Supplier");
            }
            return repo.Update(model);
        }

        public List<SupplierListItem> Search(SupplierSearchModel sm, out int recordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }

            return repo.Search(sm, out recordCount);
        }

        public List<SupplierListItem> GetAllRoots()
        {
            return repo.GetAllRoots();
        }

        public Supplier GetSupplier(int id)
        {
            return repo.Get(id);
        }
    }
}