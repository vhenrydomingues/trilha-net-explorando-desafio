using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models
{
    public class Hospede
    {
        public Pessoa P = new();
        public int Id { get; set;}

        public Hospede(){}

        public Hospede(Pessoa p, int id)
        {
            P = p;
            Id = id;
        }
    };
    public class Hospedes
    {
        public List<Hospede> ListaHospede = new();
        public void CadastrarHospede()
        {
            Console.WriteLine("Digite o nome do hospede:");
			string nome = Console.ReadLine();
            Console.WriteLine("Digite o sobrenome do hospede:");
			string sobrenome = Console.ReadLine();
            int id = ListaHospede.Count;            
            id++;
			
           ListaHospede.Add(new Hospede(new Pessoa(nome, sobrenome),id));
           Console.WriteLine("Hospede Cadastrado com Sucesso");
        }
        public void RemoverHospede(Hospede hosp)
        {
           ListaHospede.Remove(hosp);
        }
        public void ListarHospede()
        {
           if(!ListaHospede.Any())
            {
                Console.WriteLine("Não existe Hospedes cadastrado no sistema");
                return;
            }
            Console.WriteLine("Lista de hospedes:");
            ListaHospede.ForEach(x => Console.WriteLine($"Id: {x.Id}, Nome: {x.P.NomeCompleto}"));
        }
        public void RemoverHospede()
        {
           if(!ListaHospede.Any())
            {
                Console.WriteLine("Não existe suites cadastradas no sistema");
                return;
            }
            Console.WriteLine("Digite o id do Hospede que deseja remover");
            int idHospede = int.Parse(Console.ReadLine());
            if (!ListaHospede.Any(x => x.Id == idHospede))
            {
                Console.WriteLine($"Não existe o hospede com o id {idHospede} no sistema");
                return;
            }
            ListaHospede.RemoveAll(x => x.Id == idHospede);
            Console.WriteLine("Suite removida com Sucesso");   
        }

    }
    
}