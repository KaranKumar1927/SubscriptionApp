using System;
using System.Globalization;

namespace Doraemi.Validator
{
    public static class Validate
    {
        public static DateTime Input(string[] FileData, string[] dateFormats, ref bool isInputCorrect)
        {
            DateTime subScriptionStartDate;
            var date = Helper.Helper.ExtractNumber(FileData, 0, "", "");
            
            if (!DateTime.TryParseExact(date, dateFormats, DateTimeFormatInfo.InvariantInfo,
                DateTimeStyles.None, out subScriptionStartDate))
            {
                Errors.Code = Constants.Error.InvalidDate;
                Errors.SubscriptionStatus = Constants.Error.Failed;
                isInputCorrect = false;
            }
            else if (!FileData[0].Contains(Constants.Subscription.Start))
            {
                Errors.Code = Constants.Error.Input;
                Errors.SubscriptionStatus = Constants.Error.Failed;
                isInputCorrect = false;
            }
            else
            {
                int subCount = 0, musicCount = 0, videoCount = 0, podcastCount = 0, topupCount = 0;
                for (int i = 1; i < FileData.Length; i++)
                {
                    if (FileData[i].Contains(Constants.Subscription.Add))
                    {
                        subCount++;
                    }

                    if (subCount == 0)
                    {
                        Errors.Code = Constants.Error.NotFound;
                        Errors.SubscriptionStatus = Constants.Error.Failed;
                        isInputCorrect = false;
                        break;
                    }

                    if (FileData[i].Contains(Constants.Category.Music))
                    {
                        musicCount++;
                        if (musicCount > 1)
                        {
                            Errors.Code = Constants.Error.DuplicateCategory;
                            Errors.SubscriptionStatus = Constants.Error.Failed;
                            isInputCorrect = false;
                            break;
                        }
                    }

                    if (FileData[i].Contains(Constants.Category.Video))
                    {
                        videoCount++;
                        if (videoCount > 1)
                        {
                            Errors.Code = Constants.Error.DuplicateCategory;
                            Errors.SubscriptionStatus = Constants.Error.Failed;
                            isInputCorrect = false;
                            break;
                        }
                    }

                    if (FileData[i].Contains(Constants.Category.Podcast))
                    {
                        podcastCount++;
                        if (podcastCount > 1)
                        {
                            Errors.Code = Constants.Error.DuplicateCategory;
                            Errors.SubscriptionStatus = Constants.Error.Failed;
                            isInputCorrect = false;
                            break;
                        }
                    }

                    if (FileData[i].Contains(Constants.Subscription.TopUp))
                    {
                        topupCount++;
                        string num = "";
                        int val =0;
                        if (FileData[i].Contains(Constants.Topup.UptoFour))
                        {
                            val = Helper.Helper.ExtractNumber(FileData, i, num, val);
                            if (val > 4)
                            {
                                Errors.Code = Constants.Error.TopUpFourExcedded;
                                Errors.SubscriptionStatus = Constants.Error.TopupFailed;
                                isInputCorrect = false;
                                break;
                            }
                        }
                        else if (FileData[i].Contains(Constants.Topup.UptoTen))
                        {
                            val = Helper.Helper.ExtractNumber(FileData, i, num, val);
                            if (val > 10)
                            {
                                Errors.Code = Constants.Error.TopUpTenExcedded;
                                Errors.SubscriptionStatus = Constants.Error.TopupFailed;
                                isInputCorrect = false;
                                break;
                            }
                        }

                        if (topupCount > 1)
                        {
                            Errors.Code = Constants.Error.DuplicateTopup;
                            Errors.SubscriptionStatus = Constants.Error.TopupFailed;
                            isInputCorrect = false;
                            break;
                        }
                    }
                }
            }

            return subScriptionStartDate;
        }


    }
}
