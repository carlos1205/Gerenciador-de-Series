using System;
using System.Collections.Generic;
using DIO.Series.Interface;

namespace DIO.Series
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> filmList = new List<Filme>();
        public void Atualiza(int id, Filme entidade)
        {
            this.filmList[id] = entidade;
        }

        public void Exclui(int id)
        {
            this.filmList[id].Excluir();
        }

        public void Insere(Filme entidade)
        {
            this.filmList.Add(entidade);
        }

        public List<Filme> Lista()
        {
            return filmList;
        }

        public int ProximoId()
        {
            return filmList.Count;
        }

        public Filme RetornaPorId(int id)
        {
            return filmList[id];
        }
    }
}