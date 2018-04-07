using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public class Aparelho
    {
        public Aparelho(int id, string nome, string imagem)
        {
            Id = id;
            Nome = nome;
            Imagem = imagem;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

    }

    public class Aparelhos
    {
        public List<Aparelho> lista_Aparelhos=new List<Aparelho>();


        public Aparelhos()
        {
            lista_Aparelhos.Add(new Aparelho(1, "Supino", "Supino.jpg"));
            lista_Aparelhos.Add(new Aparelho(2, "Remada", "Remada.jpg"));
            lista_Aparelhos.Add(new Aparelho(3, "Cadeira Flexora", "Cadeira.jpg"));
            lista_Aparelhos.Add(new Aparelho(4, "Abdominal supra reto", "Abdominal.jpg"));
            lista_Aparelhos.Add(new Aparelho(5, "Lombar", "Lombar.jpg"));
            lista_Aparelhos.Add(new Aparelho(6, "Puxada", "Puxada.jpg"));
            lista_Aparelhos.Add(new Aparelho(7, "Leg press 45", "Leg.jpg"));

        }


        public Aparelho getAparelho(int id)
        {
            return lista_Aparelhos.Where(p => p.Id == id).FirstOrDefault();
        }

    }
}
