using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using QuizApp.Model;
using UIKit;

namespace QuizApp.Service
{
    public class MockManagementText
    {
        public List<Textline> TotalQuestion { get; set; }
        public MockManagementText()
        {
            TotalQuestion = new List<Textline>();
            /*Dummy data - prendre les données de la DB*/
            List<MbText> dummy = new List<MbText>()
            {
                new MbText{ ActorName="Will Smith", MovieName="Bright", Id="WIS-00001"},
                new MbText{ ActorName="Tom Cruise", MovieName="Vanilla Sky", Id="TOC-00001"},
                new MbText{ ActorName="Vin Diesel", MovieName="Fast and Furious", Id="VID-00001"},
                new MbText{ ActorName="Jason Statham", MovieName="The Transporter", Id="JAS-00001"},
                new MbText{ ActorName="Charlize Theron", MovieName="Atomic Blonde", Id="CHT-00001"},
                new MbText{ ActorName="Keanu Reeves", MovieName="John Wick", Id="KER-00001"},
                new MbText{ ActorName="Emily Blunt", MovieName="The Girl on the Train ", Id="EMB-00001"},
            };

            var q1 = new List<MbText>();
            var q2 = new List<MbText>();
            var q3 = new List<MbText>();
            var q4 = new List<MbText>();



            foreach (var item in dummy)
            {
                Textline myLine = new Textline();
                
                TotalQuestion.Add(myLine);
            }

        }
        

    }
}