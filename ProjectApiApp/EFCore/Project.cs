using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectApiApp.EFCore
{
    [Table("project")]
    public class Project
    {
        [Key, Required]
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public List<Item> Items { get; set; } = new List<Item>();
    }
}
