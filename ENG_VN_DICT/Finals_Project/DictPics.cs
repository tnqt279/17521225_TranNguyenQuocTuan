using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals_Project
{
    class DictPics
    {
        private WebBrowser web;

        public WebBrowser Web
        {
            get { return web; }
            set { web = value; }
        }

        public DictPics(WebBrowser wb)
        {
            this.Web = wb;
        }

        private async Task Search(string str)
        {
            HtmlElementCollection collection = Web.Document.GetElementsByTagName("input").GetElementsByName("q");
            collection[0].SetAttribute("value", str);
            HtmlElementCollection collection2 = Web.Document.GetElementsByTagName("input");
            foreach (HtmlElement e in collection2)
            {
                if (e.GetAttribute("className") == "loupe")
                {
                    e.InvokeMember("click");
                }
            }
        }

        public async void Illustrate(string str)
        {
            if (Web.Document != null)
                await Search(str);
        }

    }
}
