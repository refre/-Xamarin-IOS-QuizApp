using System.Collections.Generic;
using QuizApp.Model;

namespace QuizApp.Service
{
    public class MockManagementText
    {
        public List<MbText> Question1 { get; set; }
        public List<MbText> Question2 { get; set; }
        public List<MbText> Question3 { get; set; }
        public List<MbText> Question4 { get; set; }
        public List<MbText> Question5 { get; set; }
        public List<List<MbText>> FullQuestionList { get; set; }

        public List<Answer> Answers { get; set; }
        public MockManagementText()
        {
           
            Question1 = new List<MbText>()
            {
                new MbText { ActorName = "Will Smith", MovieName = "Bright", Id = "WIS-00001",IsCorrectAnswer=true },
                new MbText { ActorName = "Tom Cruise", MovieName = "Vanilla Sky", Id = "TOC-00001",IsCorrectAnswer=false },
                new MbText { ActorName = "Vin Diesel", MovieName = "Fast and Furious", Id = "VID-00001",IsCorrectAnswer=false },
                new MbText { ActorName = "Jason Statham", MovieName = "The Transporter", Id = "JAS-00001",IsCorrectAnswer=false },
            };
            Question2 = new List<MbText>()
            {
                new MbText{ ActorName="Tom Cruise", MovieName="Vanilla Sky", Id="TOC-00001",IsCorrectAnswer=false },
                new MbText{ ActorName="Vin Diesel", MovieName="Fast and Furious", Id="VID-00001",IsCorrectAnswer=false },
                new MbText{ ActorName="Jason Statham", MovieName="The Transporter", Id="JAS-00001",IsCorrectAnswer=true },
                new MbText{ ActorName="Charlize Theron", MovieName="Atomic Blonde", Id="CHT-00001",IsCorrectAnswer=false },
            };
            Question3 = new List<MbText>()
            {
                new MbText{ ActorName="Vin Diesel", MovieName="Fast and Furious", Id="VID-00001",IsCorrectAnswer=false},
                new MbText{ ActorName="Jason Statham", MovieName="The Transporter", Id="JAS-00001",IsCorrectAnswer=false},
                new MbText{ ActorName="Charlize Theron", MovieName="Atomic Blonde", Id="CHT-00001",IsCorrectAnswer=false},
                new MbText{ ActorName="Keanu Reeves", MovieName="John Wick", Id="KER-00001",IsCorrectAnswer=true },
            };
            Question4 = new List<MbText>()
            {
                new MbText{ ActorName="Jason Statham", MovieName="The Transporter", Id="JAS-00001",IsCorrectAnswer=false},
                new MbText{ ActorName="Charlize Theron", MovieName="Atomic Blonde", Id="CHT-00001",IsCorrectAnswer=false},
                new MbText{ ActorName="Keanu Reeves", MovieName="John Wick", Id="KER-00001",IsCorrectAnswer=false},
                new MbText{ ActorName="Emily Blunt", MovieName="The Girl on the Train ", Id="EMB-00001",IsCorrectAnswer=true },
            };
            Question5 = new List<MbText>()
            {
                new MbText{ ActorName="Vin Diesel", MovieName="Fast and Furious", Id="VID-00001",IsCorrectAnswer=false },
                new MbText{ ActorName="Will Smith", MovieName="Bright", Id="WIS-00001",IsCorrectAnswer=false },
                new MbText { ActorName = "Tom Cruise", MovieName = "Vanilla Sky", Id = "TOC-00001", IsCorrectAnswer = true },
                new MbText { ActorName = "Jason Statham", MovieName = "The Transporter", Id = "JAS-00001",IsCorrectAnswer=false },
            };

            FullQuestionList = new List<List<MbText>>()
            {
                Question1,
                Question2,
                Question3,
                Question4,
                Question5
            };


            Answers = new List<Answer>()
            {
                new Answer{ IsAnswered=false,QuestionIndex=0,IsCorrectAnswer=false },
                new Answer{ IsAnswered=false,QuestionIndex=1,IsCorrectAnswer=false },
                new Answer{ IsAnswered=false,QuestionIndex=2,IsCorrectAnswer=false },
                new Answer{ IsAnswered=false,QuestionIndex=3,IsCorrectAnswer=false },
                new Answer{ IsAnswered=false,QuestionIndex=4,IsCorrectAnswer=false }
            };

        }
    }
}