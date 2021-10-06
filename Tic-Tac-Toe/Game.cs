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

        public static int GetInput()
        {
            int choice = -1;
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

        public static void EndApplication()
        {
            _gameOver = true;
        }

        public static void SetScene(int index)
        {
            _currentSceneIndex = index;
        }

        public void RestartScreen()
        {
            Console.Clear();
            Console.WriteLine("Do you want to play again\n" +
                "1. Yes\n2. No\n");
            int input = GetInput();
            if (input == 1)
                SetScene(1);
                _gameBoard.ClearBoard();
            if (input == 2)
                Game.EndApplication();
        }
    }
}
