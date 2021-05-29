using EntityFrameWorkDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EntityFrameWorkDemo.Filters
{
    public class Auth:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            if(actionContext.Request.Headers.Authorization==null)
            {
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.Forbidden);
                res.Content = new StringContent("Authorization Data is Misssing");
                res.ReasonPhrase = "Auth Error";
                actionContext.Response = res;

            }
            else
            {
                //username:password and encoded data 
                String endcodedData = actionContext.Request.Headers.Authorization.Parameter;
                //data decoded but username:passs
                String decodedData = Encoding.UTF8.GetString(Convert.FromBase64String(endcodedData));

                String[] userdata = decodedData.Split(':');

                String uname =userdata[0];
                String Pass =userdata[1];

                DBMovieEntities1 db = new DBMovieEntities1();

                Tbl_User_Master user= db.Tbl_User_Master.Where(u => u.User_name == uname && u.USer_Password.Equals(Pass)).FirstOrDefault();

                if(user!=null)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(user.User_name),null);

                }
                else
                {
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    res.Content = new StringContent("Authorization Data is not Valid");
                    res.ReasonPhrase = "No Auth";
                    actionContext.Response = res;
                }
            }
        }
    }
}