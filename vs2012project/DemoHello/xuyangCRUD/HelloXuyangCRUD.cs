using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XuyangCRUDFramework.Sun.Xuyang.CRUD;
using System.Windows.Forms;
using XuyangCRUDFramework.Sun.Xuyang.Entity;

namespace xuyangCRUD
{
    public class HelloXuyangCRUD : IXuyangCRUD
    {
        public XuyangEntity XYCRUDCreate(XuyangEntity entityC, XuyangSchoolbag bag)
        {
            MessageBox.Show("新建成功。");
            return new HelloEntity();
        }

        public List<XuyangEntity> XYCRUDRetrieve(XuyangEntity entityR, XuyangSchoolbag bag)
        {
            MessageBox.Show("查询成功。");
            entityR = entityR as HelloEntity;
            List<XuyangEntity> entities = new List<XuyangEntity>() { entityR };
            return entities;
        }

        public XuyangEntity XYCRUDUpdate(XuyangEntity entityU, XuyangSchoolbag bag)
        {
            MessageBox.Show("更新成功。");
            return new HelloEntity();
        }

        public XuyangEntity XYCRUDDelete(XuyangEntity entityD, XuyangSchoolbag bag)
        {
            MessageBox.Show("删除成功。");
            return entityD;
        }
    }
}
