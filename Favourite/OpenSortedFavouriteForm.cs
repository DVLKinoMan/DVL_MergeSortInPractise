using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Favourite
{
    public partial class OpenSortedFavouriteForm : Form
    {
        private string folderBrowserPath;
        private string sortedListPath;

        private Dictionary<string, FavouriteItem> favouritesDic;
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

        public OpenSortedFavouriteForm()
        {
            InitializeComponent();

            buttonNext.Enabled = false;
        }

        private void checkNextVisibility()
        {
            if (textBoxBrowseSortedList.Text != string.Empty && textBoxBrowseFolder.Text != string.Empty)
                buttonNext.Enabled = true;
            else buttonNext.Enabled = false;
        }

        #region Events
        private void buttonBrowseFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            folderBrowserPath = folderBrowserDialog1.SelectedPath;
            textBoxBrowseFolder.Text = folderBrowserPath;
            checkNextVisibility();
        }

        private void buttonBrowseSortedList_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;

            openFileDialog1.ShowDialog();

            sortedListPath = openFileDialog1.FileName;

            textBoxBrowseSortedList.Text = sortedListPath;
            checkNextVisibility();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            //Read Images
            var folder = new DirectoryInfo(folderBrowserPath);
            FileInfo[] files = folder.GetFiles("*.jpg");
            try
            {
                files.Union(folder.GetFiles("*.png"));
            }
            catch (Exception)
            {
            }

            favouritesDic = new Dictionary<string, FavouriteItem>();

            for (int i = 0; i < files.Length; i++)
                favouritesDic.Add(files[i].Name, new FavouriteItem { Name = files[i].Name, Img = Image.FromFile(files[i].FullName) });

            //ReadList
            Favourites = new List<FavouriteItem>();
            string[] lines = File.ReadAllLines(sortedListPath);
            Type = lines[0];
            for (int i = 1; i < lines.Length; i++)
                Favourites.Add(favouritesDic[lines[i]]);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}
