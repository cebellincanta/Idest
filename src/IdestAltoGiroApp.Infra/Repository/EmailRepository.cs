using IdestAltoGiroApp.Domain.Entity;
using IdestAltoGiroApp.Domain.Interface;
using IdestAltoGiroApp.Infra.Context;
using IdestAltoGiroApp.Infra.Repository.Base;

namespace IdestAltoGiroApp.Infra.Repository;

public class EmailRepository : RepositoryBase<Email>, IEmailRepository
{
    public EmailRepository(IdestAltoGiroContext context) : base(context)
    {
        
    }
}