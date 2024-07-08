namespace DataManager.CQRS.Commands
{
    // TODO: zaktualizuj o pole które dodałes w Humans.cs 
    public class UpdateHumanCommandHandler // : IRequest<Human>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
