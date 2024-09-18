using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BloomFilter
{
	public class Bloom
	{
		private bool[] bitArray;
		private int size;

		private readonly Func<byte[], int>[] hashFunctions;


		public Bloom(int size)
		{
			this.size = size;
			this.bitArray = new bool[size];

			hashFunctions = new Func<byte[], int>[]
			{
			data => GetMd5Hash(data),
			data => GetSha1Hash(data),
			data => GetSha256Hash(data)
			};
		}

		public void Add(string item)
		{
			byte[] itemData = Encoding.UTF8.GetBytes(item);  // Convert the string to a byte array

			foreach (var func in hashFunctions)
			{
				int hash = func(itemData);
				bitArray[hash % size] = true;
			}
			
		}

		private static int GetMd5Hash(byte[] data)
		{
			using (var md5 = MD5.Create())
			{
				byte[] hashBytes = md5.ComputeHash(data);
				return Math.Abs(BitConverter.ToInt32(hashBytes, 0));  
			}
		}
		private static int GetSha1Hash(byte[] data)
		{
			using (var sha1 = SHA1.Create())
			{
				byte[] hashBytes = sha1.ComputeHash(data);
				return Math.Abs(BitConverter.ToInt32(hashBytes, 0));  
			}
		}

		private static int GetSha256Hash(byte[] data)
		{
			using (var sha256 = SHA256.Create())
			{
				byte[] hashBytes = sha256.ComputeHash(data);
				return Math.Abs(BitConverter.ToInt32(hashBytes, 0));  
			}
		}

		public bool MightContain(string item)
		{
			byte[] itemData = Encoding.UTF8.GetBytes(item);

			foreach(var func in hashFunctions) 
			{
				int hash = func(itemData);
				int index = hash % size;
				if (!bitArray[index])
				{
					return false;
				}
			}

			return true;
		}

	}

}

