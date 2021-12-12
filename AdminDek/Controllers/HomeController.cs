using Domain.Models;
using Microsoft.AspNet.Identity;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdminDek.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccount _accountObj;

        public HomeController()
        {

        }
        public HomeController(IAccount accountObj)
        {
            _accountObj = accountObj;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //User Profile View
        [HttpGet]
        public async Task<ActionResult> UserProfile()
        {
            var Id = User.Identity.GetUserId();
            var TableName = "UpdateAdminTbl";
            var list = await _accountObj.GetAdminUserData(TableName, Id);
            return View(list);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateAdmin(AccountModel _accountModel)
        {
            try
            {
                bool isError = true;
                var message = string.Empty;
                var res = await _accountObj.UpdateAdminData(_accountModel);
                if (res > 0)
                {
                    isError = false;
                    message = "Successfully Updated";
                }
                else
                {
                    isError = true;
                    message = "Something went wrong.";
                }
                return Json(new
                {
                    IsError = isError,
                    Message = message
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    IsError = true,
                    Message = e.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}