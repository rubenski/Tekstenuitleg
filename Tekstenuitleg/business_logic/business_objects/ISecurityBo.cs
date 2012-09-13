using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tekstenuitleg.business_logic.business_objects
{
    public interface ISecurityBo
    {
        List<string> GetBlockedIps();
    }
}
