namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        private List<Suite> suites = new();

        public Suite(int quarto, string tipoSuite, int capacidade, decimal valorDiaria)
        {
            Quarto = quarto;
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public int Quarto { get; set; }
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
        public bool Disponivel {get; set;}

        public void CadastrarSuite()
        {
            Console.WriteLine("Digite o numero do quarto:");
			int quarto = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o tipo da suite:");
			string tipoSuite = Console.ReadLine();
			Console.WriteLine("Digite a capacidade de pessoas na suite (apenas numero)");
			int capacidade = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite o valor da diaria");
			decimal valorDiaria = Decimal.Parse(Console.ReadLine());

            if (suites.Any(s => s.Quarto == quarto))
            {
                Console.WriteLine("Quarto ja cadastrado!");
                return;
            }
            suites.Add(new Suite { Quarto = quarto, TipoSuite = tipoSuite, Capacidade = capacidade, ValorDiaria = valorDiaria, Disponivel = true});
            Console.WriteLine("Suite Cadastrada com Sucesso");            
        }
        public void 
        ListarSuites()
        {
            if(!suites.Any())
            {
                Console.WriteLine("Não existe suites cadastradas no sistema");
                return;
            }
            Console.WriteLine("Lista de suites:");
            suites.ForEach(x => Console.WriteLine($"Suite: {x.Quarto}, Tipo: {x.TipoSuite}, Capacidade: {x.Capacidade}, Valor da diaria: {x.ValorDiaria}, Disponivel: {x.Disponivel}"));
        }
        public void DadosDaSuite(int quarto)
        {
            Suite su = suites.First(x => x.Quarto == quarto);
            Console.WriteLine($"Suite: {su.Quarto}, Tipo: {su.TipoSuite}, Capacidade: {su.Capacidade}, Valor da diaria: {su.ValorDiaria}, Disponivel: {su.Disponivel}");
        }
        public List<Suite> RetornaSuites()
        {
           return suites;
        }
        public void AtualizaSuite(int quarto, bool disponivel)
        {
           suites.First(x => x.Quarto == quarto).Disponivel = disponivel;
        }
        public void RemoverSuite()
        {
           if(!suites.Any())
            {
                Console.WriteLine("Não existe suites cadastradas no sistema");
                return;
            }
            Console.WriteLine("Digite o numero da suite que deseja remover");
            int quarto = int.Parse(Console.ReadLine());
            if (!suites.Any(x => x.Quarto == quarto))
            {
                Console.WriteLine($"Não existe o quarto numero {quarto} no sistema");
                return;
            }
            suites.RemoveAll(x => x.Quarto == quarto);
            Console.WriteLine("Suite removida com Sucesso");   
        }
    }
}