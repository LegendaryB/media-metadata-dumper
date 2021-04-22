using System.Diagnostics;

namespace MediaMetadataDumper
{
    internal static class FFProbeWrapper
    {
        private static string _executablePath;

        internal static void Configure(
            string executablePath)
        {
            _executablePath = executablePath;
        }

        internal static string ExecuteCommand(
            string command)
        {
            string output;

            var process = CreateProcess(command);            

            process.Start();
            output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }

        private static Process CreateProcess(string arguments)
        {
            var configuration = new ProcessStartInfo
            {
                FileName = _executablePath,
                Arguments = arguments,
                CreateNoWindow = true,
                RedirectStandardOutput = true
            };

            return new Process
            {
                StartInfo = configuration,
                EnableRaisingEvents = true
            };
        }
    }
}
