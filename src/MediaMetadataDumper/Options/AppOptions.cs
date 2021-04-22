namespace MediaMetadataDumper.Options
{
    public class AppOptions
    {
        public string Directory { get; set; }
        public string FilePattern { get; set; }
        public FFProbeOptions FFProbe { get; set; }
    }
}
