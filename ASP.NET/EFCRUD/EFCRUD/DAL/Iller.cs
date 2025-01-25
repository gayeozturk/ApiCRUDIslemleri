using System;
using System.Collections.Generic;

namespace EFCRUD.DAL;

public partial class Iller
{
    public int Id { get; set; }

    public string Sehir { get; set; } = null!;

    public virtual ICollection<Kullanici> Kullanicis { get; set; } = new List<Kullanici>();
}
