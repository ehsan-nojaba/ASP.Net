using FrameWork;
using Security.DomainModel.DTO.User;
using Security.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.BusinessServiceContract
{
    public interface IAccountBuss
    {
        OperationResult Login(Login login);
        OperationResult Register(User command);
        void LogoutUser();
        UserInfo GetAccountInfo();
        bool CheckIfUserHasAccess(CheckPermission per);
    }
}