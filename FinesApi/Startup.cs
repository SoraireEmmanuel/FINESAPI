using Fines.BL.Data;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;



namespace FinesApi
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(FinesContext.Create);
        }
    }
}
