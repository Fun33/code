<%@ WebHandler Language="C#" Class="Handler3" %>

using System;
using System.Web;

public class Handler3 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string aaa = context.Request.Form["p1"];
        context.Response.ContentType = "text/plain";

        switch (aaa)
        {
            case "A":
                context.Response.Write("文字衰人");
                break;
            case "B":
                context.Response.Write("<DocumentElement><web101>xml神人</web101></DocumentElement>");
                break;

            default:
                
                break;
        }
       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}