using System.Drawing;

namespace Favourite
{
    public class FavouriteItem
    {
        private string name;
        private Image img;

        public FavouriteItem(string n, Image img)
        {
            name = n.Substring(0, n.Length - 4);
            this.img = img;
        }

        public FavouriteItem()
        {
        }

        public Image Img
        {
            get { return img; }
            set { img = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
