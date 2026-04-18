using System.ComponentModel.DataAnnotations;

namespace Fornspar.Data.Db;

public class RemnantPlacement
{
    [Key]
    public int DbId { get; init; }

    public required string Identifier { get; init; }
}

/*
Bebyggt stadslager
Ej synlig ovan mark
I byggnad eller under vatten
Synlig ovan mark
*/