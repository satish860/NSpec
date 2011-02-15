﻿using System.Linq;
using NSpec;
using NUnit.Framework;

namespace NSpecSpec
{
    [TestFixture]
    public class when_finding_specs
    {
        protected SpecFinder finder;

        [SetUp]
        public void setup()
        {
            finder = new SpecFinder();
        }

        [Test]
        public void should_find_sample_spec()
        {
            Assert.AreEqual("sample",finder.SpecClasses().First().Name);
        }
    }

    [TestFixture]
    public class after_running_the_sample_spec 
    {
        private SpecFinder finder;

        [SetUp]
        public void setup()
        {
            finder = new SpecFinder();
            finder.Run();
        }
        [Test]
        public void should_have_one_exception_after_running()
        {
            Assert.AreEqual(1, finder.Failures().Count());
        }

        [Test]
        public void should_have_two_examples()
        {
            Assert.AreEqual(2, finder.Examples().Count());
        }
    }
}
