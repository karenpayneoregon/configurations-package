using Bogus;
using System.ComponentModel;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace SortableBindingListExample.Models;

public partial class Customer : INotifyPropertyChanged
{
    private int id;
    public int Id
    {
        get => id;
        set
        {
            if (id != value)
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }

    private string firstName;
    public string FirstName
    {
        get => firstName;
        set
        {
            if (firstName != value)
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
    }

    private string lastName;
    public string LastName
    {
        get => lastName;
        set
        {
            if (lastName == value) return;
            lastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }

    private DateTime? birthDay;
    public DateTime? BirthDay
    {
        get => birthDay;
        set
        {
            if (birthDay == value) return;
            birthDay = value;
            OnPropertyChanged(nameof(BirthDay));
        }
    }

    private string email;
    public string Email
    {
        get => email;
        set
        {
            if (email == value) return;
            email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    private Gender? gender;
    public Gender? Gender
    {
        get => gender;
        set
        {
            if (gender == value) return;

            gender = value;
            OnPropertyChanged(nameof(Gender));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
