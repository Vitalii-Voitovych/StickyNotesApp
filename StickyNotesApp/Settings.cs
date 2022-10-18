using System;

namespace StickyNotesApp
{
    public class Settings
    {
        public static string Path => $@"C:\Users\{Environment.UserName}\Documents\{Environment.UserName}-StickyNotes.json";
    }
}
