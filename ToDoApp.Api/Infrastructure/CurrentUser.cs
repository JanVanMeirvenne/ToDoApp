using System;
using System.Security.Claims;
using System.Security.Principal;
using ToDoApp.Application.Interfaces;

namespace ToDoApp.Api.Infrastructure
{
    public class CurrentUser:ICurrentUser
    {
        private readonly ClaimsPrincipal _principal;

        public CurrentUser(IPrincipal principal)
        {
            _principal = principal as ClaimsPrincipal;
            this.Id = new Guid(_principal
                .FindFirst(o => o.Type.Equals("http://schemas.microsoft.com/identity/claims/objectidentifier")).Value ?? Guid.Empty.ToString());
            this.Mail = this.Name = _principal
                .FindFirst(o => o.Type.Equals("emails")).Value;
            this.Name = _principal
                .FindFirst(o => o.Type.Equals("name")).Value;
        }
        
        public CurrentUser(){}
        
        

        public Guid Id { get; private set; }
        public string Mail { get; private set; }
        public string Name { get; private set; }

        public static CurrentUser Create(ClaimsPrincipal principal)
        {
            return new CurrentUser()
            {
                Id = new Guid(principal
                                  .FindFirst(o =>
                                      o.Type.Equals("http://schemas.microsoft.com/identity/claims/objectidentifier"))
                                  .Value ?? Guid.Empty.ToString()),
               Mail = principal
                .FindFirst(o => o.Type.Equals("emails")).Value,
                Name = principal
                .FindFirst(o => o.Type.Equals("name")).Value
            };
            
        }
        
       
    }
}