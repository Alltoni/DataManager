namespace DataManager.CQRS.Commands
{
    // DONE: zaktualizuj o pole które dodałes w Humans.cs 
    public class UpdateHumanCommandHandler // : IRequest<Human>
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required string Surname { get; set; }
        public string? Description { get; set; }
    }
}
