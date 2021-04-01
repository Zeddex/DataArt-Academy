using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework8
{
    public class AuthenticationMiddleware
    {
        readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey("auth"))
            {
                string auth = context.Request.Cookies["auth"];

                if (String.IsNullOrEmpty(auth))
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Authentication failed");
                }

                else
                    await _next(context);
            }

            else
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Authentication failed");
            }
        }
    }
}
