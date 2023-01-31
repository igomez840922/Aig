using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Interfaces;
using AutoMapper;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using Aig.Farmacoterapia.Domain.Models;
using Aig.Farmacoterapia.Domain.Identity;

namespace Aig.Farmacoterapia.Application.Features.Medicament.Queries
{
    public class GetAllUserQuery : IRequest<PaginatedResult<UserModelOutput>>
    {
        public PageSearchArgs Args { get; set; }
        public GetAllUserQuery(PageSearchArgs args) => Args = args;
    }
    public class GetUsernameQuery : IRequest<Result<bool>>
    {
        public string UserName { get; set; }
        public GetUsernameQuery(string userName) => UserName = userName;

    }
    public class GetPhoneQuery : IRequest<Result<bool>>
    {
        public string Phone { get; set; }
        public GetPhoneQuery(string phone) => Phone = phone;
    }

    public class GetUserQuery : IRequest<Result<UpdateProfileRequest>>
    {
        public string UserName { get; set; }
        public GetUserQuery(string userName) => UserName = userName;
    }
    internal class UserQueryHandler : 
        IRequestHandler<GetAllUserQuery, PaginatedResult<UserModelOutput>>,
        IRequestHandler<GetUserQuery, Result<UpdateProfileRequest>>,
        IRequestHandler<GetUsernameQuery, Result<bool>>,
        IRequestHandler<GetPhoneQuery, Result<bool>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ISystemLogger _logger;

        public UserQueryHandler(IUserService userService, IMapper mapper,ISystemLogger logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PaginatedResult<UserModelOutput>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            PaginatedResult<UserModelOutput> answer = new();
            try
            {   var result = await _userService.ListAsync(request.Args);
                if (result.Succeeded)
                    answer = PaginatedResult<UserModelOutput>.Success(_mapper.Map<List<UserModelOutput>>(result.Data), result.TotalCount, result.CurrentPage, result.PageSize);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return PaginatedResult<UserModelOutput>.Failure(new List<string>() { exc.Message });
            }
            return answer;
        }
        public async Task<Result<UpdateProfileRequest>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var answer = new Result<UpdateProfileRequest>();
            try
            {
                answer = Result<UpdateProfileRequest>.Success(_mapper.Map<UpdateProfileRequest>(
                                 await _userService.GetUserByNameAsync(request.UserName)));
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<UpdateProfileRequest>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }
        public async Task<Result<bool>> Handle(GetUsernameQuery request, CancellationToken cancellationToken)
        {
            var answer = new Result<bool>();
            try
            {
               answer = _userService.GetUserByName(request.UserName) != null ?Result<bool>.Success(true) :Result<bool>.Success(false);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<bool>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }
        public async Task<Result<bool>> Handle(GetPhoneQuery request, CancellationToken cancellationToken)
        {
            var answer = new Result<bool>();
            try
            {
                answer = _userService.GetUserByPhone(request.Phone) != null ? Result<bool>.Success(true) : Result<bool>.Success(false);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<bool>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

    }
}