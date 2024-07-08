//using DataManager.CQRS.Commands;
//using DataManager.Models;
//using DataManager.Repositories;
//using System.Security.Cryptography.X509Certificates;
//using System.Xml.Linq;

//namespace DataManager.CQRS.CommandsHandlers
//{
//    public class CreateHumanCommandHandler : IRequestHandler<CreateHumanCommand, Human>
//    {
//        private readonly IHumanRepository _repository;

//        public CreateHumanCommandHandler()
//        {
//        }

//        public CreateHumanCommandHandler(IHumanRepository repository)
//        {
//            _repository = repository;
//        }

//        public Human Handle(CreateHumanCommand request, CancellationToken cancellationToken)  // powinno być zamiast Human Task<Human>
//        {
//            var human = new Human
//            {
//                Id = request.Id,
//                Name = request.Name,
//                Surname = request.Surname,
//                Description = request.Description
//            };

//            return _repository.CreateHuman(human);
//        }
//    }
//}
