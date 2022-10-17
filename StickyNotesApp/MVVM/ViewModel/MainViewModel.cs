using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StickyNotesApp.MVVM.View;
using System.Windows;

namespace StickyNotesApp.MVVM.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [RelayCommand]
        private void OpenNewTextStickyNote()
        {
            NewTextStickyNote view = new NewTextStickyNote();
            view.ShowDialog();
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
    }
}
