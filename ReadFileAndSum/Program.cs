using ReadFileAndSum;
using static System.Int32;

var padLock = new object();

using var reader = new StreamReader(Constants.LargeNumbers);
var line = string.Empty;
while ((line = reader.ReadLine()) is not null)
{
    var values = line.Split(',');
    var sum = 0;

    Parallel.ForEach(values, value =>
    {
        lock (padLock)
        {
            _ = TryParse(value, out var number);
            sum += number;
        }
    });

    Console.WriteLine("Sum of the numbers in a file");
    Console.WriteLine(sum);
}