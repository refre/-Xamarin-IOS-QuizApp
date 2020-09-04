using QuizApp.Model;
using System;

namespace QuizApp.ViewController
{
    public class CellDataUpdateEventArgs : EventArgs
    {
        public int Index { get; set; }
        public Answer CurrentAnswer { get; set; }
    }
}