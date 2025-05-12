using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.ServiceContracts;

public interface IUsersService
{
    /// <summary>
    /// Returns UserDTO object based on the given UserID
    /// </summary>
    /// <param name="userID">UserID to search</param>
    /// <returns>UserDTO object based on the matching UserID</returns>
    Task<UserDTO> GetUserByUserID(Guid userID);
    
    /// <summary>
    /// Method to handle user login use case and return AuthenticationResponse object that contains login status
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
    
    /// <summary>
    /// Method to handle user registration use case and return AuthenticationResponse object that contains registration status
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
}