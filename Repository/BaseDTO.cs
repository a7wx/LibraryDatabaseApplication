using System.ComponentModel;
using System.Runtime.CompilerServices;
#nullable disable
namespace LibraryApplication.Repository
{
     public class BaseDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (field != null && field.Equals(value)) return false;
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
