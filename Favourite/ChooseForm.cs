using System;
using System.IO;
using System.Windows.Forms;

namespace Favourite
{
    public partial class ChooseForm : Form
    {
        private string path;
        private string type;

        public FormChoosingFavourite f1;

        public ChooseForm()
        {
            InitializeComponent();
            checkedListBoxType.CheckOnClick = true;
            checkedListBoxType.Items.Add("Actress", true);
            checkedListBoxType.Items.Add("Actor", false);
            checkedListBoxType.Items.Add("Movie", false);
            toolTip1.SetToolTip(this.textBoxAdd, "After Typing Click On Add or Press Enter");
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        #region Events
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo folder = new DirectoryInfo(path);
                if (checkedListBoxType.CheckedItems.Count == 0)
                    throw new Exception();
                f1 = new FormChoosingFavourite(path, type);
                f1.Show();
                this.Hide();
            }
            catch (ArgumentException)
            {
                errorProvider1.SetError(textBox1, "The Path is Incorrect");
            }
            catch (PathTooLongException)
            {
                errorProvider1.SetError(textBox1, "The Path is Incorrect");
            }
            catch (Exception)
            {
                if (checkedListBoxType.CheckedItems.Count == 0)
                    errorProvider1.SetError(checkedListBoxType, "Check One Of This List");
            }
        }

        private void buttonBrowseFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            path = folderBrowserDialog1.SelectedPath;
            textBox1.Text = path;
            if (checkedListBoxType.CheckedItems.Count != 0)
                button1.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxAdd.Enabled == false)
            {
                textBoxAdd.Enabled = true;
                textBoxAdd.Visible = true;
            }
            else if (textBoxAdd.Text != "")
                checkedListBoxType.Items.Add(textBoxAdd.Text, true);
            else toolTip1.SetToolTip(this.buttonAdd, "Please Enter What To Add");
        }

        private void checkedListBoxType_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBoxType.Items.Count; ++i)
                if (i != e.Index) checkedListBoxType.SetItemChecked(i, false);
            if (textBox1.Text != "")
                button1.Enabled = true;

            var checkedListBox = (CheckedListBox)sender;
            type = checkedListBox.Items[e.Index].ToString();
        }

        private void textBoxAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
                buttonAdd_Click(sender, e);
        }
        #endregion
    }
}
