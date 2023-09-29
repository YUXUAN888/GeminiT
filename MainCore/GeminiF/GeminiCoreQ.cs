using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GeminiT.MainCore.GeminiF
{
    internal class GeminiCoreQ
    {
        public static async Task DownloadFilesAsync(IEnumerable<string> urls, string directory, CancellationToken cancellationToken, IProgress<double> progress)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (string url in urls)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    try
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

                        if (response.IsSuccessStatusCode)
                        {
                            string fileName = Path.GetFileName(url);
                            string filePath = Path.Combine(directory, fileName);

                            using (Stream contentStream = await response.Content.ReadAsStreamAsync(),
                                          fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                var buffer = new byte[8192];
                                long totalBytesRead = 0;
                                int bytesRead;

                                while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                                {
                                    cancellationToken.ThrowIfCancellationRequested();
                                    await fileStream.WriteAsync(buffer, 0, bytesRead, cancellationToken);
                                    totalBytesRead += bytesRead;

                                    // Calculate progress and report it
                                    progress.Report((double)totalBytesRead / response.Content.Headers.ContentLength.Value * 100);
                                }
                            }

                            Console.WriteLine($"Downloaded: {fileName}");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to download: {url}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error downloading {url}: {ex.Message}");
                    }
                }
            }
        }
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> ToChunks<T>(this IEnumerable<T> source, int chunkSize)
        {
            while (source.Any())
            {
                yield return source.Take(chunkSize);
                source = source.Skip(chunkSize);
            }
        }
    }
}
