using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework8
{
    public class RoutingMiddleware
    {
        readonly RequestDelegate _next;

        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value;
            string type = context.Request.Method;
            var op = context.Request.Query["operation"];
            var operands = context.Request.Query["operands"];
            var stateOp = context.Request.Query["state_operand"];
            List<string> operandsData = new();
            int result;

            if (path == "/calculate" && type == "GET")
            {
                if (op == "sum" && !operands.All(n => n == ""))
                {
                    foreach (var item in operands)
                    {
                        operandsData.Add(item.ToString());
                    }

                    if (Calculation.CheckData(operandsData))
                    {
                        result = Calculation.Sum(operandsData);
                        context.Response.Cookies.Append("state", result.ToString());
                        context.Response.StatusCode = 200;
                        await context.Response.WriteAsync(result.ToString());
                    }

                    context.Response.StatusCode = 400;
                }
                else if (op == "sub" && !operands.All(n => n == ""))
                {
                    foreach (var item in operands)
                    {
                        operandsData.Add(item.ToString());
                    }

                    if (Calculation.CheckData(operandsData))
                    {
                        result = Calculation.Sub(operandsData);
                        context.Response.Cookies.Append("state", result.ToString());
                        context.Response.StatusCode = 200;
                        await context.Response.WriteAsync(result.ToString());
                    }

                    context.Response.StatusCode = 400;
                }
                else if (op == "mult" && !operands.All(n => n == ""))
                {
                    foreach (var item in operands)
                    {
                        operandsData.Add(item.ToString());
                    }

                    if (Calculation.CheckData(operandsData))
                    {
                        result = Calculation.Mult(operandsData);
                        context.Response.Cookies.Append("state", result.ToString());
                        context.Response.StatusCode = 200;
                        await context.Response.WriteAsync(result.ToString());
                    }

                    context.Response.StatusCode = 400;
                }
                else if (op == "div" && !operands.All(n => n == ""))
                {
                    foreach (var item in operands)
                    {
                        operandsData.Add(item.ToString());
                    }

                    if (Calculation.CheckData(operandsData) && Calculation.CheckNullDiv(operandsData))
                    {
                        result = Calculation.Div(operandsData);
                        context.Response.Cookies.Append("state", result.ToString());
                        context.Response.StatusCode = 200;
                        await context.Response.WriteAsync(result.ToString());
                    }

                    context.Response.StatusCode = 400;
                }

                else if (stateOp != "")
                {
                    if (context.Request.Cookies.ContainsKey("state") && Calculation.CheckData(stateOp))
                    {
                        int cookieNumber = Convert.ToInt32(context.Request.Cookies["state"]);
                        int stateOpNumber = Convert.ToInt32(stateOp);
                        double newResult = 0;

                        if (op == "sum")
                            newResult = cookieNumber + stateOpNumber;
                        else if (op == "sub")
                            newResult = cookieNumber - stateOpNumber;
                        else if (op == "mult")
                            newResult = cookieNumber * stateOpNumber;
                        else if (op == "div" && stateOpNumber != 0)
                            newResult = cookieNumber * stateOpNumber;

                        await context.Response.WriteAsync(newResult.ToString());
                    }
                    else

                        context.Response.StatusCode = 400;
                }

                else
                    context.Response.StatusCode = 400;
            }

            else if (path == "/authentication" && type == "POST")
            {
                string username = string.Empty;
                string password = string.Empty;
                string usernameConst = "TestUser";
                string passwordConst = "!Q2w3e4r";

                if (context.Request.HasFormContentType)
                {
                    username = context.Request.Form["username"];
                    password = context.Request.Form["password"];
                }

                if (username == usernameConst && password == passwordConst)
                {
                    context.Response.Cookies.Append("auth", username);
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync($"Hello {username}");
                }
                else
                {
                    context.Response.StatusCode = 403;
                }

            }

            else if (path == "/" || path == "index")
            {
                if (context.Request.Cookies.ContainsKey("auth"))
                {
                    string user = context.Request.Cookies["auth"];
                    await context.Response.WriteAsync($"Hello {user}");
                }
            }

            else
                context.Response.StatusCode = 404;
        }
    }
}
