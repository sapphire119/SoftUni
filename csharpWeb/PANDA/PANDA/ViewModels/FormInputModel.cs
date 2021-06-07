using System.ComponentModel.DataAnnotations;

namespace Panda.Controllers
{
    public class FormInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}