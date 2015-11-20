using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Danse.App_Start
{
    public class Mail
    {
        public   IRestResponse SendSimpleMessage(string email,string subject,string message)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                               "key-9e7df0dda13390f4bf1fb5aa6c5415ae");
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                 "sandbox5ad62fe5f89e48f39146671b16c892d3.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "DanseCoach <mailgun@sandbox5ad62fe5f89e48f39146671b16c892d3.mailgun.org>");
            request.AddParameter("to", email);
            request.AddParameter("subject", subject);
            request.AddParameter("text", message);
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}