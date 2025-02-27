/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2008/5/1
 * Time: 11:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using Xunit;

#pragma warning disable 1591
namespace Lextm.SharpSnmpLib.Unit
{
    public class SequenceTestFixture
    {
        [Fact]
        public void TestException()
        {
            Assert.Throws<ArgumentNullException>(() => new Sequence((byte[])null, (ISnmpData[])null));
            Assert.Throws<ArgumentNullException>(() => new Sequence((IEnumerable<ISnmpData>) null));
            Assert.Throws<ArgumentNullException>(() => new Sequence(new Tuple<int, byte[]>(0, new byte[] { 0 }), null));
        }

        [Fact]
        public void TestToBytes()
        {
            List<Variable> vList = new List<Variable>
                                       {
                                           new Variable(
                                               new ObjectIdentifier(new uint[] {1, 3, 6, 1, 4, 1, 2162, 1001, 21, 0}),
                                               new OctetString("TrapTest"))
                                       };

            Sequence a = Variable.Transform(vList);
            Assert.Throws<ArgumentNullException>(() => a.AppendBytesTo(null));
            Assert.Equal("SNMP SEQUENCE: SNMP SEQUENCE: 1.3.6.1.4.1.2162.1001.21.0; TrapTest; ; ", a.ToString());
            byte[] bytes = a.ToBytes();
            ISnmpData data = DataFactory.CreateSnmpData(bytes);
            Assert.Equal(SnmpType.Sequence, data.TypeCode);
            Sequence array = (Sequence)data;
            Assert.Equal(1, array.Length);
            ISnmpData item = array[0];
            Assert.Equal(SnmpType.Sequence, item.TypeCode);
            Sequence v = (Sequence)item;
            Assert.Equal(2, v.Length);
            Assert.Equal(SnmpType.ObjectIdentifier, v[0].TypeCode);
            ObjectIdentifier o = (ObjectIdentifier)v[0];
            Assert.Equal(new uint[] {1,3,6,1,4,1,2162,1001,21,0}, o.ToNumerical());
            Assert.Equal(SnmpType.OctetString, v[1].TypeCode);
            Assert.Equal("TrapTest", v[1].ToString());
        }
    }
}
#pragma warning restore 1591

