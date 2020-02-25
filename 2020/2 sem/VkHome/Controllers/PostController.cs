using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace EmptyWeb
{
    public class PostController
    {
        public async Task FetchPosts(HttpContext context)
        {
            var filePath = "Files";
            var files = Directory.GetFiles(filePath, "*.txt", SearchOption.AllDirectories);
            StringBuilder result = new StringBuilder();
            result.Append(@" <!doctype html>
<html lang='en'>
<head> 
<meta charset='UTF-8'>  
  <meta name='viewport'  
 content='width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0'>
                <title>Document</title>
                </head>
                <body>");

            foreach (var e in files)
            {
                var items = File.ReadAllLines(e);
                result.Append($@"
<div class='container'>
                    <h1 class='author'>{items[0]}</h1>
                    <span>
                    <strong>{items[1]}</strong>:
                    <small>{items[2]}</small>
                    </span>
                    <form action='/edit/{items[1]+items[2]}'>
                    <button type='submit'>Edit</button>
                    </form>
                    <form action='/delete/{items[1]+items[2]}'>
                    <button type='submit'>Remove</button>
                    </form>
                    </div>");
            }

            result.Append(@"</body>
</html>");
            await context.Response.WriteAsync(result.ToString());
            }

        public async Task EditPost(HttpContext context)
        {
            var id = context.Request.Path.Value.Split('/').LastOrDefault();
            if (context.Request.Method == "POST")
            {
                string name = context.Request.Form["name"];
                string text = context.Request.Form["text"];
                
                string date = DateTime.Now.ToShortDateString();
                string txtFileName = Path.Combine("Files", id + ".txt");
                File.WriteAllLines(txtFileName, new string[] {name, text,date});
            
                context.Response.Redirect("/posts/");
            
            }
            else
            {
                var items = File.ReadAllLines($"Files/{id}.txt");
                var result = $@"<!doctype html>
<html lang='en'>
                    <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport'
                content='width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0'>
                    <
                    <title>Document</title>
                    </head>
                    <body>
                    <form action='/edit/{id}' method='post'>
                    <input name='name' value={items[0]}/>
                    <textarea name='text'>{items[1]}</textarea>
                  
                    <button type='submit'>Confirm</button>
                    </form>
                    </body>
                    </html>";
                await context.Response.WriteAsync(result);
            }
        }
        public async Task DeletePost(HttpContext context)
        {
            var id = context.Request.Path.Value.Split('/').LastOrDefault();
            File.Delete($"Files/{id}.txt");
            File.Delete($"Files/{id}.png");
            context.Response.Redirect("/posts/");
        }
        

    }
}