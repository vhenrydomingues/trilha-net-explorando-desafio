using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

bool exibirMenu = true;
string tipoSuite = string.Empty;
// Cria os modelos de hóspedes e cadastra na lista de hóspedes
Suite su = new();
Hospedes ho = new();
DadosReserva re = new();


// Cria uma nova reserva, passando a suíte e os hóspedes


// Exibe a quantidade de hóspedes e o valor da diária

Console.WriteLine("-------------------------------------");
Console.WriteLine("|                                   |");
Console.WriteLine("|          Seja bem vindo           |");
Console.WriteLine("|       Sistema de hotelaria        |");
Console.WriteLine("|                                   |");
Console.WriteLine("-------------------------------------");
Continuar();


while (exibirMenu)
{
	
	Console.Clear();
	Console.WriteLine("-------------------------------------");
	Console.WriteLine("|                                   |");
	Console.WriteLine("|          Menu Principal           |");
	Console.WriteLine("|                                   |");
	Console.WriteLine("-------------------------------------");
	Console.WriteLine();
	Console.WriteLine("Por favor, selecione uma das opções");
	Console.WriteLine();
	Console.WriteLine("1 - Cadastrar suite");
	Console.WriteLine("2 - Cadastrar hospede");
	Console.WriteLine("3 - Consultar suites");
	Console.WriteLine("4 - Consultar hospedes");
	Console.WriteLine("5 - Remover suite");
	Console.WriteLine("6 - Remover hospede");
	Console.WriteLine("7 - Cadastrar reserva");
	Console.WriteLine("8 - Consultar reservas");	
	Console.WriteLine("9 - Remover reserva");	
	Console.WriteLine("10 - Encerrar o sistema");


	switch (int.Parse(Console.ReadLine()))
	{

		case 1:
			Console.Clear();
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("|                                   |");
			Console.WriteLine("|          Cadastro de Suite        |");
			Console.WriteLine("|                                   |");
			Console.WriteLine("-------------------------------------");
			Console.WriteLine();
			
			su.CadastrarSuite();
			Continuar();

			break;
		case 2:
			ho.CadastrarHospede();
			Continuar();

			break;
		case 3:
			Console.WriteLine();
			su.ListarSuites();
			Continuar();
			break;
		case 4:
			Console.WriteLine();
			ho.ListarHospede();
			Continuar();
			break;
		case 5:
			Console.WriteLine();
			su.RemoverSuite();
			Continuar();
			break;
		case 6:
			Console.WriteLine();
			ho.RemoverHospede();
			Continuar();
			break;
		case 7:		
			Console.WriteLine();
			re.CadastrarReserva(su, ho);
			Continuar();
			break;
		case 8:
			Console.WriteLine();
			re.ListarReservas(re.ListaReserva, ho.ListaHospede);
			Continuar();
			break;
		case 9:
			Console.WriteLine();
			re.RemoverReserva(su);
			Continuar();
			break;
		case 10:
			exibirMenu = false;
			Console.Clear();
			break;
		default:
			Console.WriteLine("Por favor, selecione uma opção valida...");
			
			break;
	}
}

void Continuar()
{
	Console.WriteLine("Pressione qualquer tecla para continuar");
    Console.ReadLine();
}