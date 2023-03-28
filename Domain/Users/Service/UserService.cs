using Hotel.Domain.Users.Model;
using Hotel.Domain.Users.Repository;

namespace Hotel.Domain.Users.Service;

public interface IUserService
{
    Task<User> CreateUser(User user);
    Task<User> GetById(string user);

}
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUser(User user)
    {
        return await _userRepository.Create(user);
    }

    public async Task<User> GetById(string user)
    {
        return await _userRepository.GetById(user);
    }

}
