using IdestAltoGiroApp.Domain.Entity;
using IdestAltoGiroApp.Domain.Interface;
using IdestAltoGiroApp.Infra.Context;
using IdestAltoGiroApp.Infra.Repository.Base;

namespace IdestAltoGiroApp.Infra.Repository;

public class PersonRepository : RepositoryBase<Person>, IPersonRepository
{
    public PersonRepository(IdestAltoGiroContext context) : base(context)
    {
        
    }
}