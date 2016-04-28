using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Web.helper
{
    public class ListRequest :List<string>
    {
        public  void AddRequest( string request)
        {
            request = "/#" + request;
            if (this.Count == 2)
            {
                this.Clear();
            }
            this.Add(request);
        }
    }
}