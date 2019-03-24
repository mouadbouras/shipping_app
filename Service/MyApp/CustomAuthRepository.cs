


using System.Collections.Generic;
using ServiceStack.Auth;

public class CustomAuthRepository : IAuthRepository
{
    public IUserAuthDetails CreateOrMergeAuthSession(IAuthSession authSession, IAuthTokens tokens)
    {
        throw new System.NotImplementedException();
    }

    public IUserAuth GetUserAuth(IAuthSession authSession, IAuthTokens tokens)
    {
        throw new System.NotImplementedException();
    }

    public IUserAuth GetUserAuthByUserName(string userNameOrEmail)
    {
        throw new System.NotImplementedException();
    }

    public List<IUserAuthDetails> GetUserAuthDetails(string userAuthId)
    {
        throw new System.NotImplementedException();
    }

    public void LoadUserAuth(IAuthSession session, IAuthTokens tokens)
    {
        throw new System.NotImplementedException();
    }

    public void SaveUserAuth(IAuthSession authSession)
    {
        throw new System.NotImplementedException();
    }

    public void SaveUserAuth(IUserAuth userAuth)
    {
        throw new System.NotImplementedException();
    }

    public bool TryAuthenticate(string userName, string password, out IUserAuth userAuth)
    {
        throw new System.NotImplementedException();
    }

    public bool TryAuthenticate(Dictionary<string, string> digestHeaders, string privateKey, int nonceTimeOut, string sequence, out IUserAuth userAuth)
    {
        throw new System.NotImplementedException();
    }
}