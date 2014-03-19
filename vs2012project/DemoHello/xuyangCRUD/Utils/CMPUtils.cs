/***********************************************************************
 * Module:  AppExUtility.Utility.CMPUtils.cs
 * Author:  sunyalong
 * Created: 2012/11/20 17:20:23
 * Modify:  2012/11/20 17:20:23
 * Description: 
 ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xuyangCRUD.Utils
{
    public class CMPUtils
    {
        public static bool IsDesignMode()
        {
            bool result = true;
            string procName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            if (!procName.Equals("devenv")) result = false;

            return result;
        }
    }
}