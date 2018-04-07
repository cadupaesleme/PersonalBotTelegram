using PersonalBotTelegram.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace PersonalBotTelegram
{
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("595916691:AAFHnUS_gJrJIgafSwPKXio9ucsmE94CXTI");
        // private static BotOrquestrador BotStatus = new BotOrquestrador();
        public static bool noTreino = false;
        public static int qtdTreino = 0;
        public static int MaxqtdTreino = 0;
        public static string TreinoAtivo = "";
        public static IList<Usuario> Usuarios = new List<Usuario>();
        public static Dictionary<long, DateTime> TimerIDs = new Dictionary<long, DateTime>();
        Timer aTimer = new Timer();
        public static List<Opcao>  OpcoesAtividade = new List<Opcao>(); 
        static void Main(string[] args)
        {

            Usuarios = new List<Usuario>();

            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;

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

        private static async void OnTimedEvent(object source, ElapsedEventArgs e)
        {

            Dictionary<long, DateTime> timermanter = new Dictionary<long, DateTime>();

            dynamic rkm = new ReplyKeyboardMarkup();


            //rkm = new ReplyKeyboardRemove();

            var rows = new List<KeyboardButton[]>();
            var cols = new List<KeyboardButton>();
            for (var Index = 0; Index < OpcoesAtividade.Count; Index++)
            {
                cols.Add(new KeyboardButton("" + OpcoesAtividade[Index].Nome));
                //if (Index % 4 != 0) continue;
                rows.Add(cols.ToArray());
                cols = new List<KeyboardButton>();
            }
            rkm.Keyboard = rows.ToArray();


            foreach (var item in TimerIDs)
            {
                var dataVerificacao = item.Value.AddSeconds(10);
                if (DateTime.Now >= dataVerificacao)
                {
                    //TimerIDs.Remove(item.Key);
                    //TimerIDs.Add(item.Key, DateTime.Now);
                    //TimerIDs[item.Key] = DateTime.Now;
                    
                    await Bot.SendTextMessageAsync(
                              item.Key,
                              "Vamos PORRA!!!!!!",
                              replyMarkup: rkm);

                    timermanter.Add(item.Key,DateTime.Now);
                }
                else
                {
                    timermanter.Add(item.Key,item.Value);

                }


            }
            TimerIDs = timermanter;
        }

        private static async void OnMessage(object sender, MessageEventArgs e)
        {
            var mensagem = e.Message;

            //verifica se a mensagem é texto
            if (mensagem == null || mensagem.Type != MessageType.TextMessage) return;

            Usuario Usuario;

            if (Usuarios.FirstOrDefault(u => u.Chat == mensagem.Chat.Id) == null)
            {
                Usuarios.Add(new Usuario(mensagem.Chat.FirstName, mensagem.Chat.Id, new Fluxo()));
                Usuario = Usuarios.FirstOrDefault(u => u.Chat == mensagem.Chat.Id);

            }
            else
            {
                Usuario = Usuarios.FirstOrDefault(u => u.Chat == mensagem.Chat.Id);
                Usuario.Fluxo.MudarPasso(Usuario.Fluxo.Atual, mensagem.Text.Split(' ').First());
            }

            var fluxoAux = Usuario.Fluxo.Atual;

            if (fluxoAux.Nome == "Fim")
            {
                Usuarios.Remove(Usuario);
            }

            dynamic rkm = new ReplyKeyboardMarkup();


            if (fluxoAux.Opcoes.Count > 0)
            {

                rkm = new ReplyKeyboardMarkup();

                var rows = new List<KeyboardButton[]>();
                var cols = new List<KeyboardButton>();
                for (var Index = 0; Index < fluxoAux.Opcoes.Count; Index++)
                {
                    cols.Add(new KeyboardButton("" + fluxoAux.Opcoes[Index].Nome));
                    //if (Index % 4 != 0) continue;
                    rows.Add(cols.ToArray());
                    cols = new List<KeyboardButton>();
                }
                rkm.Keyboard = rows.ToArray();



            }
            else
                rkm = new ReplyKeyboardRemove();

            var aux = fluxoAux.Pergunta.Split('|');

            if (aux.Count() > 1)
            {

                OpcoesAtividade = fluxoAux.Opcoes;
                TimerIDs.Remove(e.Message.Chat.Id);
                TimerIDs.Add(e.Message.Chat.Id,DateTime.Now);
                var imagem = aux[1];
                var FileUrl = Directory.GetCurrentDirectory() + @"\..\..\imagens\" + imagem.Replace("\r\n", "");
                using (var stream = System.IO.File.Open(FileUrl, FileMode.Open))
                {
                    FileToSend fts = new FileToSend();
                    fts.Content = stream;
                    fts.Filename = FileUrl.Split('\\').Last();
                    var test = await Bot.SendPhotoAsync(mensagem.Chat.Id, fts, fluxoAux.Pergunta.Split('|')[0],
                        replyMarkup: rkm);
                }
            }
            else
            {
                TimerIDs.Remove(e.Message.Chat.Id);
                await Bot.SendTextMessageAsync(
                        mensagem.Chat.Id,
                        fluxoAux.Pergunta,
                        replyMarkup: rkm);
            }
        }
        
    }
}
