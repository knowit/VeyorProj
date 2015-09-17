
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VeyorProj.WebApp.Data;

namespace VeyorProj.Tests
{
    [TestClass]
    public class DataTests
    {
        private IDbRepo repo;

        [TestInitialize]
        public void init()
        {
            repo = new DbRepo();
        }

        //[TestMethod]
        //public void get_items()
        //{
        //    var items = repo.GetItems();

        //    Assert.IsTrue(items.Any());
        //}

    }
}
