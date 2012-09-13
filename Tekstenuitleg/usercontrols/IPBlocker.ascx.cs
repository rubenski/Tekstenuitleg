using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CursusIndex.business_logic.business_objects;
using CursusIndex.util;
using Tekstenuitleg.business_logic.business_objects;
using umbraco.BusinessLogic;
using umbraco.NodeFactory;
using umbraco.cms.businesslogic.web;
using umbraco.interfaces;
using Property = umbraco.cms.businesslogic.property.Property;

namespace Tekstenuitleg.usercontrols
{
    public partial class IPBlocker : System.Web.UI.UserControl
    {
        private IGenericNodeBo nodeBo = BusinessFactory.GetGenericNodeBo();

        protected void Page_Load(object sender, EventArgs e)
        {
            string userIp = Request.UserHostAddress;

            INode settingsNode = nodeBo.FindDescendants(new Node(-1), new List<string>() { "Settings" }).FirstOrDefault();
            Document settings = new Document(settingsNode.Id);
            Property property = settings.getProperty("blockedIPs");
            

            if (property != null)
            {
                string ipString = property.Value.ToString();
                string[] ips = Regex.Split(ipString, "\n");
                var ipList = new List<string>();

                foreach (var ip in ips)
                {
                    if (ip.Trim().Length > 0)
                    {
                        ipList.Add(ip);    
                    }
                }

                if (!ips.Contains(userIp))
                {
                    ipList.Add(userIp);
                    string newIps = "";
                    foreach (string ip in ipList)
                    {
                        newIps += ip + "\n";
                    }

                    property.Value = newIps;
                    settings.Save();
                    settings.Publish(new User(5));
                    umbraco.library.UpdateDocumentCache(settings.Id);
                    
                }
            } 
        }
    }
}