﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jitter.Models;
using System.Collections.Generic;

namespace Jitter.Tests.Models
{
    [TestClass]
    public class JitterUserTests
    {
        [TestMethod]
        public void JitterUserEnsureICanCreateInstance()
        {
            Jitter.Models.JitterUser a_user = new Jitter.Models.JitterUser();
            Assert.IsNotNull(a_user);
        }

        [TestMethod]
        public void JitterUserEnsureJitterUserHasAllTheThings()
        {
            // Arrange
            Jitter.Models.JitterUser a_user = new Jitter.Models.JitterUser();
            a_user.Handle = "adam1";
            a_user.FirstName = "Adam";
            a_user.LastName = "Sandler";
            a_user.Picture = "https://google.com";
            a_user.Description = "I am Awesome!";

            // Assert 
            Assert.AreEqual("I am Awesome!", a_user.Description);
            Assert.AreEqual("adam1", a_user.Handle);
            Assert.AreEqual("Adam", a_user.FirstName);
            Assert.AreEqual("Sandler", a_user.LastName);
            Assert.AreEqual("https://google.com", a_user.Picture);
        }
        [TestMethod]
        public void JitterUserEnsureUserHasJots()
        {
            List<Jot> list_of_jots = new List<Jot>
            {
                new Jot { Content = "blah!" },
                new Jot { Content = "blah, part 2!" }
            };
            Jitter.Models.JitterUser a_user = new Jitter.Models.JitterUser { Handle = "adam1", Jots = list_of_jots};
            List<Jot> actual_jots = a_user.Jots;

            CollectionAssert.AreEqual(list_of_jots, actual_jots);
        }
        [TestMethod]
        public void JitterUserEnsureUserFollowsOthers()
        {
            List<Jitter.Models.JitterUser> list_of_users = new List<Jitter.Models.JitterUser>
            {
                new Jitter.Models.JitterUser { Handle = "blah" },
                new Jitter.Models.JitterUser { Handle = "blah2" }
            };
            Jitter.Models.JitterUser a_user = new Jitter.Models.JitterUser { Handle = "adam1", Following = list_of_users };
            List<Jitter.Models.JitterUser> actual_users = a_user.Following;

            CollectionAssert.AreEqual(list_of_users, actual_users);
        }
    }
}
