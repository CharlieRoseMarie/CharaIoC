using CharacIoC;
using CharacIoC.Exceptions;
using CharacIoC.Interfaces;
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
                var dummy = new DummyClass();
                TestIoc.RegisterInstance(dummy);
                var result = TestIoc.Resolve<DummyClass>();
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(DummyClass));
            }
        }

        [TestClass]
        public class RegisterSpecificTypeTest : CharaIoCContainerTest
        {
            [TestMethod]
            public void SimpleExample_FunctionsCorrectly()
            {
                TestIoc.RegisterType<IDummy, DummyClass>();
                var result = TestIoc.Resolve<IDummy>();
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(DummyClass));
            }

            [TestMethod]
            public void CanRegisterTypeWithNonParamterlessConstructor_Succeeeds()
            {
                TestIoc.RegisterType<IDummy, NonEmptyConstructorDummy>(() => new NonEmptyConstructorDummy(5));
                var result = TestIoc.Resolve<IDummy>();
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(NonEmptyConstructorDummy));
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