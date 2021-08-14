using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Ninject.Activation;
using PracticeApplication.DataAccess.Repository;
using PracticeApplication.DataAccess.Repository.Interface;
using PracticeApplication.DataAccess.Settings;
using PracticeApplication.Orchestrator;
using PracticeApplication.Orchestrator.Interface;
using System;

namespace PracticeApplication
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
            services.Configure<PracticeDatabaseLocalSettings>(
                Configuration.GetSection(nameof(PracticeDatabaseLocalSettings)));
            
            services.AddSingleton<IPracticeDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<PracticeDatabaseLocalSettings>>().Value);
            services.AddSingleton<IPieceRepository, PieceRepository>();
            services.AddSingleton<IComposerRepository, ComposerRepository>();
            services.AddSingleton<ILibraryOrchestrator, LibraryOrchestrator>();
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Library}/{action=ComposerIndex}/{id?}");
                endpoints.MapRazorPages();
            });

        }
    }
}