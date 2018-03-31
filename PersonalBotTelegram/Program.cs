using PersonalBotTelegram.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace PersonalBotTelegram
{
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("581796064:AAEN11t28iX4yJvnNs1aBY86Cejjed9i2dM");
        private static BotOrquestrador BotStatus = new BotOrquestrador();

        static void Main(string[] args)
        {
            var bot = Bot.GetMeAsync().Result;
            Console.Title = bot.Username;

            Bot.OnMessage += OnMessage;
            Bot.OnMessageEdited += OnMessage;
            //Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
            //Bot.OnInlineQuery += BotOnInlineQueryReceived;
            //Bot.OnInlineResultChosen += BotOnChosenInlineResultReceived;
            //Bot.OnReceiveError += BotOnReceiveError;


            Bot.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine($"Iniciou o bot - @{bot.Username}");
            Console.ReadLine();
            Bot.StopReceiving();

        }

        private static async void OnMessage(object sender, MessageEventArgs e)
        {
            var mensagem = e.Message;
            Conversa.RespostaRecebida(mensagem.Text);
            //verifica se a mensagem é texto
            if (mensagem == null || mensagem.Type != MessageType.TextMessage) return;

            //await Bot.SendTextMessageAsync(e.Message.Chat.Id, BotStatus.Etapa);

            string p = Conversa.MapaPergunta();

            ReplyKeyboardMarkup ReplyKeyboard = new ReplyKeyboardMarkup();
            if (p == Conversa.GetPergunta(-1))
            {
                //resposta invalida
                await Bot.SendTextMessageAsync(
                       mensagem.Chat.Id,
                       p,
                       replyMarkup: new ReplyKeyboardRemove());

                p = Conversa.UltimaPergunta();
            }
            if (p == Conversa.GetPergunta(0))
            {
                //Fim

                await Bot.SendTextMessageAsync(
                            mensagem.Chat.Id,
                            Conversa.FazerPergunta(p),
                     replyMarkup: new ReplyKeyboardRemove());
                return;
            }

            if (p == Conversa.GetPergunta(1))
            {
                ReplyKeyboard = new ReplyKeyboardMarkup
                {

                    Keyboard = new KeyboardButton[][] {
                                    new KeyboardButton[]
                                     {
                                      new KeyboardButton("Sim"),
                                      new KeyboardButton("Não")

                                    }
                                }
                };
            }
            if (p == Conversa.GetPergunta(2))
            {
                ReplyKeyboard = new ReplyKeyboardMarkup
                {

                    Keyboard = new KeyboardButton[][] {
                                    new KeyboardButton[]
                                     {
                                         new KeyboardButton("Frango"),
                                         new KeyboardButton("Moderado"),
                                        new KeyboardButton("Monstro"),
                                    }
                                }
                };
            }

            await Bot.SendTextMessageAsync(
                        mensagem.Chat.Id,
                        Conversa.FazerPergunta(p),
                        replyMarkup: ReplyKeyboard);


        }

        //private static async void OnMessage(object sender, MessageEventArgs e)
        //{
        //    var mensagem = e.Message;
        //    Conversa.RespostaRecebida(mensagem.Text);
        //    //verifica se a mensagem é texto
        //    if (mensagem == null || mensagem.Type != MessageType.TextMessage) return;

        //    //await Bot.SendTextMessageAsync(e.Message.Chat.Id, BotStatus.Etapa);

        //    switch (mensagem.Text.ToLower().Split(' ').First())
        //    {
        //        case "oi":
        //        case "ola":
        //        case "olá":
        //        case "/start":
        //            // await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Olá, tudo bem " + e.Message.Chat.FirstName + " ? Vamos malhar ?");
        //            ReplyKeyboardMarkup ReplyKeyboard = new ReplyKeyboardMarkup
        //            {

        //                Keyboard = new KeyboardButton[][] {
        //                    new KeyboardButton[]
        //                     {
        //                      new KeyboardButton("Sim"),
        //                      new KeyboardButton("Não")

        //                    }
        //                }
        //            };

        //            BotStatus.Etapa = "/start";

        //            await Bot.SendTextMessageAsync(
        //                mensagem.Chat.Id,
        //                Conversa.FazerPergunta("Olá, tudo bem " + e.Message.Chat.FirstName + " ? Vamos malhar ? "),
        //                replyMarkup: ReplyKeyboard);
        //            break;


        //        case "sim":
        //            // await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Olá, tudo bem " + e.Message.Chat.FirstName + " ? Vamos malhar ?");


        //            BotStatus.Etapa = "/start";

        //            await Bot.SendTextMessageAsync(
        //                mensagem.Chat.Id,
        //                Conversa.FazerPergunta("Ok " + e.Message.Chat.FirstName + " ? Qual treino deseja ? "),
        //                replyMarkup: new ReplyKeyboardMarkup
        //                {

        //                    Keyboard = new KeyboardButton[][] {
        //                    new KeyboardButton[]
        //                     {
        //                      new KeyboardButton("Frango"),
        //                      new KeyboardButton("Moderado"),
        //                      new KeyboardButton("Monstro"),                           

        //                    },

        //                     new KeyboardButton[]
        //                     {

        //                     new KeyboardButton("Sair")
        //                     }

        //                }
        //                });
        //            break;


        //        case "não":
        //        case "sair":
        //            await Bot.SendTextMessageAsync(
        //                   mensagem.Chat.Id,
        //                   "Ok " + e.Message.Chat.FirstName + ". Até mais preguiçoso!",
        //                   replyMarkup: new ReplyKeyboardRemove());
        //            Conversa.Limpar();
        //            BotStatus.Etapa = "/erro";
        //            break;


        //        default:
        //            //await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Não entendi " + e.Message.Chat.FirstName + ". Pode repetir por favor ?");

        //            await Bot.SendTextMessageAsync(
        //               mensagem.Chat.Id,
        //               "Não entendi " + e.Message.Chat.FirstName + ". Pode repetir por favor ? ",
        //               replyMarkup: new ReplyKeyboardRemove());
        //            BotStatus.Etapa = "/erro";

        //            break;

        //    }
        //}
    }
}
