using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Finals_Project
{
    class Speech
    {
        private WebBrowser web;



        public WebBrowser Web
        {
            get { return web; }
            set { web = value; }
        }
        public Speech(WebBrowser wb)
        {
            this.Web = wb;
        }

        private async Task SetText(string str)
        {
            HtmlElement e = Web.Document.GetElementById("text");
            e.SetAttribute("value", str);

        }
        private void Pronounce()
        {
            HtmlElement e = Web.Document.GetElementById("playbutton");
            e.InvokeMember("click");
        }


        public async void Speak(string str)
        {
            if (Web.Document != null)
            {
                await SetText(str);
                Pronounce();
            }  
        }
    }
}
