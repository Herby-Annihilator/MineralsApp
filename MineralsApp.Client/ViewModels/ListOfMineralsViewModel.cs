using MineralsApp.DataAccessLayer.Entities;
using MineralsApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;

namespace MineralsApp.Client.ViewModels
{
    public class ListOfMineralsViewModel
    {
        private IRepository<Mineral> _repository;
        public ListOfMineralsViewModel(IRepository<Mineral> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Mineral> Minerals => _repository.GetAll();
    }
}
