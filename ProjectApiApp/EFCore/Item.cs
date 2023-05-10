using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectApiApp.EFCore
{
    [Table("item")]
    public class Item
    {
        [Key, Required]
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Item Parent { get; set; }
        public int? ParentId { get; set; }
        public ICollection<Item> SubItems { get; } = new List<Item>();

        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
