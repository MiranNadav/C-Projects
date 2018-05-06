using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace B18_Ex02
{
    internal class InputValidation
    {
        public string getInputNameFromUser()
        {
            Console.WriteLine("Please enter your name:");
            string inputName = Console.ReadLine();

            while (!IsInputNameValid(inputName))
            {
                Console.WriteLine("Your name is invalid! Please tell us your name.");
                inputName = Console.ReadLine();
            }

            return inputName;
        }

        public string GetBoardSizeFromUser()
        {
            Console.WriteLine("Please enter a valid board size (6,8,10):");
            string boardSize = Console.ReadLine();

            while (!ValidateBoardSizeInput(boardSize))
            {
                Console.WriteLine(ErrorMessageGenerator.BoardSizeErrorMessage());
                boardSize = Console.ReadLine();
            }

            return boardSize;
        }

        public string GetNumOfPlayersFromUser()
        {
            Console.WriteLine("Write 1 if you want to play against the computer, 2 if you want to play vs another player:");
            string numOfPlayers = Console.ReadLine();

            while (!int.TryParse(numOfPlayers, out int numOfPlayers_int) || (!(numOfPlayers_int == 1) && !(numOfPlayers_int == 2)))
            {
                Console.WriteLine("The number of players can only be 1 or 2. Please enter one of the following");
                numOfPlayers = Console.ReadLine();
            }

            return numOfPlayers;
        }

        public bool IsTryingToQuit(string i_InputMove)
        {
            return i_InputMove.Equals(Constants.k_QuitAnswer);
        }

        public bool IsEmptyInput()
        {
            return false;
        }

        public bool InputFormatIsValid(string i_CurrentMove)
        {
            bool formatIsValid = true;
            Regex regex = new Regex(@"^[A-Z][a-z]>[A-Z][a-z]$");
            Match match = regex.Match(i_CurrentMove);

            if (!match.Success)
            {
                formatIsValid = false;
            }

            return formatIsValid;
        }

        public bool IsInputNameValid(string i_Name)
        {
            return (i_Name.Length > 0) && (i_Name.Length <= 20) && (!i_Name.Contains(" "));
        }

        public bool ValidateBoardSizeInput(string i_BoardSize)
        {
            bool boardSizeIsValid = true;

            if (!int.TryParse(i_BoardSize, out int integerBoardSize))
            {
                boardSizeIsValid = false;
            }
            else
            {
                if (integerBoardSize != 6 && integerBoardSize != 8 && integerBoardSize != 10)
                {
                    boardSizeIsValid = false;
                }
            }

            return boardSizeIsValid;
        }

        public string ValidYesOrNo()
        {
            string playerAnswer = Console.ReadLine();

            while (!playerAnswer.Equals(Constants.k_YesAnswer) && !playerAnswer.Equals(Constants.k_NoAnswer))
            {
                Console.WriteLine("Invalid answer. Please type Y or N");
                playerAnswer = Console.ReadLine();
            }

            return playerAnswer;
        }
    }
}
