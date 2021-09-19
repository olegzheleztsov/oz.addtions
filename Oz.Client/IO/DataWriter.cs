using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oz.Client.IO
{
    public class DataWriter
    {
        public async Task WriteDoublePairsAsync(string fileName, IEnumerable<(double a, double b)> pairs, CancellationToken cancellationToken)
        {
            await using FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None,
                4096, FileOptions.Asynchronous);
            await using StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);

            foreach (var (a, b) in pairs)
            {
                string line = $"{a.ToString(CultureInfo.InvariantCulture)} {b.ToString(CultureInfo.InvariantCulture)}";
                await streamWriter.WriteLineAsync(line.ToArray(), cancellationToken).ConfigureAwait(false);
            }
        }
    }
}