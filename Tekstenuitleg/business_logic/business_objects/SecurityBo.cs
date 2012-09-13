using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CursusIndex.business_logic.business_objects;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace Tekstenuitleg.business_logic.business_objects
{
    public class SecurityBo : ISecurityBo
    {
        private IGenericNodeBo nodeBo = BusinessFactory.GetGenericNodeBo();

        public List<string> GetBlockedIps()
        {
            var ipList = new List<string>();
            INode settingsNode = nodeBo.FindDescendants(new Node(-1), new List<string>() { "Settings" }).FirstOrDefault();
            if (settingsNode != null)
            {
                IProperty property = settingsNode.GetProperty("blockedIPs");

                if (property != null)
                {
                    string ipString = property.Value;
                    string[] ips = Regex.Split(ipString, "\n");
                    

                    foreach (string ip in ips)
                    {
                        if (ip.Trim().Length > 0)
                        {
                            ipList.Add(ip);    
                        }
                    }
                }
            }
            return ipList;
        }
    }
}