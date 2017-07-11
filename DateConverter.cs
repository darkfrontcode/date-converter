namespace DateConverter
{
	class DateConverter
	{
		int day, month, year, hour, minute;
		int[] calendar = new int[]{31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

		public delegate void Operation(long value);
		Operation Apply;

		public string ChangeDate(String date, char op, long value)
		{
			ValidOperator(op);
			Unmount(date);
			ConfigOperation(op);
			Apply(Math.Abs(value));
			return Mount();
		}

		#region actions

		public void ValidOperator(char op)
		{
			if (op != '-' && op != '+') throw new Exception("Available operators: + | -");
		}

		public void Unmount(string date)
		{
			day		= int.Parse(date.Substring(0, 2));
			month	= int.Parse(date.Substring(3, 2));
			year	= int.Parse(date.Substring(6, 4));
			hour	= int.Parse(date.Substring(11, 2));
			minute	= int.Parse(date.Substring(14, 2));
		}

		public void ConfigOperation(char op)
		{
			Apply = op == '+' ? new Operation((long value) => Increase(value)) : new Operation((long value) => Decrease(value));
		}

		public void Increase(long value)
		{
			for (int i = 1; i <= value; i++) sumMinute();
		}

		public void Decrease(long value)
		{
			for (int i = 1; i <= value; i++) subMinute();
		}

		public string Mount()
		{
			string mDay 	= day.ToString("00");
			string mMounth 	= month.ToString("00");
			string mHour 	= hour.ToString("00");
			string mMinute 	= minute.ToString("00");

			return $"{mDay}/{mMounth}/{year} {mHour}:{mMinute}";
		}

		#endregion

		#region Operation SUM

		public void sumYear()
		{
			++year;
		}

		public void sumMonth()
		{
			if (month == 12)
			{
				month = 1;
				sumYear();
			}
			else
			{
				++month;
			}
		}

		public void sumDay()
		{
			if (calendar[month] == day)
			{
				day = 1;
				sumMonth();
			}
			else
			{
				++day;
			}
		}

		public void sumHour()
		{
			if (hour == 23)
			{
				hour = 0;
				sumDay();
			}
			else
			{
				++hour;
			}
		}

		public void sumMinute()
		{
			if (minute == 59)
			{
				minute = 00;
				sumHour();
			}
			else
			{
				++minute;
			}
		}
		#endregion

		#region Operation SUB
		public void subYear()
		{
			--year;
		}

		public void subMonth()
		{
			if (month == 1)
			{
				month = 12;
				subYear();
			}
			else
			{
				--month;
			}
		}

		public void subDay()
		{
			if (day == 1)
			{
				day = calendar[month];
				subMonth();
			}
			else
			{
				--day;
			}
		}

		public void subHour()
		{
			if (hour == 0)
			{
				hour = 23;
				subDay();
			}
			else
			{
				--hour;
			}
		}

		public void subMinute()
		{
			if (minute == 00)
			{
				minute = 59;
				subHour();
			} 
			else
			{
				--minute;
			}
		}

		#endregion

	}
}