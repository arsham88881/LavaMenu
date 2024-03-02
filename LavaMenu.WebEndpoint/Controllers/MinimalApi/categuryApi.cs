using LavaMenu.Application.Application.Services.Categuries.command;
using LavaMenu.Application.Common.RequestDTO;
using Microsoft.AspNetCore.Mvc;

namespace LavaMenu.WebEndpoint.Controllers.MinimalApi
{
    public static class categuryApi
    {
        public static async void UseCateguryMinimalApi(this WebApplication app)
        {
            var categuryGroup = app.MapGroup("/api/categury");
            categuryGroup.MapPost("", async ([FromBody] AddCateguryRequestDTO categury, IAddCategury _addCategury) =>
            {
                var result = _addCategury.Excute(categury);
                return Results.Ok(result); 
            });
        }
    }
}
