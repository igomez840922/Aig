namespace Aig.Farmacoterapia.Admin.Extensions
{
    public class UploadChunk
    {
        public string FileName { get; set; } = string.Empty;
        public string UniqueFileName { get; set; } = string.Empty;
        public int FileSizeInBytes { get; set; } = 0;
        public int ChunkSizeInKB { get; set; } = 0;
        public double MegaBytesPerSeconds { get; set; } = 0;
        public string Duration { get; set; } = string.Empty;

        public double FileSizeInMB
        {
            get
            {
                return FileSizeInBytes / (1024F * 1024F);
            }
        }

        public double CalculateMegabytesPerSeconds(double seconds)
        {
            double MBs = FileSizeInMB;
            return MBs / seconds;
        }
    }
}
