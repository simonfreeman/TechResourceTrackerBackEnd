using System;
using NUnit.Framework;

namespace TechResourceServiceTest
{

    public class TechResourceServiceTest
    {
        //temp obviously
        [Test]
        public void Test_One_Is_One()
        {
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void Test_One_Is_Two_Will_Fail()
        {
            Assert.AreEqual(1, 2);
        }
    }
}
