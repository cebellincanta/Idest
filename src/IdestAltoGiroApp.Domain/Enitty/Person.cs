using IdestAltoGiroApp.Domain.Entity.Base;

namespace IdestAltoGiroApp.Domain.Entity;

public class Person  : EntityBase
{
    public string Document {get; set;}
    public string Name{get; set;}
    public string Type{ get; set; }
    public List<Address> Address { get; set; } = new List<Address>();
    public List<Email> Emails { get; set; } = new List<Email>();
    public List<Phone> Phones { get; set; } = new List<Phone>();
}