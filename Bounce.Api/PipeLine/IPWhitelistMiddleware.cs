using Bounce.DataTransferObject.DTO.Auth;
using Bounce_Domain;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;
using System.Text;

namespace Bounce.Api.PipeLine
{
    public class IPWhitelistOptions
    {
        public List<string> Whitelist { get; set; }
    }
    public class IPWhitelistMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPWhitelistOptions _iPWhitelistOptions;
        private readonly ILogger<IPWhitelistMiddleware> _logger;
        public IPWhitelistMiddleware(RequestDelegate next,
        ILogger<IPWhitelistMiddleware> logger,
            IOptions<IPWhitelistOptions> applicationOptionsAccessor)
        {
            _iPWhitelistOptions = applicationOptionsAccessor.Value;
            _next = next;
            _logger = logger;
        }







        public async Task InvokeAsync(HttpContext context)
        {
            // Encrypt request body
            //EnableBuffering();
            //using var reader = new StreamReader(context.Request.Body);
            //var requestBody = await reader.ReadToEndAsync();
            //var encryptedBody = "fine hanine";

            //var mode = new LoginModel { Password = "sssssssssss", Username = "sssssssssssssssssss" };

            //var req = JsonConvert.SerializeObject(mode);
            //context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(req));
            //context.Request.ContentLength = context.Request.Body.Length;
            //context.Request.Body.Position = 0;

            //var response = RequestExtention.load();
           
            // Call next middleware in the pipeline
            await _next(context);

            // Decrypt response body
            //using var responseStream = context.Response.Body;
            //responseStream.Seek(0, SeekOrigin.Begin);
            //var responseBody = await new StreamReader(responseStream).ReadToEndAsync();
            //var decryptedBody = Decrypt(responseBody);
            //context.Response.Body = new MemoryStream(Encoding.UTF8.GetBytes(decryptedBody));

            //// Reset content length header and stream position
            //context.Response.ContentLength = context.Response.Body.Length;
            //context.Response.Body.Position = 0;
        }





        //public async Task Invoke(HttpContext httpContext)
        //{



        //    var request = httpContext.Request;
        //    if (request.Method == HttpMethods.Post && request.ContentLength > 0)
        //    {
        //        try
        //        {
        //            request.EnableBuffering();
        //            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        //            await request.Body.ReadAsync(buffer, 0, buffer.Length);
        //            //get body string here...
        //            var requestContent = Encoding.UTF8.GetString(buffer).ToString();

        //            var SSSS = JsonConvert.DeserializeObject<dynamic>(requestContent);

        //           var response =  RequestExtention.load();
        //            var properties = response.Properties;
        //            var objectType = response.Type;
        //            foreach (var prop in properties)
        //            {
        //                var value = "";
        //            }


        //            //var entry = Assembly.GetEntryAssembly();

        //            //var assemblies = entry
        //            //      // This will get B and C with type: `AssemblyName`
        //            //      .GetReferencedAssemblies()
        //            //      // Load assembly B and C.
        //            //      .Select(t => Assembly.Load(t))
        //            //      // Get all class in B and C.
        //            //      .Select(t => t.DefinedTypes)
        //            //      .ToList();

        //            //var ass = Assembly.GetCallingAssembly();

        //            ////assemblies.FirstOrDefault().Namespace
        //            //var requestType = assemblies.Where(x => x.Name == "Chat").FirstOrDefault();

        //            //var name = Assembly.GetExecutingAssembly().GetName().Name;
        //            //var type = Type.GetType(requestType.FullName);
        //            //object? objType = Activator.CreateInstance(type);
        //            //var properties = requestType.GetProperties();
        //        }
        //        catch(Exception exp)
        //        {
        //            var sssssaaa = exp.Message;

        //        }





        //        request.Body.Position = 0;  //rewinding the stream to 0








        //    }
        //    await _next(httpContext);

        //}

        //public async Task Invoke(HttpContext context)
        //{

        //    var request = context.Request;
        //    var path = request.Path.Value.Split('/').ToList() ;
        //    var methodName = path[path.Count - 1];
        //    var controllerName = path[path.Count - 2];



        //    if (context.Request.Method != HttpMethod.Get.Method)
        //    {
        //        var ipAddress = context.Connection.RemoteIpAddress;
        //        List<string> whiteListIPList =
        //        _iPWhitelistOptions.Whitelist;
        //        var isIPWhitelisted = whiteListIPList
        //        .Where(ip => IPAddress.Parse(ip)
        //        .Equals(ipAddress))
        //        .Any();
        //        if (!isIPWhitelisted)
        //        {
        //            _logger.LogWarning("");
        //            context.Response.StatusCode =
        //            (int)HttpStatusCode.Forbidden;
        //            return;
        //        }

        //        var body = new StreamReader(context.Request.Body);
        //        //The modelbinder has already read the stream and need to reset the stream index
        //        body.BaseStream.Seek(0, SeekOrigin.Begin);
        //        var requestBody = body.ReadToEnd();


        //    }
        //    await _next.Invoke(context);
        //}
    }

    public static class IPWhitelistMiddlewareExtensions
    {
        public static IApplicationBuilder UseIPWhitelist(this
        IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IPWhitelistMiddleware>();
        }
    }

}
