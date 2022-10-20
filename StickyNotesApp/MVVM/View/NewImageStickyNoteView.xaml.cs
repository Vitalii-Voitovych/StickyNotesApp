using System.Windows;
using System.Windows.Input;

namespace StickyNotesApp.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для NewImageStickyNoteView.xaml
    /// </summary>
    public partial class NewImageStickyNoteView : Window
    {
        public NewImageStickyNoteView()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
