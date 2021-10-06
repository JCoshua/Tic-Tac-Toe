using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Game
    {
        private static bool _gameOver = false;
        private static int _currentSceneIndex = 1;
        private Board _gameBoard = new Board();

        /// <summary>
        /// Begins the Game
        /// </summary>
        public void Run()
        {
            Start();

            while (!_gameOver)
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
            switch (_currentSceneIndex)
            {
                case 1:
                    _gameBoard.Update();
                    break;
                case 2:
                    RestartScreen();
                    break;
            }

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

        /// <summary>
        /// A function to get the input of the player
        /// </summary>
        /// <returns>The player's choice</returns>
        public static int GetInput()
        {
            int choice = -1;
            //Loops while the player does not have a valid input
            while (choice == -1)
            {
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey(true);
                    choice = -1;
                }
            }
            return choice;
        }

        /// <summary>
        /// A function to end the Application
        /// </summary>
        public static void EndApplication()
        {
            _gameOver = true;
        }

        /// <summary>
        /// Sets the Games Scene
        /// </summary>
        /// <param name="index">The desired scene</param>
        public static void SetScene(int index)
        {
            //Sets the current screen to the desired scene
            _currentSceneIndex = index;
        }

        /// <summary>
        /// The Restart Screen
        /// </summary>
        public void RestartScreen()
        {
            Console.Clear();
            Console.WriteLine("Do you want to play again\n" +
                "1. Yes\n2. No\n");
            int input = GetInput();
            //IF Yes
            if (input == 1)
            {
                //Start a new game
                SetScene(1);
                _gameBoard.ClearBoard();
            }
            //If no
            else if (input == 2)
                //End Game
                Game.EndApplication();
        }
    }
}
