﻿using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities 
    {
    public class Conteudo
    {
        [Key]
        [Required]
        public int CdConteudo { get; set; }
        public required string DsConteudo { get; set; }
        public required string NmArquivo { get; set; }
        public Extensao DsExtencao { get; set; }

        [Required]
        public virtual int CdAula { get; set; }
        [Required]
        public virtual int CdTurma { get; set; }
        public virtual required Aula Aula { get; set; }

    }
}
