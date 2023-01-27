using IdestAlgotGiroApp.Application.DTO;
using IdestAltoGiroApp.Domain.Entity;

namespace IdestAlgotGiroApp.Application.Mapper;

public static class PersonMapper
{
   public static Person ToEntity(PersonDTO person)
   {
        List<Address> address = new();
        foreach(var addressDTO in person.Address)
        {
            address.Add(new Address{
                PublicPlace = addressDTO.PublicPlace,
                AddressName = addressDTO.AddressName,
                Number = addressDTO.Number,
                Cep = addressDTO.Cep,
                Neighborhood = addressDTO.Neighborhood,
                Complement = addressDTO.Complement,
                State = addressDTO.State,
                City = addressDTO.City,
                Country = addressDTO.Country
            });
        }
        List<Email> emails = new();
        foreach(var emailDTO in person.Emails)
        {
           emails.Add(new Email{
                EmailName = emailDTO.Email,
                IsMain = emailDTO.IsMain
           });  
        }

         List<Phone> phones = new();
        foreach(var phoneDTO in person.Phones)
        {
           phones.Add(new Phone{
                PhoneNumber = phoneDTO.Phone,
                IsMain = phoneDTO.IsMain
           });  
        }

        return new Person
        {
            Document = person.Document,
            Name = person.Name,
            Type = person.Type,
            Address  = address,
            Phones = phones,
            Emails = emails
        };
   }

     public static PersonDTO ToDTO(Person person)
   {
        List<AddressDTO> addressDTO = new();
        foreach(var address in person.Address)
        {
            addressDTO.Add(new AddressDTO{
                PublicPlace = address.PublicPlace,
                AddressName = address.AddressName,
                Number = address.Number,
                Cep = address.Cep,
                Neighborhood = address.Neighborhood,
                Complement = address.Complement,
                State = address.State,
                City = address.City,
                Country = address.Country
            });
        }
        List<EmailDTO> emailsDTO = new();
        foreach(var email in person.Emails)
        {
           emailsDTO.Add(new EmailDTO{
                Email = email.EmailName,
                IsMain = email.IsMain
           });  
        }

         List<PhoneDTO> phonesDTO = new();
        foreach(var phone in person.Phones)
        {
           phonesDTO.Add(new PhoneDTO{
                Phone = phone.PhoneNumber,
                IsMain = phone.IsMain
           });  
        }

        return new PersonDTO
        {
            Document = person.Document,
            Name = person.Name,
            Type = person.Type,
            Address  = addressDTO,
            Phones = phonesDTO,
            Emails = emailsDTO
        };
   }


   
}