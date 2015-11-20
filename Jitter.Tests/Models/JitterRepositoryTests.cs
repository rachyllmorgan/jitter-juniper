using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jitter.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;

namespace Jitter.Tests.Models
{
    [TestClass]
    public class JitterRepositoryTests
    {
        [TestMethod]
        public void JitterContextEnsureICanCreateInstance()
        {
            JitterContext context = new JitterContext();
            Assert.IsNotNull(context);
        }
        [TestMethod]
        public void JitterRepositoryEnsureICanCreateInstance()
        {
            JitterRepository repository = new JitterRepository();
            Assert.IsNotNull(repository);
        }
        [TestMethod]
        public void JitterRepositoryEnsureICanGetAllUsers()
        {
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "adam1"},
                new JitterUser { Handle = "rumbadancer2"}
            };
            // connecting mock context to repository
            Mock<JitterContext> mock_context = new Mock<JitterContext>();
            // Mock our DbSet from JitterContext.cs
            Mock<DbSet<JitterUser>> mock_set = new Mock<DbSet<JitterUser>>();
            // Stubbing JitterUsers property getter
            // a represents JitterContext(DbContext-pathway to database)
            //mock_set.Object returns DbSet<JitterUser> (set of users)
            mock_context.Setup(a => a.JitterUsers).Returns(mock_set.Object);
            JitterRepository repository = new JitterRepository(mock_context.Object);
            mock_set.Object.AddRange(expected);
            var actual = repository.GetAllUsers();
            //Assert.AreEqual("adam1", actual.First().Handle);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void JitterRepositoryEnsureIHaveAContext()
        {
            JitterRepository repository = new JitterRepository();
            var actual = repository.Context;
            Assert.IsInstanceOfType(actual, typeof(JitterContext));
        }
    }
}
