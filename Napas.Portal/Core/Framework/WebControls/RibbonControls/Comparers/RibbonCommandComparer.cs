﻿using System.Collections.Generic;
using Microsoft.SharePoint.WebControls;

namespace NAPAS.Portal.Common.Framework.Core.WebControls
{
    public class RibbonCommandComparer : IEqualityComparer<IRibbonCommand>
    {
        #region IEqualityComparer<IRibbonCommand> Members

        public bool Equals(IRibbonCommand x, IRibbonCommand y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            //Check whether the ribbon command id are equal.
            return x.Id == y.Id;
        }

        public int GetHashCode(IRibbonCommand obj)
        {
            //Check whether the object is null
            return ReferenceEquals(obj, null) ? 0 : obj.Id.GetHashCode();
        }

        #endregion
    }
}