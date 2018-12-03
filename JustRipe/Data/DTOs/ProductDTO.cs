using SQLite.Net.Attributes;

namespace JustRipe.Data.DTOs
{
    [Table("products")]
    public class ProductDTO
    {
        [PrimaryKey, Column("id"), AutoIncrement]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("quantity")]
        public double Quantity { get; set; }

        [Column("unit")]
        public string Unit { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("status")]
        public string Status{ get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

    }
}