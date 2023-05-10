namespace ProjectApiApp.Model
{
    public class ItemModel
    {
        public int id { get; set; }

        public string code { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;

        public int? parent_id { get; set; }
    }
}
