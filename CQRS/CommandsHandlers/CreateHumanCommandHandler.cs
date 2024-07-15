using DataManager.CQRS.Commands;
using DataManager.Models;
using DataManager.Repositories;

namespace DataManager.CQRS.CommandsHandlers
{
    //DONE: jak zmienisz lokalizacje Human.cs do Modelu lub go usuniesz to pamietaj aby zaktualizowac tutaj referencje do nich (bedize brakowal USING namespace) (na Human kliknij, potem CTRL + . )
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

            return _repository.AddHuman(human);
        }

        
    }

  
}
