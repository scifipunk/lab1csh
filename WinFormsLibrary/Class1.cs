using System;

using System.Drawing;
using System.Text.RegularExpressions;

namespace WinFormsLibrary
{
    
    
    public class timePattern
    {
        private string Name = "time";
        private string sign = @"\s\d{2}:\d{2}:\d{2}";
        private string textToParse;
        private Color color;

        public timePattern(string textToParse, Color color)
        {
            this.color = color;
            this.textToParse = textToParse;
        }

        public string GetSign() { return this.sign; }

        public string GetName() { return this.Name; }

        public string GetTextToParse() { return this.textToParse; }

        public Color GetColor() { return this.color; }

        public MatchCollection parseText()
        {
            DateTime date = DateTime.Today;
            string pattern = date.ToShortDateString();
            Regex regexDate = new Regex(@pattern + @"\s\d{2}:\d{2}:\d{2}");
            MatchCollection matchesDate = regexDate.Matches(this.textToParse);
            return matchesDate;
        }    
    }



    public class ParseIt
    {
        private string Name;
        private string sign;
        private string textToParse;
        private Color color;


        static Color GenerateRandomColor(string word)
        {
            int length = word.Length;
            int hashCode = word.GetHashCode();

            // Используем полученные значения для генерации цвета
            int red = Math.Abs(length % 256);
            int green = Math.Abs(hashCode % 256);
            int blue = Math.Abs((length * hashCode) % 256);

            return Color.FromArgb(red, green, blue);
        }

        public ParseIt(string signature, string textToParse) { 
            
            this.sign = @signature;
            this.Name = signature;
            this.color = GenerateRandomColor(this.Name);
            this.textToParse = textToParse;
        }

        public string GetSign() { return this.sign; }
        
        public string GetName() { return this.Name; }

        public string GetTextToParse() { return this.textToParse; }

        public Color GetColor() { return this.color; }

        public MatchCollection parseText() { 
            
            Regex regex  = new Regex(this.sign, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(this.textToParse);
            return matches;
        }

    }
}
