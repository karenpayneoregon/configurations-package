namespace SortableBindingListExample;

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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        CustomersBindingNavigator = new NavigatorLibrary.CoreBindingNavigator();
        CustomersDataGridView = new DataGridView();
        Column1 = new DataGridViewTextBoxColumn();
        Column2 = new DataGridViewTextBoxColumn();
        Column5 = new DataGridViewTextBoxColumn();
        Column3 = new DataGridViewTextBoxColumn();
        Column4 = new DataGridViewTextBoxColumn();
        CustomersBindingNavigator.BeginInit();
        ((System.ComponentModel.ISupportInitialize)CustomersDataGridView).BeginInit();
        SuspendLayout();
        // 
        // CustomersBindingNavigator
        // 
        CustomersBindingNavigator.ImageScalingSize = new Size(20, 20);
        CustomersBindingNavigator.Location = new Point(0, 0);
        CustomersBindingNavigator.Name = "CustomersBindingNavigator";
        CustomersBindingNavigator.Size = new Size(829, 27);
        CustomersBindingNavigator.TabIndex = 0;
        CustomersBindingNavigator.Text = "coreBindingNavigator1";
        // 
        // CustomersDataGridView
        // 
        CustomersDataGridView.AllowUserToAddRows = false;
        CustomersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        CustomersDataGridView.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column5, Column3, Column4 });
        CustomersDataGridView.Location = new Point(12, 47);
        CustomersDataGridView.Name = "CustomersDataGridView";
        CustomersDataGridView.RowHeadersWidth = 51;
        CustomersDataGridView.Size = new Size(802, 338);
        CustomersDataGridView.TabIndex = 1;
        // 
        // Column1
        // 
        Column1.DataPropertyName = "FirstName";
        Column1.HeaderText = "First";
        Column1.MinimumWidth = 6;
        Column1.Name = "Column1";
        Column1.Width = 125;
        // 
        // Column2
        // 
        Column2.DataPropertyName = "LastName";
        Column2.HeaderText = "Last";
        Column2.MinimumWidth = 6;
        Column2.Name = "Column2";
        Column2.Width = 125;
        // 
        // Column5
        // 
        Column5.DataPropertyName = "Gender";
        Column5.HeaderText = "Gender";
        Column5.MinimumWidth = 6;
        Column5.Name = "Column5";
        Column5.Width = 125;
        // 
        // Column3
        // 
        Column3.DataPropertyName = "BirthDay";
        dataGridViewCellStyle1.Format = "MM/dd/yyyy";
        dataGridViewCellStyle1.NullValue = null;
        Column3.DefaultCellStyle = dataGridViewCellStyle1;
        Column3.HeaderText = "Birth";
        Column3.MinimumWidth = 6;
        Column3.Name = "Column3";
        Column3.Width = 125;
        // 
        // Column4
        // 
        Column4.DataPropertyName = "Email";
        Column4.HeaderText = "Email";
        Column4.MinimumWidth = 6;
        Column4.Name = "Column4";
        Column4.Width = 125;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(829, 409);
        Controls.Add(CustomersDataGridView);
        Controls.Add(CustomersBindingNavigator);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "CoreBindingNavigator";
        CustomersBindingNavigator.EndInit();
        ((System.ComponentModel.ISupportInitialize)CustomersDataGridView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private NavigatorLibrary.CoreBindingNavigator CustomersBindingNavigator;
    private DataGridView CustomersDataGridView;
    private DataGridViewTextBoxColumn Column1;
    private DataGridViewTextBoxColumn Column2;
    private DataGridViewTextBoxColumn Column5;
    private DataGridViewTextBoxColumn Column3;
    private DataGridViewTextBoxColumn Column4;
}
