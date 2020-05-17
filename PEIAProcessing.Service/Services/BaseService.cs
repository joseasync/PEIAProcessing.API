using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using FluentValidation;
using PEIAProcessing.Data;
using PEIAProcessing.Domain.Entities;
using PEIAProcessing.Domain.Interfaces;

namespace PEIAProcessing.Service.Services
{
    public class BaseService<T> : IServiceDomain<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public BaseService(ConnectionConfig connectionConfig)
        {
            var repositoryLocal = typeof(BaseConnection).Assembly.ExportedTypes.FirstOrDefault(x =>
                    typeof(IRepository<T>).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            _repository = (IRepository<T>) Activator.CreateInstance(repositoryLocal, connectionConfig);

        }

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            _repository.Delete(id);
        }

        public IList<T> Get() => _repository.Select();

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return _repository.Select(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
