using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xuyangCRUD.Utils;
using XuyangCRUDFramework.Sun.Xuyang.UI;
using XuyangCRUDFramework.Sun.Xuyang.WinForm;

namespace xuyangCRUD
{
    public partial class Form1 : XuyangForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private WinFormXYCommand xYCommand;

        # region 事件处理

        private void Form1_Load(object sender, EventArgs e)
        {
            xYCommand = new WinFormXYCommand(this, new HelloXuyangCRUD());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HelloEntity helloC = new HelloEntity();
            helloC.Hello = this.txtHello.Text.ToString();

            this.xYCommand.Create(helloC, new HelloBag());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HelloEntity helloC = new HelloEntity();
            helloC.Hello = this.txtHello.Text.ToString();

            this.xYCommand.Retrieve(helloC, new HelloBag());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HelloEntity helloC = new HelloEntity();
            helloC.Hello = this.txtHello.Text.ToString();

            this.xYCommand.Update(helloC, new HelloBag());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HelloEntity helloC = new HelloEntity();
            helloC.Hello = this.txtHello.Text.ToString();

            this.xYCommand.Delete(helloC, new HelloBag());
        }

        # endregion

        # region 旭阳CRUD界面框架

        public override bool XYRequiredFullfilled()
        {
            if ("".Equals(this.txtHello.Text.ToString())) return false;
            else return true;
        }

        public override void XYSetCurrentRow(XuyangCRUDFramework.Sun.Xuyang.Entity.XuyangEntity entity)
        {
        }

        public override void XYSetXuyangLocked(bool isLock)
        {
            this.txtHello.Enabled = !isLock;
        }

        # endregion

        private void button5_Click(object sender, EventArgs e)
        {
            this.xYCommand.StartCreate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.xYCommand.StartEdit();
        }
    }
}
