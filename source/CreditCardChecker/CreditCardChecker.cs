using System;

namespace CreditCardChecker
{
    public class CreditCardChecker
    {
        /// <summary>
        /// Diese Methode überprüft eine Kreditkartenummer, ob diese gültig ist.
        /// Regeln entsprechend der Angabe.
        /// </summary>
        public static bool IsCreditCardValid(string creditCardNumber)
        {
            if (creditCardNumber == null)
            {
                //throw new ArgumentNullException(nameof(creditCardNumber));
                return false;
            }

            if (creditCardNumber.Length != 16)
            {
                return false;
            }

            int oddSum = 0;
            int evenSum = 0;

            for (int i = 0; i < creditCardNumber.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    evenSum += CalculateDigitSum(ConvertToInt(creditCardNumber[i]) * 2);
                }
                else
                {
                    oddSum += ConvertToInt(creditCardNumber[i]);
                }
            }

            int checkNumber = CalculateCheckDigit(oddSum, evenSum);

            return checkNumber == ConvertToInt(creditCardNumber[15]);
        }

        /// <summary>
        /// Berechnet aus der Summe der geraden Stellen (bereits verdoppelt) und
        /// der Summe der ungeraden Stellen die Checkziffer.
        /// </summary>
        private static int CalculateCheckDigit(int oddSum, int evenSum)
        {
            int checknumber;
            int sum = oddSum + evenSum;

            checknumber = sum % 10;
            if (checknumber > 0)
            {
                checknumber = 10 - checknumber;
            }

            return checknumber;
        }

        /// <summary>
        /// Berechnet die Ziffernsumme einer Zahl.
        /// </summary>
        private static int CalculateDigitSum(int number)
        {
            int sum = 0;
            do
            {
                sum = sum + number % 10;
                number = number / 10;
            } while (number > 0);
            return sum;
        }

        private static int ConvertToInt(char ch)
        {
            return ch - '0';
        }
    }
}
