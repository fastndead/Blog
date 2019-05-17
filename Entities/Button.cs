using System.Runtime.InteropServices;

namespace Entities
{
    public class Button
    {
        public string Href;
        public string Text;


        public Button(string href, string text)
        {
            Href = href;
            Text = text;
        }
    }
}