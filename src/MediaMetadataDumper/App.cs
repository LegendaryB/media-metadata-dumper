using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

namespace MediaMetadataDumper
{
    public class App
    {
        private readonly ILogger<App> _log;

        public App(ILogger<App> logger)
        {
            _log = logger;
        }

        public async Task RunAsync()
        {
            try
            {
                _log.LogDebug("ENTER");

            }
            finally
            {
                _log.LogDebug("LEAVE");
            }
        }
    }
}
