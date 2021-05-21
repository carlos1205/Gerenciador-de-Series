using System;

namespace DIO.Series
{
    class Program
    {   
        static Repositorio repo = new Repositorio();
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
                    case "6":
                        ListarFilme();
                        break;
                    case "7": 
                        InserirFilme();
                        break;
                    case "8":
                        AtualizarFilme();
                        break;
                    case "9":
                        ExcluirFilme();
                        break;
                    case "10":
                        VisualizarFilme();
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

            var serie = repo.RetornaPorId(Tipo.Serie ,indiceSerie);

            Console.WriteLine(serie);
        }
        
        public static void ExcluirSerie()
        {
            Console.WriteLine("Excluir Série");
            Console.Write("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repo.Exclui(Tipo.Serie ,indiceSerie);
        }
        public static void InserirSerie()
        {
            Console.WriteLine("Inserir Série");

            Serie novaSerie = ObterDadosSerie(repo.ProximoId(Tipo.Serie));

            repo.Insere(Tipo.Serie, novaSerie);
        }

        public static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar Série");
            Console.Write("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Serie novaSerie = ObterDadosSerie(indiceSerie);

            repo.Atualiza(Tipo.Serie, indiceSerie, novaSerie);
            
        }

        public static void ListarSerie(){
            Console.WriteLine("Listar Séries");

            var lista = repo.Lista(Tipo.Serie);
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série Cadastrada");
                return;
            }

            foreach(var serie in lista)
            {
                var s = serie as Serie;
                var excluido = s.IsExcluido();
                Console.WriteLine("#ID {0}: - {1}{2}", s.RetornaId(), s.RetornaTitulo(), (excluido ? "(Excluído)" : ""));

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

        public static void VisualizarFilme()
        {
            Console.WriteLine("Visualizar Filme");
            Console.Write("Digite o Id do Filme: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var filme = repo.RetornaPorId(Tipo.Filme, indiceSerie);

            Console.WriteLine(filme);
        }
        
        public static void ExcluirFilme()
        {
            Console.WriteLine("Excluir Filme");
            Console.Write("Digite o Id do Filme: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repo.Exclui(Tipo.Filme, indiceSerie);
        }
        public static void InserirFilme()
        {
            Console.WriteLine("Inserir Filme");

            Filme novoFilme = ObterDadosFilme(repo.ProximoId(Tipo.Filme));

            repo.Insere(Tipo.Filme, novoFilme);
        }

        public static void AtualizarFilme()
        {
            Console.WriteLine("Atualizar Filme");
            Console.Write("Digite o Id da Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            Filme novoFilme = ObterDadosFilme(indiceFilme);

            repo.Atualiza(Tipo.Filme, indiceFilme, novoFilme);
            
        }

        public static void ListarFilme(){
            Console.WriteLine("Listar Filmes");

            var lista = repo.Lista(Tipo.Filme);
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum Filme Cadastrado");
                return;
            }

            foreach(var filme in lista)
            {
                var f = filme as Filme;
                var excluido = f.IsExcluido();
                Console.WriteLine("#ID {0}: - {1}{2}", f.RetornaId(), f.RetornaTitulo(), (excluido ? "(Excluído)" : ""));
            }
        }

        public static Filme ObterDadosFilme(int id){

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a duração do filme: ");
            Console.Write("Formato (hh:mm:ss): ");
            string entradaDuracao = Console.ReadLine();

            Console.Write("Digite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            return new Filme(
                id: id,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                duracao: entradaDuracao,
                ano: entradaAno,
                descricao: entradaDescricao
            );
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Carlos Entreterimento!!!");
            Console.WriteLine("Informe a Opção Desejada");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("6 - Listar filmes");
            Console.WriteLine("7 - Inserir novo filme");
            Console.WriteLine("8 - Atualizar filme");
            Console.WriteLine("9 - Excluir filme");
            Console.WriteLine("10 - Visualizar filme");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
