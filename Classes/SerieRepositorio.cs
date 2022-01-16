using System;
using DIO.Series.Interfaces;
using System.Collections.Generic;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int Proximoid()
        {
            /* Como o vetor começa no 0 a quantidade de elementos dele sempre será
            Uma a mais das posições do mesmo. Ou seja, o Count sempre retornará
            um elemento a mais, em outras palavras, o próximo elemento
            */
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}