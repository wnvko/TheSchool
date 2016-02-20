namespace TheSchool.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using TheSchool.Common;
    using TheSchool.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
