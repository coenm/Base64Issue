using System;
using System.Buffers;
using Xunit;
using Xunit.Abstractions;

namespace Base64Difference
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            var source = Span<byte>.Empty;
            const bool finalBlock = false;

            var status = System.Buffers.Text.Base64.EncodeToUtf8(source, new byte[42], out _, out _, finalBlock);

            output.WriteLine($"Returned status: {status}");

            // netcore 2.0
            Assert.Equal(OperationStatus.NeedMoreData, status);

            // // netcore 3.0
            // Assert.Equal(OperationStatus.Done, status);
        }
    }
}
