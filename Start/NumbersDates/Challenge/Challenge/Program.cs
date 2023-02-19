using System;
using System.Text;

DateTime today = DateTime.Today;
string input;

while (true)
{
	Console.WriteLine("please enter a date:");
	input = Console.ReadLine();
	DateTime enteredDate;
	StringBuilder sb = new StringBuilder("THe date is ");

	if (DateTime.TryParse(input, out enteredDate)){
		TimeSpan interval = enteredDate > today ? enteredDate - today : today - enteredDate;
		sb.Append(interval.Days);
		if (enteredDate > today){ sb.Append(" days in the future"); }
		else if (enteredDate.Date == today.Date) { Console.WriteLine("The date is today!"); continue; }
		else{ sb.Append(" days past the entered date"); }
		Console.WriteLine(sb.ToString());
	} else if (input.Trim().Equals("exit")) { break;}
	else { Console.WriteLine("This is not a valid date."); }
}