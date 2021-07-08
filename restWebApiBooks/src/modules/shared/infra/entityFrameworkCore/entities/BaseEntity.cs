using System.ComponentModel.DataAnnotations.Schema;

namespace restWebApiBooks.src.modules.shared.infra.entityFrameworkCore.entities
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}