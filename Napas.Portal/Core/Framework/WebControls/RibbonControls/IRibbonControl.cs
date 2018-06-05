using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.SharePoint.WebControls;

namespace NAPAS.Portal.Common.Framework.Core.WebControls
{
    public interface IRibbonControl : IXmlSerializable
    {
        string Id { get; set; }

        IRibbonCommand Command { get; set; }

        IList<IRibbonControl> ChildControls { get; set; }

        int Sequence { get; set; }

        string TemplateAlias { get; set; }

        string LabelText { get; set; }

        XmlNode GetXmlDefinition();
    }
}
