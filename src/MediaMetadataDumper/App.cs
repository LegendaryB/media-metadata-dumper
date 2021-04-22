using MediaMetadataDumper.Options;

using Microsoft.Extensions.Logging;

using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MediaMetadataDumper
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly AppOptions _options;

        public App(
            ILogger<App> logger,
            AppOptions options)
        {
            _logger = logger;
            _options = options;
        }

        public Task RunAsync()
        {
            _logger.LogInformation("Starting job run...");

            var matchingFiles = FileEnumerator.EnumerateFiles(
                _options.Directory,
                _options.FilePattern);

            _logger.LogDebug($"Found {matchingFiles.Count()} files which match the pattern: {null}");

            FFProbeWrapper.Configure(_options.FFProbe.Path);

            _logger.LogDebug($"Set ffprobe path to: '{_options.FFProbe.Path}'");

            Parallel.ForEach(matchingFiles, file =>
            {
                _logger.LogDebug($"Dumping info with ffprobe for file: '{file}'");

                var command = CreateCommand(file);

                var output = FFProbeWrapper.ExecuteCommand(command);

                File.WriteAllText(
                    $"{file}.json",
                    output);

                _logger.LogInformation($"Saved ffprobe output to: '{$"{file}.json"}'");
            });

            _logger.LogInformation("Finished job run");

            return Task.CompletedTask;
        }

        private string CreateCommand(string path)
        {
            return $"{_options.FFProbe.Command} \"{path}\"";
        }
    }
}
