using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Media;

namespace StickyNotesApp.MVVM.Models
{
    public partial class StickyNote : ObservableObject
    {
        [ObservableProperty]
        private string? text;

        [ObservableProperty]
        private string color = "";
    }
}
