using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public class Passo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<string> Perguntas = new List<string>();
        public string Pergunta { get; set; }
        public List<Opcao> Opcoes { get; set; }

        public Passo() { Opcoes = new List<Opcao>(); }
    }


}
