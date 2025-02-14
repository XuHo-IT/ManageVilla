using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VillaManage_Web.Model.DTO
{
    public class VillaNumberDTO
    {
        [Required]
        public int VillaNo { get; set; }

        [Required]
        public int VillaID { get; set; }
        public string SpecialDetails { get; set; }
    }
}
