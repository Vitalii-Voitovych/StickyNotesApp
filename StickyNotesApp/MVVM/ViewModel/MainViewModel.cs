using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StickyNotesApp.MVVM.Models;
using StickyNotesApp.MVVM.View;
using StickyNotesApp.Services;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace StickyNotesApp.MVVM.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private BindingList<StickyNote> tempStickyNotes = null!;

        [ObservableProperty]
        private BindingList<StickyNote> stickyNotes = null!;

        private string filter = "";
        public string Filter
        {
            get => filter;
            set
            {
                if (SetProperty(ref filter, value))
                {
                    
                    OnPropertyChanged();
                }
            }
        }

        [RelayCommand]
        private void OpenNewTextStickyNote()
        {
            NewTextStickyNote view = new NewTextStickyNote();
            if (view.ShowDialog() == true)
            {
                StickyNotes = StickyNoteDataSaver.Load(Settings.Path);
            }
        }

        [RelayCommand]
        private void OpenNewImageStickyNote()
        {
            NewImageStickyNoteView view = new NewImageStickyNoteView();
            if (view.ShowDialog() == true)
            {
                StickyNotes = StickyNoteDataSaver.Load(Settings.Path);
            }
        }

        [RelayCommand]
        private void DeleteStickyNote(StickyNote note)
        {
            StickyNotes.Remove(note);
            StickyNoteDataSaver.Save(StickyNotes, Settings.Path);
        }

        [RelayCommand]
        private void Close(Window window)
        {
            window.Close();
        }

        [RelayCommand]
        private void Minimize(Window window)
        {
            window.WindowState = WindowState.Minimized;
        }

        public MainViewModel()
        {
            StickyNotes = StickyNoteDataSaver.Load(Settings.Path);
            StickyNoteDataSaver.Save(StickyNotes, Settings.Path);
        }
    }
}
