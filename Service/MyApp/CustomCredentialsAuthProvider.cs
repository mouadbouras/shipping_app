using ServiceStack;
using ServiceStack.Auth;
using MyApp.DataAccess.DataAccess;
using System.Linq;
using ServiceStack.Web;
using System.Collections.Generic;

public class CustomCredentialsAuthProvider : BasicAuthProvider
{
    public override bool TryAuthenticate(IServiceBase authService, 
        string userName, string password)
    {
        //base.TryAuthenticate(authService, userName, password);
        //Add here your custom auth logic (database calls etc)
        //Return true if credentials are valid, otherwise false
        var context = new shippingcoContext();
        var users = context.Users
            .Where(u => u.Username.ToString() == userName)
            .ToList();

        var s = authService.GetSession();
        authService.SaveSession(s);

        if(users.Count == 1) 
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    // public override IHttpResult OnAuthenticated(IServiceBase authService, 
    //     IAuthSession session, IAuthTokens tokens, 
    //     Dictionary<string, string> authInfo)
    // {
    //     //Fill IAuthSession with data you want to retrieve in the app eg:
    //     //session.FirstName = "some_firstname_from_db";
    //     //...

    //     //Call base method to Save Session and fire Auth/Session callbacks:
    //     return base.OnAuthenticated(authService, session, tokens, authInfo);

    //     //Alternatively avoid built-in behavior and explicitly save session with
    //     //authService.SaveSession(session, SessionExpiry);
    //     //return null;
    // }
}