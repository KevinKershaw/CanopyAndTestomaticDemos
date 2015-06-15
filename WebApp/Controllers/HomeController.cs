using System;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string emailAddress, string password)
        {
            TempData["msg"] = "New account created";
            return RedirectToAction("ProtectedContent");
        }

        public ActionResult ProtectedContent()
        {
            if (TempData["msg"] == null && Session["msg"] != null)
            {
                TempData["msg"] = Session["msg"];
                Session["msg"] = null;
            }
            return View();
        }

        public ActionResult Finders()
        {
            return View();
        }

        public ActionResult Stabilization()
        {
            return View();
        }

        public ActionResult StabilizationAjax()
        {
            return View();
        }

        public JsonResult AjaxCall()
        {
            var duration = new Random().Next(8000);
            Thread.Sleep(duration);
            return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult StabilizationExtendTimeout()
        {
            return View();
        }

        public ActionResult Warmup()
        {
            return View();
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult Alert()
        {
            return View();
        }

        public ActionResult OtherWindows()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}