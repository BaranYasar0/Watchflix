using Watchflix.Api.Movies.Models.Exceptions;
using Watchflix.Shared.Models;

namespace Watchflix.Api.Movies.Features.Rules
{
    public abstract class BaseBusinessRules<T> where T:BaseEntity
    {
        public async Task CheckEntityNullOrNot(T entity)
        {
            if (entity == null)
                throw new BusinessException(message: $"{nameof(entity)} is null");
        }
    }
}
