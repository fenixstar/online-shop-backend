using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Implementations;
using online_shop_backend.Repositories.Interfaces;
using online_shop_backend.Services.Implementations;
using online_shop_backend.Services.Interfaces;
using online_shop_backend.Utils;

namespace online_shop_backend;

public class Startup(IConfiguration configuration)
{
    private IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(Configuration["ConnectionStrings:OnlineShopDatabase"]));

        services.AddTransient<ICategoriesRepository, EfCategoriesRepository>();
        services.AddTransient<ISubcategoriesRepository, EfSubcategoriesRepository>();
        services.AddTransient<IProductRepository, EfProductRepository>();
        services.AddTransient<IProducerRepository, EfProducerRepository>();
        services.AddTransient<IProducerDetailRepository, EfProducerDetailRepository>();
        services.AddTransient<IInvoiceRepository, EfInvoiceRepository>();
        services.AddTransient<IInvoiceDetailRepository, EfInvoiceDetailRepository>();
        services.AddTransient<IOrderRepository, EfOrderRepository>();
        services.AddTransient<IOrderDetailRepository, EfOrderDetailRepository>();
        services.AddTransient<IPaymentTypeRepository, EfPaymentTypeRepository>();
        services.AddTransient<IPaymentMethodRepository, EfPaymentMethodRepository>();
        services.AddTransient<IDiscountRepository, EfDiscountRepository>();
        services.AddTransient<IReviewRepository, EfReviewRepository>();
        services.AddTransient<IUserDetailRepository, EfUserDetailRepository>();
        services.AddTransient<IShippingMethodRepository, EfShippingMethodRepository>();
        services.AddTransient<IRefreshTokenRepository, EfRefreshTokenRepository>();
        services.AddTransient<IMailService, MailService>();

        services.AddTransient<TokenFactory>();

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(Configuration["SecretKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

        services.AddControllers()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseStaticFiles();

        // app.UseHttpsRedirection(); 

        app.UseRouting();

        app.UseCors(builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}