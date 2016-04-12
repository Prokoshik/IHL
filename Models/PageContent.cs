using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Northwind.Web.Models
{
    [Serializable]
    public class PageContent
    {
        public string PathToImage;
        public string Text;
        public PageContent() { }
        public PageContent(string pathToXml)
        {
            PageContent pageContent;

            var logsSerializer = new XmlSerializer(typeof(PageContent));

            using (var logReader = new StreamReader(pathToXml))
            {
                pageContent = logsSerializer.Deserialize(logReader) as PageContent;  
                PathToImage = pageContent.PathToImage;
                Text = pageContent.Text;
            }



        }
    }
}


