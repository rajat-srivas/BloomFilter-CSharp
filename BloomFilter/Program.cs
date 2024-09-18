namespace BloomFilter
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Generating bulk Email Address..." + Environment.NewLine);
			var emails = BulkEmailGenerator.GenerateRandomEmailList(1000);

			Console.WriteLine("Adding Emails to the Bloom Filter..." + Environment.NewLine);


			var existingEmail = emails[100];
			
			Bloom filter = new Bloom(300000);
			emails.ForEach(x => filter.Add(x));

			Console.WriteLine("Bloom Filter Created..." + Environment.NewLine);


			Console.WriteLine("Checking existence of stackup@outlook.com" + Environment.NewLine);
			var result = filter.MightContain("stackup@outlook.com");


			Console.WriteLine(result ? "stackup@outlook.coms might Exist.." : "stackup@outlook.com for sure doesnt exist" + Environment.NewLine);


			Console.WriteLine("Checking existence of " + existingEmail + Environment.NewLine);
			var yesResult = filter.MightContain(existingEmail);

			Console.WriteLine(yesResult ? existingEmail + " might Exist.." : existingEmail + " for sure doesnt exist");

			Console.ReadLine();

		}
	}
}
