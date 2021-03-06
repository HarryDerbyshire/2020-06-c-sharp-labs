﻿using System;
using System.Collections;

namespace DataTypesPt2Lib
{
    public enum Suit
    {
        HEARTS, CLUBS, DIAMONDS, SPADES
    }
    public class Methods
    {
        public static int AgeAt(DateTime birthDate, DateTime date)
        { 
            if (birthDate > date) throw new System.ArgumentException("Error - birthDate is in the future");
            var age = date - birthDate;
            return (int)((age.Days) / 365.25);
            
        }

        public static string FormatDate(DateTime date)
        {
            return date.ToString("yy/dd/MMM");
        }
        public static string GetMonthString(DateTime date)
        {
            return date.ToString("MMMMM");
        }

        public static string Fortune(Suit suit)
        {
            switch(suit)
            {
                case Suit.CLUBS:
                    return "And the seventh rule is if this is your first night at fight club, you have to fight.";
                case Suit.DIAMONDS:
                    return "Diamonds are a girls best friend";
                case Suit.HEARTS:
                    return "You've broken my heart";
                case Suit.SPADES:
                    return "Bucket and spade";

            }
            return string.Empty;
        }
    }
}