using System.ComponentModel;

namespace App4;

public class Bindable<T> : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public Bindable(T defaultValue)
    {
        _value = defaultValue;
    }

    protected T _value = default;
    public virtual T Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (_value != null)
            {
                if (!_value.Equals(value))
                {
                    _value = value;
                    OnPropertyChanged();
                }
            }
            else
            {
                _value = value;
                OnPropertyChanged();
            }
        }
    }

    protected void OnPropertyChanged()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
    }
}

