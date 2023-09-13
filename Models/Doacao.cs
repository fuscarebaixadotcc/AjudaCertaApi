using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AjudaCerta.Models.Enuns;
using AjudaCerta.Models;

namespace AjudaCerta.Models
{
    public class Doacao
    {
        [Key]
        public int idDoacao { get; set; }
        public DateTime data { get; set; }
        [JsonIgnore]
        public Pessoa Pessoa{ get; set; }
        public StatusDoacaoEnum statusDoacao { get; set; }
        public TipoDoacaoEnum tipoDoacao { get; set; }
        public StatusDoacaoEnum idDoacaoOrigem { get; set; }
        [JsonIgnore]
        public Agenda Agenda { get; set; }
        [JsonIgnore]
        public Dinheiro? dinheiro { get; set; }
        public List<ItemDoacaoDoado> ItemDoacaoDoado { get; set; }

    }
}