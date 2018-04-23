using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Control popupControl;

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Console.WriteLine(e.Link.LinkedObject);
            if (e.Link.LinkedObject == popupMenu1)
                MessageBox.Show(string.Format("The context menu was invoked for '{0}'.", popupControl));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ribbonControl1.Manager.QueryShowPopupMenu += ShowPopupMenuHandler;
        }        

        private void ShowPopupMenuHandler(object sender, QueryShowPopupMenuEventArgs e)
        {
            Console.WriteLine(e.Control);
            popupControl = e.Control;
        }

        private void popupMenu1_CloseUp(object sender, EventArgs e)
        {
            popupControl = null;
        }
    }
}