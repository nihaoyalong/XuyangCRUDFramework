using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XuyangCRUDFramework.Sun.Xuyang.Entity;

namespace xuyangCRUD
{
    public class HelloEntity : XuyangEntity
    {
        private string hello;

        public string Hello
        {
            get { return hello; }
            set { hello = value; }
        }
        private string world;

        public string World
        {
            get { return world; }
            set { world = value; }
        }
    }
}
