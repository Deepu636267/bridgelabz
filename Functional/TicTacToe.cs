// --------------------------------------------------------------------------------------------------------------------
// <copyright file=TicTacToe.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Functional
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class TicTacToe
    {
        int player = 1;
        private  char[,] board = new char[3,3];
        private  char computerMarker = 'o';
        private char UserMarker = 'x';
        Utility util = new Utility();
        public void play()
        {
            char ch = 'n';
            do
            {
                Console.WriteLine("Welcome To the TicTacToe Game:");
                Console.WriteLine("You have played against the computer and computer has first play then you have play");
                Console.WriteLine("Please Enter Your Name");
                string User = util.InputString();
                Console.WriteLine("hi " + User + " your marker is; " + UserMarker);
                //intializ board
                char[] counter = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                int k = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        board[i, j] = counter[k++];
                    }
                }
                display(board);
                //Play the Game
                for (int i = 0; i < 5; i++)
                {

                    Console.WriteLine("Computer turn");
                    player = 1;
                    putVal();
                    display(board);
                    if (i == 4)
                        break;
                    if (i >= 1)
                    {
                        if (winner())
                        {

                            Console.WriteLine(" Winner comuter");
                            break;


                        }
                    }

                    Console.WriteLine(User + "Turn" + "Marker" + UserMarker);
                    Console.WriteLine();
                    char choice = Convert.ToChar(Console.ReadLine());
                    replace(board, choice, UserMarker);
                    display(board);
                    if (winner())
                    {
                       Console.WriteLine(" Winner user");
                        break;
                    }
                }
                if (winner())
                {
                    Console.WriteLine("Winner");
                }
                else
                    Console.WriteLine("Draw");
            } while (ch=='y');
        }
        /// <summary>
        /// Displays the specified board.
        /// </summary>
       /// <param name="board">The board.</param>
       static void display(char[,] board)
       {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
        /*  void ComputerTurn(char computerMarker)
         {
             int computerSpot = 0;
             do
             {
                 Random rand = new Random();
                 computerSpot = (int)(rand.NextDouble()*9)+1;

             } while ((board[(computerSpot - 1) / 3,(computerSpot - 1) % 3] == 'x') || (board[(computerSpot - 1) / 3,(computerSpot - 1) % 3] == 'o'));
             board[(computerSpot - 1) / 3,(computerSpot - 1) % 3] = computerMarker;
         }*/
        /// <summary>
        /// Puts the value for computer turn.
        /// </summary>
        void putVal()
        {
            int i = 0; ;
            int j = 0;
            if (player % 2 == 1)
            {
                Random rand = new Random();
                i = (int)(rand.NextDouble() * 9) + 1;
                j = (int)(rand.NextDouble() * 9) + 1;
            }
            i = (i - 1) / 3;
            j = (j - 1) % 3;
            ////check for row to increse chances win for computer
            int f = checkWin();
            if (f != -1)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (board[f, k] != 'o' && board[f, k] != 'x')
                    {
                        board[f, k] = 'o';
                        return;
                    }
                }
            }
            ////check for column to increse chances win for computer
            else
            {
                int f1 = checkWin1();
                if (f1 >= 0)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (board[k, f1] != 'o' && board[k, f1] != 'x')
                        {
                            board[k, f1] = 'o';
                            return;

                        }
                    }
                }
              // else if(checkWin2())
                //{ return; }
            }
            ////if not making any chance to win then put
            if (board[i, j] != 'x' && board[i, j] != 'o')
            {
                board[i, j] = 'o';
            }
            ////if the position will be occupied
            else
                putVal();
        }
        /// <summary>
        /// Checks the row for counting that can have 2 position will be filled by computer then put the third one to win.
        /// </summary>
        /// <returns></returns>
        int checkWin()
        {
            int count = 0;
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<3;j++)
                {
                    if (board[i, j] == 'o')
                    {
                        count++;
                    }
                }
                if(count==2)
                {
                    return i;
                }
                else
                {
                    count = 0;
                }
            }
            return -1;
        }
        /// <summary>
        ///  Checks the column for counting that can have 2 position will be filled by computer then put the third one to win.
        /// </summary>
        /// <returns></returns>
        int checkWin1()
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[j, i] == 'o')
                    {
                        count++;
                    }
                }
                if (count == 2)
                {
                    return i;
                }
                else
                {
                    count = 0;
                }
            }
            return -1;
        }
        /// <summary>
        ///  Checks the diagonal for counting that can have 2 position will be filled by computer then put the third one to win..
        /// </summary>
        /// <returns></returns>
      /*  bool checkWin2()
        {
            int count = 0;
            for(int i=0,j=0;i<3;i++,j++)
            {
                if (board[i, j] == 'o')
                    count++;
                if (count == 2)
                {
                    board[i,j]='o';
                    return true;
                }
            }
            for(int i=0,j=2;i<3;i++,j--)
            {
                if(board[i,j]=='o')
                {
                    count++;
                    if (count == 2)
                    {
                        board[i, j] = 'o';
                        return true;
                    }
                }
            }
            return false;
        }*/
        /// <summary>
        /// Winners this instance to check who will be win.
        /// </summary>
        /// <returns></returns>
        bool winner()
        {
            return (checkforRow() || checkforColumn() || checkforDiagonal());
        }
        /// <summary>
        /// Checkfors the row win.
        /// </summary>
        /// <returns></returns>
        bool checkforRow()
        {
            for (int i = 0; i < 3; i++)
            {
                if (check(board[i,0], board[i,1], board[i,2]) == true)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Checkfors the column win.
        /// </summary>
        /// <returns></returns>
        bool checkforColumn()
        {
            for (int i = 0; i < 3; i++)
            {
                if (check(board[0,i], board[1,i], board[2,i]) == true)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Checkfors the diagonal win.
        /// </summary>
        /// <returns></returns>
        bool checkforDiagonal()
        {

            if (check(board[0,0], board[1,1], board[2,2]) == true || check(board[0,2], board[1,1], board[2,0]) == true)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Checks the specified all upper method win for row column diagonal.
        /// </summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="c3">The c3.</param>
        /// <returns></returns>
        bool check(char c1, char c2, char c3)
        {
            if (c1 == c2 && c2 == c3)
                return true;
            else
                return false;
        }
         void replace(char[,] board, char choice, char UserMarker)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i,j] == choice)
                    {
                        board[i,j] = UserMarker;
                        return;
                    }
                }
            }
         }
    }
}