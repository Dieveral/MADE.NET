namespace MADE.Collections.Tests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using MADE.Collections.Tests.Fakes;

    using NUnit.Framework;

    using Shouldly;

    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class CollectionExtensionsTests
    {
        public class WhenUpdatingACollectionItem
        {
            [Test]
            public void ShouldThrowArgumentNullExceptionIfNullCollection()
            {
                // Arrange
                List<string> list = null;
                string item = "Hello";

                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => list.Update(item, (s, i) => s == i));
            }

            [Test]
            public void ShouldThrowArgumentNullExceptionIfNullItem()
            {
                // Arrange
                var list = new List<string> { "Hello" };
                string item = null;

                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => list.Update(item, (s, i) => s == i));
            }

            [Test]
            public void ShouldReturnTrueIfItemUpdated()
            {
                // Arrange
                TestObject objectToAdd = TestObjectFaker.Create().Generate();
                TestObject objectToUpdateWith = TestObjectFaker.Create().Generate();

                var list = new List<TestObject> { objectToAdd };

                // Act
                bool updated = list.Update(objectToUpdateWith, (s, i) => s.Name == objectToAdd.Name);

                // Assert
                updated.ShouldBeTrue();
            }

            [Test]
            public void ShouldReturnFalseIfItemToUpdateDoesNotExist()
            {
                // Arrange
                TestObject objectToAdd = TestObjectFaker.Create().Generate();
                TestObject objectToUpdateWith = TestObjectFaker.Create().Generate();

                var list = new List<TestObject> { objectToAdd };

                // Act
                bool updated = list.Update(objectToUpdateWith, (s, i) => s.Name == objectToUpdateWith.Name);

                // Assert
                updated.ShouldBeFalse();
            }
        }
    }
}