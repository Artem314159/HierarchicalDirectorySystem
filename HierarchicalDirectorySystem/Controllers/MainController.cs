using HierarchicalDirectorySystem.Core.Context;
using HierarchicalDirectorySystem.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HierarchicalDirectorySystem.Controllers
{
    [Route("")]
    public class MainController : Controller
    {
        private NodesService _service;

        public MainController(NodesService service)
        {
            _service = service;
        }

        [HttpGet, Route("{path:string}")]
        public ActionResult Index(string path)
        {
            if (path == "Main/Index") return Redirect("/");
            ViewBag.HierarchyNodeModel = _service.GetNode(path);
            return View();
        }
    }
}