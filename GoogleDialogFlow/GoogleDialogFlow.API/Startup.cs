using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GoogleDialogFlow.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Load the custom IoC types 
            Data.Interfaces.IState stateDb = new Data.RethinkDBData.RethinkDBState(Configuration["DataConnectionInfo:RethinkDBUrl"].ToString(), Convert.ToInt32(Configuration["DataConnectionInfo:RethinkDBPort"].ToString()));
            // Seed the databse
            stateDb.SeedDatabase();
            // Clear the old quotes from the database
            var success = stateDb.ClearPreviousQuotes().Result;
            Interfaces.IAvailableActions availableActions = new DialogFlowActions.AvailableActions();
            availableActions.LoadAvailableActions();
            // Add the singleton data
            services.AddSingleton(typeof(Data.Interfaces.IState), stateDb);
            services.AddSingleton(typeof(Interfaces.IAvailableActions), availableActions);
            // Normal startup
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
