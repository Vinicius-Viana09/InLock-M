using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        [Required]
        public int idTipoUsuario { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O email inserido não está dentro dos parametros, insira um valor válido")]
        public string emailUsuario { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "A senha inserida não está dentro dos parametros, insira um valor válido")]
        public string senhaUsuario { get; set; }
    }
}
