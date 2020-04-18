using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace shell01.ViewModels
{
    class Page2ViewModel : INotifyPropertyChanged
    {
        public Page2ViewModel() 
        {
            OKCommand = new Command(IncreaseCount);
            //            OKCommand = new Command(() => {IncreaseCount() });

        }

        string name = string.Empty;
        public string Name
        {
            get => name;
            set
            {
                if (name == value)
                    return;

                name = value;

                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        int count = 0;
        void IncreaseCount() 
        {
            count++;
            OnPropertyChanged(nameof(DisplayCount));
        }


        public string DisplayCount => $"Clicked: {count} times.";

        public string DisplayName => $"Name Entered: {Name}";

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand OKCommand { get; }
    }

}
