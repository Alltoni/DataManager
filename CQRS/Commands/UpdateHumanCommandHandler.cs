namespace DataManager.CQRS.Commands
{
    public class UpdateHumanCommandHandler // : IRequest<Human>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
