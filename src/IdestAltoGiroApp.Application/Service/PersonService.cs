

using IdestAlgotGiroApp.Application.DTO;
using IdestAlgotGiroApp.Application.Interface;
using IdestAlgotGiroApp.Application.Mapper;
using IdestAlgotGiroApp.Application.Notification;
using IdestAlgotGiroApp.Application.Validate;
using IdestAltoGiroApp.Domain.Interface;

namespace IdestAlgotGiroApp.Application.Service;

public class PersonService : IPersonService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationService _notification;


    public PersonService(IUnitOfWork unitOfWork, INotificationService notification)
    {
        _unitOfWork = unitOfWork;
        _notification = notification;

    }

    public async Task AddAsync(PersonDTO personalDTO)
    {
        try
        {
            var personal = await _unitOfWork.IPersonRepository.GetByAsync(x => x.Document == personalDTO.Document);

            
            if(personal?.Count > 0)
            {
                _notification.Handle(new Message("Erro", "Já existe pessoa com esse documento"));
                 throw new Exception();
                
            }
            ValidarDocumento(personalDTO.Type, personalDTO.Document);
            ValidaDados(personalDTO);

            var result = await _unitOfWork.IPersonRepository.AddReturnIdAsync(PersonMapper.ToEntity(personalDTO));
            

            await _unitOfWork.CommitAsync();
        }
        catch(Exception e)
        {
            if(!_notification.HasNotification())
                _notification.Handle(new Message("Erro", e.Message));
        }
        
    }

    public async Task DeleteAsync(PersonDTO personDTO)
    {
        try
            {
                await _unitOfWork.IPersonRepository.DeleteAsync(PersonMapper.ToEntity(personDTO));
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                _notification.Handle(new Message("Erro", e.Message));
            }
    }

    public Task DeleteSoftAsync(PersonDTO personDTO)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PersonDTO>> GetAllAsync()
    {
        try
        {
            var list = await _unitOfWork.IPersonRepository.GetAsync(x => x.Emails, x => x.Phones, x => x.Address);
            List<PersonDTO> listDTO = new List<PersonDTO>();
            foreach(var person in list)
            {
                listDTO.Add(PersonMapper.ToDTO(person));
            }
            return listDTO;
        }
        catch (Exception e)
            {
                _notification.Handle(new Message("Erro", e.Message));
                throw new Exception();
            }
    }

    public async Task<PersonDTO> GetByIdAsync(string Document)
    {
        var result = await _unitOfWork.IPersonRepository.GetByIdAsync(x => x.Document == Document);

        return PersonMapper.ToDTO(result);
    }

    public async Task<PersonDTO> GetByNameAsync(string Name)
    {
       var result = await _unitOfWork.IPersonRepository.GetByIdAsync(x => x.Name == Name);

        return PersonMapper.ToDTO(result);
    }

    public async  Task<PersonDTO> UpdateAsync(PersonDTO personDTO)
    {
        try
        {
            var personal = await _unitOfWork.IPersonRepository.GetByAsync(x => x.Document == personDTO.Document);

            
            if(personal == null || personal?.Count == 0)
            {
                _notification.Handle(new Message("Erro", "Pessoa não existe"));
                throw new Exception();
            }
            ValidarDocumento(personDTO.Type, personDTO.Document);

            _unitOfWork.IPersonRepository.Update(PersonMapper.ToEntity(personDTO));

            return await GetByIdAsync(personDTO.Document);

        }catch (Exception e)
        {
            if (!_notification.HasNotification())
                _notification.Handle(new Message("Erro", e.Message));
            return null;
          
        }

    }

    private void ValidarDocumento(string type, string document)
    {
        switch (type) 
            { 
                case "legal":
                    if(!CnpjValidacao.Validar(document))
                    {
                        _notification.Handle(new Message("Erro", "Cnpj inválido"));
                        throw new Exception();
                    }
                    break;
                case "individual":
                    if(!CpfCnpjValidate.Validar(document))
                    {
                        _notification.Handle(new Message("Erro", "CPF inválido."));
                        throw new Exception();
                    }
                    break;
                case "foreign":
                    
                    if (!int.TryParse(document, out int n))
                    {
                        _notification.Handle(new Message("Erro", "Documento só pode ter número."));
                        throw new Exception();
                    }
                    break;
                    
                default:
                    _notification.Handle(new Message("Erro", "Tipo de pessoa inválida."));
                    throw new Exception();
            }
    }

    private void ValidaDados(PersonDTO dto)
    {
        foreach(var email in dto.Emails)
        {
            if (!UtilsValida.ValidaEmail(email.Email))
            {
                _notification.Handle(new Message("Erro", $"O Email {email.Email} é invalido."));
                throw new Exception();
            }
        }

        foreach (var address in dto.Address)
        {
            if (!UtilsValida.ValidaCep(address.Cep))
            {
                _notification.Handle(new Message("Erro", $"O CEP {address.Cep} é invalido."));
                throw new Exception();
            }
        }
    }
}
