using AdminDek.Models;
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
        public async Task<ActionResult> UserProfile(CommonModel commonModel)
        {
            var Id = User.Identity.GetUserId();
            var TableName = "UpdateAdminTbl";
            var list = await _accountObj.GetAdminUserData(TableName, Id);
            commonModel.accountModel = list;
            _ = new ASPNETMVCEntities();
            ViewBag.CountryList = new SelectList(GetCountryList(), "Cid", "Cname");
            return View(commonModel);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateAdmin(AccountModel _accountModel)
        {
            try
            {
                var x = _accountModel.ImageFile;

                bool isError = true;
                var message = string.Empty;
                var res = await _accountObj.UpdateAdminData(_accountModel);
                if (res >= 0)
                {
                    isError = false;
                    message = "Profile Updated Successfully.";
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

        //Location List 
        public List<Country> GetCountryList()
        {
            ASPNETMVCEntities aspnetmvcEntities = new ASPNETMVCEntities();
            List<Country> countries = aspnetmvcEntities.Countries.ToList();
            return countries;
        }

        public ActionResult GetStateList(int Cid)
        {
            ASPNETMVCEntities aspnetmvcEntities = new ASPNETMVCEntities();
            List<State> selectList = aspnetmvcEntities.States.Where(x => x.Cid == Cid).ToList();
            ViewBag.StateList = new SelectList(selectList, "Sid", "Sname");
            return PartialView("_DisplayStates");
        }

        public ActionResult GetCityList(int Sid)
        {
            ASPNETMVCEntities aspnetmvcEntities = new ASPNETMVCEntities();
            List<City> selectList = aspnetmvcEntities.Cities.Where(x => x.Sid == Sid).ToList();
            ViewBag.CityList = new SelectList(selectList, "Cityid", "Cityname");
            return PartialView("_DisplayCities");
        }
    }
}