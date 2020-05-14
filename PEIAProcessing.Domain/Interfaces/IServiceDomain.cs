using System.Collections.Generic;
using FluentValidation;
using PEIAProcessing.Domain.Entities;

namespace PEIAProcessing.Domain.Interfaces
{
    public interface IServiceDomain<T> where T : BaseEntity
    {
        T Post<V>(T obj) where V : AbstractValidator<T>;

        T Put<V>(T obj) where V : AbstractValidator<T>;

        void Delete(int id);

        T Get(int id);

        IList<T> Get();
    }
}
 