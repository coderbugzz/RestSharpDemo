using RestSharpDemo.Caller;
using RestSharpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RestSharpDemo.Controllers
{
    public class HomeController : Controller
    {
         IRestClientCaller _restClient;

        public HomeController(IRestClientCaller restClient)
        {
            _restClient = restClient;
        }
        public async Task<ActionResult> Index()
        {
           var members = await _restClient.GetMembers();

            return View(members);
        }
        public async Task<ActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(member model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
             _restClient.Create(model);
            return RedirectToAction("index");
        }

        public async Task<ActionResult> Edit(int Id)
        {
            member result = await _restClient.GetMemberByID(Id);

            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(member model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _restClient.Update(model);

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int Id)
        {
            _restClient.Delete(Id);
            return RedirectToAction("index");
        }

    }
}