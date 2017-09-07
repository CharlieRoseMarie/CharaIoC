using System;
using CharacIoC;
using CharacIoC.Interfaces;
using CharacIoC.src.Exceptions;
using CharaIoC.UnitTest.IoC.Dummies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharaIoC.UnitTest.IoC.Tests
{
    [TestClass]
    public class CharaIoCContainerTest
    {
        public ICharaIoCContainer TestIoc;

        [TestInitialize]
        public void Setup()
        {
            TestIoc = new CharaIoCContainer();
        }

        [TestClass]
        public class RegisterInstanceTest : CharaIoCContainerTest
        {
            [TestMethod]
            public void SimpleExample_FunctionsCorrectly()
            {
                var dummy = new DummyClasses();
                TestIoc.RegisterInstance(dummy);
                var result = TestIoc.Resolve<DummyClasses>();
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(DummyClasses));
            }
        }

        [TestClass]
        public class RegisterSpecificTypeTest : CharaIoCContainerTest
        {
            [TestMethod]
            public void SimpleExample_FunctionsCorrectly()
            {
                TestIoc.RegisterType<IDummy, DummyClasses>();
                var result = TestIoc.Resolve<IDummy>();
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(DummyClasses));
            }
        }

        [TestClass]
        public class ResolveTest : CharaIoCContainerTest
        {
            [TestMethod]
            [ExpectedException(typeof(TypeNotFoundException))]
            public void WhenMissingType_ThrowException()
            {
                TestIoc.Resolve<IDummy>();
            }
        }
    }
}
