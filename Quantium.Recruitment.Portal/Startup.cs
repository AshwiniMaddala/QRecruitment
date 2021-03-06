﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Quantium.Recruitment.Portal.Data;
using Quantium.Recruitment.Portal.Helpers;
using Quantium.Recruitment.Portal.Models;
using Quantium.Recruitment.Infrastructure;
using Quantium.Recruitment.Infrastructure.Repositories;
using Newtonsoft.Json.Serialization;

namespace Quantium.Recruitment.Portal
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, QRecruitmentRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            AutoMapperConfig.RegisterMappings();
            services.AddTransient<ICandidateHelper, CandidateHelper>();
            services.AddTransient<IHttpHelper, HttpHelper>();
            services.AddScoped<IRecruitmentContext, RecruitmentContext>();
            services.AddTransient<IConnectionString, ConnectionString>();
            services.AddTransient<ICandidateRepository, CandidateRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
                     
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IOptionRepository, OptionRepository>();
            services.AddTransient<ILabelRepository, LabelRepository>();
            services.AddTransient<IDifficultyRepository, DifficultyRepository>();
            services.AddTransient<IJobLabelDifficultyRepository, JobLabelDifficultyRepository>();
            services.AddTransient<IQuestionGroupRepository, QuestionGroupRepository>();
                     
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<IJobRepository, JobRepository>();
            services.AddTransient<ICandidateJobRepository, CandidateJobRepository>();
            services.AddTransient<IChallengeRepository, ChallengeRepository>();
            services.AddTransient<ICandidateSelectedOptionRepository, CandidateSelectedOptionRepository>();

            services.Configure<ConfigurationOptions>(Configuration.GetSection("ConfigurationOptions"));
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            app.UseBrowserLink();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                LoginPath = "/Account/Login",
                AuthenticationScheme = "Cookies",
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseStaticFiles();

            app.UseIdentity();

            GoogleOptions googleOptions = new GoogleOptions()
            {
                ClientId = "413971816292-1fneropitgu7o9tota8e3rk4a7e1jt46.apps.googleusercontent.com",
                ClientSecret = "45kIiYPalGmJBZna0XMLp90x"
            };

            MicrosoftAccountOptions microsoftOptions = new MicrosoftAccountOptions()
            {
                ClientId = "0d3fc5fa-3c69-4457-858d-8646a18d39c2",
                ClientSecret = "goiWPhP8rxggoq1Mggn0VFh"
            };

            FacebookOptions facebookOptions = new FacebookOptions()
            {
                
                AppId = "332930870375090",
                AppSecret = "d8647a5e288a3689424c28d6d4c8a510"
            };

            app.UseGoogleAuthentication(googleOptions);
            app.UseMicrosoftAccountAuthentication(microsoftOptions);
            app.UseFacebookAuthentication(facebookOptions);
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{Action=Login}/{id?}");

                routes.MapRoute(
                    name: "apiRoute",
                    template: "api/{controller}/{Action}/{id?}");
            });
        }
    }
}
