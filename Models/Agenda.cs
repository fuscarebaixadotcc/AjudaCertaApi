using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AjudaCerta.Models.Enuns;

namespace AjudaCerta.Models
{
    public class Agenda
    {
        [Key]
        public int idAgenda { get; set; }
        public DateTime data { get; set; }
        public Endereco endereco { get; set; }
        public TipoDoacaoEnum tipo { get; set; }
        public StatusDoacaoEnum status { get; set; }
        public Pessoa pessoa { get; set; }
    }
}