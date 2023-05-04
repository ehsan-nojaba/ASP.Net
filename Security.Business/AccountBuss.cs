using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork;
using FrameWork.Services;
using Security.BusinessServiceContract;
using Security.DataAccessServiceContract;
using Security.DomainModel.DTO.User;
using Security.DomainModel.Model;

namespace Security.Business
{
    public class AccountBuss:IAccountBuss
    {
        private IAccountRepository repo;
        private IAuthHelperBuss authHelperBuss;
        private IPasswordHasher passwordHasher;

        public AccountBuss(IAccountRepository repo, IAuthHelperBuss authHelperBuss, IPasswordHasher passwordHasher)
        {
            this.repo = repo;
            this.authHelperBuss = authHelperBuss;
            this.passwordHasher = passwordHasher;
        }

        public OperationResult Login(Login login)
        {
            var result = new OperationResult("Login", "User");
            var u = repo.GetFullInfo(login.Username);
            if (u == null)
            {
                return result.ToFail("شما هنوز ثبت نام نکرده اید");
            }

            var (verified, needsUpgrade) = passwordHasher.Check(u.Password, login.Password);
            if (!verified)
            {
                return result.ToFail("Invalid Credential");
            }

            var userInfo = repo.GetUserInf(login.Username);
            authHelperBuss.SignIn(userInfo);
            return result.ToSuccess("Login Successfully", userInfo.UserId);
        }

        public OperationResult Register(User command)
        {
            return repo.RegisterNewUser(command);
        }

        public void LogoutUser()
        {
            authHelperBuss.SignOut();
        }

        public UserInfo GetAccountInfo()
        {
            return authHelperBuss.GetCurrentUserInfo();
        }

        public bool CheckIfUserHasAccess(CheckPermission per)
        {
            return repo.CheckIfUserHasAccess(per);
        }
    }
}