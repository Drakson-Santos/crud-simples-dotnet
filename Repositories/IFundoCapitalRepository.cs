using System;
using System.Collections.Generic;
using Uniciv.Api.Models;

namespace Uniciv.Api.Repositories
{
    public interface IFundoCapitalRepository
    {
        void Adicionar(FundoCapital fundoCapital);
        void Atualizar(FundoCapital fundoCapital);
        void Remover(FundoCapital fundoCapital);
        FundoCapital ObterPorId(Guid id);
        IEnumerable<FundoCapital> ObterTodos();
    }
}