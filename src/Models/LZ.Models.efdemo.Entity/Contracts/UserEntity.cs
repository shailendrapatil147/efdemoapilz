using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LZ.Models.efdemo.Entity.Contracts
{
    public class UserEntity: BaseEntity
    {
        public UserEntity()
        {
            FkUserContacttNavigation = new HashSet<UserContactEntity>();
            FkUserDetailsNavigation = new UserDetailsEntity();
        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public int UserContactId { get; set; }
        public int UserDetailId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserContactEntity> FkUserContacttNavigation { get; set; }
        public virtual UserDetailsEntity FkUserDetailsNavigation { get; set; }
    }
}