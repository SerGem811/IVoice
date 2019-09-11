using Autofac.Integration.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVoice.Json
{
    public class JsonNetActionInvoker : ExtensibleActionInvoker
    {


        protected override ActionResult InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary<string, object> parameters)
        {
            ActionResult invokeActionMethod = base.InvokeActionMethod(controllerContext, actionDescriptor, parameters);

            if (invokeActionMethod.GetType() == typeof(JsonResult))
            {
                return new JsonNetResult(invokeActionMethod as JsonResult);
            }

            return invokeActionMethod;
        }

        private class JsonNetResult : JsonResult
        {
            public JsonNetResult()
            {
                ContentType = "application/json";
            }

            public JsonNetResult(JsonResult existing)
            {
                ContentEncoding = existing.ContentEncoding;
                ContentType = !string.IsNullOrWhiteSpace(existing.ContentType) ? existing.ContentType : "application/json";
                Data = existing.Data;
                JsonRequestBehavior = existing.JsonRequestBehavior;
            }

            public override void ExecuteResult(ControllerContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }
                if ((JsonRequestBehavior == JsonRequestBehavior.DenyGet)
                    && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                {
                    base.ExecuteResult(context);                            // Delegate back to allow the default exception to be thrown
                }

                HttpResponseBase response = context.HttpContext.Response;
                response.ContentType = ContentType;

                if (ContentEncoding != null)
                {
                    response.ContentEncoding = ContentEncoding;
                }

                if (Data != null)
                {
                    // Replace with your favourite serializer.  
                    var serializzedData = JsonConvert.SerializeObject(Data
                            , new JsonSerializerSettings
                            {
                                ContractResolver = new EFContractResolver(),
                                //PreserveReferencesHandling = PreserveReferencesHandling.All
                                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                MaxDepth = RecursionLimit ?? 3,
                                NullValueHandling = NullValueHandling.Ignore,
                                Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                                {
                                    //errors.Add(args.ErrorContext.Error.Message);
                                    args.ErrorContext.Handled = true;
                                }
                            });

                    response.Write(serializzedData);
                }
            }
        }
    }
}