using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КрестикиНолики.Model
{
    class KrestykyNolikyModel
    {
        private int[,] field;
        public int IndexOfMover { get; private set; }
        private VirtualBoard virtualBoard = new VirtualBoard();
        public int color
        {
            get
            {
                if (IndexOfMover == 1)
                    return 1;
                else
                    return 2;
            }
        }
        public int IndexOfComputer;
        public KrestykyNolikyModel()
        {
            IndexOfMover = 1;
            IndexOfComputer = 2;
            field = new int[3, 3];
        }
        public bool MakeOneMove(int x, int y)
        {
            if (!AddControl(x, y))
                return true;
            GameRecord++;
            virtualBoard.MakeOneMove(x, y);
            if (!CheckTheGame())
            {
                return false;
            }
            else
            {
                if (IndexOfMover == 1)
                {
                    IndexOfMover = 2;
                }
                else
                {
                    IndexOfMover = 1;
                }
                return true;
            }
        }
        public string GetColorOfWinner()
        {
            if (IndexOfMover == 1)
                return " крестики!";
            else
                return " нолики!";
        }
        public bool FieldIsFull()
        {
            for (int i = 0; i < 3; i++)
                for (int a = 0; a < 3; a++)
                {
                    if (field[i, a] == 0)
                        return false;
                }
            return true;
        }
        public bool CheckTheGame()
        {
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                {
                    //Horizontal check;
                    if (x == 0)
                    {
                        if ((field[x, y] == field[x + 1, y]) && (field[x + 2, y] == field[x + 1, y]) && field[x, y] != 0)
                            return false;
                    }
                    //Vertical check;
                    if (y ==0)
                    {
                        if ((field[x, y] == field[x, y + 1]) && (field[x, y + 2] == field[x, y + 1]) && (field[x, y] != 0))
                            return false;
                    }
                    //Diagonal right-bottom check;
                    if (x == 0 && y == 2)
                    {
                        if ((field[x, y] == field[x + 1, y - 1]) && (field[x + 2, y - 2] == field[x + 1, y - 1]) && (field[x, y] != 0))
                            return false;
                    }
                    //Diagonal right-top check;
                    if (x == 0 && y == 0)
                    {
                        if ((field[x, y] == field[x + 1, y + 1]) && (field[x + 2, y + 2] == field[x + 1, y + 1]) && (field[x, y] != 0))
                            return false;
                    }
                }
            return true;
        }
        public event EventHandler<ControlChangedEventArgs> ControlChanged;
        private void OnControlChanged(ControlChangedEventArgs args)
        {
            EventHandler<ControlChangedEventArgs> controlChanged = ControlChanged;
            if (controlChanged != null)
                controlChanged(this, args);
        }
        private bool AddControl(int x, int y)
        {
            if (field[x, y] != 0)
                return false;
            field[x, y] = color;
            OnControlChanged(new ControlChangedEventArgs(x, y, color));
            return true;
        }
        public int ToThinkAboutMove(out int y)
        {
            y = 0;
            int x = ToFindTheMostPowerfullMove(out y);
            return x;
        }
        int GameRecord = 0;
        private int ToFindTheMostPowerfullMove(out int y)
        {
            if (GameRecord == 0)
            {
                y = 1;
                return 1;
            }
            List<int> freeFields = virtualBoard.FindEnableFields();
            Dictionary<int, double> assessmentOfMoves = new Dictionary<int, double>();
            foreach (int variantOfMove in freeFields)
            {
                double assessment = ToAssesMove(variantOfMove, 1);
                assessmentOfMoves.Add(variantOfMove, assessment);
            }
            double theMostHightAssessment = -1;
            foreach (double assessment in assessmentOfMoves.Values)
            {
                if (assessment > theMostHightAssessment)
                    theMostHightAssessment = assessment;
            }
            foreach (int move in assessmentOfMoves.Keys)
            {
                if (assessmentOfMoves[move] == theMostHightAssessment)
                {
                    int x = 0;
                    y = 0;
                    if (move == 0)
                    {
                        x = 0;
                        y = 0;
                    }
                    if (move == 1)
                    {
                        x = 0;
                        y = 1;
                    }
                    if (move == 2)
                    {
                        x = 0;
                        y = 2;
                    }
                    if (move == 10)
                    {
                        x = 1;
                        y = 0;
                    }
                    if (move == 20)
                    {
                        x = 2;
                        y = 0;
                    }
                    if (move == 11)
                    {
                        x = 1;
                        y = 1;
                    }
                    if (move == 12)
                    {
                        x = 1;
                        y = 2;
                    }
                    if (move == 21)
                    {
                        x = 2;
                        y = 1;
                    }
                    if (move == 22)
                    {
                        x = 2;
                        y = 2;
                    }
                    return x;
                }
            }
            y = -1;
            return -1;
        }
        //y = move % 10;
        //int x = move - y;
        //return x;
        private double ToAssesMove(int move, int currentDeep)
        {
            int x = 0;
            int y = 0;
            if (move == 0)
            {
                x = 0;
                y = 0;
            }
            if (move == 1)
            {
                x = 0;
                y = 1;
            }
            if (move == 2)
            {
                x = 0;
                y = 2;
            }
            if (move == 10)
            {
                x = 1;
                y = 0;
            }
            if (move == 20)
            {
                x = 2;
                y = 0;
            }
            if (move == 11)
            {
                x = 1;
                y = 1;
            }
            if (move == 12)
            {
                x = 1;
                y = 2;
            }
            if (move == 21)
            {
                x = 2;
                y = 1;
            }
            if (move == 22)
            {
                x = 2;
                y = 2;
            }
            virtualBoard.RememberPosition();
            virtualBoard.MakeOneMove(x, y);
            if (!virtualBoard.CheckTheGame() && virtualBoard.IndexOfMover == IndexOfComputer)
            {
                virtualBoard.ComeBack(currentDeep);
                return 1 / (currentDeep * 0.6);
            }
            if (!virtualBoard.CheckTheGame() && virtualBoard.IndexOfMover != IndexOfComputer)
            {
                virtualBoard.ComeBack(currentDeep);
                return -1 / (currentDeep * 0.6);
            }
            if (virtualBoard.FieldIsFull())
            {
                virtualBoard.ComeBack(currentDeep);
                return 0;
            }
            List<int> freeColoumns = virtualBoard.FindEnableFields();
            Dictionary<int, double> assessmentsOfMoves = new Dictionary<int, double>();
            foreach (int coloumn in freeColoumns)
            {
                double assessment = ToAssesMove(coloumn, currentDeep + 1);
                assessmentsOfMoves.Add(coloumn, assessment);
            }
            //.
            virtualBoard.ComeBack(currentDeep);
            double amount = 0;
            foreach (double assess in assessmentsOfMoves.Values)
            {
                amount += assess;
            }
            double arithmeticMean = amount / assessmentsOfMoves.Keys.Count;
            return arithmeticMean;
        }
    }
}
