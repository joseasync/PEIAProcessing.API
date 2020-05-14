using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using PEIAProcessing.Data;
using PEIAProcessing.Domain.Entities;
using PEIAProcessing.Domain.Interfaces;

namespace PEIAProcessing.Service.Services
{
    public class BaseService<T> : IServiceDomain<T> where T : BaseEntity
    {
        private readonly IRepository<T> repository;

        public BaseService()
        {
            var RepositoryLocal = typeof(BaseConnection).Assembly.ExportedTypes.Where(x =>
                typeof(IRepository<>).IsAssignableFrom(x.BaseType))
                .ToList();
                //.Select(Activator.CreateInstance).Cast<IRepository<T>>().FirstOrDefault();



            var xpto = RepositoryLocal;

        }

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            repository.Delete(id);
        }

        public IList<T> Get() => repository.Select();

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return repository.Select(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
