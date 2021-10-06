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
        private int _currentTurn;
        private char[,] _board;

        /// <summary>
        /// Initializes player tokens and the game board
        /// </summary>
        public void Start()
        {
            _player1token = 'x';
            _player2token = 'o';
            ClearBoard();
        }

        /// <summary>
        /// Gets the Input of the player.
        /// Sets the player token at the desired spot in the 2D array.
        /// Checks if there is a winner.
        /// Changes the current token in play.
        /// </summary>
        public void Update()
        {
            //Gets the player's input
            int input = Game.GetInput();

            //Checks if token can be set at the input, then if true, sets the token
            if (!SetToken(_currentToken, (input - 1) / 3, (input - 1) % 3))
                //returns if false
                return;

            //If a player won, or if there is a tie
            if (CheckWinner(_currentToken))
                return;
            
            //Else change the player
            else
            {
                //If player 1 went
                if (_currentToken == _player1token)
                    //Make it player 2's turn
                    _currentToken = _player2token;
                //If player 2 went
                else
                    //Make it player 1's turn
                    _currentToken = _player1token;
                //Increments turn count
                _currentTurn++;
            }
        }


        /// <summary>
        /// Draws the board and let's the player know whose turn it is.
        /// </summary>
        public void Draw()
        {
            Console.WriteLine("Its " + _currentToken + "'s Turn.");
            Console.WriteLine(_board[0, 0] + "|" + _board[0, 1] + "|" + _board[0, 2] + "\n" +
                              "------\n" +
                              _board[1, 0] + "|" + _board[1, 1] + "|" + _board[1, 2] + "\n" +
                              "------\n" +
                              _board[2, 0] + "|" + _board[2, 1] + "|" + _board[2, 2] + "\n");
            if (CheckWinner(_currentToken))
            {
                Console.ReadKey(true);
                Game.SetScene(2);
                return;
            }
        }

        public void End()
        {
            Console.WriteLine("One of you did very well today.");
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
            //Checks the bounds
            if (posX > _board.GetLength(0) || posX < 0)
                return false;
            if (posY > _board.GetLength(1) || posX < 0)
                return false;

            //Checks if player is placing if a open position
            if (_board[posX, posY] == 'x' || _board[posX, posY] == 'o')
            {
                Console.WriteLine("You cannot place there.");
                Console.ReadKey(true);
                return false;
            }

            _board[posX, posY] = token;
            return true;
        }

        /// <summary>
        /// Check to see if a player has won
        /// </summary>
        /// /// <param name="token">The current player</param>
        /// <returns></returns>
        public bool CheckWinner(char token)
        {
            int matchCount;
            //Check if the player wins horizontally
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                matchCount = 0;
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j] == token)
                        matchCount++;
                    else
                        break;
                }
                if (matchCount == 3)
                {
                    Console.WriteLine(token + " wins!");
                    return true;
                }
            }

            //Check if the player wins vertically
            for (int i = 0; i < _board.GetLength(1); i++)
            {
                matchCount = 0;
                for (int j = 0; j < _board.GetLength(0); j++)
                {
                    if (_board[j, i] == token)
                        matchCount++;
                    else
                        break;
                }
                if (matchCount == 3)
                {
                    Console.WriteLine(token + " wins!");
                    return true;
                }
            }

            //Checks if player wins diagonally
            if (_board[0, 0] == token && _board[1, 1] == token && _board[2, 2] == token)
            {
                Console.WriteLine(token + " wins!");
                return true;
            }
            else if (_board[0, 2] == token && _board[1, 1] == token && _board[2, 0] == token)
            {
                Console.WriteLine(token + " wins!");
                return true;
            }

            if(_currentTurn == 10)
            {
                Console.WriteLine("Its a draw");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Clears the board for a new game
        /// </summary>
        public void ClearBoard()
        {
            _currentToken = _player1token;
            _currentTurn = 1;
            _board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        }
    }
}
