﻿/*
Snap v1.0

Copyright (c) 2010 Tyler Brinks

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
using System.Collections.Generic;
using LinFu.IoC.Configuration;
using Snap.Tests.Interceptors;

namespace SnapTests.Fakes
{
    public interface IOrderedCode
    {
        void RunInOrder();
        void RunInExplicitOrder();
        void RunInAttributedOrder();
        void RunWithoutClassInterceptor();
        void StopWithoutInterceptor();
    }

    [Implements(typeof(IOrderedCode))]  // Attribute for LinFu configuration
    [FourthClass(IncludePattern="Run.*", ExcludePattern=".*WithoutClass.*")]
    public class OrderedCode : IOrderedCode
    {
        public static List<string> Actions = new List<string>();
   
        [First]
        [Second]
        public void RunInOrder()
        {

        }

        [First]
        [Second]
        [Third]
        public void RunInExplicitOrder()
        {
        }

        [First(Order = 1)]
        [Second(Order = 2)]
        [Third(Order = 0)]
        public void RunInAttributedOrder()
        {
        }

        [First]
        public void RunWithoutClassInterceptor()
        {
        }

        public void StopWithoutInterceptor()
        {
        }
    }

    [Implements(typeof(IOrderedCode))]  // Attribute for LinFu configuration
    [FourthClass(IncludePattern = "Run.*", ExcludePattern = ".*WithoutClass.*", Order=3)]
    public class ClassOrderedCode : IOrderedCode
    {
        public static List<string> Actions = new List<string>();

        [First]
        [Second]
        public void RunInOrder()
        {

        }

        [First]
        [Second]
        [Third]
        public void RunInExplicitOrder()
        {
        }

        [First(Order = 1)]
        [Second(Order = 2)]
        [Third(Order = 0)]
        public void RunInAttributedOrder()
        {
        }

        [First]
        public void RunWithoutClassInterceptor()
        {
        }

        public void StopWithoutInterceptor()
        {
        }
    }
}
