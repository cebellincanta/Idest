using IdestAltoGiroApp.Domain.Entity;
using IdestAltoGiroApp.Domain.Interface;
using IdestAltoGiroApp.Infra.Context;
using IdestAltoGiroApp.Infra.Repository.Base;

namespace IdestAltoGiroApp.Infra.Repository;

public class AddressRepository : RepositoryBase<Address>, IAddressRepository
{
    public AddressRepository(IdestAltoGiroContext context) : base(context)
    {
        
    }
}