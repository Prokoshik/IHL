#region

using System.Web.Mvc;
using Northwind.Web.Models;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Web;
using System.Web.Routing;
using System.Collections.Generic;
using Northwind.Web.Filters;

#endregion

namespace Northwind.Web.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        public ActionResult Spa()
        {
            return View();
        }

        public ActionResult Index()
        {
           
           var pageContent = LoadXMLData("HighLoadDev.xml");
            IHtmlString str = new HtmlString(pageContent.Text);
            ViewBag.Path = pageContent.PathToImage;
            return View(str);
        }


        public ActionResult Scope()
        {
            var pageContent = LoadXMLData("Scope.xml");
            IHtmlString str = new HtmlString(pageContent.Text);
            ViewBag.Path = pageContent.PathToImage;
            return View(str);

        }
        public ActionResult Client()
        {
            var pageContent = LoadXMLData("Client.xml");
            IHtmlString str = new HtmlString(pageContent.Text);
            ViewBag.Path = pageContent.PathToImage;
            return View(str);

        }
        public ActionResult ClientApplicationDev()
        {
            var pageContent = LoadXMLData("ClientApplicationDev.xml");
            IHtmlString str = new HtmlString(pageContent.Text);
            ViewBag.Path = pageContent.PathToImage;
            return View(str);

        }
        public ActionResult StackTechnology()
        {
            var pageContent = LoadXMLData("StackTechnology.xml");
            IHtmlString str = new HtmlString(pageContent.Text);
            ViewBag.Path = pageContent.PathToImage;
            return View(str);

        }

        private PageContent LoadXMLData(string xnlName)
        {
            String rootPath = Server.MapPath("~");
            var path = rootPath + "Xml\\" + xnlName;
            var pageContent = new PageContent(path);
            return pageContent;
        }

        public ActionResult ChangeCulture(string lang)
        {
            string currentUrl = Request.UrlReferrer.AbsolutePath;
            List<string> culturies = new List<string>() { "ru", "en" };
            if (!culturies.Contains(lang))
            {
                lang = "en";
            }
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
            {
                cookie.Value = lang;
            }
            else
            {

                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(currentUrl);
        }
        

    }
}