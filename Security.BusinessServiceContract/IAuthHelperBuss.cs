using Security.DomainModel.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.BusinessServiceContract
{
    public interface IAuthHelperBuss
    {
        void SignIn(UserInfo account);
        void SignOut();
        UserInfo GetCurrentUserInfo();
    }
}