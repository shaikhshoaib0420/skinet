

using System.Text.Json;
using Microsoft.Net.Http.Headers;

public static class HttpResponseExtension {

    public static void HttpResoponse(this HttpContext httpContext, PaginationMetaData paginationMetaData) 
    {
        var options = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

        httpContext.Response.Headers.Append("Pagination", JsonSerializer.Serialize(paginationMetaData, options));
        httpContext.Response.Headers.Append(HeaderNames.AccessControlExposeHeaders, "Pagination");
    }
}