using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.Filters
{
    public class CultureAttribute : FilterAttribute, IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {       
            

            string cultureName = null;

            HttpCookie cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else
            {
                var dic = filterContext.HttpContext.Request.UserLanguages                    
                    .Where(str => str.Contains("q="))
                    .Select(str => str.Split(';'))
                    .ToDictionary(x => x[0], x => x[1].Replace("q=", string.Empty));
                var maxValue = dic.Max(kp => kp.Value);
                cultureName = dic.FirstOrDefault(kp => kp.Value == maxValue).Key;                
                var cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = cultureName;
                cookie.Expires = DateTime.Now.AddYears(1);
                filterContext.HttpContext.Response.Cookies.Add(cookie);
            }


            List<string> cultures = new List<string>() { "ru", "en" };
            if (!cultures.Contains(cultureName))
            {
                cultureName = "en";
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }       
    }}