using StickyNotesApp.MVVM.Models;
using System.ComponentModel;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace StickyNotesApp.Services
{
    public class StickyNoteDataSaver
    {
        public static BindingList<StickyNote> Load(string fileName)
        {
            if (File.Exists(fileName))
            {
                var fileText = File.ReadAllText(fileName);
                return JsonSerializer.Deserialize<BindingList<StickyNote>>(fileText)!;
            }
            else
            {
                File.Create(fileName).Dispose();
                return new BindingList<StickyNote>();
            }
        }

        public static void Save(BindingList<StickyNote> stickyNotes, string fileName)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            File.WriteAllText(fileName, JsonSerializer.Serialize(stickyNotes, options));
        }
    }
}
