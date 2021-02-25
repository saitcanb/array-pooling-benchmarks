using BenchmarkDotNet.Attributes;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace ArrayPoolingBencmarkTests
{
    [SimpleJob(launchCount: 3, warmupCount: 10, targetCount: 30)]
    [RPlotExporter]
    [MemoryDiagnoser]
    public class ArrayPoolingBenchmarks
    {
        private ArrayPool<string> StringPool = ArrayPool<string>.Shared;
        private ArrayPool<Customer> CustomerPool = ArrayPool<Customer>.Shared;
        private ArrayPool<int> IntPool = ArrayPool<int>.Shared;
        private ArrayPool<byte> BytePool = ArrayPool<byte>.Shared;


        [Params(10, 100, 1000, 10000, 100000)]
        public int N;

        [Benchmark]
        public string[] RentString()
        {
            string[] rented = StringPool.Rent(N);
            StringPool.Return(rented);

            return rented;
        }

        [Benchmark]
        public string[] AllocateString()
        {
            return new string[N];
        }

        [Benchmark]
        public Customer[] RentCustomer()
        {
            Customer[] rented = CustomerPool.Rent(N);
            CustomerPool.Return(rented);

            return rented;
        }

        [Benchmark]
        public Customer[] AllocateCustomer()
        {
            return new Customer[N];
        }

        [Benchmark]
        public int[] RentInt()
        {
            int[] rented = IntPool.Rent(N);
            IntPool.Return(rented);

            return rented;
        }

        [Benchmark]
        public int[] AllocateInt()
        {
            return new int[N];
        }

        [Benchmark]
        public byte[] RentByte()
        {
            byte[] rented = BytePool.Rent(N);
            BytePool.Return(rented);

            return rented;
        }

        [Benchmark]
        public byte[] AllocateByte()
        {
            return new byte[N];
        }
    }
}
