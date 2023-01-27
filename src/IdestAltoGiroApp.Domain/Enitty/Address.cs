using IdestAltoGiroApp.Domain.Entity.Base;

namespace IdestAltoGiroApp.Domain.Entity;

public class Address : EntityBase
{   
    public string Cep {get; set;}
    public string PublicPlace{get; set;}
    public string AddressName { get; set; }
    public int Number {get; set;}
    public string Neighborhood { get; set;}
    public string Complement{get; set;}
    public string City{get; set;}
    public string State {get; set;}
    public string Country {get ;set;} 
    public int PersonId{get; set;}
    public Person Person {get; set;}
}