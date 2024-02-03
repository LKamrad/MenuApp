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
        private int _width;
        private string _text;
        private bool _isSelected;

        public Button(int x, int y,  string text)
        {
            _x = x;
            _y = y;
            _width = text.Length+2;
            _text = text;
            _isSelected = false;
        }

        public void DrawButton(bool marked) 
        {
            _isSelected = marked;
            DrawButton();
            //Console.SetCursorPosition(_x, _y);
            
            //Console.BackgroundColor = ConsoleColor.DarkGray;
            //Console.ForegroundColor = ConsoleColor.White;
            //if (marked)
            //{
            //    Console.BackgroundColor = ConsoleColor.White;
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.Write(">");
            //}
            //else
            //{
 
            //    Console.Write(" ");
            //}

            //Console.Write(_text);

            //if (marked)
            //{
            //    Console.Write("<");
            //}
            //else
            //{
            //    Console.Write(" ");
            //}
            //Console.ResetColor();

        }
        public void DrawButton()
        {
            Console.SetCursorPosition(_x, _y);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            if (_isSelected)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(">");
            }
            else
            {

                Console.Write(" ");
            }

            Console.Write(_text);

            if (_isSelected)
            {
                Console.Write("<");
            }
            else
            {
                Console.Write(" ");
            }
            Console.ResetColor();

        }
        public bool IsSelected()
        {
            return _isSelected;
        }
    }
}
