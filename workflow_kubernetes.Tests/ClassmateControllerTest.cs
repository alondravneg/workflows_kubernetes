using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using workflow_kubernetes.Controllers;
using workflow_kubernetes.Models;
using System.Collections.Generic;

namespace workflow_kubernetes.Tests
{
    [TestClass]
    public class ClassmateControllerTests
    {
        [TestMethod]
        public void Get_WithValidId_ReturnsOkResultWithClassmate()
        {
            var controller = new ClassmateController();

            var result = controller.Get(1) as OkObjectResult;

            Assert.IsNotNull(result);
            var classmate = result.Value as Classmate;
            Assert.IsNotNull(classmate);
            Assert.AreEqual(1, classmate.ClassmateId);
            Assert.AreEqual("Daniel", classmate.Name);
        }

        [TestMethod]
        public void Get_WithInvalidId_ReturnsNotFound()
        {
            var controller = new ClassmateController();

            var result = controller.Get(999);

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void GetAll_ReturnsAllClassmates()
        {
            var controller = new ClassmateController();

            var result = controller.Get() as OkObjectResult;

            Assert.IsNotNull(result);
            var list = result.Value as List<Classmate>;
            Assert.IsNotNull(list);
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void Post_ValidClassmate_ReturnsCreatedAtAction()
        {
            var controller = new ClassmateController();
            var newMate = new Classmate(5, "Nuevo", "Alumno", 22, "Estudia mucho");

            var result = controller.Post(newMate) as CreatedAtActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(nameof(controller.Get), result.ActionName);
            var created = result.Value as Classmate;
            Assert.IsNotNull(created);
            Assert.AreEqual("Nuevo", created.Name);
        }

        [TestMethod]
        public void Put_ValidId_UpdatesClassmate()
        {
            var controller = new ClassmateController();
            var update = new Classmate(1, "Dani", "Mansur", 22, "Usa lentes");

            var result = controller.Put(1, update);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void Put_InvalidId_ReturnsNotFound()
        {
            var controller = new ClassmateController();
            var update = new Classmate(999, "X", "Y", 30, "No existe");

            var result = controller.Put(999, update);

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void Delete_ValidId_RemovesClassmate()
        {
            var controller = new ClassmateController();

            var result = controller.Delete(1);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void Delete_InvalidId_ReturnsNotFound()
        {
            var controller = new ClassmateController();

            var result = controller.Delete(999);

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}
