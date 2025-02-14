using System.ComponentModel.DataAnnotations;

namespace VillaManage_VillaAPI.Model.DTO
{
    public class VillaUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]

        public double Rate { get; set; }
        [Required]

        public int Occupancy { get; set; }
        [Required]

        public int Sqft { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}
