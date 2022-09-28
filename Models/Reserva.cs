namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<DadosReserva> reserva { get; set;}
        public int DiasReservados { get; set; }
        public int IdHospedes { get; set; }
        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        
    }

    public class DadosReserva
    {
        Suite su = new();
        public int Id { get; set; }
        public List<Reserva> ListaReserva { get; set; }
        public void CadastrarReserva()
        {
            Console.WriteLine("Por favor, Digite o id do Hospede que está fazendo a Reserva");
            int idHospede = int.Parse(Console.ReadLine());
            Console.WriteLine("Quantas pessoas irão se hospedar ?");
            int qtdHospedes = int.Parse(Console.ReadLine());
            su.ListarSuites();
            Console.WriteLine("Digite o id da suite desejada");
            int quarto = int.Parse(Console.ReadLine());

            List<Suite> suite = su.RetornaSuites();

            if(!suite.Any(x => x.Quarto == quarto && x.Capacidade <= qtdHospedes && x.Disponivel))
            {
                Console.WriteLine("A suite selecionada não pode ser utilizada!");
                su.DadosDaSuite(quarto);
                return;
            }
            
            su.AtualizaSuite(quarto, false);
            Console.WriteLine("Suite reservada com sucesso");

            
            


            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if (true)
            {
               string aHospedes = string.Empty;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
            }
        }
        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valor = 0;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (true)
            {
                valor = 0;
            }

            return valor;
        }
    }
}