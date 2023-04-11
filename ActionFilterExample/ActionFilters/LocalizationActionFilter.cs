using ActionFilterExample.Controllers;
using ActionFilterExample.Model;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilterExample.ActionFilters
{
    public class LocalizationActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string key = "localizationCode";
            string localizationCode = context.RouteData.Values[key] as string;

            //burada karakter kontrolü yada data kontrolü yapılabilir. hatalı istekler direk buradan filtrelenir.
            //örneğin tr-tr formatına uygun değilse (5 karakter) değilse geri döndür.

             
            if(context.Controller is BaseController controller)
            {
                controller.LocalizationCode = localizationCode;
            }


            //value su null olmayan ve baseRequestten türemiş olanu getir.
            var baseRequest = context.ActionArguments
                .FirstOrDefault(a => a.Value != null && typeof(BaseRequest).IsAssignableFrom(a.Value.GetType()));

            if (baseRequest.Value != null) 
            {
                var model = baseRequest.Value as BaseRequest;//(BaseRequest)baseRequest.Value şeklinde yazmanın aynısı
                model.LocalizationCode = localizationCode;
            }
            else
            {
                //bu key eklenmemişse ekleyelim
                //dışarıdan query string ile data gönderilirse diye ezelim 
                if (!context.ActionArguments.ContainsKey(key))
                    context.ActionArguments.Add(key, localizationCode);
                else
                    context.ActionArguments[key] = localizationCode;
            }
           


            await next();
        }
    }
}
