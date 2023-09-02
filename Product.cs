using NpgsqlTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FulltextSearchDemo;

public class Product
{
    [Key]
    [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
    public long Id { get; set; }
    [StringLength( 50 )]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public NpgsqlTsVector SearchVector { get; set; } = null!;
}
