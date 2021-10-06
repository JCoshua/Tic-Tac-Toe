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
            Console.WriteLine(_board[0, 0] + "|" + _board[0, 1] + "|" + _board[0, 2] + "\n" +
                              "------\n" +
                              _board[1, 0] + "|" + _board[1, 1] + "|" + _board[1, 2] + "\n" +
                              "------\n" +
                              _board[2, 0] + "|" + _board[2, 1] + "|" + _board[2, 2] + "\n");
            //If a player wins
            if (CheckWinner(_currentToken))
            {
                //Display the restart menu
                Console.ReadKey(true);
                Game.SetScene(2);
                return;
            }
            else
                Console.WriteLine("\nIts " + _currentToken + "'s Turn.");
        }

        /// <summary>
        /// The End Screen displayed before the application closes
        /// </summary>
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
            //Checks if position is within the bounds
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

            //Places the token on the board
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
           //The Super Loop
           //Checks if the current player wins
            for (int i = 0; i < 3; i++)
            {
                //Break Checks
                bool horizontalBreak = false;
                bool verticalBreak = false;
                bool diagonalBreak = false;
                bool reverseDiagonalBreak = false;
                //Token Counters
                int verticalCount = 0;
                int horizontalCount = 0;
                int diagonalCount = 0;
                int reverseDiagonalCount = 0;
                //The value to check the reverse Diagonal
                int reversej = 2;
                
                for (int j = 0; j < 3; j++)
                {

                    //Check if the player wins horizontally
                    //If the horizontal check has not broken
                    if (!horizontalBreak)
                    {
                        //If the spot has the Player's token
                        if (_board[i, j] == token)
                            //increment the counter
                            horizontalCount++;
                        else
                            //break the Check
                            horizontalBreak = true;
                    }


                    //Check if the player wins vertically
                    //If the vertical check has not broken
                    if (!verticalBreak)
                    {
                        //If the spot has the Player's token
                        if (_board[j, i] == token)
                            //increment the counter
                            verticalCount++;
                        else
                            //break the Check
                            verticalBreak = true;
                    }


                    //Check if the player wins diagonally
                    //If the diagonal check has not broken
                    if (!diagonalBreak)
                    {
                        //If the spot has the Player's token
                        if (_board[j, j] == token)
                            //increment the counter
                            diagonalCount++;
                        else
                            //Break the Check
                            diagonalBreak = true;
                    }


                    //Check if the player wins backwards diagonally
                    //If the backwards diagonal check has not broken
                    if (!reverseDiagonalBreak)
                    {
                        if (_board[j, reversej] == token)
                        {
                            //increment the counter
                            reverseDiagonalCount++;
                            //decrement the reversej value
                            reversej--;
                        }
                        else
                            //break the Check
                            reverseDiagonalBreak = true;
                    }
                    

                    //if all breaks are true
                    if (horizontalBreak == true && verticalBreak == true && diagonalBreak == true && reverseDiagonalBreak == true)
                        //break the loop
                        break;
                }

                //If there was a 3-in-a-row
                if (horizontalCount == 3 || verticalCount == 3 || diagonalCount == 3 || reverseDiagonalCount == 3)
                {
                    //The player wins
                    Console.WriteLine(token + " wins!");
                    return true;
                }
            }

            //If the current turn is ten
            if(_currentTurn == 10)
            {
                //End in a Draw
                Console.WriteLine("Its a draw");
                return true;
            }

            //IF none of the above are true, return false
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
