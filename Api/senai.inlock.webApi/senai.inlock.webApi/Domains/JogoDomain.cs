using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int idJogo { get; set; }

        public int idStudio { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome do Jogo não está dentro dos parametros, insira um nome válido")]
        public string nomeJogo { get; set; }

        [StringLength(200, ErrorMessage = "A descrição do Jogo não está dentro dos parametros, insira uma descrição válida.")]
        public string descricaoJogo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime dataLancamento { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "O valor do Jogo não está dentro dos parametros, insira um valor válido")]
        public string valorJogo { get; set; }
    }
}
