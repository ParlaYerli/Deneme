using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
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
    }
}