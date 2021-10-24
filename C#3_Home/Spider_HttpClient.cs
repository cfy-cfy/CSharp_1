using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Extensions.Http;
using System.Net.Http;            // HttpClient
using System.Net.Http.Headers;    // HttpClient
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.IO;
using System.Net;   // HttpWebRequest

// 在Visual Studio中安装下面几个包：Microsoft.Extensions.Http、Newtonsoft.Json
// https://www.jb51.net/article/189547.htm
// https://www.cjavapy.com/article/50/     .Net(C#)后台发送Get和Post请求的几种方法总结:RestSharp、Flurl.Http、HttpWebRequest、WebClient、HttpClient
// https://www.cnblogs.com/whuanle/p/11656734.html  C# HttpClient 请求认证、数据传输笔记
// https://www.cjavapy.com/article/580/            .NET(C#) HttpClient单例(Singleton)和每次请求new HttpClient对比
// https://www.cnblogs.com/nnnnnn/p/13509169.html  HttpWebRequest、WebClient、HttpClient的使用详解

namespace WindowsForms_Excel_1
{
	////—————————————————————————————————————————— 【get】
	public class Contributor
	{
		public string Login { get; set; }
		public short Contributions { get; set; }
		public override string ToString()
		{
			return $"{Login,20}: {Contributions} contributions";
		}
	}
	public class HttpClient_GetGitHub
	{
		public static async Task Sub_github()   // https://api.github.com/repos/symfony/symfony/contributors
		{
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://api.github.com");
				client.DefaultRequestHeaders.Add("User-Agent", "CJAVAPY BOT");   //在请求标头中，我们指定User-Agent
				client.DefaultRequestHeaders.Add("Accept", "application/json"); //设置accept标头，告诉JSON是可接受的响应类型
																				//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
				ShowHeaders("Request Headers:", client.DefaultRequestHeaders);

				var url = "repos/symfony/symfony/contributors";
				HttpResponseMessage response = await client.GetAsync(url);
				response.EnsureSuccessStatusCode();
				var resp = await response.Content.ReadAsStringAsync();
				List<Contributor> contributors = JsonConvert.DeserializeObject<List<Contributor>>(resp);
				contributors.ForEach(Console.WriteLine);

				ShowHeaders("Response Headers:", response.Headers);

			}
		}

