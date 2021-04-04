using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace TechLandTools.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IMapper _mapper;
        protected IHostingEnvironment _appEnvironment;

        public string EntityListViewPath = "Views/EntityView/EntityListView.cshtml";
        public string EntityEditorPath = "Views/EntityView/EntityEditor.cshtml";

        public ViewResult ViewEntityList(object model)
        {
            return View(EntityListViewPath, model);
        }

        public ViewResult ViewEntityEditor(object model)
        {
            return View(EntityEditorPath, model);
        }
    }
}