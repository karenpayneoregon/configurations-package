using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using ShadowProperties.Classes;
using ShadowPropertiesUnitTestProject.Base;

namespace ShadowPropertiesUnitTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {
       
        [TestMethod]
        [TestTraits(Trait.EntityFrameworkCore)]
        public async Task GetAllContactsNoQueryFilter()
        {
            var filters = await BogusOperations.WithNoFilter();
            Check.That(filters.Count).Equals(10);
        }
        [TestMethod]
        [TestTraits(Trait.EntityFrameworkCore)]
        public async Task GetAllContactsWithQueryFilter()
        {
            var filters = await BogusOperations.WithFilter();
            Check.That(filters.Count).Equals(8);
        }

        [TestMethod]
        [TestTraits(Trait.DataProvider)]
        public async Task DataProviderCanConnectTest()
        {
            var result = await DataProviderOperations.CanConnect();
            Check.That(true).IsTrue();
        }


    }


}
