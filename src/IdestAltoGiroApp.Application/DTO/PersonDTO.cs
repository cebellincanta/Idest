using System.ComponentModel.DataAnnotations;

namespace IdestAlgotGiroApp.Application.DTO;

public class PersonDTO
{
    public string Document {get; set;}
    public string Name{get; set;}
    public string Type{ get; set; }
    public List<AddressDTO> Address {get; set;}
    public List<EmailDTO> Emails {get; set;}
    public List<PhoneDTO> Phones {get; set;}

}