using System;
using System.Collections.Generic;
using System.IO;

namespace MediaMetadataDumper
{
    internal static class FileEnumerator
    {
        private static Lazy<EnumerationOptions> _enumerationOptions =
            new Lazy<EnumerationOptions>(() =>
            {
                var options = new EnumerationOptions();
                options.RecurseSubdirectories = true;

                return options;
            });

        internal static IEnumerable<string> EnumerateFiles(
            string directory,
            string filePattern)
        {
            var matchingFiles = Directory.EnumerateFiles(
                directory,
                filePattern,
                _enumerationOptions.Value);

            return matchingFiles;
        }
    }
}
