namespace GYM_Body_Light_API.Src.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateOnly DateReservation { get; set; }
        public string state { get; set; } = String.Empty;
    }
}