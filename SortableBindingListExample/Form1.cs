using System.ComponentModel;
using BindingListLibrary;
using SortableBindingListExample.Classes;
using SortableBindingListExample.Models;
using static SortableBindingListExample.Classes.Dialogs;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace SortableBindingListExample;

public partial class Form1 : Form
{
    private SortableBindingList<Customer> _customersSortableBindingList;
    private readonly BindingSource _customerBindingSource = [];
    public Form1()
    {
        InitializeComponent();
        CustomersDataGridView.AutoGenerateColumns = false;
        Shown += Form_Shown;

    }

    private void Form_Shown(object? sender, EventArgs e)
    {
        Setup();
    }

    private void Setup()
    {
        _customersSortableBindingList = new SortableBindingList<Customer>(
            BogusOperations.CustomersList(10));

        _customerBindingSource.DataSource = _customersSortableBindingList;
        CustomersBindingNavigator.BindingSource = _customerBindingSource;

        CustomersDataGridView.DataSource = _customerBindingSource;

        CustomersDataGridView.ExpandColumns();
        CustomersDataGridView.FixHeaders();

        CustomersDataGridView.DataError += CustomersDataGridView_DataError;

        CustomersBindingNavigator.AboutItemButton.Click += AboutItemButton_Click;
        CustomersBindingNavigator.DeleteItemButton.Click += CustomersDelete_Click;
        CustomersBindingNavigator.AddItemButton.Click += CustomersAdd_Click;
        CustomersBindingNavigator.CurrentItemButton.Click += CurrentItemButton_Click;
        CustomersBindingNavigator.RemoveDefaultHandlers();

        CustomersDataGridView.UserDeletingRow += CustomersDataGridView_UserDeletingRow;

        _customerBindingSource.ListChanged += _customerBindingSource_ListChanged;

    }

    private void CustomersDataGridView_DataError(object? sender, DataGridViewDataErrorEventArgs e)
    {
        /*
         * Gender column is prone to user entering an invalid value, if so cancel
         * For a real application, Gender would be a combobox column.
         */
        if (CustomersDataGridView.Columns[e.ColumnIndex].DataPropertyName == nameof(Gender))
        {
            e.Cancel = false;
        }
    }

    /*
     * In combination with INotifyPropertyChanged in the Customer model, handle changes
     * that for a real application would be saved to a database or rejected.
     */
    private void _customerBindingSource_ListChanged(object? sender, ListChangedEventArgs e)
    {
        if (e.ListChangedType == ListChangedType.ItemChanged)
        {
            var x = _customersSortableBindingList[e.OldIndex];
            MessageBox.Show($"Property {e.PropertyDescriptor!.DisplayName} has changed");
        }else if (e.ListChangedType == ListChangedType.ItemAdded)
        {
            // do something
        }
        else if (e.ListChangedType == ListChangedType.ItemDeleted)
        {
            // do something
        }
    }

    private void CurrentItemButton_Click(object? sender, EventArgs e)
    {
        if (_customerBindingSource.Current is null) return;
        Customer current = _customersSortableBindingList[_customerBindingSource.Position];
        MessageBox.Show($"First: {current.FirstName} Last: {current.LastName} Id: {current.Id} ");
    }

    private void AboutItemButton_Click(object? sender, EventArgs e)
    {
        Information(this, "", "BindingNavigator sample");
    }

    private void CustomersDelete_Click(object? sender, EventArgs e)
    {

        if (_customerBindingSource.Current is null) return;

        if (AskToRemoveCurrentRow())
        {
            _customerBindingSource.RemoveCurrent();
        }

    }

    private void CustomersDataGridView_UserDeletingRow(object? sender, DataGridViewRowCancelEventArgs e)
    {
        if (_customerBindingSource.Current is null) return;

        if (AskToRemoveCurrentRow())
        {
            e.Cancel = true;
            _customerBindingSource.RemoveCurrent();
        }
        else
        {
            e.Cancel = true;
        }
    }

    private bool AskToRemoveCurrentRow()
    {
        var current = _customersSortableBindingList[_customerBindingSource.Position];
        return Question(this, $"Remove {current.FirstName} {current.LastName}");
    }

    private void CustomersAdd_Click(object? sender, EventArgs e)
    {
        var id = _customerBindingSource.Count == 0 ? 
            0 : 
            _customersSortableBindingList.MaxBy(x => x.Id)!.Id;

        _customersSortableBindingList.Add(BogusOperations.Customer(id+=1));
        _customerBindingSource.MoveLast();
    }
}

