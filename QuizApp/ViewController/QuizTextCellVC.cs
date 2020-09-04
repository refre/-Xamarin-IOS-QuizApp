using System;
using System.Drawing;
using CoreGraphics;
using Foundation;
using QuizApp.Model;
using UIKit;

namespace QuizApp.ViewController
{
    public class QuizTextCellVC: UICollectionViewCell
    {
        UILabel lblQue, SentenceText;
        UIButton btn1, btn2, btn3, btn4;
        private int _currentIndex;
        private Answer currentAns;
        private QuestionMBText _musicQuestion;
        public static readonly NSString CellId = new NSString("MusicCell");
        public event EventHandler<CellDataUpdateEventArgs> CellData;

        [Export("initWithFrame:")]
        public QuizTextCellVC(RectangleF frame) : base(frame)
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.Clear };

            SentenceText = new UILabel(new CGRect(0, 0, 300, 100));
            SentenceText.Text = " ";
            SentenceText.TextColor = UIColor.White;
            SentenceText.TextAlignment = UITextAlignment.Left;
            SentenceText.Font = UIFont.SystemFontOfSize(16);
            SentenceText.Lines = 4;
            SentenceText.TranslatesAutoresizingMaskIntoConstraints = false;

            btn1 = Button(0);
            btn2 = Button(1);
            btn3 = Button(2);
            btn4 = Button(3);

            btn1.TouchUpInside += ButtonClicked;
            btn2.TouchUpInside += ButtonClicked;
            btn3.TouchUpInside += ButtonClicked;
            btn4.TouchUpInside += ButtonClicked;

            lblQue = new UILabel(new CGRect(0, 0, 300, 100));
            lblQue.Text = " ";
            lblQue.TextColor = UIColor.White;
            lblQue.TextAlignment = UITextAlignment.Left;
            lblQue.Font = UIFont.SystemFontOfSize(16);
            lblQue.Lines = 4;
            lblQue.TranslatesAutoresizingMaskIntoConstraints = false;

            ContentView.AddSubview(SentenceText);
            ContentView.AddSubview(lblQue);
            ContentView.AddSubview(btn1);
            ContentView.AddSubview(btn2);
            ContentView.AddSubview(btn3);
            ContentView.AddSubview(btn4);

            SentenceText.TopAnchor.ConstraintEqualTo(BackgroundView.TopAnchor, 30).Active = true;
            SentenceText.LeftAnchor.ConstraintEqualTo(BackgroundView.LeftAnchor, 20).Active = true;
            SentenceText.RightAnchor.ConstraintEqualTo(BackgroundView.RightAnchor, -20).Active = true;

            lblQue.TopAnchor.ConstraintEqualTo(BackgroundView.TopAnchor, 130).Active = true;
            lblQue.LeftAnchor.ConstraintEqualTo(BackgroundView.LeftAnchor, 20).Active = true;
            lblQue.RightAnchor.ConstraintEqualTo(BackgroundView.RightAnchor, -20).Active = true;

            btn1.TopAnchor.ConstraintEqualTo(BackgroundView.TopAnchor, 150).Active = true;
            btn1.LeftAnchor.ConstraintEqualTo(BackgroundView.LeftAnchor, 20).Active = true;
            btn1.RightAnchor.ConstraintEqualTo(BackgroundView.RightAnchor, -20).Active = true;

            btn2.TopAnchor.ConstraintEqualTo(BackgroundView.TopAnchor, 190).Active = true;
            btn2.LeftAnchor.ConstraintEqualTo(BackgroundView.LeftAnchor, 20).Active = true;
            btn2.RightAnchor.ConstraintEqualTo(BackgroundView.RightAnchor, -20).Active = true;

            btn3.TopAnchor.ConstraintEqualTo(BackgroundView.TopAnchor, 230).Active = true;
            btn3.LeftAnchor.ConstraintEqualTo(BackgroundView.LeftAnchor, 20).Active = true;
            btn3.RightAnchor.ConstraintEqualTo(BackgroundView.RightAnchor, -20).Active = true;

