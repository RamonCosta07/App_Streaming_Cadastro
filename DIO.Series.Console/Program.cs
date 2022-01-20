using System;
using DIO.Series;

namespace DIO.Series.Console
{

    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
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
                        System.Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nosso serviços!");
            System.Console.WriteLine();
        }

        private static void AtualizarSerie()
        {
            System.Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(System.Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite o Titulo da Série: ");

            string entradaTitulo = System.Console.ReadLine();

            System.Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite a descrição da Série: ");
            string entradaDescricao = System.Console.ReadLine();

            Serie atualizaSerie = new Serie(Id: indiceSerie,
                        genero: (Genero)entradaGenero,
                        titulo: entradaTitulo,
                        ano: entradaAno,
                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void VisualizarSerie()
        {
            System.Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(System.Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            System.Console.WriteLine(serie);
        }
        private static void ExcluirSerie()
        {
            System.Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(System.Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if (!excluido)
                {
                    System.Console.WriteLine("ID #{0} - {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }

        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite o Titulo da Série: ");

            string entradaTitulo = System.Console.ReadLine();

            System.Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite a descrição da Série: ");
            string entradaDescricao = System.Console.ReadLine();

            Serie novaSerie = new Serie(Id: repositorio.Proximoid(),
                        genero: (Genero)entradaGenero,
                        titulo: entradaTitulo,
                        ano: entradaAno,
                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("DIO Séries a seu dispor!!!");
            System.Console.WriteLine("Informe a opção desejada: ");

            System.Console.WriteLine("1: Listar Séries");
            System.Console.WriteLine("2: Inserir nova série");
            System.Console.WriteLine("3: Atualizar série");
            System.Console.WriteLine("4: Excluir série");
            System.Console.WriteLine("5: Visualizar série");
            System.Console.WriteLine("C: Limpar tela");
            System.Console.WriteLine("X: Sair");
            System.Console.WriteLine();

            string opcaoUsuario = System.Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}