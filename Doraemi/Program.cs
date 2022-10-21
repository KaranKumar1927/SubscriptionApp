using System;
using System.Collections.Generic;
using System.IO;
using Doraemi.Models;
using Doraemi.Service;
using Doraemi.Validator;

/*
 *The code is divided into various file, Please check the solution structure for better understanding 
 *Please nter  filename as a parameter (eg : Doraemi.exe <FilePath>"
 * I have used one common interface and implemented different catogories(Music/Video/Poscast) though it could have been done in one class itself
 * but to keep things better for scalabality  and  readbility I used different classes
 * Could be implemented in lot of different ways, I have used a very basic approach to solve this problem
 * I have handled all the scenarios mentioned in the problem statement apart from that there multiple more conditions I have handled as well
 */
namespace Doraemi
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string file = @"C:\Personal\Test\Input.txt";
            var Type = "";
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please enter  filename as a parameter (eg : Doraemi.exe <FilePath>");
                return;
            }

            if (!File.Exists(args[0])) Console.WriteLine("File does not exist please check !!");

            var FileData = File.ReadAllLines(args[0]);
            var UserData = new List<UserSubscriptionDetails>();


            DateTime subScriptionStartDate = default;
            DateTime subScriptionEndDate = default;
            var totalAmount = 0;
            var dateFormats = new[] {"ddMMyyyy"};
            var isInputCorrect = true;
            subScriptionStartDate = Validate.Input(FileData, dateFormats, ref isInputCorrect);

            if (isInputCorrect)
            {
                totalAmount = CalculateTotalAmountAndRenewalDate(FileData, totalAmount, subScriptionEndDate,
                    subScriptionStartDate, UserData);
                DisplayResult(UserData, totalAmount);
            }
            else
            {
                Console.WriteLine(Errors.SubscriptionStatus + "  " + Errors.Code);
            }

            Console.ReadKey();
        }

        private static void DisplayResult(List<UserSubscriptionDetails> UserData, int totalAmount)
        {
            foreach (var data in UserData)
                Console.WriteLine("RENEWAL_REMINDER " + data.Type + " " +
                                  data.RenewalDate.AddDays(-10).ToString("dd-MM-yyyy"));
            Console.WriteLine("RENEWAL_AMOUNT " + totalAmount);
        }

        private static int CalculateTotalAmountAndRenewalDate(string[] FileData, int totalAmount,
            DateTime subScriptionEndDate,
            DateTime subScriptionStartDate, List<UserSubscriptionDetails> UserData)
        {
            string Type;
            for (var i = 1; i < FileData.Length; i++)
                if (FileData[i].Contains(Constants.Subscription.Add))
                {
                    if (FileData[i].Contains(Constants.Category.Music))
                    {
                        Type = Constants.Category.Music;
                        var musicPack = new Music();
                        if (FileData[i].Contains(Constants.Pack.Personal))
                        {
                            var res = musicPack.getPersonalSubscription();
                            totalAmount = totalAmount + res.Amount;
                            subScriptionEndDate = subScriptionStartDate.AddMonths(res.Months);
                        }
                        else if (FileData[i].Contains(Constants.Pack.Free))
                        {
                            var res = musicPack.getFreeSubscription();
                            totalAmount = totalAmount + res.Amount;
                            subScriptionEndDate = subScriptionStartDate.AddMonths(res.Months);
                        }
                        else if (FileData[i].Contains(Constants.Pack.Premium))
                        {
                            var res = musicPack.getPremiumSubcription();
                            totalAmount = totalAmount + res.Amount;
                            subScriptionEndDate = subScriptionStartDate.AddMonths(res.Months);
                        }

                        Helper.Helper.AddUserSubscriptionDataToList(UserData, subScriptionEndDate, Type);
                    }
                    else if (FileData[i].Contains(Constants.Category.Video))
                    {
                        Type = Constants.Category.Video;
                        var videoPack = new Video();
                        if (FileData[i].Contains(Constants.Pack.Personal))
                        {
                            var res = videoPack.getPersonalSubscription();
                            totalAmount = totalAmount + res.Amount;
                            subScriptionEndDate = subScriptionStartDate.AddMonths(res.Months);
                        }
                        else if (FileData[i].Contains(Constants.Pack.Free))
                        {
                            var res = videoPack.getFreeSubscription();
                            totalAmount = totalAmount + res.Amount;
                            subScriptionEndDate = subScriptionStartDate.AddMonths(res.Months);
                        }
                        else if (FileData[i].Contains(Constants.Pack.Premium))
                        {
                            var res = videoPack.getPremiumSubcription();
                            totalAmount = totalAmount + res.Amount;
                            subScriptionEndDate = subScriptionStartDate.AddMonths(res.Months);
                        }

                        Helper.Helper.AddUserSubscriptionDataToList(UserData, subScriptionEndDate, Type);
                    }
                    else if (FileData[i].Contains(Constants.Category.Podcast))
                    {
                        Type = Constants.Category.Podcast;
                        var podcast = new Podcast();
                        if (FileData[i].Contains(Constants.Pack.Personal))
                        {
                            var res = podcast.getPersonalSubscription();
                            totalAmount = totalAmount + res.Amount;
                            subScriptionEndDate = subScriptionStartDate.AddMonths(res.Months);
                        }
                        else if (FileData[i].Contains(Constants.Pack.Free))
                        {
                            var res = podcast.getFreeSubscription();
                            totalAmount = totalAmount + res.Amount;
                            subScriptionEndDate = subScriptionStartDate.AddMonths(res.Months);
                        }
                        else if (FileData[i].Contains(Constants.Pack.Premium))
                        {
                            var res = podcast.getPremiumSubcription();
                            totalAmount = totalAmount + res.Amount;
                            subScriptionEndDate = subScriptionStartDate.AddMonths(res.Months);
                        }

                        Helper.Helper.AddUserSubscriptionDataToList(UserData, subScriptionEndDate, Type);
                    }
                }
                else if (FileData[i].Contains(Constants.Subscription.TopUp))
                {
                    var num = "";
                    var val = 0;
                    if (FileData[i].Contains(Constants.Topup.UptoFour))
                    {
                        val = Helper.Helper.ExtractNumber(FileData, i, num, val);
                        if (val <= 4) totalAmount = totalAmount + 50 * val;
                    }
                    else if (FileData[i].Contains(Constants.Topup.UptoTen))
                    {
                        val = Helper.Helper.ExtractNumber(FileData, i, num, val);
                        if (val <= 10) totalAmount = totalAmount + 100 * val;
                    }
                }
                else if (FileData[i].Contains(Constants.Subscription.End))
                {
                    break;
                }

            return totalAmount;
        }
    }
}