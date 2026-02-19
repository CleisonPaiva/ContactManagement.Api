using System.Diagnostics.Contracts;
using AutoMapper;
using ContactManagement.Api.Core.Dtos;
using ContactManagement.Api.Core.Entities;


namespace ContactManagement.Api.Core.AutoMappers;

public class ContactProfile: Profile
{
    public ContactProfile()
    {
        // Contact → ContactDto (leitura, sem restrições)
        CreateMap<Contact, ContactDto>();

        // ContactDto → Contact (escrita, ignora campos controlados pelo sistema)
        CreateMap<ContactDto, Contact>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

        //CreateMap<Contact, ContactDto>().ReverseMap();
        //O ReverseMap() é útil quando o mapeamento dos dois lados é idêntico e simples,
        //mas quando um lado tem regras diferentes do outro como é o caso aqui,
        //separar deixa muito mais claro o que cada mapeamento faz.
    }
}
