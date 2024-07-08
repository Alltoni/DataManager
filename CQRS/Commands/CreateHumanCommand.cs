namespace DataManager.CQRS.Commands
{
    public class CreateHumanCommand // : IRequest<Human>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string Surname { get; internal set; }
    }
}
