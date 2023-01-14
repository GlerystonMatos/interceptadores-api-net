using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Interceptadores.Domain.Dto
{
    [DisplayName("Animal")]
    public class AnimalDto : Dto
    {
        public AnimalDto()
            => Id = Guid.NewGuid();

        [Required(ErrorMessage = "Campo 'Nome' obrigatório")]
        public string Nome { get; set; }
    }
}