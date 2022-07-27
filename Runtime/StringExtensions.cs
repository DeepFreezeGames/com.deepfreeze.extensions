using UnityEngine;

namespace DeepFreeze.Packages.Extensions.Runtime
{
    public static class StringExtensions
    {
        public static string RepeatCharacter(char character, int count)
        {
            return RepeatCharacter(character.ToString(), count);
        }
        
        public static string RepeatCharacter(string character, int count)
        {
            var output = string.Empty;
            for (int i = 0; i < count; i++)
            {
                output = $"{output}{character}";
            }

            return output;
        }
        
        public static void CopyToClipboard(this string input)
        {
            var textEditor = new TextEditor
            {
                text = input
            };
            textEditor.SelectAll();
            textEditor.Copy();
        }
    }
}