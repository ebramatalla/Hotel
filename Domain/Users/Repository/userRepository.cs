using Hotel.Domain.Users.Model;
using MongoDB.Driver;

namespace Hotel.Domain.Users.Repository;
public interface IUserRepository
{
    Task<User> Create(User user);
    Task<User> GetById(string user);
}
public class userRepository:IUserRepository
{
    private readonly IMongoCollection<User> _UserCollection;

    public userRepository(IMongoDatabase mongoDatabase)
    {
        _UserCollection = mongoDatabase.GetCollection<User>("Users");
    }

    public async Task<User> Create(User user)
    {
        await _UserCollection.InsertOneAsync(user); 
        return user;
    }

    public async Task<User> GetById(string userId)
    {
        return await _UserCollection.Find(x=>x.Id == userId).FirstOrDefaultAsync();
    }
}
