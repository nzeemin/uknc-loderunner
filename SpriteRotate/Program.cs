using System;
using System.Collections.Generic;
using System.Globalization;

namespace SpriteRotate
{
	class Program
	{
		static string ConvertOneNumber(string inputStr)
		{
			int input = Convert.ToInt32(inputStr, 8);
			int output = 0;
			for (int i = 0; i < 8; i++)
			{
				output = output >> 1;
				output |= ((input & 1) << 7);
				output |= ((input & 2) << 14);
				input = input >> 2;
			}
			return Convert.ToString(output, 8);
		}

		static string ConvertOneNumberOld(string inputStr)
		{
			int input = Convert.ToInt32(inputStr, 8);
			int output = 0;
			for (int i = 0; i < 8; i++)
			{
				output |= input & 1;
				output |= ((input & 2) << 7);
				input = input >> 2;
				output = output << 1;
			}
			output = output >> 1;
			return Convert.ToString(output, 8);
		}

		[STAThread]
		static void Main(string[] args)
		{
			while(true)
			{
				string input = System.Console.In.ReadLine();
				string[] inputs = input.Split(',');
				for (int index = 0; index < inputs.Length; index++)
				{
					string inputStr = inputs[index];
					string outputStr = ConvertOneNumber(inputStr);
					while (outputStr.Length < 6)
						outputStr = "0" + outputStr;
					inputs[index] = outputStr;
				}
				string output = string.Join(",", inputs);
				System.Console.Out.WriteLine(output);
				System.Windows.Forms.Clipboard.SetText(output);
			}
		}
	}
}
