using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AjudaCerta.Models
{
    public class ItemDoacao
    {
        [Key]
        public int idItem { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public List<ItemDoacaoDoado> ItemDoacaoDoado { get; set; }
    }
}