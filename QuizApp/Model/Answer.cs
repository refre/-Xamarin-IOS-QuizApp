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
        public string SongImageUri { get; set; }
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string DisplayArtist { get; set; }
        public string ID { get; set; }
    }
}