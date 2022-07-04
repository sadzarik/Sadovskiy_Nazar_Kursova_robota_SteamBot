using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Exceptions;
using SteamBot.Client;
using SteamBot.Constant;



namespace SteamBot
{
    public class SteamAppInfoBot
    {
        bool setButtons;
        string LastText;
        string strCall;
        int intCall1;
        int intCall2;
        int intCall3;
        int intCall4;
        int intCallCount;
        TelegramBotClient botClient = new TelegramBotClient("5421131432:AAFLBMBJC5kdMOYCfX9OTQ-Dv6l4J49pF_E");
        CancellationToken cancellationToken = new CancellationToken();
        ReceiverOptions receiverOptions = new ReceiverOptions { AllowedUpdates = {}};
        public async Task Start()
        {
            botClient.StartReceiving(HandlerUpdateAsync, HandlerError, receiverOptions, cancellationToken);
            var botMe = await botClient.GetMeAsync();
            Console.WriteLine($"Bot {botMe.Username} started working.");
            Console.ReadKey();
        }

        private Task HandlerError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Error in telegram bot API:\n{apiRequestException.ErrorCode}" +
                $"\n{apiRequestException.Message}", _ => exception.ToString()
            };
            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
        private async Task HandlerUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update?.Message?.Text !=null)
            {
                await HandlerMessageAsync(botClient, update.Message);
            }
        }
        private async Task HandlerMessageAsync(ITelegramBotClient botClient, Message message)
        {
            if (message.Text == "/start")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "\tWhat can Do this Bot\n\n" +
                    "SearchApp - searches the app and returns The most public searches;\n\n" +
                    "SearchInfo - searches different infos from list by specific AppId\n" +
                    "You can find AppId of interest application using (SearchApp) \n\n");
                {
                    ReplyKeyboardMarkup replyKeyboardMarkup = new
    (
    new[]
    {
                        new KeyboardButton[]{ "_SearchApp", "_SearchInfo"}

    }
    )
                    {
                        ResizeKeyboard = true
                    };
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Choose method:", replyMarkup: replyKeyboardMarkup);
                    return;
                }
            }else
            if (message.Text == "_SearchInfo")
            {
                ReplyKeyboardMarkup replyKeyboardMarkup = new
                    (
                    new[]
                    {
                        new KeyboardButton[]{"_Details", "_News"},
                        new KeyboardButton[]{"_Reviews", "_GL_Achievements"}
                    }
                    )
                {
                    ResizeKeyboard = true
                };
                await botClient.SendTextMessageAsync(message.Chat.Id,"Choose method:", replyMarkup: replyKeyboardMarkup);
            }else
                if (message.Text=="_SearchApp")
            {
                LastText = "Write Name Of App you want to find:";
                message.Text = "Write Name Of App you want to find:";
                await botClient.SendTextMessageAsync(message.Chat.Id, "Write Name Of App you want to find:", replyMarkup: new ForceReplyMarkup() { Selective = true });
                
            }else
            if (LastText== "Write Name Of App you want to find:")
            {
                strCall=message.Text;
                SearchAppClient client = new SearchAppClient();
                var result = client.GetAppInfoAsync(strCall).Result;
                await botClient.SendTextMessageAsync(message.Chat.Id, "Most popular searches:");
                foreach (var item in result)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"AppId: {item.appId}\nTitle: {item.title}\n" +
                    $"Url: {item.url}\nPrice:{item.price}\nImgUrl{item.imgUrl}");
                }
                setButtons=true;
            }
            else
                if (message.Text== "_SearchApp")
            {
                LastText = "Write Name Of APP you want to find:";
                message.Text = "Write Name Of APP you want to find:";
                await botClient.SendTextMessageAsync(message.Chat.Id, "Write Name Of APP you want to find:", replyMarkup: new ForceReplyMarkup() { Selective = true });
               
            }
            else
            if (LastText == "Write Name Of APP you want to find:")
            {
                strCall = message.Text;
                SearchAppClient client = new SearchAppClient();
                var result = client.GetAppInfoAsync(strCall).Result;
                await botClient.SendTextMessageAsync(message.Chat.Id, "Most popular searches:");
                foreach (var item in result)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"AppId: {item.appId}\nTitle: {item.title}\n" +
                    $"Url: {item.url}\nPrice:{item.price}\nImgUrl{item.imgUrl}");
                }
                setButtons = true;
            }
            if (message.Text == "_Details")
            {
                LastText = "Write AppId Of App you want to find DETAILS:";
                message.Text = "Write AppId Of App you want to find DETAILS:";
                await botClient.SendTextMessageAsync(message.Chat.Id, "Write AppId Of App you want to find DETAILS:", replyMarkup: new ForceReplyMarkup() { Selective = true });
            }
            else
            if (LastText == "Write AppId Of App you want to find DETAILS:")
            {
                intCall1 = int.Parse(message.Text);
                AppDetailClient client = new AppDetailClient();
                var result = client.GetAppDetailsAsync(intCall1).Result;
                await botClient.SendTextMessageAsync(message.Chat.Id, "_-_-APP_DEtails-_-_");

                await botClient.SendTextMessageAsync(message.Chat.Id, $"Title: {result.title}\n" +
                $"Developer name: {result.developer.name}\nDeveloper link:{result.developer.link}\n" +
                $"Publisher name: {result.publisher.name}\nPublisher link:{result.publisher.link}\n" +
                $"Repeased:{result.released}\nDescription:{result.description}\n" +
                $"\nPrice:{result.price}\nImgUrl{result.imgUrl}");
                foreach (var item in result.DLCs)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Title:{item.name}\n" +
                        $"Url: {item.url}\n" +
                        $"AppId{item.appId}\n" +
                        $"Price{item.price}");
                }
                setButtons = true;
            }
            if (message.Text == "_News")
            {
                LastText = "Write AppId Of App you want to find NEWS:";
                message.Text = "Write AppId Of App you want to find NEWS:";
                await botClient.SendTextMessageAsync(message.Chat.Id, "Write AppId Of App you want to find NEWS:", replyMarkup: new ForceReplyMarkup() { Selective = true });

            }
            else
            if(LastText== "Write AppId Of App you want to find NEWS:")
            {
                intCall2 = int.Parse(message.Text);
                AppNewsClient client = new AppNewsClient();
                var result = client.GetAppNewsAsync(intCall2).Result;
                await botClient.SendTextMessageAsync(message.Chat.Id, "_-_-_-NEWS-_-_-_");

                foreach (var item in result.appnews.newsitems)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Title: {item.title}\n" +
                        $"Url: {item.url}\nAuthor: {item.author}\n" +
                        $"Content{item.contents}");
                }
                setButtons = true;
            }
            if (message.Text == "_GL_Achievements")
            {
                LastText = "Write AppId Of App you want to find ACHIEVEMENTS:";
                message.Text = "Write AppId Of App you want to find ACHIEVEMENTS:";
                await botClient.SendTextMessageAsync(message.Chat.Id, "Write AppId Of App you want to find ACHIEVEMENTS:", replyMarkup: new ForceReplyMarkup() { Selective = true });

            }else
            if (LastText == "Write AppId Of App you want to find ACHIEVEMENTS:")
            {
                intCall3 = int.Parse(message.Text);
                GlobalAchievementClient client = new GlobalAchievementClient();
                var result = client.GetGlobalAchievementsAsync(intCall3).Result;
                await botClient.SendTextMessageAsync(message.Chat.Id, "_-_-_-ACHIEVEMENTS-_-_-_");
                foreach (var item in result.achievementpercentages.achievements)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Achievement: {item.name}\n" +
                        $"Percent:{item.percent}");
                }
                setButtons = true;
            }
            else
                if (message.Text == "_Reviews")
            {
                LastText = "Write AppId Of App you want to find REVIEWS:";
                message.Text = "Write AppId Of App you want to find REVIEWS:";
                await botClient.SendTextMessageAsync(message.Chat.Id, "Write AppId Of App you want to find REVIEWS:", replyMarkup: new ForceReplyMarkup() { Selective = true });

            }else
            if (LastText == "Write AppId Of App you want to find REVIEWS:")
            {
                intCall4 = int.Parse(message.Text);
                LastText = "Write Count of REVIEWS you want to see:";
                message.Text = "Write Count of REVIEWS you want to see:";
                await botClient.SendTextMessageAsync(message.Chat.Id, "Write Count of REVIEWS you want to see:", replyMarkup: new ForceReplyMarkup() { Selective = true });
            }else
            if (LastText== "Write Count of REVIEWS you want to see:")
            {
                intCallCount = int.Parse(message.Text);
                AppReviewsClient client = new AppReviewsClient();
                var result = client.GetAppReviewsAsync(intCall4, intCallCount).Result;
                await botClient.SendTextMessageAsync(message.Chat.Id, "_-_-_-REVIEWS-_-_-_");
                await botClient.SendTextMessageAsync(message.Chat.Id, $"SUMMARY REVIEWS\n\n" +
                    $"Num reviews: {result.query_summary.num_reviews}\n" +
                    $"Review score: {result.query_summary.review_score}\n" +
                    $"Review score desc: {result.query_summary.review_score_desc}\n" +
                    $"Total positive: {result.query_summary.total_positive}\n" +
                    $"Total negative: {result.query_summary.total_negative}\n" +
                    $"Total reviews: {result.query_summary.total_reviews}");
                foreach (var item in result.reviews)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Author ID: {item.author.steamid}\n" +
                        $"Review: {item.review}\n" +
                        $"Recomendation Id{item.recommendationid}");
                }
                setButtons = true;
            }else
            if (setButtons == true)
            {
                ReplyKeyboardMarkup replyKeyboardMarkup = new
    (
    new[]
    {
                                    new KeyboardButton[]{ "_SearchApp", "_SearchInfo"}

    }
    )
                {
                    ResizeKeyboard = true
                };
                await botClient.SendTextMessageAsync(message.Chat.Id, "Do you need something else?", replyMarkup: replyKeyboardMarkup);
                setButtons = false;
            }
        }
    }
}
