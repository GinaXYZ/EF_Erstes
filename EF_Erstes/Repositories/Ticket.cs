using System;
using System.Collections.Generic;

namespace EF_Erstes.Repositories;

public partial class Ticket
{
    public int Tid { get; set; }

    public string Titel { get; set; } = null!;

    public string? Beschreibung { get; set; }

    public int ErstellerId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime Erstelldatum { get; set; }

    public DateTime? Faelligkeitsdatum { get; set; }

    public DateTime LetzteAenderung { get; set; }

    public virtual Ersteller Ersteller { get; set; } = null!;
}
