using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public class Conversa
    {


        private static List<string> _perguntas_realizadas = new List<string>();
        private static List<string> _respostas_realizadas = new List<string>();

        public static List<string> Respostas_realizadas { get => _respostas_realizadas; set => _respostas_realizadas = value; }
        public static List<string> Perguntas_realizadas { get => _perguntas_realizadas; set => _perguntas_realizadas = value; }

        public static string FazerPergunta(string pergunta)
        {
            if (Perguntas_realizadas == null)
            {
                Perguntas_realizadas = new List<string>();
            }
            Perguntas_realizadas.Add(pergunta);
            return pergunta;
        }
        public static string RespostaRecebida(string resposta)
        {
            if (Respostas_realizadas == null)
            {
                Respostas_realizadas = new List<string>();
            }
            Respostas_realizadas.Add(resposta);
            return resposta;
        }
        public static string UltimaPergunta()
        {
            if (Perguntas_realizadas.Count > 0)
            {
                return Perguntas_realizadas[Perguntas_realizadas.Count - 1];
            }
            return "";
        }
        public static string UltimaResposta()
        {
            if (Respostas_realizadas.Count > 0)
            {
                return Respostas_realizadas[Respostas_realizadas.Count - 1];
            }
            return "";
        }
        public static string PenultimaPergunta()
        {
            if (Perguntas_realizadas.Count > 1)
            {
                return Perguntas_realizadas[Perguntas_realizadas.Count - 2];
            }
            return "";
        }
        public static string PenultimaResposta()
        {
            if (Respostas_realizadas.Count > 1)
            {
                return Respostas_realizadas[Respostas_realizadas.Count - 2];
            }
            return "";
        }
        public static void Limpar()
        {
            Respostas_realizadas = new List<string>();
            Perguntas_realizadas = new List<string>();
        }
        public static void RepostaInvalida()
        {
            //a reposta nao é valida, remover a resposta da lista 
           
                if (Respostas_realizadas.Count > 0)
                {
                    Respostas_realizadas.RemoveAt(Respostas_realizadas.Count - 1);
                }
                //if (Perguntas_realizadas.Count > 0)
                //{
                //    Perguntas_realizadas.RemoveAt(Perguntas_realizadas.Count - 1);
                //}
            
        }
        public static string MapaPergunta()
        {
            string penultima_resposta = PenultimaResposta();
            string ultima_respota = UltimaResposta();


            if (ultima_respota == "" || penultima_resposta == "")
            {

                return GetPergunta(1);
            }
            if (UltimaPergunta() == GetPergunta(1) && ultima_respota == "Sim")
            {
                return GetPergunta(2);
            }
            if (UltimaPergunta() == GetPergunta(2) && ultima_respota == "Frango")
            {
                return GetPergunta(3);
            }
            if (UltimaPergunta() == GetPergunta(2) && ultima_respota == "Moderado")
            {
                return GetPergunta(4);
            }
            if (UltimaPergunta() == GetPergunta(2) && ultima_respota == "Monstro")
            {
                return GetPergunta(5);
            }
            if (UltimaPergunta() == GetPergunta(1) && ultima_respota == "Não")
            {
                Limpar();
                return GetPergunta(0);
            }

            RepostaInvalida();
            return GetPergunta(-1); ;


        }

        public static string GetPergunta(int cod)
        {
            return pergutas[cod];
        }

        public static Dictionary<int, string> pergutas = new Dictionary<int, string>()
    {
        { 1, "Vamos Malhar?"},
        { 2, "Legal, que tipo de treino você quer?"},
        { 3, "Frango? Putz... Então vamos!!!"},
          { 4, "Moderado? Então vamos!!!"},
            { 5, "Monstro, ai sim... Então vamos!!!"},
         {0, "Ok, seu preguiçoso" },
             {-1, "Ah? não estou entendendo!" }

    };

    }
}
