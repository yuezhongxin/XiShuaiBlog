using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XQH.EasyUi.Database;
using XQH.EasyUi.Database.EasyUiDataSetTableAdapters;
using XQH.EasyUi.Entity;

namespace XQH.EasyUi.Access
{
    /// <summary>
    /// 联结查询操作
    /// </summary>
    public class JoinQueryAccess
    {
        JoinQueryTable adp = new JoinQueryTable();
        private static FunctionItemAccess accessInstance = null;

        public static FunctionItemAccess GetInstance()
        {
            if (accessInstance == null)
            {
                accessInstance = new FunctionItemAccess();
            }

            return accessInstance;
        }
    }
}
