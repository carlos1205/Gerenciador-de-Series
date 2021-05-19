namespace DIO.Series
{
    public abstract class EntidadeBase
    {
        protected int Id { get; set; }
        protected Genero Genero { get; set; }
        protected string Titulo { get; set; }
        protected string Descricao { get; set; }
        protected int Ano { get; set; }
        protected bool Excluido { get; set; }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public bool IsExcluido(){
            return this.Excluido;
        }

        public int RetornaId()
        {
            return this.Id;
        }
        
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}