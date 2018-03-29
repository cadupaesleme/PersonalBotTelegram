using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public class BotComando
    {
        public Guid Id { get; set; }
        public string Etapa { get; set; }
        public string Comando { get; set; }
        
        public IList<BotOpcoes> Opcoes { get; set; }
        public IList<BotOpcoes> OpcoesErro { get; set; }

        //retornar as respostas possiveis pro usuario de acordo com o comando que o usuario deu
        public IList<BotOpcoes> RepostasPorComando()
        {
            //retorna os comandos baseados na resposta
            var listaRespostas = new List<BotOpcoes>().Where(op => op.Comando.Comando == Comando).ToList();

            if (listaRespostas.Count == 0)
            {
                listaRespostas = OpcoesErro.ToList();
            }

            return listaRespostas;
        }
    }
}
