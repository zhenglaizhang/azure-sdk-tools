﻿using Azure.Sdk.Tools.TestProxy.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Sdk.Tools.TestProxy.Tests
{
    public static class TestHelpers
    {
        public static Stream GenerateStreamRequestBody(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static ModifiableRecordSession LoadRecordSession(string path)
        {
            using var stream = System.IO.File.OpenRead(path);
            using var doc = JsonDocument.Parse(stream);

            return new ModifiableRecordSession(RecordSession.Deserialize(doc.RootElement));
        }

        public static byte[] GenerateByteRequestBody(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }
    }
}
