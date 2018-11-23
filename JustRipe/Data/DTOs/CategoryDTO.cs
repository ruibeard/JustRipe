using SQLite.Net.Attributes;

namespace JustRipe.Data.DTOs
{
    [Table("categories")]
    public class CategoryDTO
    {
        [PrimaryKey, Column("id"), AutoIncrement]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("parent_id")]
        public int ParentID { get; set; }
    }
}