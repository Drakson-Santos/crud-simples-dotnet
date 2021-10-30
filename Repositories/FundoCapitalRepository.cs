using System;
using System.Collections.Generic;
using Uniciv.Api.Models;

namespace Uniciv.Api.Repositories
{
    public class FundoCapitalRepository : IFundoCapitalRepository
    {
        private readonly List<FundoCapital> _storage;

        public FundoCapitalRepository()
        {
            _storage = new List<FundoCapital>();
        }

        public void Adicionar(FundoCapital fundoCapital)
        {
            _storage.Add(fundoCapital);
        }

        public void Atualizar(FundoCapital fundoCapital)
        {
            var index = _storage.FindIndex(0, 1, x => x.Id == fundoCapital.Id);
            _storage[index] = fundoCapital;
        }

        public FundoCapital ObterPorId(Guid id)
        {
            return _storage.Find(x => x.Id == id);
        }

        public IEnumerable<FundoCapital> ObterTodos()
        {
            return _storage;
        }

        public void Remover(FundoCapital fundoCapital)
        {
            _storage.Remove(fundoCapital);
        }
    }
}