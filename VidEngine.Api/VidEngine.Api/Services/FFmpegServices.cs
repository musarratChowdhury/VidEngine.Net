using System.Diagnostics;
using System.Text;

namespace VidEngine.Api.Services;

public class FFmpegServices
{
    private readonly string _ffmpegPath;

    public FFmpegServices(string ffmpegPath)
    {
        _ffmpegPath = ffmpegPath;
    }

    private async Task<string> RunCommand(string arguments)
    {
        var process = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                FileName = _ffmpegPath,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };
        
        var outputBuilder = new StringBuilder();
        var errorBuilder = new StringBuilder();

        process.OutputDataReceived += (s, e) => outputBuilder.AppendLine(e.Data);
        process.ErrorDataReceived += (s, e) => errorBuilder.AppendLine(e.Data);

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        await process.WaitForExitAsync();

        var errorOutput = errorBuilder.ToString();
        if (!string.IsNullOrWhiteSpace(errorOutput))
        {
            Console.WriteLine("FFmpeg Error: " + errorOutput);
        }

        return outputBuilder.ToString();
    }
}