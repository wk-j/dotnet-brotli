#! "netcoreapp2.0"
#r "nuget:NetStandard.Library,2.0"
#r "nuget:System.IO.Compression.Brotli,0.1.0-e180119-3"

using System.IO.Compression;

var source = "README.md";
using (var input = File.OpenRead(source))
using (var output = File.Create("scripts/files/output.md"))
using (var compressor = new BrotliStream(output, CompressionMode.Compress))
{
    input.CopyTo(compressor);
}