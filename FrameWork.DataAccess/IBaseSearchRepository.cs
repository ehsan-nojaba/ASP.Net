using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.DataAccess
{
    public interface IBaseSearchRepository<TKey , TModel,TSearchModel , TListItem , TAddModel , TUpdateModel>:IBaseRepository<TKey , TModel , TAddModel , TUpdateModel>
    {
        List<TListItem> Search(TSearchModel sm, out TKey recordCount);
    }
}
