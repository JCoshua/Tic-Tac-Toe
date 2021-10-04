using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Board
    {
        private char _player1token;
        private char _player2token;
        private char _currentToken;
        private char[,] _board;

        /// <summary>
        /// Initializes player tokens and the game board
        /// </summary>
        public void Start()
        {
            _player1token = 'x';
            _player2token = 'o';
            _currentToken = _player1token;
            _board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        }

        /// <summary>
        /// Dets the Input of the player.
        /// Sets the player token at the desired spot in the 2D array
        /// Checks if there is a winner.
        /// Changes the current token in play
        /// </summary>
        public void Update()
        {
            if (_currentToken == _player1token)
                _currentToken = _player2token;
            else
                _currentToken = _player1token;
            Console.ReadKey(true);
        }


        /// <summary>
        /// Draws the board and lest's the player know whose turn it is.
        /// </summary>
        public void Draw()
        {
            Console.WriteLine("Its " + _currentToken + "'s Turn.");
            Console.WriteLine(_board[0, 0] + "|" + _board[0, 1] + "|" + _board[0, 2] + "\n" +
                              "------\n" +
                              _board[1, 0] + "|" + _board[1, 1] + "|" + _board[1, 2] + "\n" +
                              "------\n" +
                              _board[2, 0] + "|" + _board[2, 1] + "|" + _board[2, 2] + "\n");
        }

        public void End()
        {

        }

        /// <summary>
        /// Assigns the spot at the given indices in the board array to be the given token
        /// </summary>
        /// <param name="token">The token to place</param>
        /// <param name="posX">The row the token will be placed at</param>
        /// <param name="posY">The column the token will be placed at</param>
        /// <returns>Returns False if the indices are out of range</returns>
        public bool SetToken(char token, int posX, int posY)
        {
            if (posX > _board.GetLength(0))
                return false;
            if (posY > _board.GetLength(1))
                return false;

            _board[posX, posY] = token;
            return true;
        }

        /// <summary>
        /// Check to see if a player has won
        /// </summary>
        /// /// <param name="token"></param>
        /// <returns></returns>
        private bool CheckWinner(char token)
        {
            return false;
        }

        private void ClearBoard()
        {

        }
    }
}
