namespace ProjectApiApp.Model
{
    public class ProjectModel
    {
        public int id { get; set; }
        public string code { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;

        public int? item_id { get; set; }
    }
}
