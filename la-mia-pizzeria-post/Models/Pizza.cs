using la_mia_pizzeria_static.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public Pizza(string nome, string descrizione, string? foto, double prezzo)
        {
            Nome = nome;
            Descrizione = descrizione;
            Foto = foto;
            Prezzo = prezzo;
        }
        public Pizza() { }

        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Il nome della pizza è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il nome della pizza è troppo lungo")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descrizione della pizza è obbligatoria")]
        [StringLength(500, ErrorMessage = "La descrizione della pizza è troppo lunga")]
        [MoreThanFiveWords]
        [Column(TypeName = "text")]
        public string Descrizione { get; set; } = string.Empty;
        public string? Foto { get; set; }

        [Required(ErrorMessage = "Il prezzo della pizza è obbligatorio")]
        [MoreThanZero]
        public double Prezzo { get; set; } = 0;

    }
}
