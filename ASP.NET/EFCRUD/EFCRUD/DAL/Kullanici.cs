using System;
using System.Collections.Generic;

namespace EFCRUD.DAL;

public partial class Kullanici
{
    public int Id { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Sifre { get; set; } = null!;

    public int IlId { get; set; }

    public virtual Iller Il { get; set; } = null!;
}