            btn4.TopAnchor.ConstraintEqualTo(BackgroundView.TopAnchor, 270).Active = true;
            btn4.LeftAnchor.ConstraintEqualTo(BackgroundView.LeftAnchor, 20).Active = true;
            btn4.RightAnchor.ConstraintEqualTo(BackgroundView.RightAnchor, -20).Active = true;
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Question((UIButton)sender);
        }
        private UIButton Button(int tag)
        {
            var btn = new UIButton();
            btn.Tag = tag;
            btn.SetTitle("Option", UIControlState.Normal);
            btn.SetTitleColor(UIColor.White, UIControlState.Normal);
            btn.BackgroundColor = UIColor.FromRGB(128, 128, 128);
            btn.Layer.BorderWidth = 2;
            btn.Layer.BorderColor = UIColor.White.CGColor;
            btn.Layer.CornerRadius = 0;
            btn.ClipsToBounds = true;
            btn.TranslatesAutoresizingMaskIntoConstraints = false;

            return btn;
        }

        private void Question(UIButton btnUI)
        {
            if (currentAns.IsAnswered)
                return;

            var selected = Convert.ToInt32(btnUI.Tag);
            currentAns.IsCorrectAnswer = _musicQuestion.Lines[selected].SentenceId.Equals(currentAns.ID);

            if (currentAns.IsCorrectAnswer)
                btnUI.BackgroundColor = UIColor.Green;
            else
                btnUI.BackgroundColor = UIColor.Red;

            currentAns.IsAnswered = true;

            SetNeedsDisplay();

            CellDataUpdateEventArgs args = new CellDataUpdateEventArgs
            {
                CurrentAnswer = currentAns,
                Index = _currentIndex
            };
            CellUpdated(args);

        }

        public void UpdateCell(QuestionMBText currentQuestion, int questionNum, string questionNom, Answer ans, byte selectedAnwser)
        {
            _musicQuestion = currentQuestion;
            _currentIndex = questionNum;
            currentAns = ans;
            lblQue.Text = currentQuestion.NameOfQuestion;
            SentenceText.Text = currentQuestion.Sentence;
            if (!currentAns.IsAnswered)
            {
                btn1.SetTitle(_musicQuestion.AnswerLine[0], UIControlState.Normal);
                btn2.SetTitle(_musicQuestion.AnswerLine[1], UIControlState.Normal);
                btn3.SetTitle(_musicQuestion.AnswerLine[2], UIControlState.Normal);
                btn4.SetTitle(_musicQuestion.AnswerLine[3], UIControlState.Normal);

                btn1.BackgroundColor = UIColor.FromRGB(128, 128, 128);
                btn2.BackgroundColor = UIColor.FromRGB(128, 128, 128);
                btn3.BackgroundColor = UIColor.FromRGB(128, 128, 128);
                btn4.BackgroundColor = UIColor.FromRGB(128, 128, 128);

                SetNeedsDisplay();
            }
            else
            {
                btn1.BackgroundColor = UIColor.FromRGB(128, 128, 128);
                btn2.BackgroundColor = UIColor.FromRGB(128, 128, 128);
                btn3.BackgroundColor = UIColor.FromRGB(128, 128, 128);
                btn4.BackgroundColor = UIColor.FromRGB(128, 128, 128);
                if (currentAns.IsCorrectAnswer)
                {
                    switch (selectedAnwser)
                    {
                        case 0:
                            btn1.BackgroundColor = UIColor.Green;
                            break;
                        case 1:
                            btn2.BackgroundColor = UIColor.Green;
                            break;
                        case 2:
                            btn3.BackgroundColor = UIColor.Green;
                            break;
                        case 3:
                            btn4.BackgroundColor = UIColor.Green;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (selectedAnwser)
                    {
                        case 0:
                            btn1.BackgroundColor = UIColor.Red;
                            break;
                        case 1:
                            btn2.BackgroundColor = UIColor.Red;
                            break;
                        case 2:
                            btn3.BackgroundColor = UIColor.Red;
                            break;
                        case 3:
                            btn4.BackgroundColor = UIColor.Red;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        protected void CellUpdated(CellDataUpdateEventArgs e)
        {
            EventHandler<CellDataUpdateEventArgs> handler = CellData;
            if (handler != null)
            {
                handler(this, e);
            }

        }
    }
}