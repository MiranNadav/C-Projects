using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    public class PossibleMoves
    {
        private ArrayList m_FirstPlayerPossibleMoves = new ArrayList();
        private ArrayList m_SecondPlayerPossibleMoves = new ArrayList();
        private Board m_Board;
        private MovementValidation m_MovementValidation;

        public PossibleMoves(Board i_Board)
        {
            m_MovementValidation = new MovementValidation();
            this.m_Board = i_Board;
            Coin currentCoin;
            Coin[,] boardArray = m_Board.BoardArray;

            for (int i = 0; i < i_Board.BoardSize; i++)
            {
                for (int j = 0; j < i_Board.BoardSize; j++)
                {
                    currentCoin = boardArray[i, j];
                    if (currentCoin != null)
                    {
                        addValidMovesToBothArrays(currentCoin, new Square(j, i));
                    }
                }
            }
        }

        public ArrayList FirstPlayerPossibleMoves
        {
            get
            {
                return this.m_FirstPlayerPossibleMoves;
            }
        }

        public ArrayList SecondPlayerPossibleMoves
        {
            get
            {
                return this.m_SecondPlayerPossibleMoves;
            }
        }

        private void addValidMovesToBothArrays(Coin i_Coin, Square i_Square)
        {
            if (i_Coin.Type.Equals(Constants.k_FirstCoinType))
            {
                addValidMovesToFirstArray(i_Square, i_Coin.IsKing);
            }
            else
            {
                addValidMovesToSecondArray(i_Square, i_Coin.IsKing);
            }
        }

        private void addValidMovesToArray(Square i_Square, int i_Sign, ArrayList i_CurrentPlayerPossibleMoves)
        {
            addValidMoveToArray(i_Square, i_Sign * 1, 1, m_Board, i_CurrentPlayerPossibleMoves);
            addValidMoveToArray(i_Square, i_Sign * 1, -1, m_Board, i_CurrentPlayerPossibleMoves);
            addValidMoveToArray(i_Square, i_Sign * 2, 2, m_Board, i_CurrentPlayerPossibleMoves);
            addValidMoveToArray(i_Square, i_Sign * 2, -2, m_Board, i_CurrentPlayerPossibleMoves);
        }

        private void addValidMovesToFirstArray(Square i_Square, bool i_IsKing)
        {
            if (i_IsKing)
            {
                addValidMovesToArray(i_Square, -1, m_FirstPlayerPossibleMoves);
            }

            addValidMovesToArray(i_Square, 1, m_FirstPlayerPossibleMoves);
        }

        private void addValidMovesToSecondArray(Square i_Square, bool i_IsKing)
        {
            if (i_IsKing)
            {
                addValidMovesToArray(i_Square, 1, m_SecondPlayerPossibleMoves);
            }

            addValidMovesToArray(i_Square, -1, m_SecondPlayerPossibleMoves);
        }

        private void addValidMoveToArray(Square i_CurrentSquare, int i_RowToAdd, int i_ColumnToAdd, Board i_Board, ArrayList i_CurrentPlayerMoves)
        {
            PlayerMove currentMove;
            if (MovementValidation.movementIndexesInRange(i_CurrentSquare.ColumnIndex, i_CurrentSquare.RowIndex, i_CurrentSquare.ColumnIndex + i_ColumnToAdd, i_CurrentSquare.RowIndex + i_RowToAdd, i_Board.BoardSize))
            {
                currentMove = new PlayerMove(i_CurrentSquare, new Square(i_CurrentSquare.ColumnIndex + i_ColumnToAdd, i_CurrentSquare.RowIndex + i_RowToAdd));
                if (MovementValidation.IsLegalMovement(currentMove, i_Board).Equals(string.Empty))
                {
                    i_CurrentPlayerMoves.Add(currentMove);
                }
            }
        }

        public ArrayList getAllPossibleJumps(PlayerMove i_CurrentMove, char i_CoinType)
        {
            return i_CoinType.Equals(Constants.k_FirstCoinType) ? getAllPossibleJumps(i_CurrentMove, m_FirstPlayerPossibleMoves) : getAllPossibleJumps(i_CurrentMove, m_SecondPlayerPossibleMoves);
        }

        private ArrayList getAllPossibleJumps(PlayerMove i_CurrentMove, ArrayList i_CurrentPlayerPossibleMoves)
        {
            ArrayList allPossibleJumps = new ArrayList();
            foreach (PlayerMove move in i_CurrentPlayerPossibleMoves)
            {
                if (i_CurrentMove.NextSquare.Equals(move.CurrentSquare))
                {
                    if (Math.Abs(i_CurrentMove.NextColIndex - move.NextColIndex) == 2 && Math.Abs(i_CurrentMove.NextRowIndex - move.NextRowIndex) == 2)
                    {
                        allPossibleJumps.Add(move);
                    }
                }
            }

            return allPossibleJumps;
        }

        public ArrayList getAllPossibleJumps(Square i_CurrentSquare, char i_CoinType)
        {
            return i_CoinType.Equals(Constants.k_FirstCoinType) ? getAllPossibleJumps(i_CurrentSquare, m_FirstPlayerPossibleMoves) : getAllPossibleJumps(i_CurrentSquare, m_SecondPlayerPossibleMoves);
        }

        private ArrayList getAllPossibleJumps(Square i_CurrentSquare, ArrayList i_CurrentPlayerPossibleMoves)
        {
            ArrayList allPossibleJumps = new ArrayList();
            foreach (PlayerMove move in i_CurrentPlayerPossibleMoves)
            {
                if (i_CurrentSquare.Equals(move.CurrentSquare))
                {
                    if (Math.Abs(i_CurrentSquare.ColumnIndex - move.NextColIndex) == 2 && Math.Abs(i_CurrentSquare.RowIndex - move.NextRowIndex) == 2)
                    {
                        allPossibleJumps.Add(move);
                    }
                }
            }

            return allPossibleJumps;
        }

        public static bool isJumpPossible(ArrayList i_AllPossibleJumps, PlayerMove i_CurrentMove)
        {
            bool existsLegalJump = false;
            foreach (PlayerMove move in i_AllPossibleJumps)
            {
                if (i_CurrentMove.Equals(move))
                {
                    existsLegalJump = true;
                }
            }

            return existsLegalJump;
        }
    }
}
