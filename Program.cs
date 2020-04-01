using System;
using CodingCampusCSharpHomework;

namespace HomeworkTemplate
{
    class Program
    {
        static readonly char LIVE = '1';
        static readonly char DEAD = '0';


        static void Main(string[] args)
        {
            Func<Task4, char[,]>TaskSolver = task =>
            {
                // Your solution goes here
                // You can get all needed inputs from task.[Property]
                // Good luck!
                char[,] board = task.Board;
                int rowNum = board.GetLength(0);
                int coloumnNum = board.GetLength(1);

                char[,] newBoard = new char[rowNum, coloumnNum];

                NextBoard(board, newBoard);

                return newBoard;
            };

            Task4.CheckSolver(TaskSolver);
        }

        static void NextBoard(char[,] oldBoard, char[,] newBoard)
        {
            int rowNum = oldBoard.GetLength(0);
            int coloumnNum = oldBoard.GetLength(1);
            for(int row = 0; row < rowNum; ++row)
            {
                for (int col = 0; col < coloumnNum; ++col)
                {
                    newBoard[row, col] = CheckNeigbords(oldBoard, row, col);
                }
            }
        }

        static char CheckNeigbords(char[,] board, int row, int col)
        {
            int begColPos = (col == 0) ? col : col - 1;
            int endColPos = (col == board.GetLength(1) - 1) ? col : col + 1;
            int begRowPos = (row == 0) ? row : row - 1;
            int endRowPos = (row == board.GetLength(0) - 1) ? row : row + 1;

            int liveNum = 0;
            int deadNum = 0;
            for(int i = begRowPos; i <= endRowPos; ++i)
            {
                for (int j = begColPos; j <= endColPos; ++j)
                {
                    if (i == row && j == col)
                    {
                        continue;
                    }
                    if (board[i,j] == LIVE)
                    {
                        ++liveNum;
                    }
                    else
                    {
                        ++deadNum;
                    }
                }
            }
            if (board[row,col] == LIVE)
            {
                if(liveNum < 2 || liveNum > 3)
                {
                    return DEAD;
                }
                return LIVE;
            }
            else
            {
                if (liveNum == 3)
                {
                    return LIVE;
                }
                return DEAD;
            }
        }
    }
}
