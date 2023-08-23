using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjudaCerta.Models
{
    public class Eletrodomestico : ItemDoacao
    {
        public int idEletro { get; set; }
        public string medida { get; set; }
        public string condicao { get; set; }
    }
}