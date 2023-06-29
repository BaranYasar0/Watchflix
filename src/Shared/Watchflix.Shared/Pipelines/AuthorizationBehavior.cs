using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Watchflix.Shared.Pipelines
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ISecuredRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<string>? roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            if (roleClaims == null) throw new Exception("Claims not found.");

            bool isNotMatchedARoleClaimWithRequestRoles =
                String.IsNullOrEmpty(roleClaims.FirstOrDefault(roleClaim => request.Roles.Any(role => role == roleClaim)));
            if (isNotMatchedARoleClaimWithRequestRoles) throw new Exception("You are not authorized.");

            TResponse response = await next();
            return response;
        }
    }
}
