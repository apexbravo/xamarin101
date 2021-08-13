﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {

        public Command SelectedNoteChangedCommand { get; }
        string selectedNote;

        public MainPageViewModel()
        {
            
            EraseCommand = new Command(() =>
                {
                    TheNote = string.Empty;
                });

            SavCommand = new Command(() =>
            {
                AllNotes.Add(TheNote);
                TheNote = string.Empty;
            });

            SelectedNoteChangedCommand = new Command(async() =>
            {
                var detailVM = new DetailPageViewModel(selectedNote);
                var detailsPage = new DetailsPage();

                detailsPage.BindingContext = detailVM;
                 await Application.Current.MainPage.Navigation.PushModalAsync(detailsPage);
            });

        }
        ObservableCollection<string> allNotes;
        public ObservableCollection<string> AllNotes{
            get
            {
                if (allNotes == null)
                    allNotes = new ObservableCollection<string>();
                return allNotes;
            }
            set
            {
                allNotes = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        string theNote;
        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;
                var args = new PropertyChangedEventArgs(nameof(TheNote));

                PropertyChanged?.Invoke(this, args);

            }
        }
        public Command SavCommand { get; }
       public Command EraseCommand { get; }


    }
}
