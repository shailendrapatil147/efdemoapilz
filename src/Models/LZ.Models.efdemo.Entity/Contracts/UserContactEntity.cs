using System.ComponentModel.DataAnnotations.Schema;

namespace LZ.Models.efdemo.Entity.Contracts
{
    public class UserContactEntity: BaseEntity
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string City { get; set; }
        public string Pinccode { get; set; }
        public string State{ get; set; }
        public string Area { get; set; }

        public virtual UserEntity FkUserNavigation { get; set; }
    }
}