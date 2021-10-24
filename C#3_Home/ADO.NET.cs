using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;   // 需要另外安装 SQL Server
using System.Windows.Forms;
using MySql.Data.MySqlClient;  // 需要另外安装 MySQL + (mysql-connector-net-8.0.25.msi)
using System.Data;
using System.IO;


namespace WindowsForms_Excel_1
{
	class ADO
	{
	}

	//—————————————————————————————————— 1 【 DO.NET数据库操作及常用类概述 】

	//	在 C# 语言中 ADO.NET 是在 ADO 的基础上发展起来的，ADO (Active Data Object) 是一个 COM 组件类库，用于访问数据库，而 ADO.NET 是在 .NET 平台上访问数据库的组件。
	//ADO.NET 是以 ODBC(Open Database Connectivity) 技术的方式来访问数据库的一种技术。

	//ADO.NET 中的常用命名空间如下表所示。
	//命名空间 数据提供程序
	//System.Data.SqlClient Microsoft SQL Server
	//System.Data.Odbc ODBC
	//System.Data.OracleClient Oracle
	//System.Data.OleDb OLE DB
	//在使用 ADO.NET 进行数据库操作时通常会用到 5 个类，分别是 Connection 类、 Command 类、DataReader 类、DataAdapter 类、DataSet 类。

	//在接下来的讲解中我们将以连接 SQL Server 为例介绍 ADO.NET 中的对象，引用的命名空间为 System.Data.SqlClient。

	//除了 DataSet 类以外，其他对象的前面都加上 Sql，即 SqlConnection、SqlCommand、SqlDataReader、SqlDataAdapter。

	//1) Connection 类
	//该类主要用于数据库中建立连接和断开连接的操作，并且能通过该类获取当前数据库连接的状态。
	//使用 Connection 类根据数据库的连接串能连接任意数据库，例如 SQLServer、Oracle、MySQL 等。
	//但是在.NET 平台下，由于提供了一个 SQL Server 数据库，并额外提供了一些操作菜单便于操作，所以推荐使用 SQLServer 数据库。

	//2) Command 类
	//该类主要对数据库执行增加、删除、修改以及查询的操作。
	//通过在 Command 类的对象中传入不同的 SQL 语句，并调用相应的方法来执行 SQL 语句。

	//3) DataReader 类
	//该类用于读取从数据库中查询出来的数据，但在读取数据时仅能向前读不能向后读， 并且不能修改该类对象中的值。
	//在与数据库的连接中断时，该类对象中的值也随之被清除。

	//4) DataAdapter 类
	//该类与 DataSet 联用，它主要用于将数据库的结果运送到 DataSet 中保存。
	//DataAdapter 可以看作是数据库与 DataSet 的一个桥梁，不仅可以将数据库中的操作结果运送到 DataSet 中，也能将更改后的 DataSet 保存到数据库中。

	//5) DataSet 类
	//该类与 DataReader 类似，都用于存放对数据库查询的结果。
	//不同的是，DataSet 类中的值不仅可以重复多次读取，还可以通过更改 DataSet 中的值更改数据库中的值。
	//此外，DataSet 类中的值在数据库断开连接的情况下依然可以保留原来的值。

	//———————————————————————————— 2 【 Connection：连接数据库 】System.Data.SqlClient

	//Connection 类根据要访问的数据和访问方式不同，使用的命名空间也不同，类名也稍有区别，在这里我们使用的是 SqlConnection 类，以及微软提供的 SQL Server 2014 数据库。

	//SqlConnection 类中提供的常用属性和方法如下表所示。

	//属性或方法 说明
	//SqlConnection() 无参构造方法
	//SqlConnection(string connectionstring)  带参数的构造方法，数据库连接字符串作为参数
	//Connectionstring    属性，获取或设置数据库的连接串
	//State   属性，获取当前数据库的状态，由枚举类型 Connectionstate 为其提供值
	//ConnectionTimeout   属性，获取在尝试连接时终止尝试并生成错误之前所等待的时间
	//DataSource  属性，获取要连接的 SQL Server 的实例名
	//Open()  方法，打开一个数据库连接
	//Close() 方法，关闭数据库连接
	//BeginTransaction()  方法，开始一个数据库事务

