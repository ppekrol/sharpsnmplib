using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;

namespace Lextm.SharpSnmpLib
{
    public static class Pools
    {
        private static readonly ObjectPool<List<byte>> ByteListPool = new DefaultObjectPool<List<byte>>(new DefaultPooledObjectPolicy<List<byte>>());

        public static List<byte> GetByteList()
        {
            return ByteListPool.Get();
        }

        public static void ReturnByteList(List<byte> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            list.Clear();

            ByteListPool.Return(list);
        }
    }
}
