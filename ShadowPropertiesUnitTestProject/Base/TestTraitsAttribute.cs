﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShadowPropertiesUnitTestProject.Base
{
    public enum Trait
    {
        PlaceHolder,
        EntityFrameworkCore,
        DataProvider
    }
    /// <summary>
    /// Declarative class for using Trait enum about for traits on test method.
    /// </summary>
    public class TestTraitsAttribute : TestCategoryBaseAttribute
    {
        private readonly Trait[] _traits;

        public TestTraitsAttribute(params Trait[] traits)
        {
            _traits = traits;
        }

        public override IList<string> TestCategories => _traits.Select(trait => Enum.GetName(typeof(Trait), trait)).ToList();
    }

}