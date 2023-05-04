using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.DataAccess
{
    public interface IBaseRepository<TKey , TModel , TAddModel , TUpdateModel>
    {
        TModel Get(TKey modelId);
        OperationResult Delete(TKey modelId);
        OperationResult Add(TAddModel model);
        OperationResult Update(TUpdateModel model);
        List<TModel> GetAll();
    }
}
