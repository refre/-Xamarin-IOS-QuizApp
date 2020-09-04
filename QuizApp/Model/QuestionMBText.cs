using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace QuizApp.Model
{
    public class QuestionMBText : QuestionMB
    {
        public string Sentence { get; set; }
        public List<string> AnswerLine { get; set; }
        public List<Textline> Lines { get; set; }
    }
}