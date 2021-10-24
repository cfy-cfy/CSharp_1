using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;            // HttpClient
using System.Net.Http.Headers;    // HttpClient
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Data;

// https://www.cnblogs.com/SunXianChun/p/13198630.html  利用Tu Share获取股票交易信息，c#实现
// https://waditu.com/document/2?doc_id=27

namespace WindowsForms_Excel_1 
{
	class Spider_TuShare   // Spider_TuShare.cs
	{

	}

	public interface IHttpClientUtility
	{
		string HttpClientPost(string url, object datajson);
	}

	public class HttpClientUtility : IHttpClientUtility
	{
		//public HttpClientUtility()
		//{

		//}
		public string HttpClientPost(string url, object datajson)
		{
			using (HttpClient httpClient = new HttpClient()) //http对象
			{
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				httpClient.Timeout = new TimeSpan(0, 0, 5);
				//转为链接需要的格式
				HttpContent httpContent = new JsonContent(datajson);
				//请求
				HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
				if (response.IsSuccessStatusCode)
				{
					Task<string> t = response.Content.ReadAsStringAsync();
					return t.Result;
				}
				throw new Exception("调用失败");
			}

		}

	}
	// ————————————————————————————————————
	public class JsonContent : StringContent
	{
		public JsonContent(object value)
			: base(JsonConvert.SerializeObject(value), Encoding.UTF8,"application/json")
		{
		}

		public JsonContent(object value, string mediaType)
			: base(JsonConvert.SerializeObject(value), Encoding.UTF8, mediaType)
		{
		}
	}
	// ————————————————————————————————————

	public class TuShareUtility
	{
		private IHttpClientUtility _httpClientUtility;
		private string _url = "http://api.waditu.com/";

		public TuShareUtility(IHttpClientUtility httpClientUtility)
		{
			_httpClientUtility = httpClientUtility;
		}

		/// <summary>
		/// 调用TuShare API
		/// </summary>
		/// <param name="apiName"></param>
		/// <param name="parmaMap"></param>
		/// <param name="fields"></param>
		/// <returns></returns>
		public DataTable GetData(string apiName, Dictionary<string, string> parmaMap, params string[] fields)
		{
			var tuShareParamObj = new TuShareParamObj() { ApiName = apiName, Params = parmaMap, Fields = string.Join(",", fields) };
			//做Http调用
			var result = _httpClientUtility.HttpClientPost(_url, tuShareParamObj);
			//将返回结果序列化成对象
			var desResult = JsonConvert.DeserializeObject<TuShareResult>(result);
			//如果调用失败，抛出异常
			if (!string.IsNullOrEmpty(desResult.Msg)) throw new Exception(desResult.Msg);
			//返回结果分成两部分，一部分是列头信息，另一部分是数据本身，用这两部分数据可以构建DataTable
			DataTable dt = new DataTable();
			foreach (var dataField in desResult.Data.Fields)
			{
				dt.Columns.Add(dataField);
			}

			foreach (var dataItemRow in desResult.Data.Items)
			{
				var newdr = dt.NewRow();
				for (int i = 0; i < dataItemRow.Length; i++)
				{
					newdr[i] = dataItemRow[i];
				}

				dt.Rows.Add(newdr);
			}
			return dt;
		}

		private class TuShareParamObj
		{
			[JsonProperty("api_name")]
			public string ApiName { get; set; }

			[JsonProperty("token")]
			public string Token { get; } = "0b7e5511c9611af40a85df00d8692aaf4a699d8e639d2a849d87991d";//你的Token

			[JsonProperty("params")]
			public Dictionary<string, string> Params { get; set; }

			[JsonProperty("fields")]
			public string Fields { get; set; }
		}

		private class TuShareData
		{
			[JsonProperty("fields")]
			public string[] Fields { get; set; }

			[JsonProperty("items")]
			public string[][] Items { get; set; }
		}

		private class TuShareResult
		{
			[JsonProperty("code")]
			public string Code { get; set; }

			[JsonProperty("msg")]
			public string Msg { get; set; }

			[JsonProperty("data")]
			public TuShareData Data { get; set; }
		}



	}




}
