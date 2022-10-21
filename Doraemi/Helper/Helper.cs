
using Doraemi.Models;
using System;
using System.Collections.Generic;

namespace Doraemi.Helper
{
    public static class Helper
    {
        public static void AddUserSubscriptionDataToList(List<UserSubscriptionDetails> UserData,
            DateTime subScriptionEndDate, string Type)
        {
            UserData.Add(new UserSubscriptionDetails()
            {
                RenewalDate = subScriptionEndDate,
                Type = Type
            });
        }

        public static int ExtractNumber(string[] lines, int i, string num, int val)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                if (Char.IsDigit(lines[i][j]))
                    num += lines[i][j];
            }

            if (num.Length > 0)
                val = int.Parse(num);
            return val;
        }
        public static string ExtractNumber(string[] lines, int i, string num, string val)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                if (Char.IsDigit(lines[i][j]))
                    num += lines[i][j];
            }
            return val= num;
        }
    }
}
