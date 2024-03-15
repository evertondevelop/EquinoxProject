using AutoMapper;
using Equinox.Application.ViewModels;
using Equinox.Domain.Models;

namespace Equinox.Application.AutoMapper
{
    /// <summary>
    /// This class defines a mapping profile for converting domain models to view models.
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainToViewModelMappingProfile"/> class.
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            // Creates a mapping from the Customer domain model to the CustomerViewModel view model.
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
