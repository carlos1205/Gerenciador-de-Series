using System;
using System.Collections;
using System.Collections.Generic;

namespace DIO.Series
{
    public class Repositorio
    {
        private SerieRepositorio repositorioSerie = new SerieRepositorio();
        private FilmeRepositorio repositorioFilme = new FilmeRepositorio();

        public void Atualiza(Tipo tipo, int id, object entidade)
        {
            switch(tipo)
            {
                case Tipo.Serie:
                {
                    Serie s = entidade as Serie;
                    repositorioSerie.Atualiza(id, s);
                }break;
                case Tipo.Filme:
                {
                    Filme f = entidade as Filme;
                    repositorioFilme.Atualiza(id, f);
                }break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Exclui(Tipo tipo, int id)
        {
            switch(tipo)
            {
                case Tipo.Serie:
                    repositorioSerie.Exclui(id);
                    break;
                case Tipo.Filme:
                    repositorioFilme.Exclui(id);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Insere(Tipo tipo, object entidade)
        {
            switch(tipo)
            {
                case Tipo.Serie:
                {
                    Serie s = entidade as Serie;
                    repositorioSerie.Insere(s);
                }break;
                case Tipo.Filme:
                {
                    Filme f = entidade as Filme;
                    repositorioFilme.Insere(f);
                }break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public List<object> Lista(Tipo tipo)
        {
            List<object> lista;
            switch(tipo)
            {
                case Tipo.Serie:
                {
                    lista = repositorioSerie.Lista().ConvertAll(obj => (object)obj);
                }break;
                case Tipo.Filme:
                {
                    lista = repositorioFilme.Lista().ConvertAll(obj => (object)obj);
                }break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return lista;
        }

        public int ProximoId(Tipo tipo)
        {
            switch(tipo)
            {
                case Tipo.Serie:
                    return repositorioSerie.ProximoId();
                    
                case Tipo.Filme:
                    return repositorioFilme.ProximoId();
                    
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object RetornaPorId(Tipo tipo, int id)
        {
            switch(tipo)
            {
                case Tipo.Serie:
                    return repositorioSerie.RetornaPorId(id);
                    
                case Tipo.Filme:
                    return repositorioFilme.RetornaPorId(id);
                    
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}