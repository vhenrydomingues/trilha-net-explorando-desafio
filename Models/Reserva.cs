namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public int DiasReservados { get; set; }
        public int IdHospedes { get; set; }
        public int IdQuarto { get; set; }
        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }
    }

    public class DadosReserva
    {

        public List<Reserva> ListaReserva = new();
        public void CadastrarReserva(Suite su, Hospedes ho)
        {
            ho.ListarHospede();
            Console.WriteLine("Por favor, Digite o id do Hospede que está fazendo a Reserva");
            int idHospede = int.Parse(Console.ReadLine());
            Console.WriteLine("Quantas pessoas irão se hospedar ?");
            int qtdHospedes = int.Parse(Console.ReadLine());    
            su.ListarSuites();        
            Console.WriteLine("Digite o id da suite desejada:");
            int quarto = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a quantidade de dias a ser reservada:");
            int dias = int.Parse(Console.ReadLine());

            List<Suite> suite = su.RetornaSuites();

            if(!suite.Any(x => x.Quarto == quarto && x.Capacidade >= qtdHospedes && x.Disponivel))
            {
                Console.WriteLine("A suite selecionada não pode ser utilizada!");
                su.DadosDaSuite(quarto);
                return;
            }
            
            su.AtualizaSuite(quarto, false);
            Reservar(idHospede, quarto, dias);
            CalcularValorDiaria(suite.First(x => x.Quarto == quarto && !x.Disponivel), dias);
            Console.WriteLine("Suite reservada com sucesso");
        }
        private decimal CalcularValorDiaria(Suite suite, int dias)
        {
            decimal valor = suite.ValorDiaria * dias;
            if (dias >= 10)
            {
                valor = valor * 0.90M ;
            }
            Console.WriteLine($"Valor a ser pago: {valor}");
            return valor;
        }  
        public void ListarReservas(List<Reserva> re, List<Hospede> ho)
        {
            if (!re.Any() || !ho.Any())
            {
                Console.WriteLine("Não foi localizado nenhuma reserva ou nenhum hospede!");
                return;
            }
            var query =
                from pessoa in ho
                join reserva in re on pessoa.Id equals reserva.IdHospedes
                select new
                {
                    IdPessoa = pessoa.Id,
                    nome = pessoa.P.NomeCompleto,
                    Quarto = reserva.IdQuarto
                };
                query.ToList().ForEach(x => Console.WriteLine($"Id: {x.IdPessoa}, Nome: {x.nome}, Quarto: {x.Quarto}"));
        }   

        public void RemoverReserva(Suite su)
        {
            su.ListarSuites();        
            Console.WriteLine("Digite o numero da suite que ficará vaga:");
            int quarto = int.Parse(Console.ReadLine());

            List<Suite> suite = su.RetornaSuites();

            if(!suite.Any(x => x.Quarto == quarto && !x.Disponivel))
            {
                Console.WriteLine("A suite selecionada não existe ou nao está reservada!");
                su.DadosDaSuite(quarto);
                return;
            }
            su.AtualizaSuite(quarto, true);
            ListaReserva.RemoveAll(x => x.IdQuarto == quarto);
            Console.WriteLine("A suite está disponivel para ser reservada por outro cliente!");



        }
        private void Reservar(int id, int quarto, int dias )
        {
            Reserva re = new();
            re.DiasReservados = dias;
            re.IdHospedes = id;
            re.IdQuarto = quarto;
            ListaReserva.Add(re);
        }    
    }
}