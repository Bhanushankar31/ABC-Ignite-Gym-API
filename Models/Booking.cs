namespace ABCIgnite.Models;
public class Booking
{
    public int Id { get; set; }
    public required string MemberName { get; set; }
    public int ClassId { get; set; }
    public DateTime ParticipationDate { get; set; }
}