using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloomFilter
{
	public class BulkEmailGenerator
	{
        public static List<string> GenerateRandomEmailList(int count)
		{
			List<string> emailList = new List<string>();

			Random random = new Random();

			for (int i = 0; i < count; i++)
			{
				string username = GenerateRandomString(random, 8);  // Generate random username
				string domain = "fakemail.net";  
				string email = $"{username}@{domain}";
				emailList.Add(email);
			}

			return emailList;
		}

		public static string GenerateRandomString(Random random, int length)
		{
			const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
			char[] stringChars = new char[length];

			for (int i = 0; i < length; i++)
			{
				stringChars[i] = chars[random.Next(chars.Length)];
			}

			return new string(stringChars);
		}
	}
}
