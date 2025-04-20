
using System.ComponentModel.DataAnnotations.Schema;

namespace Moves_API_.Models
{
    public class Genre
    {
        //لو شلته هحتاج ادخل انا القيمه
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ضفت السطر دا عشان ال ID يتعمل اوتوماتيك
        public byte Id { get; set; }

        [MaxLength(length: 100)]
        public string Name { get; set; } 
    }
}
