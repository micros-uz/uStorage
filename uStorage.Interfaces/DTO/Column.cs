namespace uStorage.Interfaces.DTO
{
    public class Column
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public bool IsNotNull { get; set; }
        public bool IsPrimaryKey { get; set; }
        public Table RefTable{ get; set; }
        public Column RefTableColumn { get; set; }
        public bool IsUnique { get; set; }
    }
}
