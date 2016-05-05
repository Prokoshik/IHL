#region

using System.Web.Mvc;
using Northwind.Web.Models;
using System;
using System.Web;
using System.Collections.Generic;
using Northwind.Web.Filters;
using System.Threading;
using System.Globalization;
using Northwind.Web.helper;

#endregion

namespace Northwind.Web.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        public static ListRequest listRequest = new ListRequest();
      
        public ActionResult Spa()
        {
            return View();
        }

        public ActionResult Index()
        {
            IHtmlString strhtml;
            var pageContent = LoadXMLData("HighLoadDev.xml");
           
            var culture = HttpContext.Request.Cookies["lang"].Value;
            if (string.Compare(culture, "ru") == 0)
            {
                strhtml = new HtmlString(pageContent.RUText);


            }
            else
            {
                strhtml = new HtmlString(pageContent.ENText);
            }

            

            return View(strhtml);
        }


        public ActionResult Scope()
        {
            var pageContent = LoadXMLData("Scope.xml");
          
            var culture = HttpContext.Request.Cookies["lang"].Value;
            if (String.Compare(culture, "ru") == 0)
            {
                IHtmlString str = new HtmlString(pageContent.RUText);
                return View(str);
            }
            else
            {
                IHtmlString str = new HtmlString(pageContent.ENText);
                return View(str);
            }

        }
        public ActionResult Client()
        {
            var pageContent = LoadXMLData("Client.xml");
         
            var culture = HttpContext.Request.Cookies["lang"].Value;
            if (String.Compare(culture, "ru") == 0)
            {
                IHtmlString str = new HtmlString(pageContent.RUText);
                return View(str);
            }
            else
            {
                IHtmlString str = new HtmlString(pageContent.ENText);
                return View(str);
            }
        }
        public ActionResult ClientApplicationDev()
        {
            
            var pageContent = LoadXMLData("ClientApplicationDev.xml");
           
            var culture = HttpContext.Request.Cookies["lang"].Value;
            if (String.Compare(culture, "ru") == 0)
            {
                IHtmlString str = new HtmlString(pageContent.RUText);
                return View(str);
            }
            else
            {
                IHtmlString str = new HtmlString(pageContent.ENText);
                return View(str);
            }

        }
        public ActionResult StackTechnology()
        {
            var pageContent = LoadXMLData("StackTechnology.xml");
           
            var culture = HttpContext.Request.Cookies["lang"].Value;
            if (String.Compare(culture, "ru") == 0)
            {
                IHtmlString str = new HtmlString(pageContent.RUText);
                return View(str);
            }
            else
            {
                IHtmlString str = new HtmlString(pageContent.ENText);
                return View(str);
            }

        }

        private PageContent LoadXMLData(string xnlName)
        {
            var q = Request.Url.AbsolutePath.ToString();
            listRequest.AddRequest(q);
            String rootPath = Server.MapPath("~");
            var path = rootPath + "Xml\\" + xnlName;
            var pageContent = new PageContent(path);
            return pageContent;

           
        }

        public ActionResult ChangeCulture(string lang)
        {

            var currentUrl = listRequest[listRequest.Count - 1];
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
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);
            return Redirect(currentUrl);
        }


    }
}