using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Game
    {
        public static bool _gameOver;
        private Board _gameBoard = new Board();

        /// <summary>
        /// Begins the Game
        /// </summary>
        public void Run()
        {
            Start();

            while(!_gameOver)
            {
                Draw();
                Update();
            }

            End();
        }

        /// <summary>
        /// Called when the game begins
        /// </summary>
        private void Start()
        {
            _gameBoard.Start();
        }

        /// <summary>
        /// Called every game loop
        /// </summary>
        private void Update()
        {
            _gameBoard.Update();
        }

        /// <summary>
        /// Updates the display to reflect any changes made while running
        /// </summary>
        private void Draw()
        {
            Console.Clear();
            _gameBoard.Draw();
        }

        /// <summary>
        /// Called when the game ends
        /// </summary>
        private void End()
        {
            _gameBoard.End();
        }

        public static int GetInput()
        {
            int choice = -1;
            while (choice == -1)
            {
                if (!int.TryParse(Console.ReadLine(), out choice))
                    choice = -1;
            }

            return choice;
        }
    }
}
