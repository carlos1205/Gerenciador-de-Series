using System;
using System.Collections.Generic;
using DIO.Series.Interface;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> serieList = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            serieList[id] = entidade;
        }

        public void Exclui(int id)
        {
            serieList[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            serieList.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return serieList;
        }

        public int ProximoId()
        {
            return serieList.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return serieList[id];
        }
    }
}