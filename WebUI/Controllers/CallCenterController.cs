using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CallCenterController : Controller
    {
        private IAuthService _authService;
        private ILoggingService _loggingService;
        public CallCenterController(IAuthService _authService, ILoggingService _loggingService)
        {
            this._authService = _authService;
            this._loggingService = _loggingService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListCallCenterUser()
        {
            var list = _authService.GetAllCallCenterUser();
            List<CallCenterUserViewModel> modelList = new List<CallCenterUserViewModel>();
            foreach (var item in list)
            {
                CallCenterUserViewModel model = new CallCenterUserViewModel()
                {
                     Id =item.Id,
                    CreatedDate=item.CreatedDate,
                    FullName = item.FullName,
                    IsActive=item.IsActive
                };
                modelList.Add(model);
            }
            return View(modelList);
        }

        public async Task<bool> LoginUserAsync(LoginViewModel model)
        {
            var user = _authService.LoginCallCenter(model.DealerId, model.Password);
            if (user!=null)
            {
                var claims = new List<Claim>();
                if (user.RoleId == 2)
                {
                    claims.Add(new Claim(ClaimTypes.Name, user.FullName.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, "CallCenterAdmin"));
                    claims.Add(new Claim(ClaimTypes.PrimarySid, user.Id.ToString()));
                }
                else if (user.RoleId == 4)
                {
                    claims.Add(new Claim(ClaimTypes.Name, user.FullName.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, "CallCenter"));
                    claims.Add(new Claim(ClaimTypes.PrimarySid, user.Id.ToString()));
                }

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);
                _loggingService.Log("CallCenter Login işlemi", Entities.Abstract.LogType.Login,user.Id);
                return true;
            }
            return false;
        } 

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Search");
            }
            if (await LoginUserAsync(model))
            {
                return RedirectToAction("ListCallCenterUser");
            }
            if (model.Password != null)
            {
                ViewBag.LoginResult = "Lütfen Kullanıcı ID'nizi ve şifrenizi kontrol ediniz.";
            }

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "CallCenter");
        }

        public IActionResult CreateCallCenterUser(CallCenterUserViewModel model)
        {
            if (model.FullName == null || model.Password==null)
            {
                return View();
            }

            User user = new User()
            {
                IsActive = model.IsActive,
                FullName = model.FullName,
                Password = _authService.PasswordHasher(model.Password),
                CreatedDate = DateTime.Now,
                RoleId = 4,
                CreatedBy = 2
            };
            _authService.CreateCallCenter(user);
            return RedirectToAction("ListCallCenterUser","CallCenter");
        }
        public IActionResult Search()
        {
            return View();
        }
        public JsonResult SearchByDealerId(int dealerId)
        {
            User user = new User();
            user = _authService.GetUserByDealerId(dealerId);
            return Json(user?.DealerId);
        }

    }
}