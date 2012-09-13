using umbraco.interfaces;

namespace CursusIndex.business_logic.entitities
{
    public class ThemeListItem
    {
        public string Url;
        public string Name;
        public bool Selected;


        public ThemeListItem(INode parent, INode theme, INode currentlySelectedTheme)
        {
            Url = parent.NiceUrl + "/" + theme.UrlName;
            Name = theme.Name;
            Selected = currentlySelectedTheme != null && theme.Id.Equals(currentlySelectedTheme.Id);
        } 
    }
}