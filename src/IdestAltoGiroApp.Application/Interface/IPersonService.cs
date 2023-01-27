using IdestAlgotGiroApp.Application.DTO;
using IdestAltoGiroApp.Domain.Entity;

namespace IdestAlgotGiroApp.Application.Interface;

public interface IPersonService
{
        Task AddAsync(PersonDTO personalDTO);

        Task DeleteSoftAsync(PersonDTO personDTO);

        Task DeleteAsync(PersonDTO personDTO);  

        
        Task<List<PersonDTO>> GetAllAsync();

        Task<PersonDTO> GetByIdAsync(string document);

        Task<PersonDTO> GetByNameAsync(string Name);

        Task<PersonDTO> UpdateAsync(PersonDTO personDTO);
}