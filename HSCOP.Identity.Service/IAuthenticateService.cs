namespace HSCOP.Identity.Service
{
    public interface IAuthenticateService
    {
        /// <summary>
        /// Get JWT Token
        /// </summary>
        /// <returns>JWT Token</returns>
        string GetJWTToken();
    }
}
