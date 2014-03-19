using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XuyangCRUDFramework.Sun.Xuyang.Entity;

namespace xuyangCRUD
{
    public class HelloBag : XuyangSchoolbag
    {
        private string dbschema;

        public string Dbschema
        {
            get { return dbschema; }
            set { dbschema = value; }
        }
    }
}
