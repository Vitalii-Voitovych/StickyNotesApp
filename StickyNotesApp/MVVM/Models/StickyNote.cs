using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Ink;

namespace StickyNotesApp.MVVM.Models
{
    public partial class StickyNote : ObservableObject
    {
        [ObservableProperty]
        private string? text;

        [ObservableProperty]
        private string color = "";

        [ObservableProperty]
        private byte[]? strokes;
    }
}