	//使用 Connection 类连接数据库:

	//第1种方式:
	//server = 服务器名称 / 数据库的实例名 ; uid = 登录名 ; pwd = 密码 ; database = 数据库名称

	//第2种方式:
	//Data Source = 服务器名称 \ 数据库实例名 ; Initial Catalog = 数据库名称; User ID = 用户名; Password = 密码

	//第3种方式:
	//此外，还可以在连接字符串中使用 Integrate Security = True 的属性，省略用户名和密码，
	//即以 Windows 身份验证方式登录 SQL Server 数据库。

	//Data Source = 服务器名称 \ 数据库实例名 ; Initial Catalog = 数据库名称; Integrate Security = True

	//———————————————————————————— 3 【 Connection：连接数据库 】System.Data.SqlClient

	// 下载(mysql-connector-net-8.0.25.msi)  https://dev.mysql.com/downloads/file/?id=504670
	// 建立在已经安装MySQL数据库的前提:
	//方法一：Visual Studio, 在 项目(右键)-管理NuGet程序包(N)  然后在浏览里面搜索MySql.Data并进行安装。
	//方法二：安装数据库MySQL时要选中Connector.NET 6.9的安装，将C:\Program Files(x86)\MySQL\Connector.NET 6.9\Assemblies里
	//v4.0或v4.5中的MySql.Data.dll添加到项目的引用。v4.0和v4.5，对应Visual Studio具体项目 属性-应用程序-目标框架 里的.NET Framework的版本号。

	
	
	//——————————————————————————— 4 【 Connection：连接数据库 】MySql.Data.MySqlClient

	//mysql+pymysql://root:whhxpp@127.0.0.1:3306/runoob",
	//mysql+pymysql:// 用户名:密码@地址:端口/数据库名称

	public class MySQLclass
	{
		public static void SubMySQL_conn()
		{
			String connetStr = "server=127.0.0.1;port=3306;user=root;password=whhxpp; database=runoob;";
			// server=127.0.0.1/localhost 代表本机，端口号port默认是3306可以不写
			MySqlConnection conn = new MySqlConnection(connetStr);
			try
			{
				conn.Open();    // 打开通道，建立连接，可能出现异常,使用try catch语句
				Console.WriteLine("已经建立连接");
				
				//在这里使用代码对数据库进行增删查改
			}
			catch (MySqlException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				conn.Close();
				Console.WriteLine("已经关闭连接");
			}

		}
//——————————————————————————————————
		public static void SubMySQL_conn_using()
		{
			String connetStr = "server=127.0.0.1;port=3306;user=root;password=whhxpp; database=runoob;";
			// server=127.0.0.1/localhost 代表本机，端口号port默认是3306可以不写
			try
			{
				using (MySqlConnection conn = new MySqlConnection(connetStr))
				{ 
					conn.Open();    // 打开通道，建立连接，可能出现异常,使用try catch语句
					Console.WriteLine("已经建立连接");

				}
			}
			catch (MySqlException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.WriteLine("已经关闭连接");
			}

		}
	}

	//——————————————————————————— 5 【 Command：操作数据库 】MySql.Data.MySqlClient
		//在 System.Data.SqlClient 命名空间下，对应的 Command 类为 SqlCommand，在创建 SqlCommand 实例前必须已经创建了与数据库的连接。

		//SqlCommand 类中常用的构造方法如下表所示。

		//构造方法 说明
		//SqlCommand() 无参构造方法
		//SqlCommand(string commandText, SqlConnection conn) 带参的构造方法，第 1 个参数是要执行的 SQL 语句，第 2 个参数是数据库的连接对象
		//对数据库中对象的操作不仅包括对数据表的操作，还包括对数据库、视图、存储过程等数据库对象的操作，接下来主要介绍的是对数据表和存储过程的操作。

