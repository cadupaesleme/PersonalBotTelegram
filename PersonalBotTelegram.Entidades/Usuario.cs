using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public class Usuario
    {
        public string Nome { get; set; }
        public long Chat { get; set; }
        public Fluxo Fluxo { get; set; }

        public Usuario(string nome, long chat, Fluxo fluxo)
        {
            Nome = nome;
            Chat = chat;
            Fluxo = fluxo;
        }
    }
}
