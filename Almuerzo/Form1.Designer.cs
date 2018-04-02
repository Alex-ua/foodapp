namespace Almuerzo
{
  partial class Form1
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
      this.GetRandomFoodBtn = new System.Windows.Forms.Button();
      this.SetInDocButton = new System.Windows.Forms.Button();
      this.ClearInDocButton = new System.Windows.Forms.Button();
      this.foodDataGridView = new System.Windows.Forms.DataGridView();
      this.daysListBox = new System.Windows.Forms.CheckedListBox();
      this.nameTbox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.lnkPredefined = new System.Windows.Forms.LinkLabel();
      this.orderFoodDocLink = new System.Windows.Forms.LinkLabel();
      ((System.ComponentModel.ISupportInitialize)(this.foodDataGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // GetRandomFoodBtn
      // 
      this.GetRandomFoodBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.GetRandomFoodBtn.Location = new System.Drawing.Point(449, 25);
      this.GetRandomFoodBtn.Name = "GetRandomFoodBtn";
      this.GetRandomFoodBtn.Size = new System.Drawing.Size(75, 23);
      this.GetRandomFoodBtn.TabIndex = 1;
      this.GetRandomFoodBtn.Text = "Reshuffle";
      this.GetRandomFoodBtn.UseVisualStyleBackColor = true;
      this.GetRandomFoodBtn.Click += new System.EventHandler(this.GetRandomFoodBtn_Click);
      // 
      // SetInDocButton
      // 
      this.SetInDocButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.SetInDocButton.Enabled = false;
      this.SetInDocButton.Location = new System.Drawing.Point(449, 54);
      this.SetInDocButton.Name = "SetInDocButton";
      this.SetInDocButton.Size = new System.Drawing.Size(75, 23);
      this.SetInDocButton.TabIndex = 2;
      this.SetInDocButton.Text = "Save";
      this.SetInDocButton.UseVisualStyleBackColor = true;
      this.SetInDocButton.Click += new System.EventHandler(this.SetInDocButton_Click);
      // 
      // ClearInDocButton
      // 
      this.ClearInDocButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ClearInDocButton.Location = new System.Drawing.Point(449, 83);
      this.ClearInDocButton.Name = "ClearInDocButton";
      this.ClearInDocButton.Size = new System.Drawing.Size(75, 23);
      this.ClearInDocButton.TabIndex = 3;
      this.ClearInDocButton.Text = "Clear in Doc";
      this.ClearInDocButton.UseVisualStyleBackColor = true;
      this.ClearInDocButton.Click += new System.EventHandler(this.ClearInDocButton_Click);
      // 
      // foodDataGridView
      // 
      this.foodDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.foodDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.foodDataGridView.Location = new System.Drawing.Point(24, 25);
      this.foodDataGridView.Name = "foodDataGridView";
      this.foodDataGridView.Size = new System.Drawing.Size(406, 295);
      this.foodDataGridView.TabIndex = 4;
      // 
      // daysListBox
      // 
      this.daysListBox.FormattingEnabled = true;
      this.daysListBox.Location = new System.Drawing.Point(449, 112);
      this.daysListBox.Name = "daysListBox";
      this.daysListBox.Size = new System.Drawing.Size(75, 214);
      this.daysListBox.TabIndex = 5;
      // 
      // nameTbox
      // 
      this.nameTbox.Location = new System.Drawing.Point(97, 332);
      this.nameTbox.Name = "nameTbox";
      this.nameTbox.Size = new System.Drawing.Size(100, 20);
      this.nameTbox.TabIndex = 6;
      this.nameTbox.TextChanged += new System.EventHandler(this.nameTbox_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(24, 335);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(67, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "Name in doc";
      // 
      // lnkPredefined
      // 
      this.lnkPredefined.AutoSize = true;
      this.lnkPredefined.Location = new System.Drawing.Point(217, 335);
      this.lnkPredefined.Name = "lnkPredefined";
      this.lnkPredefined.Size = new System.Drawing.Size(85, 13);
      this.lnkPredefined.TabIndex = 8;
      this.lnkPredefined.TabStop = true;
      this.lnkPredefined.Text = "Predefined Food";
      this.lnkPredefined.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPredefined_LinkClicked);
      // 
      // orderFoodDocLink
      // 
      this.orderFoodDocLink.AutoSize = true;
      this.orderFoodDocLink.Location = new System.Drawing.Point(317, 335);
      this.orderFoodDocLink.Name = "orderFoodDocLink";
      this.orderFoodDocLink.Size = new System.Drawing.Size(83, 13);
      this.orderFoodDocLink.TabIndex = 9;
      this.orderFoodDocLink.TabStop = true;
      this.orderFoodDocLink.Text = "Order Food Doc";
      this.orderFoodDocLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.orderFoodDocLink_LinkClicked);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(540, 361);
      this.Controls.Add(this.orderFoodDocLink);
      this.Controls.Add(this.lnkPredefined);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.nameTbox);
      this.Controls.Add(this.daysListBox);
      this.Controls.Add(this.foodDataGridView);
      this.Controls.Add(this.ClearInDocButton);
      this.Controls.Add(this.SetInDocButton);
      this.Controls.Add(this.GetRandomFoodBtn);
      this.MinimumSize = new System.Drawing.Size(550, 400);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.foodDataGridView)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button GetRandomFoodBtn;
    private System.Windows.Forms.Button SetInDocButton;
    private System.Windows.Forms.Button ClearInDocButton;
    private System.Windows.Forms.DataGridView foodDataGridView;
    private System.Windows.Forms.CheckedListBox daysListBox;
    private System.Windows.Forms.TextBox nameTbox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.LinkLabel lnkPredefined;
    private System.Windows.Forms.LinkLabel orderFoodDocLink;
  }
}

