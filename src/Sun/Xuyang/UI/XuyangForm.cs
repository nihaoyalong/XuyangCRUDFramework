using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XuyangCRUDFramework.Sun.Xuyang.Entity;

namespace XuyangCRUDFramework.Sun.Xuyang.UI
{
    public partial class XuyangForm : Form
    {
        public XuyangForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置所有可编辑窗体控件为锁定/非锁定
        /// </summary>
        /// <param name="isLock">是否锁定</param>
        virtual public void XYSetXuyangLocked(bool isLock) { }

        /// <summary>
        /// 设置可编辑窗体控件列表选定列
        /// </summary>
        /// <param name="entity">实体对象</param>
        virtual public void XYSetCurrentRow(XuyangEntity entity) { }

        /// <summary>
        /// 所有必填项都已经填写完成
        /// </summary>
        /// <returns>是否已经完成</returns>
        virtual public bool XYRequiredFullfilled() { return true; }
    }
}
