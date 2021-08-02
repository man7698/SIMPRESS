using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROVASIMPRESS.Models
{
    public class Produto
    {
        public int ID { get; set; }

        public string NOME { get; set; }

        [Required(ErrorMessage = "Informe uma DESCRICAO !")]
        public string DESCRICAO { get; set; }

        
        public bool ATIVO { get; set; }

      
        public bool PERECIVEL { get; set; }

        public int IDCATEGORIA { get; set; }


    }
}