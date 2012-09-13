using System.Collections.Generic;
using umbraco.interfaces;

namespace CursusIndex.util.ordering
{
    public class HomepageArticleSorter : IComparer<INode>
    {
        public int Compare(INode x, INode y)
        {
            int xPos = -1;
            int yPos = -1;

            string xPosString = x.GetProperty("homepagePosition").Value;
            string yPosString = y.GetProperty("homepagePosition").Value;

            int.TryParse(xPosString, out xPos);
            int.TryParse(yPosString, out yPos);

            return xPos - yPos;

        }
    }
}