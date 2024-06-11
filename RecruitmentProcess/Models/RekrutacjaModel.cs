using Microsoft.AspNetCore.Mvc;

namespace RecruitmentProcess.Models
{
    public class RekrutacjaModel
    {
        public int Id { get; set; }
        public int IdAplikacji { get; set; }
        public int IdOgloszenia { get; set; }
        public int IdRekrutera { get; set; }
        public int IdUzytkownika { get; set; }
        public string Tresc { get; set; }
        public DateTime DataAplikacji { get; set; }
        public byte[] PlikCV { get; set; }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                List<string> validStatuses = new List<string> {
                "Oczekujące",
                "W trakcie weryfikacji",
                "Odrzucone",
                "W trakcie selekcji",
                "Zaproszenie na rozmowę",
                "Oferta pracy wysłana",
                "Zatrudniony"
            };
                if (validStatuses.Contains(value))
                {
                    status = value;
                }
                else
                {
                    throw new ArgumentException("Niepoprawny status.");
                }
            }
        }
    }
}
