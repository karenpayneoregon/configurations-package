using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HasQueryFilterApp.Classes;
using ShadowProperties.Models;

namespace HasQueryFilterApp
{
    public partial class Form1 : Form
    {
        private BindingList<Contact1> _bindingList;
        private readonly BindingSource _bindingSource = new ();
        public Form1()
        {
            InitializeComponent();
            Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            _bindingList = new BindingList<Contact1>(Operations.Contacts());
            _bindingSource.DataSource = _bindingList;
            dataGridView1.DataSource = _bindingSource;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Operations.Remove(_bindingList[_bindingSource.Position]);
            _bindingList.RemoveAt(_bindingSource.Position);
        }
    }
}
