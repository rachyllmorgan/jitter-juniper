using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jitter.Models;

namespace Jitter.Tests.Models
{
    [TestClass]
    public class JotTests
    {
        [TestMethod]
        public void JotEnsureICanCreateInstance()
        {
            Jot a_jot = new Jot();
            Assert.IsNotNull(a_jot);
        }
        [TestMethod]
        public void JotEnsureJotHasAllTheThings()
        {
            //Arrange -set up
            Jot a_jot = new Jot();

            //Act - call method
            DateTime expected_time = DateTime.Now; 
            a_jot.JotId = 1;
            a_jot.Content = "My Content";
            a_jot.Date = expected_time;
            a_jot.Author = null;
            a_jot.Picture = "https://google.com";

            //Assert - call asserts
            Assert.AreEqual(1, a_jot.JotId);
            Assert.AreEqual("My Content", a_jot.Content);
            Assert.AreEqual(expected_time, a_jot.Date);
            Assert.AreEqual(null, a_jot.Author);
            Assert.AreEqual("https://google.com", a_jot.Picture);
        }
        [TestMethod]
        public void JotEnsureICanUseObjectInitializerSyntax()
        {
            //Arrange -set up
            DateTime expected_time = DateTime.Now;

            //Act - call method
            Jot a_jot = new Jot { JotId = 1, Content = "My Content", Date = expected_time, Author = null, Picture = "https://google.com" };
            //Assert - call asserts
            Assert.AreEqual(1, a_jot.JotId);
            Assert.AreEqual("My Content", a_jot.Content);
            Assert.AreEqual(expected_time, a_jot.Date);
            Assert.AreEqual(null, a_jot.Author);
            Assert.AreEqual("https://google.com", a_jot.Picture);
        }
    }
}
