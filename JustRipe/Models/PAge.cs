using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRipe.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }



        public static List<Page> GetPages()
        {
            return new List<Page>()
        {
            new Page()
            {
                Id = 1,
                Name = "Crop",
                Description = "Crops Page Description",
            },
            new Page()
            {
                Id = 2,
                Name = "Stock",
                Description = "Stock Page Description",
            },
            new Page()
            {
                Id = 3,
                Name = "harvest",
                Description = "harvest Page Description",
            }
        };
        }

    }
}
