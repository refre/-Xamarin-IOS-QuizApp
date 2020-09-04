using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace QuizApp.ViewController
{
    public class QuizTextCellVC: UIViewController, IUICollectionViewDataSource, IUICollectionViewDelegate,
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
        private List<QuestionMBText> _questionData;
        private string QuestionPageQuestionWord, QuestionPageTypeOFQ1, QuestionPageTypeOFQ2, QuestionPageTypeOFQ3;
        private readonly string model = UIDevice.CurrentDevice.Model;
        private readonly string brand = UIDevice.CurrentDevice.Name;
        private List<byte> selectedAnwser;
        public QuizTextCellVC()
        {
            NavigationItem.HidesBackButton = true;
        }

        public UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            throw new NotImplementedException();
        }

        public nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            throw new NotImplementedException();
        }
    }
}