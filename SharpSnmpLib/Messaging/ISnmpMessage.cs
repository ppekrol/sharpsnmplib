// SNMP message interface.
// Copyright (C) 2008-2010 Malcolm Crowe, Lex Li, and other contributors.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2008/5/1
 * Time: 11:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Lextm.SharpSnmpLib.Security;
using System;

namespace Lextm.SharpSnmpLib.Messaging
{
    /// <summary>
    /// SNMP message.
    /// </summary>
    public interface ISnmpMessage : IDisposable
    {
        /// <summary>
        /// Gets the header.
        /// </summary>
        Header Header { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        SecurityParameters Parameters { get; }

        /// <summary>
        /// Gets the scope.
        /// </summary>
        /// <value>The scope.</value>
        Scope Scope { get; }
        
        /// <summary>
        /// Converts to the bytes.
        /// </summary>
        /// <returns></returns>
        byte[] ToBytes();

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        VersionCode Version { get; }

        /// <summary>
        /// Gets the privacy provider.
        /// </summary>
        /// <value>The privacy provider.</value>
        IPrivacyProvider Privacy { get; }
    }
}
