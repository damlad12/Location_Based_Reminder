namespace Remind_Location
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLatitude = new TextBox();
            txtLongitude = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnSave = new Button();
            listView1 = new ListView();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // txtLatitude
            // 
            txtLatitude.Location = new Point(123, 95);
            txtLatitude.Name = "txtLatitude";
            txtLatitude.Size = new Size(150, 31);
            txtLatitude.TabIndex = 1;
            // 
            // txtLongitude
            // 
            txtLongitude.Location = new Point(345, 95);
            txtLongitude.Name = "txtLongitude";
            txtLongitude.Size = new Size(150, 31);
            txtLongitude.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(374, 58);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 3;
            label1.Text = "longitude";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(161, 58);
            label2.Name = "label2";
            label2.Size = new Size(71, 25);
            label2.TabIndex = 4;
            label2.Text = "latitude";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(617, 92);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 5;
            btnSave.Text = "save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // listView1
            // 
            listView1.FullRowSelect = true;
            listView1.Location = new Point(62, 156);
            listView1.Name = "listView1";
            listView1.Size = new Size(975, 422);
            listView1.TabIndex = 6;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.MouseClick += listView1_MouseClick;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(807, 92);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1238, 646);
            Controls.Add(btnUpdate);
            Controls.Add(listView1);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtLongitude);
            Controls.Add(txtLatitude);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtLatitude;
        private TextBox txtLongitude;
        private Label label1;
        private Label label2;
        private Button btnSave;
        private ListView listView1;
        private Button btnUpdate;
    }
}