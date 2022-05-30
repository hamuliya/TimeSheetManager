using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace TimeSheetManager.App_Start
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/token", new PathItem
            {
                post = new Operation
                {
                    //Swagger UI uses tags to group the displayed operations.
                    tags = new List<string> { "Auth" },
                    //consumes仅影响带有请求正文的操作，例如 POST、PUT 和 PATCH。对于 GET 等无实体操作，它会被忽略。在操作级别上使用时，consumes覆盖produces（而不是扩展）全局定义。
                    //consumes和produces部分定义 API 支持的 MIME 类型 。根据定义可以在单个操作中被覆盖。
                    //https://swagger.io/docs/specification/2-0/mime-types/

                    consumes = new List<string>
               {
                  "application/x-www-form-urlencoded"
               },
                    parameters = new List<Parameter>
               {
                   new Parameter
                   {
                     type="string",
                     name="grant_type",
                     required=true,
                     @in="formData",
                     @default="password"

                   },
                    new Parameter
                   {
                     type="string",
                     name="username",
                     required=false,
                     @in="formData"

                   },
                    new Parameter
                   {
                     type="string",
                     name="password",
                     required=false,
                     @in="formData"

                   }
                    }
                }
            });
        }
    }
}