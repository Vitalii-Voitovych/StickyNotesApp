using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StickyNotesApp.MVVM.Models;
using StickyNotesApp.MVVM.View;
using StickyNotesApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace StickyNotesApp.MVVM.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private BindingList<StickyNote> stickyNotes = null!;
        
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
        private void DeleteStickyNote(StickyNote note)
        {
            StickyNotes.Remove(note);
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
            StickyNotes.ListChanged += StickyNotes_ListChanged;
        }

        private void StickyNotes_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                StickyNoteDataSaver.Save(StickyNotes, Settings.Path);
            }
        }
    }
}
