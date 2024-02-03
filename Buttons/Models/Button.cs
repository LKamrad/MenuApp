using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttons.Models
{
    class Button
    {
        private int _x;
        private int _y;
        private string _text;
        private bool _isSelected;

        public Button(int x, int y,  string text, bool isSelected)
        {
            _x = x;
            _y = y;
            _text = text;
            _isSelected = isSelected;
        }

        public void DrawButton(bool marked) 
        {
            _isSelected = marked;
            DrawButton();
        }
        public void DrawButton()
        {
            Console.SetCursorPosition(_x, _y);

            if (_isSelected)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($">{_text}<");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" {_text} ");
            }
            Console.ResetColor();

        }
        public bool IsSelected()
        {
            return _isSelected;
        }
    }
}
