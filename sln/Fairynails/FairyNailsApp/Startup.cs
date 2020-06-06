using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FairyNails.Service.Entity;
using FairyNails.Service;
using FairyNails.Service.RendezVousServices;
using FairyNails.Service.PrestationServices;
using FairyNails.Service.ClientService;
using FairyNails.Service.MailerServices;
using Microsoft.Extensions.Options;

namespace FairyNailsApp
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
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();

            services.AddDbContext<FairynailsContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("FairynailConnection"),
                    b => b.MigrationsAssembly("FairyNails.Service")));
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<FairynailsContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            // Add business service
            services.AddScoped<IRendezVousService,RendezVousService>();
            services.AddScoped<IPrestationService,PrestationService>();
            services.AddScoped<IClientService, ClientService>();
            services.Configure<EmailConfig>(Configuration.GetSection("EmailConfig"));
            services.AddTransient<IMailerService>(s => new MailerService(
                new EmailConfig
                {
                    UserName = s.GetRequiredService<IOptions<EmailConfig>>().Value.UserName,
                    Password = s.GetRequiredService<IOptions<EmailConfig>>().Value.Password,
                    SmtpServer = s.GetRequiredService<IOptions<EmailConfig>>().Value.SmtpServer,
                    SmtpPortNumber = s.GetRequiredService<IOptions<EmailConfig>>().Value.SmtpPortNumber,
                    DefaultAdress = s.GetRequiredService<IOptions<EmailConfig>>().Value.DefaultAdress,
                }
                ));
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
