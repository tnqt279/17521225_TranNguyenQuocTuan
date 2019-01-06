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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.DisplayMember = "head";
            dControl.LoadtoCB(comboBox1);
            speech = new Speech(webBrowser1);
            pics = new DictPics(webBrowser2);
        }

        DictControl dControl = new DictControl();

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        #region combobox ctrl

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.DataSource == null)
                return;
            DictData dData= comboBox1.SelectedItem as DictData;
            richTextBox1.Text = dData.Def;
        }

        #endregion


        #region pronounce control
        Speech speech;
        bool isLoading;
        private void ListenButton_Click(object sender, EventArgs e)
        {
            string SelectedString = String.Empty;
            SelectedString = (comboBox1.SelectedItem as DictData).Head;
            
            if (SelectedString != null)
            {
                speech.Speak(SelectedString);
            }
            else
            {
                MessageBox.Show("Can not pronounce!");
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            isLoading = false;
            ChangeLoading();
        }
        private void ChangeLoading()
        {
            this.Enabled = !(isLoading);
        }

        #endregion

        #region search control
        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            int temp = comboBox1.FindString(SearchBar.Text);
            if (temp != -1)
            {
                comboBox1.SelectedIndex = temp;
            }
        }
        private void SearchBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Return))
            {
                var temp = comboBox1.FindString(SearchBar.Text);
                if (temp != -1)
                {
                    comboBox1.SelectedIndex = temp;
                }

            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var temp = comboBox1.FindString(SearchBar.Text);
            if (temp != -1)
            {
                comboBox1.SelectedIndex = temp;
            }

        }
        #endregion

        #region Dict Image control

        DictPics pics;
        bool isLoading2;

        private void ChangeLoading2()
        {
            this.Enabled = !(isLoading2);
        }
        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            isLoading2 = false;
            ChangeLoading2();
        }
        private void ImageButton_Click(object sender, EventArgs e)
        {
            string SelectedWord = String.Empty;
            SelectedWord = (comboBox1.SelectedItem as DictData).Head;
            if (SelectedWord != null)
            {
                pics.Illustrate(SelectedWord);
            }
            else
            {
                MessageBox.Show("Image Not Found!");
            }
        }



        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dControl.Serialize();
        }
    }
}
