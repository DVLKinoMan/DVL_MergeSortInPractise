using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Favourite
{
    public partial class ViewSortedFavouriteForm : Form
    {
        private List<FavouriteItem> favourites;
        private string type;

        public List<FavouriteItem> Favourites
        {
            get
            {
                return favourites;
            }

            set
            {
                favourites = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public ViewSortedFavouriteForm(List<FavouriteItem> a, string t)
        {
            InitializeComponent();

            Type = t;
            label1.Text = "Your Sorted Favourite " + t + "es:";

            Favourites = new List<FavouriteItem>();
            Favourites = a;
            paintFavourites();
        }

        private void paintFavourites()
        {
            int y = 122;
            for (int i = 0; i < Favourites.Count; i++)
            {
                PictureBox k = new PictureBox();
                k.Name = "pictureBox" + (i + 2).ToString();
                k.Location = new Point(104, y);
                k.Size = new Size(99, 125);
                k.Image = FormChoosingFavourite.resizeImage(Favourites[i].Img, new Size(k.Size.Width, k.Size.Height));
                this.Controls.Add(k);

                Label l = new Label();
                l.Name = "label" + (i + 2).ToString();
                l.Location = new Point(250, y);
                l.Font = label1.Font;// new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular);
                l.ForeColor = SystemColors.ButtonHighlight;
                l.AutoSize = true;
                l.Text = (i + 1).ToString() + ") " + Favourites[i].Name;
                this.Controls.Add(l);
                y += 150;
            }
            Label la = new Label();
            la.Name = "label" + (Favourites.Count + 1).ToString();
            la.Text = "";
            la.Location = new Point(1, y += 70);
            this.Controls.Add(la);
        }

        #region Events
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSaveList_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName);
                file.WriteLine(Type);
                for (int i = 0; i < Favourites.Count; i++)
                {
                    file.WriteLine(Favourites[i].Name);
                }

                file.Close();
            }
        }

        private void buttonOpenOtherList_Click(object sender, EventArgs e)
        {
            OpenSortedFavouriteForm f1 = new OpenSortedFavouriteForm();
            if (f1.ShowDialog() == DialogResult.OK)
            {
                Favourites = f1.Favourites;
                Type = f1.Type;
                redrawView();
            }
        }

        private void ViewSortedFavouriteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void redrawView()
        {
            label1.Text = "Your Sorted Favourite " + Type + "es:";

            foreach (var pb in this.Controls.OfType<PictureBox>())
                this.Controls.Remove(pb);

            foreach (var pb in this.Controls.OfType<Label>())
                if (pb != label1)
                    this.Controls.Remove(pb);

            paintFavourites();
        }
        #endregion
    }
}
