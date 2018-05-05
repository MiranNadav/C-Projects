using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace B18_Ex02
{
    class GameManager
    {

        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private Player m_CurrentPlayer;
        private bool m_WinnerFound = false;
        private Board m_PlayingBoard;
        private PossibleMoves m_PossibleMoves;


        public void initializeMatch()
        {
            string boardSize;
            string firstUserName;
            string numOfPlayers;
            //Player firstPlayer;
            //Player Computer;

            Console.WriteLine("Please enter your name:");
            firstUserName = Console.ReadLine();
            while (firstUserName.Length == 0)
            {
                Console.WriteLine("Your name cannot be blank. Please tell us your name.");
                firstUserName = Console.ReadLine();
            }


            Console.WriteLine("Please enter a valid board size (6,8,10):");
            boardSize = Console.ReadLine();
            while (!Validation.ValidateBoardSizeInput(boardSize))
            {
                Console.WriteLine("Board size is invalid. Please enter one of the following: 6/8/10");
                boardSize = Console.ReadLine();
            }

            Console.WriteLine("Write 1 if you want to play against another player, 2 if you want to play vs the computer:");
            numOfPlayers = Console.ReadLine();
            while (!int.TryParse(numOfPlayers, out int numOfPlayers_int) || (!(numOfPlayers_int == 1) && !(numOfPlayers_int == 2)))
            {
                Console.WriteLine("The number of players can only be 1 or 2. Please enter one of the following");
                numOfPlayers = Console.ReadLine();
            }

            m_FirstPlayer = new Player(firstUserName, 'O', int.Parse(boardSize));
            m_SecondPlayer = new Player("Comp", 'X', int.Parse(boardSize));
            m_CurrentPlayer = m_FirstPlayer;

            m_PlayingBoard = new Board(int.Parse(boardSize));
            m_PlayingBoard.printBoard();
            m_PossibleMoves = new PossibleMoves(m_PlayingBoard);

            // TO DELETE!!!!!!!!!
            m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Bc>Cd"));
            m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Ef>Fe"));
            m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Cd>De"));
            m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Gf>He"));
            m_PlayingBoard.MoveCoinInBoard(new PlayerMove("De>Ef"));
            m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Fg>Gf"));
            m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Ef>Fg"));
            m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Dg>Ef"));
            m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Cb>Bc"));
            m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Eh>Dg"));
            m_PlayingBoard.printBoard();

            matchManager(m_PlayingBoard);
            // TO DELETE!!!!!!!!!


            //TODO: remove this 
            Console.WriteLine("Press enter to close terminal");
            Console.ReadLine();
        }

        private void matchManager(Board i_PlayingBoard)
        {
            //Board currentBoard = i_PlayingBoard;
            int boardSize = i_PlayingBoard.BoardSize;
            bool gameIsOver = false;
            bool isFirstUserTurn = true;
            //Coins firstUserCoins = i_FirstPlayer.GetCoins();
            //Coins secondUserCoins = i_SecondPlayer.GetCoins();

            Console.WriteLine(m_CurrentPlayer.Name + "'s turn:");

            while (!gameIsOver)
            {
                if (isFirstUserTurn)
                {
                    gameIsOver = parseUserInput(m_FirstPlayer, m_SecondPlayer);
                    isFirstUserTurn = false;
                }
                else
                {
                    gameIsOver = parseUserInput(m_SecondPlayer, m_FirstPlayer);
                    isFirstUserTurn = true;
                }
            }
        }

        private bool parseUserInput(Player i_CurrentPlayer, Player i_OtherPlayer)
        {
            bool isValidMove = false;
            string inputMove;
            PlayerMove currentMove;
            bool currentMoveIsJump = false;
            bool gameIsOver = false;
            bool tryingToQuit = false;
            Coin currentCoin;
            m_PossibleMoves = new PossibleMoves(m_PlayingBoard);


            inputMove = Console.ReadLine();

            while (!gameIsOver && (!isValidMove || (isValidMove && tryingToQuit)))
            {
                tryingToQuit = InputValidation.IsTryingToQuit(inputMove);
                if (tryingToQuit)
                {
                    //isValidMove = quitHandler(i_CurrentPlayer.Name);
                    if (quitHandler(i_CurrentPlayer.Name))
                    {
                        gameIsOver = true;
                    }
                    else
                    {
                        tryingToQuit = false;
                        inputMove = Console.ReadLine();
                    }
                }
                //Not Trying To QUIT
                else
                {
                    isValidMove = InputValidation.inputFormatIsValid(inputMove);
                    if (isValidMove)
                    {
                        currentMove = new PlayerMove(inputMove);
                        string errorMessage = Validation.IsLegalMovement(currentMove, m_PlayingBoard);
                        if (!errorMessage.Equals(String.Empty))
                        {
                            isValidMove = false;
                            Console.WriteLine(errorMessage);
                        }
                        if (!isValidMove)
                        {
                            inputMove = Console.ReadLine();
                        }
                    }
                    else
                    {
                        ErrorPrinter.FormatErrorMessage();
                        inputMove = Console.ReadLine();
                    }
                }
            }

            currentMove = new PlayerMove(inputMove);
            if (!gameIsOver)
            {
                Coin[,] boardArray = m_PlayingBoard.BoardArray;
                currentCoin = m_PlayingBoard.BoardArray[currentMove.CurrentRowIndex, currentMove.CurrentColIndex];
                char currentUserCoinType = currentCoin.Type;
                m_PlayingBoard.MoveCoinInBoard(currentMove);

                if (shouldBeKinged(currentMove, m_PlayingBoard, currentUserCoinType))
                {
                    currentCoin.IsKing = true;
                }

                currentMoveIsJump = currentCoin.IsKing == false ? Validation.IsTryingToJump(currentMove, currentUserCoinType) : KingValidation.isTryingToJump_King(currentMove);
                //if (currentMoveIsJump)
                while (currentMoveIsJump)
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    m_PlayingBoard.printBoard();
                    m_PlayingBoard.EatCoin(currentMove);
                    calcUserPoints(i_OtherPlayer);
                    m_PossibleMoves = new PossibleMoves(m_PlayingBoard);
                    ArrayList allPossibleJumps = m_PossibleMoves.getAllPossibleJumps(currentMove, currentUserCoinType);
                    if (allPossibleJumps.Count != 0)
                    {
                        Console.WriteLine(i_CurrentPlayer.Name + ", you can eat more. Please enter another move.");
                        inputMove = Console.ReadLine();
                        isValidMove = InputValidation.inputFormatIsValid(inputMove);
                        while (!isValidMove)
                        {
                            Console.WriteLine(i_CurrentPlayer.Name + ", the input is invalid. eneter a good move please");
                            inputMove = Console.ReadLine();
                            isValidMove = InputValidation.inputFormatIsValid(inputMove);
                            currentMove = new PlayerMove(inputMove);
                            if (!allPossibleJumps.Contains(currentMove))
                            {
                                Console.WriteLine(i_CurrentPlayer.Name + ", the Move is not a valid jump. eneter a good jump please");
                                isValidMove = false;
                            }
                        }
                    }
                }
            }

            Ex02.ConsoleUtils.Screen.Clear();
            if (!gameIsOver)
            {
                m_PlayingBoard.printBoard();
                Console.WriteLine(i_CurrentPlayer.Name + "'s move was: " + currentMove.GetFullMove());
                Console.WriteLine(i_OtherPlayer.Name + "'s Turn (" + i_OtherPlayer.CoinType + ") :");
            }

            return gameIsOver;
        }


        private bool isGameOverDueToQuit(string i_InputMove)
        {
            return InputValidation.IsTryingToQuit(i_InputMove) && quitHandler(m_CurrentPlayer.Name);

        }
        private static bool quitHandler(string i_PlayerName)
        {
            string playerAnswer;
            bool playerWantsToQuit = false;

            Console.WriteLine(i_PlayerName + ", Do You really want to quit? Y/N");
            playerAnswer = Console.ReadLine();

            while (!playerAnswer.Equals("Y") && !playerAnswer.Equals("N"))
            {
                Console.WriteLine("Invalid answer. Please type Y or N");
                playerAnswer = Console.ReadLine();
            }

            if (playerAnswer.Equals("Y"))
            {
                playerWantsToQuit = true;
            }
            else
            {
                Console.WriteLine(i_PlayerName + ", We are happy to see you are not a loser. Please enter your move");
            }

            return playerWantsToQuit;
        }

        private static bool shouldBeKinged(PlayerMove i_CurrentMove, Board i_CurrentBoard, char i_CurrentCoinType)
        {
            bool turnToKing = false;
            Coin[,] boardArray = i_CurrentBoard.BoardArray;
            Coin currentCoin = boardArray[i_CurrentMove.NextRowIndex, i_CurrentMove.NextColIndex];

            if (currentCoin.IsKing)
            {
                turnToKing = false;
            }
            else
            {
                if (i_CurrentCoinType.Equals('X'))
                {
                    turnToKing = i_CurrentMove.NextRowIndex == 0 ? true : false;
                }
                else
                {
                    turnToKing = i_CurrentMove.NextRowIndex == i_CurrentBoard.BoardSize - 1 ? true : false;
                }
            }

            return turnToKing;
        }

        private void calcUserPoints(Player i_CurrentPlayer)
        {
            int totalPoints = 0;
            ArrayList firstUserCoins = m_PlayingBoard.GetUserCoins(i_CurrentPlayer.CoinType);
            foreach (Coin coin in firstUserCoins)
            {
                totalPoints += coin.IsKing ? 4 : 1;
            }

            i_CurrentPlayer.Points = totalPoints;
        }
    }
}
