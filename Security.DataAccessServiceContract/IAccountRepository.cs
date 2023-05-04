using FrameWork;
using Security.DomainModel.DTO.User;
using Security.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccessServiceContract
{
    public interface IAccountRepository
    {
        UserInfo GetUserInf(string userName);
        User GetFullInfo(string userName);
        OperationResult RegisterNewUser(User u);
        bool CheckIfUserHasAccess(CheckPermission per);
    }
}