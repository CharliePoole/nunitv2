// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections;
using System.Text;
using NUnit.Framework;

namespace NUnit.TestData
{
    [TestFixture]
    public class UnhandledExceptions
    {
        #region Normal
        [NUnit.Framework.Test]
        public void Normal()
        {
            throw new ApplicationException("Test exception");
        }
        #endregion Normal

        #region Threaded
        [NUnit.Framework.Test]
        public void Threaded()
        {
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(Normal));
            thread.Start();
            System.Threading.Thread.Sleep(100);
        }
        #endregion Threaded

        #region ThreadedAndForget
        [NUnit.Framework.Test]
        public void ThreadedAndForget()
        {
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(Normal));
            thread.Start();
        }
        #endregion ThreadedAndForget

        #region ThreadedAndWait
        [NUnit.Framework.Test]
        public void ThreadedAndWait()
        {
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(Normal));
            thread.Start();
            thread.Join();
        }
        #endregion ThreadedAndWait

        #region ThreadedAssert
        [Test]
        public void ThreadedAssert()
        {
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadedAssertProc));
            thread.Start();
            thread.Join();
        }

        private void ThreadedAssertProc()
        {
            Assert.AreEqual(5, 2 + 2);
        }
        #endregion
    }
}
