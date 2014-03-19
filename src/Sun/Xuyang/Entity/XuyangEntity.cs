using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XuyangCRUDFramework.Sun.Xuyang.Entity
{
    [Serializable]
    public class XuyangEntity
    {
        private int xYID;

        /// <summary>
        /// 旭阳ID，不可重复
        /// </summary>
        public int XYID
        {
            get { return xYID; }
            set { xYID = value; }
        }

    }
}
