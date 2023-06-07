using System.ComponentModel.DataAnnotations.Schema;

namespace ProductProject.Models.Entities
{
    public class Address: BaseEntity<int>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public string City { get; set; }
        public string Text { get; set; }

    }
}
