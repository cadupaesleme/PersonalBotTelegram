using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace PersonalBotTelegram
{
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("581796064:AAEN11t28iX4yJvnNs1aBY86Cejjed9i2dM");
        static void Main(string[] args)
        {
            Bot.OnMessage += OnMessage;
            Bot.OnMessageEdited += OnMessage;

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();

        }

        private static void OnMessage(object sender, MessageEventArgs e)
        {

            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage)
            {
                if (e.Message.Text .ToLower() == "oi" || e.Message.Text.ToLower() == "/start")
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Olá, tudo bem com vc? Vamos malhar ?" + e.Message.Chat.Username);

                }
                else
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Eu te amo leo - Eu sou seu Robin" + e.Message.Chat.Username);
                    //Bot.SendTextMessageAsync(e.Message.Chat.Id, "Não entendi, tudo bem com vc? Vamos malhar ?" + e.Message.Chat.Username);
                }
            }
        }
    }
}
