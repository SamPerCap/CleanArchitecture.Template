using Application.Common.DTOs;
using Application.Common.Models;
using MediatR;

namespace Application.Users.Queries
{
    public record GetUserByIdQuery(int Id) : IRequest<Result<UserDto?>>;
}
