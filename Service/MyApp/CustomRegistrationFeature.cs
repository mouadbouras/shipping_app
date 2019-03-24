using ServiceStack;
using ServiceStack.Auth;
using MyApp.DataAccess.DataAccess;
using System.Linq;
using ServiceStack.Web;
using System.Collections.Generic;

public class CustomAuthUserSession : AuthUserSession
{

    public override void OnRegistered(IRequest httpReq, IAuthSession session, IServiceBase service) {   

        
        var p = session.ProviderOAuthAccess[1];

        var context = new shippingcoContext();
        Users user = new Users();
        user.Name = this.UserName;

        var saltedHash = HostContext.Resolve<IHashProvider>();  
    }

}

// public class CustomAuthEvents : AuthEvents
// {
//     public override void OnRegistered(IRequest req, IAuthSession session, IServiceBase registerService)
//     {
//         var context = new shippingcoContext();
//         Users user = new Users();
//         user.Name = session.UserName;

//         var saltedHash = HostContext.Resolve<IHashProvider>();
//         return saltedHash.VerifyHashString(password, registerService.PasswordHash, registerService.Salt);
//         //user.Password = session.

//         //context.Parcel.Add(parcel);
//         //context.SaveChanges();

//     }
// }