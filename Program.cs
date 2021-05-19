using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario;

            do{
                opcaoUsuario = ObterOpcaoUsuario();

                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2": 
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        Console.WriteLine("Até a proxima");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }while(opcaoUsuario != "X");
        }

        public static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar Série");
            Console.Write("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        
        public static void ExcluirSerie()
        {
            Console.WriteLine("Excluir Série");
            Console.Write("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
        public static void InserirSerie()
        {
            Console.WriteLine("Inserir Série");

            Serie novaSerie = ObterDadosSerie(repositorio.ProximoId());

            repositorio.Insere(novaSerie);
        }

        public static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar Série");
            Console.Write("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Serie novaSerie = ObterDadosSerie(indiceSerie);

            repositorio.Atualiza(indiceSerie, novaSerie);
            
        }

        public static void ListarSerie(){
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série Cadastrada");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.IsExcluido();
                Console.WriteLine("#ID {0}: - {1}{2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "(Excluído)" : ""));

            }
        }

        public static Serie ObterDadosSerie(int id){

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a temporada da série: ");
            int entradaTemporada = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero de episodios que a temporada tem: ");
            int entradaQuantidadeEpisodios = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            return new Serie(
                id: id,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                temporada: entradaTemporada,
                quantidadeEpisodio: entradaQuantidadeEpisodios,
                ano: entradaAno,
                descricao: entradaDescricao
            );
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries!!!");
            Console.WriteLine("Informe a Opção Desejada");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
