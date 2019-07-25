namespace Favourite
{
    partial class OpenSortedFavouriteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenSortedFavouriteForm));
            this.textBoxBrowseSortedList = new System.Windows.Forms.TextBox();
            this.textBoxBrowseFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowseSortedList = new System.Windows.Forms.Button();
            this.buttonBrowseFolder = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // textBoxBrowseSortedList
            // 
            this.textBoxBrowseSortedList.Location = new System.Drawing.Point(23, 38);
            this.textBoxBrowseSortedList.Name = "textBoxBrowseSortedList";
            this.textBoxBrowseSortedList.Size = new System.Drawing.Size(195, 20);
            this.textBoxBrowseSortedList.TabIndex = 0;
            // 
            // textBoxBrowseFolder
            // 
            this.textBoxBrowseFolder.Location = new System.Drawing.Point(23, 113);
            this.textBoxBrowseFolder.Name = "textBoxBrowseFolder";
            this.textBoxBrowseFolder.Size = new System.Drawing.Size(195, 20);
            this.textBoxBrowseFolder.TabIndex = 1;
            // 
            // buttonBrowseSortedList
            // 
            this.buttonBrowseSortedList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowseSortedList.ForeColor = System.Drawing.Color.Blue;
            this.buttonBrowseSortedList.Location = new System.Drawing.Point(219, 35);
            this.buttonBrowseSortedList.Name = "buttonBrowseSortedList";
            this.buttonBrowseSortedList.Size = new System.Drawing.Size(132, 25);
            this.buttonBrowseSortedList.TabIndex = 2;
            this.buttonBrowseSortedList.Text = "Browse Sorted List";
            this.buttonBrowseSortedList.UseVisualStyleBackColor = true;
            this.buttonBrowseSortedList.Click += new System.EventHandler(this.buttonBrowseSortedList_Click);
            // 
            // buttonBrowseFolder
            // 
            this.buttonBrowseFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowseFolder.ForeColor = System.Drawing.Color.Blue;
            this.buttonBrowseFolder.Location = new System.Drawing.Point(219, 110);
            this.buttonBrowseFolder.Name = "buttonBrowseFolder";
            this.buttonBrowseFolder.Size = new System.Drawing.Size(132, 25);
            this.buttonBrowseFolder.TabIndex = 3;
            this.buttonBrowseFolder.Text = "Browse Folder";
            this.buttonBrowseFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseFolder.Click += new System.EventHandler(this.buttonBrowseFolder_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.Blue;
            this.buttonCancel.Location = new System.Drawing.Point(23, 173);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(132, 25);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.ForeColor = System.Drawing.Color.Blue;
            this.buttonNext.Location = new System.Drawing.Point(195, 173);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(132, 25);
            this.buttonNext.TabIndex = 6;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // OpenSortedFavouriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 210);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonBrowseFolder);
            this.Controls.Add(this.buttonBrowseSortedList);
            this.Controls.Add(this.textBoxBrowseFolder);
            this.Controls.Add(this.textBoxBrowseSortedList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OpenSortedFavouriteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Sorted Favourite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBrowseSortedList;
        private System.Windows.Forms.TextBox textBoxBrowseFolder;
        private System.Windows.Forms.Button buttonBrowseSortedList;
        private System.Windows.Forms.Button buttonBrowseFolder;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}