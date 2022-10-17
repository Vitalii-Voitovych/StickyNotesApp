using System.Windows;
using System.Windows.Input;

namespace StickyNotesApp.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для NewTextStickyNote.xaml
    /// </summary>
    public partial class NewTextStickyNote : Window
    {
        public NewTextStickyNote()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
