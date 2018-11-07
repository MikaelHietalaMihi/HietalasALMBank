using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HietalasALMBank.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HietalasALMBank
{
    public class Startup
    {
        public static List<Customer> Dummydata = new List<Customer>() {

            new Customer(){
                CustomerID=1,
                Firstname="Mikael",
                Lastname="Hietala",
                AccountList= new List<Account>(){
                    new Account(){
                        Id=1,
                        Balance=10
                    },
                    new Account(){
                        Id=2,
                        Balance=20
                    }
                }
            },
             new Customer(){
                CustomerID=1,
                Firstname="Göran",
                Lastname="Illern",
                AccountList= new List<Account>(){
                    new Account(){
                        Id=3,
                        Balance=30
                    },
                    new Account(){
                        Id=4,
                        Balance=40
                    }
                }
            },
              new Customer(){
                CustomerID=1,
                Firstname="Nisse",
                Lastname="Finsko",
                AccountList= new List<Account>(){
                    new Account(){
                        Id=5,
                        Balance=50
                    },
                    new Account(){
                        Id=6,
                        Balance=60
                    }
                }
            }
        };


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
