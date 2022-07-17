using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingLibrary
{
    //新增 PropertyChanged 方法
    public abstract class NotifyPropertyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //更新畫面Property
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T storage, T value,[CallerMemberName] string propertyName = null)
        {
            //判斷目前的值是否有不同，若不同則更新
            if(!EqualityComparer<T>.Default.Equals(storage, value))
            {
                storage = value;
                OnPropertyChanged(propertyName);
            }
        }
    }
}
