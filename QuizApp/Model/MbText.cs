using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace QuizApp.Model
{
    public class MbText
    {
        public string Id { get; set; }
        
        public string MovieName { get; set; }
        
        public string ActorName { get; set; }
        public bool IsCorrectAnswer { get; set; }

    }
}