using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lextm.SharpSnmpLib
{
    public static class Pools
    {
        private static readonly ObjectPool<List<byte>> ByteListPool = new DefaultObjectPool<List<byte>>(new DefaultPooledObjectPolicy<List<byte>>());

        public static List<byte> GetByteList()
        {
            var list = ByteListPool.Get();

            Debug.Assert(list.Count == 0);

            return list;
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
