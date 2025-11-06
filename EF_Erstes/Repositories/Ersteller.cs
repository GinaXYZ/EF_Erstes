using System;
using System.Collections.Generic;

namespace EF_Erstes.Repositories;

public partial class Ersteller
{
    public int Eid { get; set; }

    public string Vorname { get; set; } = null!;

    public string Nachname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefon { get; set; }

    public bool Aktiv { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
