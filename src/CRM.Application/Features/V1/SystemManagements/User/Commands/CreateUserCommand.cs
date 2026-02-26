using AutoMapper;
using CRM.Application.Common.Abstractions.Data;
using CRM.Application.Features.V1.SystemManagements.User.Modals;
using CRM.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Features.V1.SystemManagements.User.Commands
{
    public class CreateUserCommand : IRequest<Response<bool>>
    {
        public UserRequest? UserRequest { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;   
            public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public Task<Response<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
