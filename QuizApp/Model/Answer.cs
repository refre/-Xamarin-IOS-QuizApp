using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace QuizApp.Model
{
    public class Answer
    {
        public short QuestionIndex { get; set; }
        public bool IsAnswered { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}