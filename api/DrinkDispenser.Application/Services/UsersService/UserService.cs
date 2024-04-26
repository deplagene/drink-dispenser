using AutoMapper;
using DrinkDispenser.Application.Common.Authentication;
using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Contracts.Users;
using DrinkDispenser.Domain.Common.Abstractions;
using DrinkDispenser.Domain.Common.Errors.Users;
using DrinkDispenser.Domain.User;
using ErrorOr;

namespace DrinkDispenser.Application.Services.UsersService;

public class UsersService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;
    private readonly IMapper _mapper;
    public UsersService(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
        _mapper = mapper;
    }

    public async Task<ErrorOr<AuthenticationResult>> LoginUser(string email, string password, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByEmailAsync(email, cancellationToken);

        if(user is null)
            return Errors.User.UserNotFound;

        if(!_passwordHasher.Verify(user.Password, password))
            return Errors.User.WrongPassword;

        var token = _jwtProvider.GenerateToken(user);

        var userDto = _mapper.Map<UserDto>(user);

        return new AuthenticationResult(token, userDto);
    }

    public async Task<ErrorOr<Success>> RegisterUser(string userName, string password, string email, CancellationToken cancellationToken = default)
    {
        var hashedPassword = _passwordHasher.Generate(password);

        var isEmailUnique = await _userRepository.IsEmailUnique(email);

        if(!isEmailUnique)
            return Errors.User.EmailNotUnique;

        var user = User.Create(userName, hashedPassword, email);

        await _userRepository.AddAsync(user.Value, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}