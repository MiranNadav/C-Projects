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
        private Board m_PlayingBoard;
        private PossibleMoves m_PossibleMoves;
        private MatchInformation m_PointsCalculator;
        private PlayerMove m_CurrentMove;
        private bool m_StartNewMatch = false;

        public static void Main()
        {
            GameManager gameManager = new GameManager();
            gameManager.initializeMatch();
        }

        public void initializeMatch()
        {
            string boardSize;
            string firstUserName;
            string numOfPlayers;
            //Player firstPlayer;
            //Player Computer;


            firstUserName = getInputNameFromUser();

            Console.WriteLine("Please enter a valid board size (6,8,10):");
            boardSize = Console.ReadLine();
            while (!InputValidation.ValidateBoardSizeInput(boardSize))
            {
                Console.WriteLine("Board size is invalid. Please enter one of the following: 6/8/10");
                boardSize = Console.ReadLine();
            }

            m_FirstPlayer = new Player(firstUserName, 'O', int.Parse(boardSize));

            Console.WriteLine("Write 1 if you want to play against the computer, 2 if you want to play vs another player:");
            numOfPlayers = Console.ReadLine();
            while (!int.TryParse(numOfPlayers, out int numOfPlayers_int) || (!(numOfPlayers_int == 1) && !(numOfPlayers_int == 2)))
            {
                Console.WriteLine("The number of players can only be 1 or 2. Please enter one of the following");
                numOfPlayers = Console.ReadLine();
            }

            if (int.Parse(numOfPlayers) == 2)
            {
                m_SecondPlayer = new Player(getInputNameFromUser(), 'X', int.Parse(boardSize));
            }
            else
            {
                m_SecondPlayer = new Player(int.Parse(boardSize));
            }

            m_CurrentPlayer = m_FirstPlayer;

            m_PlayingBoard = new Board(int.Parse(boardSize));
            m_PlayingBoard.printBoard();
            m_PossibleMoves = new PossibleMoves(m_PlayingBoard);

            //// TO DELETE!!!!!!!!!
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Bc>Cd"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Ef>Fe"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Cd>De"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Gf>He"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("De>Ef"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Fg>Gf"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Ef>Fg"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Dg>Ef"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Cb>Bc"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Eh>Dg"));
            //m_PlayingBoard.printBoard();

            //// TO DELETE!!!!!!!!!

            matchManager(m_PlayingBoard);

            //TODO: remove this 
            Console.ReadLine();
            Console.WriteLine("Press enter to close terminal");
        }
        private void startNewMatch()
        {
            int boardSize = m_PlayingBoard.BoardSize;
            m_PlayingBoard = new Board(boardSize);
            m_PlayingBoard.printBoard();
            m_PossibleMoves = new PossibleMoves(m_PlayingBoard);
            matchManager(m_PlayingBoard);
        }
        private string getInputNameFromUser()
        {
            Console.WriteLine("Please enter your name:");
            string inputName = Console.ReadLine();
            while (!InputValidation.IsInputNameValid(inputName))
            {
                Console.WriteLine("Your name is invalid! Please tell us your name.");
                inputName = Console.ReadLine();
            }
            return inputName;
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
            if (m_StartNewMatch)
            {
                startNewMatch();
            }
            else
            {
                endGameScreen();
            }
        }

        private void endGameScreen()
        {
            string gameWinnerName;
            int firstUserTotalPoints = this.m_FirstPlayer.TotalNumberOfPoints;
            int secondUserTotalPonts = this.m_SecondPlayer.TotalNumberOfPoints;
            currentStatePrinter();

            if (firstUserTotalPoints == secondUserTotalPonts)
            {
                Console.WriteLine("The game ended in a DRAW. GOODBYE");
            }
            else
            {
                gameWinnerName = firstUserTotalPoints > secondUserTotalPonts ? this.m_FirstPlayer.Name : this.m_SecondPlayer.Name;
                Console.WriteLine(gameWinnerName + " Has won the game!!! congratulations " + gameWinnerName, "you are the BEST. GOODBYE");
            }
        }

        private bool parseUserInput(Player i_CurrentPlayer, Player i_OtherPlayer)
        {
            bool isValidMove = false;
            string inputMove;
            bool currentMoveIsJump = false;
            bool gameIsOver = false;
            bool tryingToQuit = false;
            Coin currentCoin;
            ArrayList allPossibleJumps;
            //PointsCalculator pointsCalculator;

            m_PossibleMoves = new PossibleMoves(m_PlayingBoard);

            if (!i_CurrentPlayer.IsComputer)
            {
                inputMove = Console.ReadLine();

                while (!gameIsOver && (!isValidMove || (isValidMove && tryingToQuit)))
                {
                    tryingToQuit = InputValidation.IsTryingToQuit(inputMove);
                    if (tryingToQuit)
                    {
                        //pointsCalculator = new PointsCalculator(this.m_FirstPlayer, this.m_SecondPlayer, this.m_PlayingBoard);
                        this.m_PointsCalculator = new MatchInformation(this.m_FirstPlayer, this.m_SecondPlayer, this.m_PlayingBoard);
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
                        isValidMove = InputValidation.InputFormatIsValid(inputMove);
                        if (isValidMove)
                        {
                            this.m_CurrentMove = new PlayerMove(inputMove);
                            string errorMessage = Validation.IsLegalMovement(this.m_CurrentMove, m_PlayingBoard);
                            if (!errorMessage.Equals(String.Empty))
                            {
                                isValidMove = false;
                                Console.WriteLine(errorMessage);
                                inputMove = Console.ReadLine();
                            }
                            else
                            {
                                currentCoin = m_PlayingBoard.BoardArray[this.m_CurrentMove.CurrentRowIndex, this.m_CurrentMove.CurrentColIndex];
                                if (!MovementValidation.IsCoinBelongToPlayer(i_CurrentPlayer, currentCoin))
                                {
                                    Console.WriteLine("You are trying to move an opponents coin. Please enter a valid input.");
                                    inputMove = Console.ReadLine();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(ErrorMessageGenerator.FormatErrorMessage());
                            inputMove = Console.ReadLine();
                        }
                    }
                }
                this.m_CurrentMove = new PlayerMove(inputMove);
            }
            else
            {
                this.m_CurrentMove = RandomMovementGenerator.getRandomMove(m_PossibleMoves.SecondPlayerPossibleMoves);
            }
            Coin[,] boardArray = m_PlayingBoard.BoardArray;
            currentCoin = m_PlayingBoard.BoardArray[this.m_CurrentMove.CurrentRowIndex, this.m_CurrentMove.CurrentColIndex];


            if (!gameIsOver)
            {
                char currentUserCoinType = currentCoin.Type;

                m_PlayingBoard.MoveCoinInBoard(this.m_CurrentMove);

                if (shouldBeKinged())
                {
                    currentCoin.IsKing = true;
                }
                else
                {

                    currentMoveIsJump = currentCoin.IsKing == false ? Validation.IsTryingToJump(this.m_CurrentMove, currentUserCoinType) : KingValidation.isTryingToJump_King(this.m_CurrentMove);
                    if (currentMoveIsJump)
                    {
                        m_PlayingBoard.EatCoin(this.m_CurrentMove);
                        //calcUserPoints(i_OtherPlayer);

                        m_PossibleMoves = new PossibleMoves(m_PlayingBoard);
                        allPossibleJumps = m_PossibleMoves.getAllPossibleJumps(this.m_CurrentMove, currentUserCoinType);

                        while (allPossibleJumps.Count != 0)
                        {
                            Ex02.ConsoleUtils.Screen.Clear();
                            m_PlayingBoard.printBoard();

                            if (!i_CurrentPlayer.IsComputer)
                            {
                                Console.WriteLine(i_CurrentPlayer.Name + ", you can eat more. Please enter another move.");
                                inputMove = Console.ReadLine();
                                isValidMove = InputValidation.InputFormatIsValid(inputMove);
                                while (!isValidMove)
                                {
                                    Console.WriteLine(i_CurrentPlayer.Name + ", the input is invalid. enter a good move please");
                                    inputMove = Console.ReadLine();
                                    isValidMove = InputValidation.InputFormatIsValid(inputMove);
                                    this.m_CurrentMove = new PlayerMove(inputMove);
                                }
                                this.m_CurrentMove = new PlayerMove(inputMove);
                                if (!PossibleMoves.isJumpPossible(allPossibleJumps, this.m_CurrentMove))
                                {
                                    Console.WriteLine(i_CurrentPlayer.Name + ", the Move is not a valid jump. enter a good jump please");
                                    isValidMove = false;
                                }
                            }
                            else
                            {
                                this.m_CurrentMove = RandomMovementGenerator.getRandomMove(allPossibleJumps);
                            }

                            m_PlayingBoard.EatCoin(this.m_CurrentMove);
                            //calcUserPoints(i_OtherPlayer);
                            m_PlayingBoard.MoveCoinInBoard(this.m_CurrentMove);
                            allPossibleJumps = m_PossibleMoves.getAllPossibleJumps(this.m_CurrentMove, currentUserCoinType);
                        }
                    }
                }
            }

            Ex02.ConsoleUtils.Screen.Clear();
            if (!gameIsOver)
            {
                this.m_PointsCalculator = new MatchInformation(this.m_FirstPlayer, this.m_SecondPlayer, m_PlayingBoard);
                gameIsOver = this.m_PointsCalculator.IsWinnerFound();
                if (gameIsOver)
                {
                    endMatch();
                }
                else
                {
                    m_PlayingBoard.printBoard();
                    Console.WriteLine(i_CurrentPlayer.Name + "'s move was: " + this.m_CurrentMove.GetFullMove());
                    Console.WriteLine(i_OtherPlayer.Name + "'s Turn (" + i_OtherPlayer.CoinType + ") :");
                }
            }

            return gameIsOver;
        }

        private bool quitHandler(string i_PlayerName)
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
                endMatch();
            }
            else
            {
                Console.WriteLine(i_PlayerName + ", We are happy to see you are not a loser. Please enter your move");
            }

            return playerWantsToQuit;
        }

        private bool shouldBeKinged()
        {
            bool turnToKing = false;
            Coin[,] boardArray = this.m_PlayingBoard.BoardArray;
            Coin currentCoin = boardArray[this.m_CurrentMove.NextRowIndex, this.m_CurrentMove.NextColIndex];
            char currentPlayerCoinType = this.m_CurrentPlayer.CoinType;

            if (currentCoin.IsKing)
            {
                turnToKing = false;
            }
            else
            {
                if (currentPlayerCoinType.Equals('X'))
                {
                    turnToKing = this.m_CurrentMove.NextRowIndex == 0 ? true : false;
                }
                else
                {
                    turnToKing = this.m_CurrentMove.NextRowIndex == this.m_PlayingBoard.BoardSize - 1 ? true : false;
                }
            }
            return turnToKing;
        }

        private void endMatch()
        {
            calcTotalPoints();
            bool startNewMatch;
            string userInput;

            if (this.m_PointsCalculator.IsWinnerFound())
            {
                Console.WriteLine(this.m_PointsCalculator.MatchWinner.Name + ", you won the match!");
            }
            else
            {
                Console.WriteLine("The match ended in a draw");
            }

            currentStatePrinter();
            Console.WriteLine("Would you like to start a new match? please answer with Y/N");
            userInput = InputValidation.ValidYesOrNo();

            if (userInput.Equals("Y"))
            {
                startNewMatch = true;
            }
            else
            {
                startNewMatch = false;
            }

            this.m_StartNewMatch = startNewMatch;
        }

        private void calcTotalPoints()
        {
            //TODO: change the name of this class
            {
                this.m_PointsCalculator.MatchWinner.TotalNumberOfPoints = Math.Abs(this.m_PointsCalculator.FirstPlayerCurrentPoints - this.m_PointsCalculator.SecondPlayerCurrentPoints);
            }
        }

        private void currentStatePrinter()
        {
            Console.WriteLine(this.m_FirstPlayer.Name + "'s number of total points is: " + this.m_FirstPlayer.TotalNumberOfPoints);
            Console.WriteLine(this.m_SecondPlayer.Name + "s' number of total points is: " + this.m_SecondPlayer.TotalNumberOfPoints);
        }


    }
}
