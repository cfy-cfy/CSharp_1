using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Data;
using System.ComponentModel; // DefaultValueAttribute是指定属性 (Property) 的默认值。

//使用Json的时候，会涉及到几个序列化对象的使用：DataContractJsonSerializer,JavaScriptSerializer 和Json.NET即Newtonsoft.Json。
//大多数人都会选择性能以及通用性较好Json.NET，这个不是微软的类库，但是一个开源的世界级的Json操作类库

// https://www.cnblogs.com/yanweidie/p/4605212.html
// https://www.it1352.com/1512222.html

namespace WindowsForms_Excel_1
{
	class Spider_Json
	{

	}



	public class Newtonsoft_Json
	{
		public static void JsonReader_1()  // using Newtonsoft.Json;  使用JsonReader读Json字符串
		{
			string jsonText = @"{""input"" : ""value"", ""output"" : ""result""}";
			JsonReader reader = new JsonTextReader(new StringReader(jsonText));
			while (reader.Read())
			{
				//Console.WriteLine(reader.TokenType + "\t\t" + reader.ValueType + "\t\t" + reader.Value + "\r\n");
				Console.WriteLine(reader.Value);

			}

		}

		public static void JsonWriter_2()   //  使用JsonWriter写字符串
		{
			StringWriter sw = new StringWriter();
			JsonWriter writer = new JsonTextWriter(sw);
			writer.WriteStartObject();
			writer.WritePropertyName("input");
			writer.WriteValue("value");
			writer.WritePropertyName("output");
			writer.WriteValue("result");
			writer.WriteEndObject();
			writer.Flush();
			string jsonText2 = sw.GetStringBuilder().ToString();
			Console.WriteLine(jsonText2);
		}

		public static void JObject_3()      // using Newtonsoft.Json.Linq;    使用JObject读写字符串
		{
			string jsonText = @"{""input"" : ""value"", ""output"" : ""result""}";

			JObject jo = JObject.Parse(jsonText);
			Console.WriteLine(jo["input"]);
			//string[] values = jo.Properties().Select(item => item.Value.ToString()).ToArray();
			string[] values = jo.Properties().Select(key => key.Value.ToString()).ToArray();
			foreach (string v in values)
			{
				Console.WriteLine(v);
			}

			string jsonArrayText1 = "[{'a':'a1','b':'b1'},{'a':'a2','b':'b2'}]";
			JArray ja = (JArray)JsonConvert.DeserializeObject(jsonArrayText1);
			Console.WriteLine(ja[1]["a"].ToString());

			JObject o = (JObject)ja[0];
			Console.WriteLine(o["a"].ToString());

			string jsonText3 = "{\"beijing\":{\"zone\":\"海淀\",\"zone_en\":\"haidian\"}}";
			JObject jo1 = (JObject)JsonConvert.DeserializeObject(jsonText3);
			string zone = jo1["beijing"]["zone"].ToString();
			string zone_en = jo1["beijing"]["zone_en"].ToString();
			Console.WriteLine(zone);
			Console.WriteLine(zone_en);
			Console.WriteLine(jo1);


		}

		//支持序列化和反序列化DataTable,DataSet,Entity Framework和Entity的。下面分别举例说明序列化和反序列化。DataTable：

		public static void JsonConvert_4()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("Age", Type.GetType("System.Int32"));
			dt.Columns.Add("Name", Type.GetType("System.String"));
			dt.Columns.Add("Sex", Type.GetType("System.String"));
			dt.Columns.Add("IsMarry", Type.GetType("System.Boolean"));
			for (int i = 0; i < 4; i++)
			{
				DataRow dr = dt.NewRow();
				dr["Age"] = i + 1;
				dr["Name"] = "Name" + i;
				dr["Sex"] = i % 2 == 0 ? "男" : "女";
				dr["IsMarry"] = i % 2 > 0 ? true : false;
				dt.Rows.Add(dr);
			}
			string dtjsontext = JsonConvert.SerializeObject(dt);
			Console.WriteLine(dtjsontext);                        // 序列化

			DataTable dtjson = new DataTable();
			dtjson = JsonConvert.DeserializeObject<DataTable>(dtjsontext);  // 反序列化

			Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", dt.Columns[0], dt.Columns[1], dt.Columns[2], dt.Columns[3]);
			foreach (DataRow dr in dtjson.Rows)
			{
				Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", dr[0], dr[1], dr[2], dr[3]);
			}

		}

		//一.忽略某些属性
		//类似本问开头介绍的接口优化，实体中有些属性不需要序列化返回，可以使用该特性。首先介绍Json.Net序列化的模式:OptOut 和 OptIn

		//OptOut  默认值,类中所有公有成员会被序列化,如果不想被序列化,可以用特性【JsonIgnore】
		//OptIn   默认情况下,所有的成员不会被序列化,类中的成员只有标有特性【JsonProperty】的才会被序列化,当类的成员很多,但客户端仅仅需要一部分数据时,很有用


