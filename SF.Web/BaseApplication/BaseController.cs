using SF.Web.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SF.Web.BaseApplication
{
    [SysAuthorize]
    public class BaseController : Controller
    {

    }
}