﻿using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BTG.WebAPI.Core.User
{
    public interface IAspNetUser
    {
        string Name { get; }

        Guid GetUserId();

        string GetUserEmail();

        string GetUserToken();

        bool IsAuthenticated();

        bool IsInRole(string role);

        IEnumerable<Claim> GetClaims();

        HttpContext GetHttpContext();
    }
}