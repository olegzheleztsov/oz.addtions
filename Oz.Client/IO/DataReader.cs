using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Oz.Client.IO
{
    public class DataReader
    {
        public async Task<IEnumerable<(double a, double b)>> ReadDoublePairsAsync(string fileName)
        {
            await using var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None,
                4096, FileOptions.Asynchronous);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8);

            var result = new List<(double, double)>();

            while (true)
            {
                var line = await streamReader.ReadLineAsync().ConfigureAwait(false);
                if (string.IsNullOrEmpty(line)) break;

                var tokens = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length != 2) throw new FormatException($"Invalid line: {line}");

                if (!double.TryParse(tokens[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var num))
                    throw new FormatException($"Invalid number: {num}");

                if (!double.TryParse(tokens[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var num2))
                    throw new FormatException($"Invalid number {num2}");
                result.Add((num, num2));
            }

            return result;
        }
    }
}