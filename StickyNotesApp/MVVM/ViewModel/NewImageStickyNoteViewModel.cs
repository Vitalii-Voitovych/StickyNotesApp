using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StickyNotesApp.MVVM.Models;
using StickyNotesApp.Services;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;

namespace StickyNotesApp.MVVM.ViewModel
{
    public partial class NewImageStickyNoteViewModel : ObservableObject
    {
        private readonly BindingList<StickyNote> stickyNotes;

        [ObservableProperty]
        private Brush color = (SolidColorBrush)new BrushConverter().ConvertFrom("#3AAF97")!;

        [ObservableProperty]
        private StickyNote stickyNote = new();

        [ObservableProperty]
        private StrokeCollection strokes = new StrokeCollection();

        [ObservableProperty]
        private InkCanvasEditingMode mode = InkCanvasEditingMode.Ink;

        [RelayCommand]
        private void ColorChange(RadioButton radioButton)
        {
            Color = radioButton.Background;
        }

        [RelayCommand]
        private void EditMode()
        {
            Mode = InkCanvasEditingMode.Ink;
        }

        [RelayCommand]
        private void RemoveMode()
        {
            Mode = InkCanvasEditingMode.EraseByPoint;
        }

        [RelayCommand]
        private void SaveStickyNote(Window window)
        {
            StickyNote.Color = new BrushConverter().ConvertToString(Color)!;
            using (MemoryStream ms = new MemoryStream())
            {
                Strokes.Save(ms);
                StickyNote.Strokes = ms.ToArray();
            }
            stickyNotes.Add(StickyNote);
            StickyNoteDataSaver.Save(stickyNotes, Settings.Path);
            window.DialogResult = true;
            window.Close();
        }

        [RelayCommand]
        private void Close(Window window)
        {
            window.Close();
        }

        public NewImageStickyNoteViewModel()
        {
            stickyNotes = StickyNoteDataSaver.Load(Settings.Path);
        }
    }
}
