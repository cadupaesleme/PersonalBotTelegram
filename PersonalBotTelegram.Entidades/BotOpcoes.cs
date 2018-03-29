using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public class BotOpcoes
    {
        public Guid Id { get; set; }
        public string Opcao { get; set; }
        public BotComando Comando { get; set; }
    }
}
