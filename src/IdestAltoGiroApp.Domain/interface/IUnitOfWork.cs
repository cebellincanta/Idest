using IdestAltoGiroApp.Domain.Entity;
using IdestAltoGiroApp.Domain.Interface.Base;

namespace IdestAltoGiroApp.Domain.Interface;

public interface IUnitOfWork : IDisposable
    {
        IPersonRepository IPersonRepository { get; }
        IAddressRepository IAddressRepository {get;}
        IPhoneRepository IPhoneRepository {get;}
        IEmailRepository IEmailRepository {get;}

        Task<int> CommitAsync();
    }