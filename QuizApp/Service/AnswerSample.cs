//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Foundation;
//using QuizApp.Model;
//using UIKit;

//namespace QuizApp.Service
//{
//    public class MockAnswerSample
//    {
//        public List<Answer> MusicAnswer { get; set; }

//        public MockAnswerSample()
//        {
//            var musicAnswer = new List<Answer>();
//            Answer answer0 = new Answer
//            {
//                ArtistName = "Booba",
//                //Deeplink = null,
//                DisplayArtist = "Lunatic",
//                ID = "66881848",
//                IsAnswered = true,
//                IsCorrectAnswer = true,
//                QuestionIndex = 1,
//                //SelectedAnswer = 1,
//                SongImageUri = "http://e-cdn-images.deezer.com/images/cover/cd736ce0b522609e9fea51d405c6441a/120x120-000000-80-0-0.jpg",
//                SongName = "Intro"
//            };
//            Answer answer1 = new Answer
//            {
//                ArtistName = "Booba",
//                //Deeplink = null,
//                DisplayArtist = "Lunatic",
//                ID = "66881849",
//                IsAnswered = true,
//                IsCorrectAnswer = false,
//                QuestionIndex = 2,
//                //SelectedAnswer = 2,
//                SongImageUri = "http://e-cdn-images.deezer.com/images/cover/cd736ce0b522609e9fea51d405c6441a/120x120-000000-80-0-0.jpg",
//                SongName = "Pas l'temps pour les regrets"
//            };
//            Answer answer2 = new Answer
//            {
//                ArtistName = "Booba",
//                //Deeplink = null,
//                DisplayArtist = "Booba",
//                ID = "66881834",
//                IsAnswered = true,
//                IsCorrectAnswer = true,
//                QuestionIndex = 3,
//                //SelectedAnswer = 3,
//                SongImageUri = "https://e-cdns-images.dzcdn.net/images/cover/b84883ff11523a49080c43e67352db86/250x250-000000-80-0-0.jpg",
//                SongName = "Indépendant"
//            };

//            musicAnswer.Add(answer0);
//            musicAnswer.Add(answer1);
//            musicAnswer.Add(answer2);
//            musicAnswer.Add(answer0);
//            musicAnswer.Add(answer1);
//            musicAnswer.Add(answer2);
//            musicAnswer.Add(answer0);
//            musicAnswer.Add(answer1);
//            musicAnswer.Add(answer2);
//            musicAnswer.Add(answer2);

//            MusicAnswer = musicAnswer;

//        }
//    }
//}