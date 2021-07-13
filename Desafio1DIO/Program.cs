using Desafio1DIO.Classes;
using Desafio1DIO.Enum;
using System;
using System.Collections.Generic;

namespace Desafio1DIO
{
	class Program
	{
		static void Main(string[] args)
        {
			do{
				int producao = TipoProducao();
				
				switch (producao)
				{
					case "1":
						static FilmeRepositorio repositorio = new FilmeRepositorio();
						break;
					case "2":
						static SerieRepositorio repositorio = new SerieRepositorio();
						break;
					default:
						throw new ArgumentOutOfRangeException();

				}
			}while(producao!="1" && producao!="2")

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
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirItem()
		{
			Console.WriteLine("Digite o id do filme ou série: ");
			int indiceItem = int.Parse(Console.ReadLine());

			Console.WriteLine("Tem certeza que deseja excluir? 1=SIM | 2=NÃO: ");
			int confirmacao = int.Parse(Console.ReadLine());

			if(confirmacao == 1){}
				repositorio.Exclui(indiceItem);
			}
		}

        private static void VisualizarItem()
		{
			Console.Write("Digite o id da série ou filme: ");
			int indiceItem = int.Parse(Console.ReadLine());

			var Item = repositorio.RetornaPorId(indiceItem);

			Console.WriteLine(Item);
		}

        private static void AtualizarItem()
		{
			Console.Write("Digite o id da série ou filme: ");
			int indiceItem = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série ou Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série ou Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série ou Filme: ");
			string entradaDescricao = Console.ReadLine();

			switch (producao)
			{
				case "1":
					Filme atualizaItem = new Filme(id: indiceItem,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
				break;
				case "2":
					Serie atualizaItem = new Serie(id: indiceItem,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
				break;
			}
			

			repositorio.Atualiza(indiceItem, atualizaItem);
		}
        private static void ListarItem()
		{
			Console.WriteLine("Listar Obras");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum item cadastrado.");
				return;
			}

			foreach (var item in lista)
			{
                var excluido = item.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", item.retornaId(), item.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirItem()
		{
			Console.WriteLine("Inserir nova série ou filme");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			switch (producao)
			{
				case "1":
					Filme novoItem = new Filme(id: indiceItem,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
				break;
				case "2":
					Serie novoItem = new Serie(id: indiceItem,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
				break;
			}

			repositorio.Insere(novoItem);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Títulos");
			Console.WriteLine("2- Inserir novo");
			Console.WriteLine("3- Atualizar tem");
			Console.WriteLine("4- Excluir Item");
			Console.WriteLine("5- Visualizar Item");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		private static string TipoProducao()
		{
			Console.WriteLine();
			Console.WriteLine("Entre com o tipo de Produção desejado?");
			Console.WriteLine("1 = Filmes");
			Console.WriteLine("2 = Series");
			Console.WriteLine();

			return Console.ReadLine();

		}

	}	
}

