using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using QuizApp.Model;
using QuizApp.Service;
using UIKit;

namespace QuizApp.ViewController
{
    public class QuizTextVC : UIViewController, IUICollectionViewDataSource, IUICollectionViewDelegate,
    IUICollectionViewDelegateFlowLayout
    {
        private UIButton btnPrev;
        private UIButton btnNext;
        private UILabel lblQueNumber;
        private UILabel lblScore;
        private UICollectionView collectionView;
        private int currentQuestionNumber = 1;
        private int _index;
        private List<Answer> _answers;
        private MockManagementText _questionData;
        private string QuestionPageQuestionWord, QuestionPageTypeOFQ1, QuestionPageTypeOFQ2, QuestionPageTypeOFQ3;
        private readonly string model = UIDevice.CurrentDevice.Model;
        private readonly string brand = UIDevice.CurrentDevice.Name;
        private List<byte> selectedAnwser;

        public QuizTextVC(MockManagementText dataText)
        {
            this.Title = "Ios Quiz";
            //string filename = "bg02.png";
            //UIImage image = UIImage.FromFile(filename);
            //image = image.Scale(View.Frame.Size);
            //this.View.BackgroundColor = UIColor.FromPatternImage(image);

            //_answers = dataText.Answers;
            _questionData = dataText;

            selectedAnwser = new List<byte>(10);

            for (int i = 0; i < 10; i++)
            {
                selectedAnwser.Add(0);
            }

        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        public override void ViewDidLoad()
        {
            QuestionPageQuestionWord = "Question";
            QuestionPageTypeOFQ1 = "Who is the main actor of this movie ?";
            //QuestionPageTypeOFQ2 = "Qui est le chanteur de cette chanson ?";
            //QuestionPageTypeOFQ3 = "D'où viens cette phrase ?";


            btnPrev = new UIButton();
            btnPrev.SetTitle("< " + "Previous", UIControlState.Normal);
            btnPrev.SetTitleColor(UIColor.White, UIControlState.Normal);
            btnPrev.BackgroundColor = UIColor.Orange;
            btnPrev.TranslatesAutoresizingMaskIntoConstraints = false;
            btnPrev.TouchUpInside += (sender, e) => { btnPrevNextAction((UIButton)sender); };

            btnNext = new UIButton();
            btnNext.SetTitle("Next" + " >", UIControlState.Normal);
            btnNext.SetTitleColor(UIColor.White, UIControlState.Normal);
            btnNext.BackgroundColor = UIColor.Purple;
            btnNext.TranslatesAutoresizingMaskIntoConstraints = false;
            btnNext.TouchUpInside += (sender, e) => { btnPrevNextAction((UIButton)sender); };

            lblQueNumber = new UILabel();
            lblQueNumber.Text = "0 / 0";
            lblQueNumber.TextColor = UIColor.White;
            lblQueNumber.TextAlignment = UITextAlignment.Left;
            lblQueNumber.Font = UIFont.SystemFontOfSize(16);
            lblQueNumber.TranslatesAutoresizingMaskIntoConstraints = false;

            lblScore = new UILabel();
            lblScore.Text = "0 / 0";
            lblScore.TextColor = UIColor.White;
            lblScore.TextAlignment = UITextAlignment.Right;
            lblScore.Font = UIFont.SystemFontOfSize(16);
            lblScore.TranslatesAutoresizingMaskIntoConstraints = false;

            CGSize size = new CGSize(View.Frame.Width, View.Frame.Height);

            var layout = new UICollectionViewFlowLayout
            {
                SectionInset = new UIEdgeInsets(0, 0, 0, 0),
                MinimumInteritemSpacing = 0,
                MinimumLineSpacing = 0,
                ItemSize = size,
                ScrollDirection = UICollectionViewScrollDirection.Horizontal
            };

            if (model == "iPhone")
            {
                if (brand.Contains('X'))
                {
                    collectionView = new UICollectionView(new CGRect(0, 80, this.View.Frame.Width, this.View.Frame.Height), layout);
                }
                else
                {
                    collectionView = new UICollectionView(new CGRect(0, 60, this.View.Frame.Width, this.View.Frame.Height), layout);
                }
            }
            else
            {
                collectionView = new UICollectionView(new CGRect(0, 60, this.View.Frame.Width, this.View.Frame.Height), layout);
            }

            //collectionView = new UICollectionView(new CGRect(0, 60, this.View.Frame.Width, this.View.Frame.Height), layout);
            collectionView.DataSource = this;
            collectionView.ContentMode = UIViewContentMode.Center;
            collectionView.ShowsVerticalScrollIndicator = false;
            collectionView.RegisterClassForCell(typeof(QuizTextCellVC), QuizTextCellVC.CellId);
            collectionView.PagingEnabled = true;
            collectionView.BackgroundColor = UIColor.Clear;

            this.View.AddSubview(collectionView);
            this.View.AddSubview(btnPrev);
            this.View.AddSubview(btnNext);
            this.View.AddSubview(lblQueNumber);
            this.View.AddSubview(lblScore);

        }
        

        public override void ViewDidLayoutSubviews()
        {
            collectionView.TopAnchor.ConstraintEqualTo(this.View.TopAnchor).Active = true;
            collectionView.LeftAnchor.ConstraintEqualTo(this.View.LeftAnchor).Active = true;
            collectionView.RightAnchor.ConstraintEqualTo(this.View.RightAnchor).Active = true;
            collectionView.BottomAnchor.ConstraintEqualTo(this.View.BottomAnchor).Active = true;

            btnPrev.HeightAnchor.ConstraintEqualTo(50).Active = true;
            btnPrev.WidthAnchor.ConstraintEqualTo(this.View.WidthAnchor, 0.5f).Active = true;
            btnPrev.LeftAnchor.ConstraintEqualTo(this.View.LeftAnchor).Active = true;
            btnPrev.BottomAnchor.ConstraintEqualTo(this.View.BottomAnchor, 0).Active = true;

            btnNext.HeightAnchor.ConstraintEqualTo(btnPrev.HeightAnchor).Active = true;
            btnNext.WidthAnchor.ConstraintEqualTo(btnPrev.WidthAnchor).Active = true;
            btnNext.RightAnchor.ConstraintEqualTo(this.View.RightAnchor).Active = true;
            btnNext.BottomAnchor.ConstraintEqualTo(this.View.BottomAnchor, constant: 0).Active = true;


            lblQueNumber.HeightAnchor.ConstraintEqualTo(20).Active = true;
            lblQueNumber.WidthAnchor.ConstraintEqualTo(150).Active = true;
            lblQueNumber.LeftAnchor.ConstraintEqualTo(this.View.LeftAnchor, 20).Active = true;
            lblQueNumber.BottomAnchor.ConstraintEqualTo(this.View.BottomAnchor, -120).Active = true;
            lblQueNumber.Text = "Question" + $": { currentQuestionNumber}/ {_questionData.FullQuestionList.Count()}";


            lblScore.HeightAnchor.ConstraintEqualTo(lblQueNumber.HeightAnchor).Active = true;
            lblScore.WidthAnchor.ConstraintEqualTo(lblQueNumber.WidthAnchor).Active = true;
            lblScore.RightAnchor.ConstraintEqualTo(this.View.RightAnchor, -20).Active = true;
            lblScore.BottomAnchor.ConstraintEqualTo(lblQueNumber.BottomAnchor).Active = true;
            lblScore.Text = $"Score: {_answers.Count(x => x.IsCorrectAnswer)}/{_answers.Count(x => x.IsAnswered)}";

        }
        private void btnPrevNextAction(UIButton sender)
        {
            if (sender == btnNext && currentQuestionNumber == 5)
            {
                Completed(currentQuestionNumber);
                return;
            }

            var collectionBounds = this.collectionView.Bounds;
            float contentOffset = 0;
            if (sender == btnNext)
            {
                contentOffset = (float)Math.Floor(this.collectionView.ContentOffset.X + collectionBounds.Size.Width);
                currentQuestionNumber += currentQuestionNumber >= _questionData.FullQuestionList.Count() ? 0 : 1;
            }
            else
            {
                if (currentQuestionNumber > 1)
                {
                    contentOffset = (float)Math.Floor(this.collectionView.ContentOffset.X - collectionBounds.Size.Width);
                    currentQuestionNumber -= currentQuestionNumber <= 0 ? 0 : 1;
                }
            }
            lblQueNumber.Text = "Question" + $": { currentQuestionNumber}/ {_questionData.FullQuestionList.Count()}";
            int total = _answers.Count;
            int score = _answers.Count(x => x.IsCorrectAnswer);
            lblScore.Text = $"Score: {_answers.Count(x => x.IsCorrectAnswer)}/{_answers.Count(x => x.IsAnswered)}";

            MoveToFrame(contentOffset);
        }

        private void Completed(int currentQuestionNum)
        {
            int total = 5;
            if (currentQuestionNum != total)
                return;

            int finished = _answers.Count(x => x.IsAnswered);
            if (finished == total)
            {
                //FinalTextVC final = new FinalTextVC(_answers);
                //final.Answers = _answers;
                //NavigationController.PushViewController(final, true);

                var okAlertController = UIAlertController.Create("Congratulation", "You have finished the game", UIAlertControllerStyle.Alert);

                //Add Action
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                // Present Alert
                PresentViewController(okAlertController, true, null);

            }
        }

        private void MoveToFrame(float contentOffset)
        {
            var frame = new CGRect(contentOffset, this.collectionView.ContentOffset.Y, this.collectionView.Frame.Width, this.collectionView.Frame.Height);
            this.collectionView.ScrollRectToVisible(frame, true);

        }
        private void SetQuestionNumber()
        {
            var x = collectionView.ContentOffset.X;
            var w = collectionView.Bounds.Size.Width;
            var currentPage = (int)Math.Ceiling(x / w);
            if (currentPage < 5)
            {
                lblQueNumber.Text = "Question" + $": { currentQuestionNumber}/ {_questionData.FullQuestionList.Count()}";
                currentQuestionNumber = currentPage + 1;
            }
        }

        public nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return _questionData.FullQuestionList.Count();
        }

        public UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell(QuizTextCellVC.CellId, indexPath) as QuizTextCellVC;
            cell.UpdateCell(_questionData, indexPath.Row, QuestionPageTypeOFQ1, selectedAnwser[indexPath.Row]);
            cell.CellData += CellDataUpdated;
            return cell;
        }

        void CellDataUpdated(object sender, CellDataUpdateEventArgs e)
        {
            Answer cellAnswer = e.CurrentAnswer;
            int index = e.Index;
            _index = index;
            currentQuestionNumber = index + 1;
            lblQueNumber.Text = "Question" + $": { currentQuestionNumber}/ {_questionData.FullQuestionList.Count()}";
        }

        [Export("scrollViewDidEndDecelerating:")]
        public void DecelerationEnded(UIScrollView scrollView)
        {
            System.Diagnostics.Debug.WriteLine(scrollView.ContentOffset.Y.ToString());
        }
    }
}