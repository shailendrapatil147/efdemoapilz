using System.ComponentModel.DataAnnotations.Schema;

namespace LZ.Models.efdemo.Entity.Contracts
{
    public class UserDetailsEntity: BaseEntity
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string Email { get; set; }

        public virtual UserEntity FkUserNavigation { get; set; }
    }
}