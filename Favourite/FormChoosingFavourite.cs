using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Favourite
{
    public partial class FormChoosingFavourite : Form
    {
        private List<List<FavouriteItem>> favoriteLists;

        private List<FavouriteItem> firstList;
        private List<FavouriteItem> secondList;
        private List<FavouriteItem> currentList;

        private int selectedFirstListIndex;
        private int selectedSecondListIndex;

        private string type;
        public ViewSortedFavouriteForm f2;

        private DirectoryInfo folder;

        public FormChoosingFavourite(string path, string t)
        {
            InitializeComponent();

            favoriteLists = new List<List<FavouriteItem>>();
            currentList = new List<FavouriteItem>();

            readFromFile(path);
            type = t;
            labelMessage.Text = "Which " + type + " Do You Like More?";

            firstList = favoriteLists[0];
            secondList = favoriteLists[1];
            selectedFirstListIndex = 0;
            selectedSecondListIndex = 0;

            redrawPictureBoxesAndLabels();
        }

        #region Needed functions
        public static Image resizeImage(Image myImage, Size size)
        {
            return (Image)(new Bitmap(myImage, size));
        }

        private void readFromFile(string path)
        {
            folder = new DirectoryInfo(path);
            FileInfo[] files = folder.GetFiles("*.jpg");
            try
            {
                files.Union(folder.GetFiles("*.png"));
            }
            catch (Exception)
            {
            }

            for (int i = 0; i < files.Length; i++)
                favoriteLists.Add(new List<FavouriteItem>() { new FavouriteItem { Name = files[i].Name, Img = Image.FromFile(files[i].FullName) } });
        }

        private void redrawPictureBoxesAndLabels()
        {
            pictureBoxForFirstElement.Image = resizeImage(firstList[selectedFirstListIndex].Img, new Size(pictureBoxForFirstElement.Size.Width - 10, pictureBoxForFirstElement.Size.Height - 10));
            labelForFirstPictureBox.Text = firstList[selectedFirstListIndex].Name;
            pictureBoxForSecondElement.Image = resizeImage(secondList[selectedSecondListIndex].Img, new Size(pictureBoxForSecondElement.Size.Width - 10, pictureBoxForSecondElement.Size.Height - 10));
            labelForSecondPictureBox.Text = secondList[selectedSecondListIndex].Name;
        }
        #endregion

        #region Events
        private void pictureBoxForFirstElement_Click(object sender, EventArgs e)
        {
            currentList.Add(firstList[selectedFirstListIndex]);

            bool isFirstListLastElement = selectedFirstListIndex == firstList.Count - 1;

            if (isFirstListLastElement)
            {
                currentList.AddRange(secondList.Skip(selectedSecondListIndex));
                favoriteLists.Add(currentList);

                favoriteLists.Remove(firstList);
                favoriteLists.Remove(secondList);
                currentList = new List<FavouriteItem>();

                if (favoriteLists.Count == 1)
                {
                    f2 = new ViewSortedFavouriteForm(favoriteLists[0], type);
                    f2.Show();
                    this.Hide();
                    return;
                }
                else
                {
                    firstList = favoriteLists[0];
                    secondList = favoriteLists[1];
                    selectedFirstListIndex = 0;
                    selectedSecondListIndex = 0;
                }
            }
            else selectedFirstListIndex++;

            redrawPictureBoxesAndLabels();

            Cursor.Position = this.PointToScreen(new Point(labelVS.Location.X + labelVS.Size.Width / 2, labelVS.Location.Y + labelVS.Size.Height / 2));
        }

        private void pictureBoxForSecondElement_Click(object sender, EventArgs e)
        {
            currentList.Add(secondList[selectedSecondListIndex]);

            bool isSecondListLastElement = selectedSecondListIndex == secondList.Count - 1;

            if (isSecondListLastElement)
            {
                currentList.AddRange(firstList.Skip(selectedFirstListIndex));
                favoriteLists.Add(currentList);

                favoriteLists.Remove(firstList);
                favoriteLists.Remove(secondList);
                currentList = new List<FavouriteItem>();

                if (favoriteLists.Count == 1)
                {
                    f2 = new ViewSortedFavouriteForm(favoriteLists[0], type);
                    f2.Show();
                    this.Hide();
                    return;
                }
                else
                {
                    firstList = favoriteLists[0];
                    secondList = favoriteLists[1];
                    selectedFirstListIndex = 0;
                    selectedSecondListIndex = 0;
                }
            }
            else selectedSecondListIndex++;

            redrawPictureBoxesAndLabels();

            Cursor.Position = this.PointToScreen(new Point(labelVS.Location.X + labelVS.Size.Width / 2, labelVS.Location.Y + labelVS.Size.Height / 2));
        }

        private void FormChoosingFavourite_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxForFirstElement_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxForFirstElement.BackColor = Color.FromArgb(255, 255, 192);
            labelUnderVS.Text = labelForFirstPictureBox.Text;
            pictureBoxForFirstElement.Size = new Size(pictureBoxForFirstElement.Size.Width + 10, pictureBoxForFirstElement.Size.Height + 10);
            pictureBoxForFirstElement.Location = new Point(pictureBoxForFirstElement.Location.X - 10, pictureBoxForFirstElement.Location.Y - 10);
        }

        private void pictureBoxForFirstElement_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxForFirstElement.BackColor = SystemColors.Control;
            labelUnderVS.Text = "";
            pictureBoxForFirstElement.Size = new Size(pictureBoxForFirstElement.Size.Width - 10, pictureBoxForFirstElement.Size.Height - 10);
            pictureBoxForFirstElement.Location = new Point(pictureBoxForFirstElement.Location.X + 10, pictureBoxForFirstElement.Location.Y + 10);
        }

        private void pictureBoxForSecondElement_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxForSecondElement.BackColor = Color.FromArgb(255, 255, 192);
            labelUnderVS.Text = labelForSecondPictureBox.Text;
            pictureBoxForSecondElement.Size = new Size(pictureBoxForSecondElement.Size.Width + 10, pictureBoxForSecondElement.Size.Height + 10);
            pictureBoxForSecondElement.Location = new Point(pictureBoxForSecondElement.Location.X + 10, pictureBoxForSecondElement.Location.Y - 10);
        }

        private void pictureBoxForSecondElement_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxForSecondElement.BackColor = SystemColors.Control;
            labelUnderVS.Text = "";
            pictureBoxForSecondElement.Size = new Size(pictureBoxForSecondElement.Size.Width - 10, pictureBoxForSecondElement.Size.Height - 10);
            pictureBoxForSecondElement.Location = new Point(pictureBoxForSecondElement.Location.X - 10, pictureBoxForSecondElement.Location.Y + 10);
        }
        #endregion
    }
}
