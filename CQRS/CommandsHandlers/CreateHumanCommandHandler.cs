using DataManager.CQRS.Commands;
using DataManager.Repositories;

namespace DataManager.CQRS.CommandsHandlers
{
    public class CreateHumanCommandHandler : IRequestHandler<CreateHumanCommand, Human>
    {
        private readonly IHumanRepository _repository;

        public CreateHumanCommandHandler(IHumanRepository repository)
        {
            _repository = repository;
        }

        public Human Handle(CreateHumanCommand request, CancellationToken cancellationToken)  // powinno być zamiast Human Task<Human>
        {
            var human = new Human(request.Id, request.Name, request.Surname, request.Description)
            {
                Id = request.Id,
                Name = request.Name,
                Surname = request.Surname,
                Description = request.Description == null ? "Missing description" : request.Description
            };

            return _repository.CreateHuman(human);
        }
    }
}
