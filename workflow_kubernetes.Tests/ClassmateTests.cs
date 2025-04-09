using Microsoft.VisualStudio.TestTools.UnitTesting;
using workflow_kubernetes.Models;

namespace workflow_kubernetes.Tests
{
    [TestClass]
    public class ClassmateTests
    {
        [TestMethod]
        public void Constructor_Should_Assign_Properties_Correctly()
        {
            // Arrange
            var expectedId = 1;
            var expectedName = "Ana";
            var expectedLastName = "Pérez";
            var expectedAge = 22;
            var expectedDescription = "Excelente compañera de clase.";

            // Act
            var classmate = new Classmate(expectedId, expectedName, expectedLastName, expectedAge, expectedDescription);

            // Assert
            Assert.AreEqual(expectedId, classmate.ClassmateId);
            Assert.AreEqual(expectedName, classmate.Name);
            Assert.AreEqual(expectedLastName, classmate.LastName);
            Assert.AreEqual(expectedAge, classmate.Age);
            Assert.AreEqual(expectedDescription, classmate.Description);
        }
    }
}
