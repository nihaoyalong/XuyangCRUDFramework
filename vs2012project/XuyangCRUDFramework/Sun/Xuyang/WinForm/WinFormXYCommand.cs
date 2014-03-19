using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XuyangCRUDFramework.Sun.Xuyang.UI;
using System.Windows.Forms;
using XuyangCRUDFramework.Sun.Xuyang.CRUD;

namespace XuyangCRUDFramework.Sun.Xuyang.WinForm
{
    public class WinFormXYCommand : XuyangCommand
    {
        public WinFormXYCommand(XuyangForm form, IXuyangCRUD crud)
            : base(form, crud)
        {
        }

        protected override bool NotifyUserNotCreating(Entity.XuyangEntity entityC, Entity.XuyangSchoolbag bag)
        {
            MessageBox.Show("请先点击新建按钮，填写好[必填项]后，再点击[保存]。");
            return false;
        }

        protected override bool NotifyUserNotEditing(Entity.XuyangEntity entityU, Entity.XuyangSchoolbag bag)
        {
            MessageBox.Show("请先点击修改按钮，再点击[保存]。");
            return false;
        }

        protected override bool NotifyUserNotNormal(Entity.XuyangEntity entityR, Entity.XuyangSchoolbag bag)
        {
            DialogResult dr = MessageBox.Show("当前数据处于未保存状态，是否确认继续", "注意：",
                                                MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK) return true;
            else return false;
        }
    }
}
