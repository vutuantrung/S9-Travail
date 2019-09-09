using LexicogTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsLexicogTree
{
    [TestFixture]
    class T1UserTests
    {
        [Test]
        public void can_create_user()
        {
            UserInfor userExample = new UserInfor
            {
                FirstName = "VU",
                LastName = "Tuan Trung",
                Age = 25,
                UserType = UserType.Administrator
            };
            Assert.That(userExample.FirstName == "VU");
            Assert.That(userExample.LastName == "Tuan Trung");
            Assert.That(userExample.Age == 25);
            Assert.That(userExample.UserType == UserType.Administrator);

            Assert.Throws<ArgumentException>(() => { userExample.FirstName = string.Empty; }, "Invalid First name.");
            Assert.Throws<ArgumentException>(() => { userExample.LastName = string.Empty; }, "Invalid Last name.");
            Assert.Throws<ArgumentException>(() => { userExample.Age = -1; }, "Invalid Age.");
        }

        [Test]
        public void unit_test_example()
        {

        }
    }
}
