
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using System;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Text;

namespace HNUE_THACSY
{
    public class BaseController: PortalModuleBase
    {
        public virtual string BuildUrl(string control, params string[] ps)
        {
            var prm = ps.ToList();
            prm.Add("moduleId=" + ModuleId);
            if (!string.IsNullOrEmpty(control))
            {
                prm.Add("control=" + control);
            }
            return Globals.NavigateURL(TabId, "", prm.ToArray());
        }   
      //  public SVDataContext DataContext { get; private set; }
    }
}