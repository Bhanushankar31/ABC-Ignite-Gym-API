namespace ABCIgnite.Models;
public class BookingRequest
{
    public required string MemberName { get; set; }
    public int ClassId { get; set; }
    public DateTime ParticipationDate { get; set; }
}
