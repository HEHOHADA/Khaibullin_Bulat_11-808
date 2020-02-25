using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EmptyWeb
{
	public class HomeController
	{
		public async Task GetForm(HttpContext context)
		{
			await context.Response.WriteAsync(File.ReadAllText("Views\\index.html"));
		}

		public async Task AddEntry(HttpContext context)
		{
			string filePath = "Files";

			int fileCount = Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories).Length;
			fileCount++;

			string name = context.Request.Form["name"];
			string text = context.Request.Form["text"];
			string date = DateTime.Now.ToShortDateString();
			foreach (var formFile in context.Request.Form.Files)
			{
				if (formFile.Length > 0)
				{
					string newFile = Path.Combine(filePath, text+date + Path.GetExtension(formFile.FileName));
					using (var inputStream = new FileStream(newFile, FileMode.Create))
					{
						
						await formFile.CopyToAsync(inputStream);
						
						byte[] array = new byte[inputStream.Length];
						inputStream.Seek(0, SeekOrigin.Begin);
						inputStream.Read(array, 0, array.Length);

						string fName = formFile.FileName;
					}
				}
			}

			
			string txtFileName = Path.Combine(filePath, text+date + ".txt");
			File.AppendAllLines(txtFileName, new string[] {name, text,date});
			
			await context.Response.WriteAsync("New Entry was added");
		}
	}
}
