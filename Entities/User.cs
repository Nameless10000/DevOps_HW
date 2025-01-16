using System.ComponentModel.DataAnnotations;

namespace DevOps_HW.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public override string ToString()
        {
            return $"{ID} - {Name} ({Email})";
        }
    }
}
