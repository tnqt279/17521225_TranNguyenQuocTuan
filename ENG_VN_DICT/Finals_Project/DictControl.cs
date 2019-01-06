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
using System.Xml.Serialization;

namespace Finals_Project
{
    class DictControl
    {
        private DictItem wordCollection;

        private DictItem WordCollection
        {
            get { return wordCollection; }
            set { wordCollection = value; }
        }

        
        string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\dict.xml");
        public DictControl()
        {
            WordCollection = (DictItem)DeserializeFromXML(filepath);
        }
        
        public void LoadtoCB(ComboBox cb)
        {
            cb.DataSource = WordCollection.DWords;
        }



        public void Serialize()
        {
            SerializeToXML(WordCollection, filepath);
        }

        private object DeserializeFromXML(string path)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xmlsrl = new XmlSerializer(typeof(DictItem));
            object obj = xmlsrl.Deserialize(fs);
            fs.Close();
            return obj;
        }

        private void SerializeToXML(object obj, string path)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xmlsrl = new XmlSerializer(typeof(DictItem));
            xmlsrl.Serialize(fs, obj);
            fs.Close();
        }
    }
}
