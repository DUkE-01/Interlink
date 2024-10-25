using System.ComponentModel.DataAnnotations;

namespace Interlink.Core.Application.ViewModels.Post
{
    public class SavePostViewModel
    {
        [Required]
        public int UserId { get; set; } 

        [Required(ErrorMessage = "El contenido es obligatorio.")]
        [StringLength(1000, ErrorMessage = "El contenido no puede exceder los 1000 caracteres.")]
        public string Content { get; set; } 

        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

       
        public DateTime? UpdatedAt { get; set; }

      
        public bool IsDeleted { get; set; } = false;
    }
}
