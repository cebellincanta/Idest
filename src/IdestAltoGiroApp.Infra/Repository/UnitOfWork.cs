using IdestAltoGiroApp.Domain.Entity;
using IdestAltoGiroApp.Domain.Interface;
using IdestAltoGiroApp.Infra.Context;
using IdestAltoGiroApp.Infra.Repository.Base;

namespace IdestAltoGiroApp.Infra.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly IdestAltoGiroContext _context;
    private PersonRepository _personRepository;
    private AddressRepository _addressRepository;
    private PhoneRepository _phoneRepository;
    private EmailRepository _emailRepository;


    public UnitOfWork(IdestAltoGiroContext context) => _context = context;
    
    public IPersonRepository IPersonRepository => _personRepository ??= new PersonRepository(_context);

    public IAddressRepository IAddressRepository => _addressRepository ??= new AddressRepository(_context);

    public IPhoneRepository IPhoneRepository => _phoneRepository ??= new PhoneRepository(_context);

    public IEmailRepository IEmailRepository => _emailRepository ??= new EmailRepository(_context);

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
       _context.Dispose();
    }
}