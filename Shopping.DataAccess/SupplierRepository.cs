using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork;
using Shopping.DataAccessServiceContract;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Model;

namespace Shopping.DataAccess
{
    public class SupplierRepository:ISupplierRepository
    {
        private WorkShopDevelopContext db;

        public SupplierRepository(WorkShopDevelopContext db)
        {
            this.db = db;
        }
        public Supplier Get(int modelId)
        {
            return db.Suppliers.FirstOrDefault(x => x.SupplierId == modelId);
        }

        public OperationResult Delete(int modelId)
        {
            OperationResult op = new OperationResult("Delete", "Supplier",modelId);
            try
            {
                var item = Get(modelId);
                db.Suppliers.Remove(item);
                db.SaveChanges();
                op.ToSuccess("Delete Successfully");
            }
            catch (Exception e)
            {
                op.ToFail("Delete Failed " + e.Message);
            }

            return op;
        }

        public OperationResult Add(SupplierAddModel model)
        {
            OperationResult op = new OperationResult("Add", "Supplier");
            try
            {
                Supplier sup = new Supplier
                {
                    SupplierName = model.SupplierName,
                    Tel = model.Tel,
                    Grade = model.Grade,
                };
                db.Suppliers.Add(sup);
                db.SaveChanges();
                op.RecordId = sup.SupplierId;
                op.ToSuccess("Add Successfully" , sup.SupplierId);
            }
            catch (Exception e)
            {
                op.ToFail("Add Failed" + e.Message);
            }
            return op;
        }

        public OperationResult Update(SupplierUpdateModel model)
        {
            OperationResult op = new OperationResult("Update", "Supplier", model.SupplierId);
            try
            {
                var item = Get(model.SupplierId);
                item.SupplierName = model.SupplierName;
                item.Tel = model.Tel;
                item.Grade = model.Grade;
                db.SaveChanges();
                op.ToSuccess("Update Successfully");
            }
            catch (Exception e)
            {
                op.ToFail("Update Failed" + e.Message);
            }
            return op;
        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }

        public List<SupplierListItem> Search(SupplierSearchModel sm, out int recordCount)
        {
            var listItem = from item in db.Suppliers select item;
            if (!string.IsNullOrEmpty(sm.SupplierName))
            {
                listItem = listItem.Where(x => x.SupplierName.StartsWith(sm.SupplierName));
            }
            if (!string.IsNullOrEmpty(sm.Tel))
            {
                listItem = listItem.Where(x => x.Tel.StartsWith(sm.Tel));
            }

            recordCount = listItem.Count();
            return listItem.Select(x => new SupplierListItem
            {
                SupplierId = x.SupplierId,
                SupplierName = x.SupplierName,
                Tel = x.Tel,
                Grade = x.Grade,
                ProductCount = x.Products.Count
            }).OrderByDescending(x => x.SupplierId).Skip(sm.PageSize * sm.PageIndex).Take(sm.PageSize).ToList();
        }

        public bool HasProduct(int supplierId)
        {
            return db.Products.Any(x => x.SupplierId == supplierId);
        }

        public bool HasSupplierNameExist(string supplierName)
        {
            return db.Suppliers.Any(x => x.SupplierName == supplierName);
        }

        public bool HasSupplierNameExist(string supplierName, int supplierId)
        {
            return db.Suppliers.Any(x => x.SupplierName == supplierName && x.SupplierId != supplierId);
        }

        public List<SupplierListItem> GetAllRoots()
        {
            return db.Suppliers.Select(x => new SupplierListItem
            {
                SupplierId = x.SupplierId,
                SupplierName = x.SupplierName,
            }).OrderBy(x => x.SupplierName).ToList();
        }
    }
}