// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Gambler.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Functional
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// Gambler is class Where Play() is Method to Play the
    /// Game
    /// </summary>
    class Gambler
    {
        Utility utility = new Utility();
        /// <summary>
        /// Plays this instance.
        /// </summary>
        public void Play()
        {
            Console.WriteLine("Enter the Total Stake");
            int stake = utility.InputInteger();
            if (stake <= 0)
            {
                Console.WriteLine("Check Your Inputs and Enter In Positive Numbers");
            }
            Console.WriteLine("Enter the Goa what You want to acheeive");
            int goal = utility.InputInteger();
            if (goal <= 0)
            {
                Console.WriteLine("Check Your Inputs and Enter In Positive Numbers");
            }
            Console.WriteLine("Enter the number's How many Times You Want to Play?");
            int trials = utility.InputInteger();
            if (trials <= 0)
            {
                Console.WriteLine("Check Your Inputs and Enter In Positive Numbers");
            }
            int bets = 0;
            int win = 0;
            int loss = 0;
            int cash = 0;
            ////for loop is for To play Until to reach the Trials.
            for (int i = 0; i < trials; i++)
            {
                bets++;
                cash = stake;
                ////While loop is checking the cash should be greater then Zero and less then Goal
                while (cash > 0 && cash < goal)
                {
                    Random rand = new Random();
                    double val = rand.NextDouble();
                    if (val < 0.5)
                        cash++;
                    else
                        cash--;
                }
                ////if our cash is Equal to Goal then We will Win other wise loss
                if (cash == goal)
                    win++;
                else
                    loss++;
            }
            ////Finding the Wining Percentage and Loss Percentage
             int WinP = win * 100 / trials;
             int LossP = loss * 100 / trials;
             Console.WriteLine("Win of the Game is :" + win + " out of " + bets);
             Console.WriteLine("Winning Percentage is :" + WinP);
             Console.WriteLine("\nLoss of the Game is :" + loss + " out of " + bets);
             Console.WriteLine("Loss Percentage is :" + LossP);
        }
    }
}