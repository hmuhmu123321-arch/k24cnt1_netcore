using System.ComponentModel.DataAnnotations.Schema;

namespace Hmp_TvcLesson12.Models
{
    public partial class HmpProduct
    {
        [NotMapped]
        public IFormFile? HmpImageFile { get; set; }
    }
}