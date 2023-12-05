namespace Laboratorium_3.Models
{
    public class LastVisitCookie
    {
        private readonly RequestDelegate _next;
        public static readonly string CookieName = "visit";
        public static readonly string LastVisit = "LastVisit";

        public LastVisitCookie(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey("visit"))
            {
                if (DateTime.TryParse(context.Request.Cookies["visit"], out var date))
                {
                    context.Items.Add(LastVisit, date);
                }
              
            }
            else
            {
                context.Items.Add(LastVisit, "First visit");
            }
            context.Response.Cookies.Append(CookieName, DateTime.Now.ToString());
            await _next(context);
        }
    }
}