		public static void ShowHeaders(string title, HttpHeaders headers)
		{
			Console.WriteLine(title);
			foreach (var header in headers)
			{
				string value = string.Join(" ", header.Value);
				Console.WriteLine($"Header: {header.Key} Value: {value}");
			}
		}

	}



	//——————————————————————————————————————————

	public class HttpClient_get
	{
		// GetAsync + ReadAsStringAsync
		public static async Task Sub_GetAsync()
		{
			using (var client = new HttpClient())
			{
				var result = await client.GetAsync("http://webcode.me");
				Console.WriteLine("【】"+result.StatusCode);
				Console.WriteLine(await result.Content.ReadAsStringAsync());

			}
		}

		// GetStringAsync
		public static async Task Sub_GetStringAsync()
		{
			using (var client = new HttpClient())
			{
				var content = await client.GetStringAsync("http://webcode.me");
				Console.WriteLine(content);
			}
		}

		public static async Task Sub_SendAsync()    // head
		{
			var url = "http://webcode.me";
			using (var client = new HttpClient())
			{
				var result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
				Console.WriteLine(result);

				var request = new HttpRequestMessage(HttpMethod.Get, url);
				HttpResponseMessage response = await client.SendAsync(request);
				Console.WriteLine("response.Version" + response.Version.ToString());
				response.EnsureSuccessStatusCode();
				string getResult = await response.Content.ReadAsStringAsync();
				Console.WriteLine(getResult);


			}
		}

		public static async Task Sub_Baidu(string uri = "http://news.baidu.com/")
		{
			using (HttpClient client = new HttpClient())
			{
				try
				{
					client.Timeout = TimeSpan.FromSeconds(30);                          // 设置超时限制，有效防止浪费资源

					HttpResponseMessage response = await client.GetAsync(uri);          //使用 GetAsync 进行异步 HTTPGET 请求

					response.EnsureSuccessStatusCode();                                 // 判断服务器响应代码是否为 2XX

					string responseBody = await response.Content.ReadAsStringAsync();   //使用 await 语法读取响应内容

					Console.WriteLine(responseBody);
				}
				catch (HttpRequestException e)
				{
					Console.WriteLine("Error Message :{0} ", e.Message);
				}
			}
		}


		//——-—————————————————— 
		// HttpClient应该只被实例化一次，并在应用程序的整个生命周期中被重用。如为每个请求实例化一个HttpClient类将耗尽沉重负载
		// 下可用的套接字数量。这将导致SocketException错误。下面是正确使用HttpClient的示例。

		public static readonly HttpClient client = new HttpClient();
		public static async Task Sub_contoso()
		{
			// 在try/catch块中调用异步网络方法来处理异常。
			try
			{
				HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				// string responseBody = await client.GetStringAsync(uri);
				Console.WriteLine(responseBody);
			}
			catch (HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");
				Console.WriteLine("Message :{0} ", e.Message);
			}
		}

	}

	//—————————————————————————————————————————— 【post】
	
	public class HttpClient_post
	{

		public static async Task Sub_example()
		{
			HttpClient client = new HttpClient();

			//var responseString = await client.GetStringAsync(@"http://www.example.com/recepticle.aspx");  //发送Get请求

			var values = new Dictionary<string, string>
			{
					{ "thing1", "hello" },
					{ "thing2", "world" }
			};
			var content = new FormUrlEncodedContent(values);
			var response = await client.PostAsync(@"http://www.example.com/recepticle.aspx", content);  //发送Post请求
			var responsetext = await response.Content.ReadAsStringAsync();
			Console.WriteLine(responsetext);

		}
		public static async Task Sub_Ocean()
		{

			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36"); 
			client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"); //设置accept标头，告诉JSON是可接受的响应类型
			client.DefaultRequestHeaders.Add("Origin", "http://i1168.vicp.net:9050");
			client.DefaultRequestHeaders.Add("Refere", "http://i1168.vicp.net:9050/ocean/");
			client.DefaultRequestHeaders.Add("Host", "i1168.vicp.net:9050");
			HttpClient_GetGitHub.ShowHeaders("Request Headers:", client.DefaultRequestHeaders);
			var values = new Dictionary<string, string>
			{
					{ "authenticityToken", "404d7a04806e8d619f8300f7dd3882d2559eadb0" },
					{ "username", "cfycfy" },
					{ "password", "122333" }
			};
			var content = new FormUrlEncodedContent(values);
			//var response = await client.PostAsync(@"http://erp.aicabathrooms.com:9050/ocean/users/login", content);  //发送Post请求
			var response = await client.PostAsync(@"http://i1168.vicp.net:9050/ocean/users/login", content);
			HttpClient_GetGitHub.ShowHeaders("Response Headers:", response.Headers);
			var responsetext = await response.Content.ReadAsStringAsync();
			Console.WriteLine(responsetext);

		}
	
	//————————————————————————————————————————
	
	//一，授权认证
	//1. 基础认证示例
	//2. JWT 认证示例
	//3. Cookie 示例
	//二，请求类型
	//三，数据传输
	//1. Query
	//2. Header
	//3. 表单
	//4. JSON
	//5. 上传文件

	//客户端请求服务器时，需要通过授权认证许可，方能获取服务器资源，目前比较常见的认证方式有 Basic 、JWT、Cookie。
	//HttpClient 是 C# 中的 HTTP/HTTPS 客户端，用于发送 HTTP 请求和接收来自通过 URI 确认的资源的 HTTP 响应。

	//——-—————————————————— 【1. 基础认证示例】


		public static async Task NoCookie()
		{
			var httpclientHandler = new HttpClientHandler()
			{
				UseCookies = true
			};
			// 如果服务器有 https 证书，但是证书不安全，则需要使用下面语句
			// => 也就是说，不校验证书，直接允许

			var values = new Dictionary<string, string>
			{
					{ "authenticityToken", "404d7a04806e8d619f8300f7dd3882d2559eadb0" },
					{ "username", "cfycfy" },
					{ "password", "122333" }
			};
			var content = new FormUrlEncodedContent(values);

			using (var httpClient = new HttpClient(httpclientHandler))
			{
				httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36");
				// 先登陆
				//var result = await httpClient.PostAsync(@"http://erp.aicabathrooms.com:9050/ocean/users/login", content);
				var result = await httpClient.PostAsync(@"http://i1168.vicp.net:9050/ocean/users/login", content);

				var responsetext = await result.Content.ReadAsStringAsync();
				Console.WriteLine(responsetext);
				// 登陆成功后，客户端会自动携带 cookie ，不需要再手动添加
				//if (result.IsSuccessStatusCode)
				//{
				//    /*
				//     * 如果请求成功
				//     */
				//}

				//var result2 = await httpClient.GetAsync(url);
				// httpclient 已经携带 Cookie ，可以多次使用
				// var result3 = await httpClient.GetAsync(url3);
				// var result4 = await httpClient.GetAsync(url4);

				httpClient.Dispose();
			}
		}


		//已经拿到 cookie ，直接使用 cookie 请求
		public static async Task Cookie()
		{
			string cookie = "PLAYAB_SESSION=fe17aa4f50e48921dcf6efc74a5a8d445a15356f-%00___AT%3A435b98d80fcd02f8dafced0ac1baf7ec2e8d5238%00%00role%3A5%00%00user%3Acfycfy%00; Path=/ocean/";

			var httpclientHandler = new HttpClientHandler()
			{
				UseCookies = false
			};
			// 如果服务器有 https 证书，但是证书不安全，则需要使用下面语句
			// => 也就是说，不校验证书，直接允许

			using (var httpClient = new HttpClient(httpclientHandler))
			{
				httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36");
				httpClient.DefaultRequestHeaders.Add("Cookie", cookie);
				var result = await httpClient.GetAsync(@"http://i1168.vicp.net:9050/ocean/eorders/search");
				var responsetext = await result.Content.ReadAsStringAsync();
				Console.WriteLine(responsetext);
				httpClient.Dispose();
			}
		}

	}

	

}
