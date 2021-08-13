using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class DetailPageViewModel : INotifyPropertyChanged
    {
     
        public event PropertyChangedEventHandler PropertyChanged;

        public DetailPageViewModel(String note)
        {
            DismissPageCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        string noteText;
        public string NoteText;
        public Command DismissPageCommand { get; }
    }
}
