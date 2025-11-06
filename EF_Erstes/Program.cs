using EF_Erstes.Repositories;
using Microsoft.EntityFrameworkCore; 

namespace EF_Erstes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbContext context = new TicketsystemContext();

            List<Ersteller> erstellerListe = context.Set<Ersteller>().ToList();

            foreach (var ersteller in erstellerListe)
            {
                Console.WriteLine($"ID:{ersteller.Eid}, Name: {ersteller.Vorname},Email: {ersteller.Email}");
            }
        }
    }
}
