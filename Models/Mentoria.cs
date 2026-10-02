namespace Nodo.Models
{
    public class Mentoria
    {
        public int ID { get; set; }
        public int? ID_Mentorando { get; set; }
        public int? ID_Mentor { get; set; }
        public int? ID_Material_De_Apoio { get; set; }
         public int? ID_Anotacao { get; set; }
        public DateTimeOffset Horario_Inicio { get; set; }
        public DateTimeOffset Horario_Fim { get; set; }
        public string? Link { get; set; }
        public required string status { get; set; }
        public required string Descricao { get; set; }
    }
}