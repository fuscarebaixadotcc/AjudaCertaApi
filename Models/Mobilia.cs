using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AjudaCerta.Models
{
    public class Mobilia : ItemDoacao
    {
        
        public int idMobilia { get; set; }
        public string tipo { get; set; }
        public string medida { get; set; }
        public string condicao { get; set; }
    }
}