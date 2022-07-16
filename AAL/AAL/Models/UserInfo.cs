using System.ComponentModel.DataAnnotations;

namespace AAL.Models
{
    public partial class UserInfo
    {
        public int UserInfoId { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Avatar { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public string UserId { get; set; }
        public CustomUser? CustomUser { get; set; }
    }
}
