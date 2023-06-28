﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Watchflix.Api.Identity.Application.Models.Dtos;
using Watchflix.Api.Identity.Application.Models.Entities;
using Watchflix.Api.Identity.EntityFramework;

namespace Watchflix.Api.Identity.Application.Features.Queries.GetAll
{
    public class GetAllUsersQuery:IRequest<List<UserQueryDto>>
    {

        public class GetAllUsersQueryHandler:IRequestHandler<GetAllUsersQuery,List<UserQueryDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public GetAllUsersQueryHandler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<UserQueryDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                List<User> users = await _context.Users.OrderByDescending(x => x.CreatedDate).ToListAsync();

                return _mapper.Map<List<UserQueryDto>>(users);
            }
        }
    }
}