		//在对不同数据库对象进行操作时，SqlCommand 类提供了不同的属性和方法，常用的属性和方法如下表所示。

		//属性或方法 说明
		//CommandText 属性，Command 对象中要执行的 SQL 语句
		//Connection 属性，获取或设置数据库的连接对象
		//CommandType 属性，获取或设置命令类型
		//Parameters  属性，设置 Command 对象中 SQL 语句的参数
		//ExecuteReader() 方法，获取执行查询语句的结果
		//ExecuteScalar() 方法，返回查询结果中第 1 行第 1 列的值
		//ExecuteNonQuery() 方法，执行对数据表的增加、删除、修改操作

	public class MySQLCommandclass
	{
		public static void SubMySQL_Command_ExecuteNonQuery()
		{
			//编写数据库连接串
			string connStr = "server=127.0.0.1;port=3306;user=root;password=whhxpp; database=runoob;";
			//创建 SqlConnection的实例
			MySqlConnection conn = null;
			try
			{
				conn = new MySqlConnection(connStr);
				//打开数据库连接
				conn.Open();
				string sql = "insert into runoob_tbl(runoob_title, runoob_author, submission_date) values('{0}','{1}','{2}')";
				//填充SQL语句
				sql = string.Format(sql, "学习 VBA", "3WCSchool","2021-07-02");
				//创建SqlCommand对象
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				//执行SQL语句
				int returnvalue = cmd.ExecuteNonQuery();
				//判断SQL语句是否执行成功
				if (returnvalue != -1)
				{
					MessageBox.Show("插入成功");
				}
			}
			
			catch (Exception ex)
			{
				MessageBox.Show("插入失败！" + ex.Message);
			}
			finally
			{
				if (conn != null)
				{
					conn.Close();
					MessageBox.Show("已关闭数据库连接");
				}
			}


		}

//————————————————————————————————————————
		public static void SubMySQL_Command_ExecuteScalar()
		{
			//编写数据库连接串
			string connStr = "server=127.0.0.1;port=3306;user=root;password=whhxpp; database=runoob;";
			//创建SQLConnection的实例
			MySqlConnection conn = null;
			try
			{
				conn = new MySqlConnection(connStr);
				//打开数据库连接
				conn.Open();
				string sql = "Select * from runoob_tbl where runoob_title='{0}' and runoob_author='{1}'";
				//填充SQL语句
				sql = string.Format(sql, "JAVA 教程", "RUNOOB.COM");
				//创建SqlCommand对象
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				//执行SQL语句
				int returnvalue = (int)cmd.ExecuteScalar();
				//判断SQL语句是否执行成功
				if (returnvalue != 0)
				{
					MessageBox.Show("登录成功！"+ returnvalue.ToString());
				}
				else
				{
					MessageBox.Show("登录失败！");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("注册失败！" + ex.Message);
			}
			finally
			{
				if (conn != null)
				{
					conn.Close();
					MessageBox.Show("已关闭数据库连接");
				}
			}


		}
		//————————————————————————— 6 【 DataReader：读取查询结果 】MySql.Data.MySqlClient

		//DataReader 类概述
		//DataReader 类在 System.Data.SqlClient 命名空间中，对应的类是 SqlDataReader，主要用于读取表中的查询结果，并且是以只读方式读取的（即不能修改 DataReader 中存放的数据）。

		//正是由于 DataReader 类的特殊的读取方式，其访问数据的速度比较快，占用的服务器资源比较少。

		//SqlDataReader 类中常用的属性和方法如下表所示。

		//属性或方法 说明
		//FieldCount 属性，获取当前行中的列数
		//HasRows 属性，获取 DataReader 中是否包含数据
		//IsClosed    属性，获取 DataReader 的状态是否为已经被关闭
		//Read    方法，让 DataReader 对象前进到下一条记录
		//Close   方法，关闭 DataReader 对象
		//Get XXX(int i) 方法，获取指定列的值，其中XXX代表的是数据类型。例如获取当前行第1列 double 类型的值，获取方法为GetDouble(o)


		//使用 DataReader 类读取查询结果
		//在使用 DataReader 类读取查询结果时需要注意，当查询结果仅为一条时，可以使用 if 语句查询 DataReader 对象中的数据，
		//如果返回值是多条数据，需要通过 while 语句遍历 DataReader 对象中的数据。

		public static void SubMySQL_Command_ExecuteReader()
		{
			string connStr = "server=127.0.0.1;port=3306;user=root;password=whhxpp; database=runoob;";
			MySqlConnection conn = null;
			MySqlDataReader dr = null;   // 定义SqlDataReader类的对象
			try
			{
				conn = new MySqlConnection(connStr);
				conn.Open();
				//string sql = "select * from runoob_tbl where runoob_title='{0}'";
				//sql = string.Format(sql, "JAVA 教程");

				string sql = "select * from runoob_tbl ";

				MySqlCommand cmd = new MySqlCommand(sql, conn);
				dr = cmd.ExecuteReader();

				//if (dr.Read())    //  获取一条记录
				//{
				//	string msg = "runoob_title：" + dr[1] + " runoob_author：" + dr[2];
				//	Console.WriteLine(msg);
				//}

				while (dr.Read())    //  获取多条记录
				{
					string msg = "runoob_title：" + dr[1] + " runoob_author：" + dr[2];
					Console.WriteLine(msg);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("查询失败！" + ex.Message);
			}
			finally
			{
				if (dr != null)
				{
					dr.Close();    // 判断dr不为空，关闭SqlDataReader对象
				}
				if (conn != null)
				{
					conn.Close();
					MessageBox.Show("已关闭数据库连接");
				}
			}
		}



	}

	//————————————————————————— 7 【 DataSet和DataTable：保存查询结果 】MySql.Data.MySqlClient
		
		//在执行对表中数据的查询时还能将数据保存到 DataSet 中，但需要借助 DataAdapter 类来实现。
		//在实际应用中，DataAdapter 与 DataSet 是在查询操作中使用最多的类。
		//此外，还可以通过 DataSet 实现对表中数据的增加、修改、删除操作。

		//DataAdapter 与 DataSet 类简介
		//DataAdapter 类用于将数据表中的数据查询出来并添加到 DataSet 中，DataAdapter 在 System.Data.SqlClient 命名空间下对应的类名是 SqlDataAdapter。

		////——————————————————SqlDataAdapter 类的主要构造方法如下表所示。

		//构造方法 说明
		//SqlDataAdapter(SqlCommand cmd)  带参数的构造方法，传递 SqlCommand 类的对象作为参数
		//SqlDataAdapter(string sql, SqlConnection conn)  带参数的构造方法，sql 参数是指定对数据表执行的 SQL 语句，conn 是数据库的连接对象
		//SqlDataAdapter()    不带参数的构造方法
		//从 SqlDataAdapter 类的构造方法可以看出，SqlDataAdapter 类需要与 SqlCommand 类和 SqlConnection 类一起使用。

		//SqlDataAdapter 类常用的属性和方法如下表所示。

		//属性或方法 说明
		//SelectCommand 属性，设置 SqlDataAdapter 中要执行的查询语句
		//InsertCommand   属性，设置 SqlDataAdapter 中要执行的添加语句
		//UpdateCommand   属性，设置 SqlDataAdapter 中要执行的修改语句
		//DeleteCommand   属性，设置 SqlDataAdapter 中要执行的删除语句
		//Fill(DataSet ds)    方法，将 SqlDataAdapter 类中查询出的结果填充到 DataSet 对象中
		//Fill(DataTable dt)  方法，将 SqlDataAdapter 类中查询出的结果填充到 DataTable 对象 中，DataTable是数据表对象，在一个DataSet对象中由多个 DataTable对象构成
		//Update(DataSet ds)  方法，更新 DataSet 对象中的数据
		//Update(DataTable dt)    方法，更新 DataTable 对象中的数据
		//DataSet 类是一种与数据库结构类似的数据集，每个 DataSet 都是由若干个数据表构成的，DataTable 即数据表，每个 DataTable 也都是由行和列构成的，行使用 DataRow 类表示、列使用 DataColumn 类表示。

		//此外，用户还可以通过 DataRelation 类设置数据表之间的关系。

		//下面介绍 DataSet 类以及 DataTable 类的使用。
		//1)—————————————————— DataSet 类
		//DataSet 类中的构造方法如下表所示。

		//构造方法 说明
		//DataSet()   无参构造方法
		//DataSet(string DataSetName) 带参数的构造方法，DataSetName 参数用于指定数据集名称
		//DataSet 类中常用的属性和方法如下表所示。

		//属性或方法 说明
		//Tables 属性，获取 DataSet 中所有数据表的集合，Tables[0] 代表集合中的第一个数据表
		//CaseSensitive 属性，获取或设置 DataSet 中的字符串是否区分大小写
		//Relations   属性，获取 DataSet 中包含的关系集合
		//Clear() 方法，清空 DataSet 中的数据
		//Copy()  方法，复制 DataSet 中的数据
		//AcceptChanges() 方法，更新 DataSet 中的数据
		//HasChanges()    方法，获取 DataSet 中是否有数据发生变化
		//RejectChanges() 方法，撤销对 DataSet 中数据的更改
		//2) DataTable
		//DataTable 作为 DataSet 中的重要对象，其与数据表的定义是类似的，都是由行和列构成，并有唯一的表名。

		//从 SqlDataAdapter 类的填充方法(Fill) 中可以看出允许将数据直接填充到 DataTable 中，这样既能节省存储空间也能简化查找数据表中的数据。

		//——————————————————DataTable 中常用的构造方法如下表所示。

		//构造方法 说明
		//DataTable()     无参构造方法
		//DataTable(string TableName) 带参数的构造方法， TableName 参数用于指定数据表的名称
		//DataTable 与 DataSet 有很多相似的属性和方法，在下表中列出了一些与 DataSet 类不同的属性。

		//属性 说明
		//TableName 属性，获取或设置 DataTable 的名称
		//Columns 属性，获取 DataTable 中列的集合
		//Rows    属性，获取 DataTable 中行的集合
		//DataSet 属性，获取 DataTable 所在的 DataSet
		//Constraints 属性，获取 DataTable 中的所有约束

	public class DataAdapterClass
	{
		Form2 frm2;
		public DataAdapterClass(Form2 f)
		{
			frm2 = f;
		}
		public void SubMySQL_DataAdapter_DataSet()
		{
			string connStr = "server=127.0.0.1;port=3306;user=root;password=whhxpp; database=runoob;";
			MySqlConnection conn = null;
			try
			{
				conn = new MySqlConnection(connStr);
				conn.Open();
				string sql = "select * from runoob_tbl";
				MySqlDataAdapter sda = new MySqlDataAdapter(sql, conn);  // 创建 SQLDataAdapter 类的对象

				DataSet ds = new DataSet();   // 创建DataSet类的对象——using System.Data;								  
				sda.Fill(ds);                 // 使用SQLDataAdapter对象sda将查询结果填充到Dataset对象ds中

				frm2.listBox2.DataSource = ds.Tables[0];   // 设置ListBox控件的数据源（DataSource）属性								 
				frm2.listBox2.DisplayMember = ds.Tables[0].Columns[2].ToString();  // 在listBox控件中显示name列的值
			}
			catch (Exception ex)
			{
				MessageBox.Show("查询失败！" + ex.Message);
			}
			finally
			{
				if (conn != null)
				{
					conn.Close();
					MessageBox.Show("已关闭数据库连接");
				}
			}

		}
		//——————————————————————————————————————
		public void DataAdapter_DataSet_MySqlCommandBuilder()
		{
			string connStr = "server=127.0.0.1;port=3306;user=root;password=whhxpp; database=runoob;";
			MySqlConnection conn = null;
			try
			{
				conn = new MySqlConnection(connStr);
				conn.Open();
				string sql = "select * from runoob_tbl";
				MySqlDataAdapter sda = new MySqlDataAdapter(sql, conn); //创建SqlDataAdapter类的对象											

				//———————————————————— 【查询】

				DataSet ds = new DataSet();  //创建DataSet类的对象						 
				sda.Fill(ds);                //使用SQLDataAdapter对象sda将查询结果填充到DataTable对象ds中

				frm2.listBox2.DataSource = ds.Tables[0];     // 设置ListBox控件的数据源（DataSource）属性								 
				frm2.listBox2.DisplayMember = ds.Tables[0].Columns[2].ToString();  // 在listBox控件中显示name列的值
				
				MySqlCommandBuilder cmdBuilder = new MySqlCommandBuilder(sda);     //创建SqlCommandBuilder类的对象

				//———————————————————— 【新增】

				DataRow dr = ds.Tables[0].NewRow();
				//dr["runoob_title"] = frm2.textBox1.Text;
				//dr["runoob_author"] = frm2.textBox1.Text;

				//dr["runoob_title"] = "经典原味薯片";
				//dr["runoob_author"] = "乐事";

				//ds.Tables[0].Rows.Add(dr); // 向DataTable对象中添加一行

				//sda.Update(ds);            // 更新数据库
				//MessageBox.Show("设置成功！");

				//———————————————————— 【修改】

				DataRow dr1 = ds.Tables[0].Rows[5];
				dr1["runoob_author"] = "哇哈哈哈";

				((DataRow)ds.Tables[0].Rows[5])["runoob_author"] = "哇挖下下";
				((DataRow)ds.Tables[0].Rows[5])[2] = "哇挖虾虾";
				ds.Tables[0].Rows[5][2] = "哇挖鱼鱼";
				sda.Update(ds);                 //更新数据库
				ds.Tables[0].AcceptChanges();   //更新DataSet对象中的数据
				MessageBox.Show("修改成功！");

				Console.WriteLine("行数" + ds.Tables[0].Rows.Count.ToString());
				Console.WriteLine("列数"+ds.Tables[0].Columns.Count.ToString());
				int i = 0;
				foreach (DataColumn column in ds.Tables[0].Columns)
				{
					Console.WriteLine("第{0}列名称是："+column.ColumnName,i++);
				}

				//———————————————————— 【删除】
				//ds.Tables[0].Rows[5].Delete();    // 删除 DataTable 中的指定行，ds代表DataSet对象		
				//sda.Update(ds);                   // 更新数据库，sda代表SqlDataAdapter对象				
				//ds.Tables[0].AcceptChanges();     // 更新DataSet对象中的数据

			}
			catch (Exception ex)
			{
				MessageBox.Show("注册失败！" + ex.Message);
			}
			finally
			{
				if (conn != null)
				{
					conn.Close();
					MessageBox.Show("已关闭数据库连接");
				}
			}

		}

			//——————————————————————————————————————

			public void SubMySQL_DataAdapter_DataTable()

		{
			string connStr = "server=127.0.0.1;port=3306;user=root;password=whhxpp; database=runoob;";
			MySqlConnection conn = null;
			try
			{
				conn = new MySqlConnection(connStr);
				conn.Open();
				string sql = "select * from runoob_tbl";
				MySqlDataAdapter sda = new MySqlDataAdapter(sql, conn);  // 创建 SQLDataAdapter 类的对象

				DataTable dt = new DataTable();   // 创建DataSet类的对象——using System.Data;								  
				sda.Fill(dt);                     // 使用SQLDataAdapter对象sda将查询结果填充到Dataset对象ds中

				frm2.listBox2.DataSource = dt;    // 设置ListBox控件的数据源（DataSource）属性								 
				frm2.listBox2.DisplayMember = dt.Columns[2].ToString();  // 在listBox控件中显示name列的值
			}
			catch (Exception ex)
			{
				MessageBox.Show("查询失败！" + ex.Message);
			}
			finally
			{
				if (conn != null)
				{
					conn.Close();
					MessageBox.Show("已关闭数据库连接");
				}
			}

		}



	}

	//————————————————————————— 8 【  DataRow和DataColumn：更新数据表 】MySql.Data.MySqlClient
	//在前面《C# Command》一节中已经介绍了使用 SqlCommand 对象中的 ExecuteNonQuery 方法执行非查询 SQL 语句来实现对数据表的更新操作，使用 DataSet 对象也能实现相同的功能， 并且能节省数据访问时间。

	//每个 DataSet 都是由多个 DataTable 构成的，更新 DataSet 中的数据实际上是通过更新 DataTable 来实现的。

	//每个 DataTable 对象都是由行(DataRow) 和列(DataColumn) 构成的，下面分别介绍 DataRow 类和 DataColumn 类的使用。
	//1) DataRow 类
	//DataRow 类代表数据表中的行，并允许通过该类直接对数据表进行添加、修改、删除行的操作。

	//DataRow 类中常用的属性和方法如下表所示。

	//属性或方法 说明
	//Table 属性，设置 DataRow 对象所创建 DataTable 的名称
	//RowState    属性，获取当前行的状态
	//HasErrors   属性，获取当前行是否存在错误
	//AcceptChanges() 方法，更新 DataTable 中的值
	//RejectChanges() 方法，撤销对 DataTable 中的值的更新
	//Delete()    方法，标记当前的行被删除，并在执行 AcceptChanges 方法后更新数据表
	//在 DataRow 类中没有提供构造方法，需要通过 DataTable 中的 NewRow 方法创建 DataRow 类的对象，具体的语句如下。
	//DataTable dt = new DataTable();
	//	DataRow dr = dt.NewRow();
	//	这样，dr 即为新添加的行，每行数据是由多列构成的，如果在 DataTable 对象中已经存在表结构，则直接使用dr[编号或列名]= 值的形式即可为表中的列赋值。
	//2) DataColumn 类
	//DataColumn 类是数据表中的列对象，与数据库中表的列定义一样，都可以为其设置列名以及数据类型。

	//DataColumn类中常用的构造方法如下表所示。

	//构造方法 说明
	//DataColumn()    无参构造方法
	//DataColumn(string columnName)   带参数的构造方法，columnName 参数代表的是列名
	//DataColumn(string columnName, Type dataType) 带参数的构造方法，columnName 参数代表的是列名，dataType 参数代表的是列的数据类型
	//DataColumn 类提供了一些属性对 DataColumn 对象进行设置，常用的属性如下表所示。

	//属性 说明
	//ColumnName 属性，设置 DataColumn 对象的列名
	//DataType    属性，设置 DataColumn 对象的数据类型
	//MaxLength   属性，设置 DataColumn 对象值的最大长度
	//Caption 属性，设置 DataColumn 对象在显示时的列名，类似于给表中的列设置别名
	//DefaultValue    属性，设置 DataColumn 对象的默认值
	//AutoIncrement   属性，设置 DataColumn 对象为自动增长列，与 SQL Server 中数据表的标识列类似
	//AutoIncrementSeed 属性，与 AutoIncrement 属性联用,用于设置自动增长列的初始值
	//AutoIncrementStep   属性，与 AutoIncrement 属性联用，用于设置自动增长列每次增加的值
	//Unique  属性，设置 DataColumn 对象的值是唯一的，类似于数据表的唯一约束
	//AllowDBNull 属性，设置 DataColumn 对象的值是否允许为空

	public  class DataRowColumn
	{
		Form2 frm2;

		public DataRowColumn(Form2 f)
		{
			frm2 = f;
		}

		private DataTable dt = new DataTable("major");   //创建DataTable类的对象其表明为major
														 //在构造方法中初始化DataTable对象，设置DataTable 中的列
		public  void DataColumn_Create()
		{
			
			DataColumn id = new DataColumn("id", typeof(int));         //创建专业编号列，列明为id 、数据类型为整型
			id.AutoIncrement = true;    //设置id为自动增长的列					  
			id.AutoIncrementSeed = 1;   //设置id的初始值							
			id.AutoIncrementStep = 1;   //设置id每次增长的值					  
			dt.Columns.Add(id);         //将id列加入到DataTable中				  

			DataColumn name = new DataColumn("name", typeof(string));  //创建专业名称列，列明为name，数据类型为字符串类型													   
			name.Unique = true;         //设置name列的值是唯一的					  
			dt.Columns.Add(name);       //将name列加入到DataTable 对象中

		}

		public  void DataRow_Create()
		{
			
			DataRow dr = dt.NewRow();                 //向DataTable中天加一行，创建DataRow对象							
			dr["name"] = frm2.textBox1.Text;          //添加专业名称列的值							  
			dt.Rows.Add(dr);                          //将DataRow添加到DataTable对象中							 
			frm2.listBox2.DataSource = dt;            //设置ListBox控件中的DataSource属性						  
			frm2.listBox2.DisplayMember = dt.Columns["name"].ToString();  //设置在listBox控件中显示的列
		}

		public void DataTable_Create()
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

			Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", dt.Columns[0], dt.Columns[1], dt.Columns[2], dt.Columns[3]);

			foreach (DataRow dr in dt.Rows)
			{
				Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", dr[0], dr[1], dr[2], dr[3]);
			}

		}


		//————————————————————————— 9 【ComboBox：组合框控件数据绑定】Mysql
		public void SubMysql_ComboBox()
		{
			string connStr = "server=127.0.0.1;port=3306;user=root;password=whhxpp; database=runoob;";
			MySqlConnection conn = null;
			try
			{
				conn = new MySqlConnection(connStr);
				conn.Open();
				string sql = "select * from runoob_tbl";
	
				MySqlDataAdapter sda = new MySqlDataAdapter(sql, conn);
				DataSet ds = new DataSet();
				sda.Fill(ds);

				frm2.comboBox1.DataSource = ds.Tables[0];
				frm2.comboBox1.DisplayMember = "runoob_title";
				frm2.comboBox1.ValueMember = "runoob_author";
			}
			catch (Exception ex)
			{
				MessageBox.Show("出现错误！" + ex.Message);
			}
			finally
			{
				if (conn != null)
				{
					conn.Close();
					MessageBox.Show("已关闭数据库连接");
				}
			}
		}
		//————————————————————————— 10 【DataGridView：数据表格控件数据绑定】Mysql
		public void SubMysql_DataGridView()
		{
			string connStr = "server=127.0.0.1;port=3306;user=root;password=whhxpp; database=runoob;";
			MySqlConnection conn = null;
			try
			{
				conn = new MySqlConnection(connStr);

				conn.Open();
				string sql = "select * from runoob_tbl";

				MySqlDataAdapter sda = new MySqlDataAdapter(sql, conn);

				DataSet ds = new DataSet();

				sda.Fill(ds);
				
				frm2.dataGridView1.DataSource = ds.Tables[0];  //设置表格控件的DataSource属性
				
				// —————————————— 如果需要更改 DataGridView 控件的列标题，则需要在上面的代码中加入以下代码
															   
				frm2.dataGridView1.Columns[0].HeaderText = "编号";     //设置第 1 列的列标题

				frm2.dataGridView1.Columns[1].HeaderText = "专业名称"; //设置第2列的列标题


			}
			catch (Exception ex)
			{
				MessageBox.Show("出现错误！" + ex.Message);
			}
			finally
			{
				if (conn != null)
				{
					conn.Close();
					MessageBox.Show("已关闭数据库连接");
				}
			}
			//————————————————————————— 11 【C# 数据表格（DataGridView）控件的应用案例】





		}



	}








}