		public static void JsonConvert_5OptOut()      // 不输出 IsMarry
		{
			JsonConvert_OptOut p = new JsonConvert_OptOut { room = 1, Age = 10, Name = "张三丰", Sex = "男", IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
			Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented));
		}
		
		[JsonObject(MemberSerialization.OptOut)]
		public class JsonConvert_OptOut
		{
			[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
			public int? room { get; set; }

			[DefaultValue(10)]                            // using System.ComponentModel;
			public int Age { get; set; }

			[JsonProperty("params")]
			public string Name { get; set; }

			public string Sex { get; set; }

			[JsonIgnore]  
			public bool IsMarry { get; set; }             // 不输出 IsMarry

			public DateTime Birthday { get; set; }
		}
//——————————————————————————————————————————————————
		public static void JsonConvert_6OptIn()         // 仅需要 name 属性
		{
			JsonConvert_OptIn p = new JsonConvert_OptIn { Age = 10, Name = "张三丰", Sex = "男", IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
			Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented));
		}

		[JsonObject(MemberSerialization.OptIn)]
		public class JsonConvert_OptIn
		{
			public int Age { get; set; }
			             
			[JsonProperty]                                // 仅需要姓名属性
			public string Name { get; set; } 

			[JsonProperty(PropertyName = "PersonSex")]    // 自定义序列化的字段名称
			public string Sex { get; set; }

			public bool IsMarry { get; set; }

			public DateTime Birthday { get; set; }
		}

		//——————————————————————————————————————
		public static void JsonConvert_6OptIn_1()         // 只输出"Age", "IsMarry"两个属性
		{
			JsonConvert_Null p = new JsonConvert_Null { Age = 10, Name = "张三丰", Sex = "男", IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
			JsonSerializerSettings jsetting = new JsonSerializerSettings();
			jsetting.ContractResolver = new LimitPropsContractResolver(new string[] { "Age", "IsMarry" });
			
			Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented, jsetting));
		}

		public class LimitPropsContractResolver : DefaultContractResolver
		{
			private string[] props = null;

			public LimitPropsContractResolver(string[] props)
			{
				this.props = props;
			}

			protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
			{
				IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
				//只保留清單有列出的屬性
				return list.Where(p => props.Contains(p.PropertyName)).ToList();
			}
		}

		//二.默认值处理

		//序列化时想忽略默认值属性可以通过JsonSerializerSettings.DefaultValueHandling来确定，该值为枚举值
		//DefaultValueHandling.Ignore  序列化和反序列化时, 忽略默认值
		//DefaultValueHandling.Include 序列化和反序列化时, 包含默认值
		public static void JsonConvert_7DefaultValue()
		{
			JsonConvert_OptOut p = new JsonConvert_OptOut { room = 1, Age = 10, Name = "张三丰", Sex = "男", IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
			JsonSerializerSettings jsetting = new JsonSerializerSettings();
			jsetting.DefaultValueHandling = DefaultValueHandling.Ignore;
			Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented, jsetting));

		}

		//三.空值的处理
		//序列化时需要忽略值为NULL的属性，可以通过JsonSerializerSettings.NullValueHandling来确定，另外通过JsonSerializerSettings设置
		//属性是对序列化过程中所有属性生效的，想单独对某一个属性生效可以使用JsonProperty，下面将分别展示两个方式


		public static void JsonConvert_8null()    // JsonProperty
		{
			JsonConvert_OptOut p = new JsonConvert_OptOut { room = null, Age = 10, Name = "张三丰", Sex = "男", IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
			Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented));
		}

		public class JsonConvert_Null
		{
			//[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
			public int? room { get; set; }

			public int Age { get; set; }

			public string Name { get; set; }

			public string Sex { get; set; }

			public bool IsMarry { get; set; }

			//[JsonConverter(typeof(JavaScriptDateTimeConverter))]
			//[JsonConverter(typeof(IsoDateTimeConverter))]
			//[JsonConverter(typeof(OnlyDateConverter))]    // 自定义格式。当调用 JsonConvert_10Dateime 需要注释掉这个属性设计
			public DateTime Birthday { get; set; }
		}
//————————————————————————————————————————
		public static void JsonConvert_9null()     // JsonSerializerSettings
		{
			JsonConvert_Null p = new JsonConvert_Null { room = null, Age = 10, Name = "张三丰", Sex = "男", IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
			JsonSerializerSettings jsetting = new JsonSerializerSettings();
			jsetting.NullValueHandling = NullValueHandling.Ignore;     // 忽略值为NULL的属性
			Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented, jsetting));
		}
		//————————————————————————————————————————

		public static void JsonConvert_10Dateime()     // JsonSerializerSettings
		{
			JsonConvert_Null p = new JsonConvert_Null { room = null, Age = 10, Name = "张三丰", Sex = "男", IsMarry = false, Birthday = new DateTime(1991, 1, 2) };

			//IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
			//timeFormat.DateTimeFormat = "yyyy-MM-dd hh:mm";

			IsoDateTimeConverter timeFormat = new IsoDateTimeConverter { DateTimeFormat = "yyyy'年'MM'月'dd'日'" };

			Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented, timeFormat));
		}
		//————————————————————————————————————————
		public static void JsonConvert_11Dateime()     // JsonSerializerSettings
		{
			JsonConvert_Null p = new JsonConvert_Null { room = null, Age = 10, Name = "张三丰", Sex = "男", IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
			Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented));
		}

		public class OnlyDateConverter : IsoDateTimeConverter
		{
			public OnlyDateConverter()
			{
				DateTimeFormat = "yyyy-MM-dd";
			}
		}

		//————————————————————————————————————————



	}





}
