using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AjudaCerta.Models
{
    
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public byte[]? senha_hash { get; set; }
        public byte[]? senha_salt { get; set; } 

        [NotMapped]
        public int? numeroTentativas { get; set; }
        [NotMapped]
        public Boolean? bloqueado { get; set; }

        [NotMapped]
        public Pessoa? pessoa{ get; set; }
    }
}