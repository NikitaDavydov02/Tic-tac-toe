using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КрестикиНолики.Model
{
    class VirtualBoard
    {

        public int[,] field { get; private set; }
        public int IndexOfMover { get; private set; }
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
        public VirtualBoard()
        {
            IndexOfMover = 1;
            IndexOfComputer = 1;
            field = new int[3, 3];
            remeberedIndexes = new List<int>();
            rememberedPositions = new List<int[,]>();
        }
        public List<int> FindEnableFields()
        {
            List<int> toReturn = new List<int>();
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    if (field[x, y] == 0)
                        toReturn.Add(10 * x + y);
            return toReturn;
        }
        public bool MakeOneMove(int x, int y)
        {
            if (!AddControl(x, y))
                return true;
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
        private List<int> remeberedIndexes;
        public List<int[,]> rememberedPositions;
        public void RememberPosition()
        {
            remeberedIndexes.Add(IndexOfMover);
            int[,] board = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int a = 0; a < 3; a++)
                    board[i, a] = field[i, a];
            rememberedPositions.Add(board);
        }
        public void ComeBack(int deepOfPosition)
        {
            IndexOfMover = remeberedIndexes[deepOfPosition - 1];
            remeberedIndexes.RemoveAt(deepOfPosition - 1);
            field = rememberedPositions[deepOfPosition - 1];
            rememberedPositions.RemoveAt(deepOfPosition - 1);
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
                    if (y == 0)
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
    }
}
