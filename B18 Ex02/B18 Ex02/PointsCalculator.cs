﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    class PointsCalculator
    {
        private int m_FirstPlayerCurrentPoints = 0;
        private int m_SecondPlayerCurrentPoints = 0;
        private int m_FirstPlayerTotalPoints = 0;
        private int m_SecondPlayerTotalPoints = 0;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private Player m_MatchWinner;
        private bool m_WinnerIsFound = false;

        public Player MatchWinner
        {
            get
            {
                return m_MatchWinner;
            }
        }
        public int FirstPlayerTotalPoints
        {
            get
            {
                return m_FirstPlayerTotalPoints;
            }
        }

        public int SecondPlayerTotalPoints
        {
            get
            {
                return m_SecondPlayerTotalPoints;
            }
        }

        public PointsCalculator(Player i_FirstPlayer, Player i_SecondPlayer, Board i_PlayingBoard)
        {
            this.m_FirstPlayer = i_FirstPlayer;
            this.m_SecondPlayer = i_SecondPlayer;
            calculatePoints(i_PlayingBoard);
        }
        private void calculatePoints (Board i_PlayingBoard)
        {
            PossibleMoves allPossibleMoves = new PossibleMoves(i_PlayingBoard);
            ArrayList firstPlayerPossibleMoves = allPossibleMoves.FirstPlayerPossibleMoves;
            ArrayList secondPlayerPossibleMoves = allPossibleMoves.SecondPlayerPossibleMoves;

            int totalMovesFirstPlayer = firstPlayerPossibleMoves.Count;
            int totalMovesSecondPlayer= secondPlayerPossibleMoves.Count;

            this.m_FirstPlayerCurrentPoints = calcUserPoints(m_FirstPlayer, i_PlayingBoard);
            this.m_SecondPlayerCurrentPoints = calcUserPoints(m_SecondPlayer, i_PlayingBoard);
            //Checks if there are no more possible moves for both players
            if (totalMovesFirstPlayer == 0 && totalMovesSecondPlayer == 0)
            {
                calcTiePoints();
                m_WinnerIsFound = true;
            }
            else if (totalMovesFirstPlayer == 0)
            {
                this.m_SecondPlayerTotalPoints += this.m_SecondPlayerCurrentPoints - this.m_FirstPlayerCurrentPoints;
                m_WinnerIsFound = true;
            }
            else if (totalMovesSecondPlayer == 0)
            {
                this.m_FirstPlayerTotalPoints += this.m_FirstPlayerCurrentPoints - this.m_SecondPlayerCurrentPoints;
                m_WinnerIsFound = true;
            }
            else
            {
                ArrayList firstUserCoins = i_PlayingBoard.GetUserCoins(this.m_FirstPlayer.CoinType);
                ArrayList secondUserCoins = i_PlayingBoard.GetUserCoins(this.m_SecondPlayer.CoinType);

                if (firstUserCoins.Count == 0)
                {
                    this.m_SecondPlayerTotalPoints += this.m_SecondPlayerCurrentPoints - this.m_FirstPlayerCurrentPoints;
                    m_WinnerIsFound = true;
                }
                else if (secondUserCoins.Count == 0)
                {
                    this.m_FirstPlayerTotalPoints += this.m_FirstPlayerCurrentPoints - this.m_SecondPlayerCurrentPoints;
                    m_WinnerIsFound = true;
                }
            }
            if (m_WinnerIsFound)
            {
                SetWinner();
            }
        }

        private int calcUserPoints(Player i_CurrentPlayer, Board i_Board)
        {
            int totalPoints = 0;
            ArrayList firstUserCoins = i_Board.GetUserCoins(i_CurrentPlayer.CoinType);
            foreach (Coin coin in firstUserCoins)
            {
                totalPoints += coin.IsKing ? 4 : 1;
            }

            return totalPoints;
        }

        private void calcTiePoints()
        {
            if (this.m_FirstPlayerCurrentPoints > this.m_SecondPlayerCurrentPoints)
            {
                this.m_FirstPlayerTotalPoints = m_FirstPlayerCurrentPoints - this.m_SecondPlayerCurrentPoints;
            }
            else
            {
                this.m_SecondPlayerTotalPoints = m_SecondPlayerCurrentPoints - this.m_FirstPlayerCurrentPoints;
            }
        }

        private void SetWinner()
        {
            if (m_FirstPlayerCurrentPoints > m_SecondPlayerCurrentPoints)
            {
                m_MatchWinner = m_FirstPlayer;
            }
            else if (m_FirstPlayerCurrentPoints > m_SecondPlayerCurrentPoints)
            {
                m_MatchWinner = m_SecondPlayer;
            }
        }
        public bool IsWinnerFound()
        {
            return m_MatchWinner != null;
        }
    }
}
