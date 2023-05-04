using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork;
using Security.DataAccessServiceContract;
using Security.DomainModel.DTO.User;
using Security.DomainModel.Model;

namespace Security.DataAccess
{
    public class AccountRepository:IAccountRepository
    {
        private SecurityContext db;

        public AccountRepository(SecurityContext db)
        {
            this.db = db;
        }

        public UserInfo GetUserInf(string userName)
        {
            var items = from r in db.Roles
                join u in db.Users on r.RoleId equals u.RoleId
                where u.UserName == userName || u.Email == userName
                select new UserInfo
                {
                    FullName = u.FirstName + u.LastName,
                    RoleId = u.RoleId,
                    UserName = u.UserName,
                    RoleName = r.RoleName,
                    UserId = u.UserId,
                    Mobile = u.Mobile,
                    Email = u.Email,
                };
            return items.FirstOrDefault();
        }

        public User GetFullInfo(string userName)
        {
            return db.Users.FirstOrDefault(x => x.UserName == userName || x.Email == userName);
        }

        public OperationResult RegisterNewUser(User u)
        {
            OperationResult op = new OperationResult("Register New User", "User");
            try
            {
                if (u.RoleId == 0)
                {
                    u.RoleId = 2;
                }
                db.Users.Add(u);
                db.SaveChanges();
                op.ToSuccess("User Registered Successfully" + u.UserId);
            }
            catch (Exception e)
            {
                op.ToFail("Register Failed" + e.Message);
            }
            return op;
        }

        public bool CheckIfUserHasAccess(CheckPermission per)
        {
            var items = from u in db.Users
                join r in db.Roles on u.RoleId equals r.RoleId
                join ra in db.RoleActions on r.RoleId equals ra.RoleId
                join pa in db.ProjectActions on ra.ProjectActionId equals pa.ProjectActionId
                join pc in db.ProjectControllers on pa.ProjectControllerId equals pc.ProjectControllerId
                select new
                {
                    pc.ProjectControllerName,
                    pa.ProjectActionName,
                    u.UserName,
                    ra.HasPermission
                };
            var result = items.First(x =>
                x.UserName == per.UserName && x.ProjectActionName == per.ActionName &&
                x.ProjectControllerName == per.Controller);
            if (result == null)
            {
                return false;
            }

            return result.HasPermission;
        }
    }
}