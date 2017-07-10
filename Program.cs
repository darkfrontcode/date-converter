using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateConverter
{
	class Program
	{
		static void Main(string[] args)
		{
			string date1 = new DateConverter().ChangeDate("01/03/2010 23:00", '+', 4000);
			string date2 = new DateConverter().ChangeDate("01/03/2010 00:40", '-', 70);
			string date3 = new DateConverter().ChangeDate("01/03/2010 23:00", '-', 30);
			string date4 = new DateConverter().ChangeDate("26/02/2010 23:00", '+', 4020);
			string date5 = new DateConverter().ChangeDate("26/02/2010 23:00", '+', 4020);
			string date6 = new DateConverter().ChangeDate("01/03/2010 01:20", '-', 100);

			Console.WriteLine(date1);
			Console.WriteLine(date2);
			Console.WriteLine(date3);
			Console.WriteLine(date4);
			Console.WriteLine(date5);
			Console.WriteLine(date6);
		}
	}
}
