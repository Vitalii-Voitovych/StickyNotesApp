using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace StickyNotesApp.MVVM.ViewModel
{
    public partial class NewTextStickyNoteViewModel : ObservableObject
    {
        [ObservableProperty]
        private Brush? color = (SolidColorBrush?)new BrushConverter().ConvertFrom("#3AAF97");

        [RelayCommand]
        private void ColorChange(RadioButton radioButton)
        {
            Color = radioButton.Background;
        }

        [RelayCommand]
        private void BoldText(TextSelection text)
        {
            if (text.IsEmpty) return;
            if (text.GetPropertyValue(TextElement.FontWeightProperty) is FontWeight weight && 
                weight == FontWeights.Bold)
            {
                text.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
            }
            else
            {
                text.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
        }

        [RelayCommand]
        private void ItalicStyleText(TextSelection text)
        {
            if (text.IsEmpty) return;
            if (text.GetPropertyValue(TextElement.FontStyleProperty) is FontStyle style &&
                style == FontStyles.Italic)
            {
                text.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
            }
            else
            {
                text.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
            }
        }

        [RelayCommand]
        private void UnderlineText(TextSelection text)
        {
            if (text.IsEmpty) return;
            if (text.GetPropertyValue(Inline.TextDecorationsProperty) is TextDecorationCollection textDecorations &&
                textDecorations == TextDecorations.Underline)
            {
                text.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
            }
            else
            {
                text.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
        }

        [RelayCommand]
        private void Close(Window window)
        {
            window.Close();
        }
    }
}
