#r "../packages/System.IO.Compression.Brotli/lib/netstandard1.1/System.IO.Compression.Brotli.dll"
#r "../packages/System.IO.Compression/ref/netstandard1.1/System.IO.Compression.dll"


open System.IO.Compression
open System.IO

let source = "README.md"
let input = File.OpenRead(source)
let output = File.Create("scripts/files/output.md")
let compressor = new BrotliStream(output, CompressionMode.Compress)
input.CopyTo(compressor)