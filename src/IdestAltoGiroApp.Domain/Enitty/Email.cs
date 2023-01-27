using IdestAltoGiroApp.Domain.Entity.Base;

namespace IdestAltoGiroApp.Domain.Entity;

public class Email  : EntityBase
{
    public string EmailName {get; set;}
    public bool IsMain{get; set;}
    public int PersonId{get; set;}
    public Person Person {get; set;}
}