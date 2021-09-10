using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class StudioDomain
    {
        public int idStudio { get; set; }

        [Required(ErrorMessage = "Não é possivel cadastrar um Studio sem nome, por favor repita o processo.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "O nome do Studio não está dentro dos parametros, insira um nome válido")]
        public string nomeStudio { get; set; }
    }
}
