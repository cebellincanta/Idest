using IdestAltoGiroApp.Domain.Entity;
using IdestAltoGiroApp.Domain.Interface;
using IdestAltoGiroApp.Infra.Context;
using IdestAltoGiroApp.Infra.Repository.Base;

namespace IdestAltoGiroApp.Infra.Repository;

public class PhoneRepository : RepositoryBase<Phone>, IPhoneRepository
{
    public PhoneRepository(IdestAltoGiroContext context) : base(context)
    {
        
    }
}