using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teste.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        [Required]
        public int EnderecoId { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; }
    }

    public class Endereco
    {
        public int Id { get; set; }
        public string Logradouto { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public Cidade Cidade { get; set; }
        [Required]
        public int CidadeId { get; set; }
    }

    public class UF
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public UF UF { get; set; }
        [Required]
        public int UFId { get; set; }
    }

    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
