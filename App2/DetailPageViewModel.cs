using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class DetailPageViewModel : ContentPage, INotifyPropertyChanged
    {
     
        public event PropertyChangedEventHandler PropertyChanged;

        public DetailPageViewModel(string note)
        {
            DismissPageCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });
            NoteText = note;
        }

        string noteText ;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));
            }
        }
        public Command DismissPageCommand { get; }

        async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
