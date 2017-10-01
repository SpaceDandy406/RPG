using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RPG.Common;

namespace RPG.UnitTests.Core.Random
{
    [TestFixture]
    class RandomGeneratorTests
    {
        [Test]
        public void NextIntEven_genX1X2_X1notEqualX2()
        {
            // Arrange
            int x1;
            int x2;

            // Act
            x1 = RandomGenerator.NextIntEven();
            x2 = RandomGenerator.NextIntEven();

            // Assert
            Assert.AreNotEqual(x1, x2);
        }

        [Test]
        public void NextDoubleEven_genX1X2_X1notEqualX2()
        {
            // Arrange
            double x1;
            double x2;

            // Act
            x1 = RandomGenerator.NextDoubleEven();
            x2 = RandomGenerator.NextDoubleEven();

            // Assert
            Assert.AreNotEqual(x1, x2);
        }

        [Test]
        public void NextIntEven_gen1000valueFrom5to8_allValueIncludedFrom5to8()
        {
            // Arrange
            int x1 = 5;
            int x2 = 8;
            var values = new List<int>();

            // Act
            for (int i = 0; i < 1000; i++)
            {
                values.Add(RandomGenerator.NextIntEven(x1, x2));
            }

            // Assert
            var isInInterval = values.Any(x => x < 5 || x >= 8);
            values.ForEach(x => Console.WriteLine(x));
            Assert.IsFalse(isInInterval);
        }

        [Test]
        public void NextDoubleNormal_genX1X2_X1notEqualX2()
        {
            // Arrange
            double x1;
            double x2;

            // Act
            x1 = RandomGenerator.NextDoubleNormal();
            x2 = RandomGenerator.NextDoubleNormal();

            // Assert
            Assert.AreNotEqual(x1, x2);
        }

        [Test]
        public void NextDoubleNormal_genX1X2withParametrs_X1notEqualX2()
        {
            // Arrange
            double x1;
            double x2;

            // Act
            x1 = RandomGenerator.NextDoubleNormal(10.5, 1.3);
            x2 = RandomGenerator.NextDoubleNormal(10.5, 1.3);

            // Assert
            Assert.AreNotEqual(x1, x2);
        }
    }
}
