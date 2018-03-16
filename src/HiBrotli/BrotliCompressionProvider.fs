namespace HiBrotli

open System.IO.Compression
open Microsoft.AspNetCore.ResponseCompression

type  BrotliCompressionProvider() =
    interface ICompressionProvider with
        member __.EncodingName = "br"
        member __.SupportsFlush = true
        member __.CreateStream outputStream =
            printfn "🚚  compress"
            let stream = new BrotliStream(outputStream, CompressionMode.Compress)
            upcast stream