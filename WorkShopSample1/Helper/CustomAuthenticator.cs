using Microsoft.AspNetCore.Mvc.Filters;
using Security.BusinessServiceContract;
using Security.DomainModel.DTO.User;

namespace WorkShopSample1.Helper
{
    public class CustomAuthenticator : ActionFilterAttribute
    {
        private readonly IAuthHelperBuss authHelperBuss;
        private readonly IAccountBuss accountBuss;

        public CustomAuthenticator(IAuthHelperBuss authHelperBuss, IAccountBuss accountBuss)
        {
            this.authHelperBuss = authHelperBuss;
            this.accountBuss = accountBuss;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var username = context.HttpContext.User.Identity.Name;
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.HttpContext.Response.Redirect("/Account/Login");
            }

            var ControllerName = context.RouteData.Values["Controller"].ToString();
            var ActionName = context.RouteData.Values["Action"].ToString();

            var userInfo = authHelperBuss.GetCurrentUserInfo();

            //Checking SecurityInfo
            if (string.IsNullOrEmpty(userInfo.UserName))
            {
                context.HttpContext.Response.Redirect("/Account/Login");
            }

           CheckPermission permission = new CheckPermission
            {
                UserName = username
                ,
                Controller = ControllerName
                ,
                ActionName = ActionName
            };
            if (!accountBuss.CheckIfUserHasAccess(permission))
            {
                context.HttpContext.Response.Redirect("/Account/Login");
            }

            base.OnActionExecuting(context);
        }
    }
}