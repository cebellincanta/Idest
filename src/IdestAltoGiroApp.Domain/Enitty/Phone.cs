using IdestAltoGiroApp.Domain.Entity.Base;

namespace IdestAltoGiroApp.Domain.Entity;

public class Phone  : EntityBase
{   
    public string PhoneNumber {get; set;}
    public bool IsMain{get; set;}
    public int PersonId{get; set;}
    public Person Person {get; set;}
}