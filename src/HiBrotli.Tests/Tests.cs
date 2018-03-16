using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Xunit;

namespace HiBrotli.Tests {
    public class CompressionTests {
        void BrotliCompress(string inputFileName, string outputFileName) {
            using (FileStream input = File.OpenRead(inputFileName))
            using (FileStream output = File.Create(outputFileName))
            using (BrotliStream compressor = new BrotliStream(output, CompressionMode.Compress)) {
                input.CopyTo(compressor);
            }
        }

        void GzipCompress(string inputFileName, string outputFileName) {
            using (var input = File.OpenRead(inputFileName))
            using (var output = File.Create(outputFileName))
            using (var compressor = new GZipStream(output, CompressionMode.Compress)) {
                input.CopyTo(compressor);
            }
        }


        [Fact]
        public void CompressTest() {
            var sourceDir = "/Users/wk/Source/DotNetBrotli/resources/inputs";
            var files = new DirectoryInfo(sourceDir).GetFiles().Select(x => x.FullName);

            foreach (var file in files) {
                BrotliCompress(file, file.Replace("inputs", "brotli"));
                GzipCompress(file, file.Replace("inputs", "gzip"));
            }
        }
    }
}
