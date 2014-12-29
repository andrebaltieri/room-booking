using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomBooking.Core.Helpers;
using System;

namespace RoomBooking.Core.Tests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        [TestCategory("ValidatorHelper")]
        public void EnsureDateIsGreaterOrEqualThan()
        {
            ValidatorHelper.EnsureDateIsGreaterOrEqualThan(DateTime.Now.AddHours(1), DateTime.Now, "Greater");
            ValidatorHelper.EnsureDateIsGreaterOrEqualThan(DateTime.Now, DateTime.Now, "Equals");
        }

        [TestMethod]
        [TestCategory("ValidatorHelper")]
        public void EnsureDateIsGreaterThan()
        {
            ValidatorHelper.EnsureDateIsGreaterThan(DateTime.Now.AddHours(1), DateTime.Now, "Greater");
        }

        [TestMethod]
        [TestCategory("ValidatorHelper")]
        public void EnsureDateIsLessOrEqualThan()
        {
            ValidatorHelper.EnsureDateIsLessOrEqualThan(DateTime.Now.AddHours(-1), DateTime.Now, "Less");
            ValidatorHelper.EnsureDateIsLessOrEqualThan(DateTime.Now, DateTime.Now, "Equal");
        }

        [TestMethod]
        [TestCategory("ValidatorHelper")]
        public void EnsureDateIsLessThan()
        {
            ValidatorHelper.EnsureDateIsLessThan(DateTime.Now.AddHours(-1), DateTime.Now, "Less");
        }

        [TestMethod]
        [TestCategory("ValidatorHelper")]
        public void EnsureHourIsGreaterOrEqualThan()
        {
            ValidatorHelper.EnsureHourIsGreaterOrEqualThan(10, 1, "Greater");
            ValidatorHelper.EnsureHourIsGreaterOrEqualThan(1, 1, "Equal");
        }

        [TestMethod]
        [TestCategory("ValidatorHelper")]
        public void EnsureHourIsGreaterThan()
        {
            ValidatorHelper.EnsureHourIsGreaterThan(10, 1, "Greater");
        }

        [TestMethod]
        [TestCategory("ValidatorHelper")]
        public void EnsureHourIsLessOrEqualThan()
        {
            ValidatorHelper.EnsureHourIsLessOrEqualThan(1, 10, "Less");
            ValidatorHelper.EnsureHourIsLessOrEqualThan(10, 10, "Equal");
        }

        [TestMethod]
        [TestCategory("ValidatorHelper")]
        public void EnsureHourIsLessThan()
        {
            ValidatorHelper.EnsureHourIsLessThan(1, 10, "Less");
        }

        [TestMethod]
        [TestCategory("ValidatorHelper")]
        public void EnsureTimeIsGreaterOrEqualThan()
        {
            ValidatorHelper.EnsureTimeIsGreaterOrEqualThan(DateTime.Now.AddHours(1), DateTime.Now, "Greater");
            ValidatorHelper.EnsureTimeIsGreaterOrEqualThan(DateTime.Now, DateTime.Now, "Equal");
        }

        [TestMethod]
        [TestCategory("ValidatorHelper")]
        public void EnsureTimeIsGreaterThan()
        {
            ValidatorHelper.EnsureTimeIsGreaterThan(DateTime.Now.AddHours(1), DateTime.Now, "Greater");
        }

        [TestMethod]
        [TestCategory("ValidatorHelper")]
        public void EnsureTimeIsLessOrEqualThan()
        {
            ValidatorHelper.EnsureTimeIsLessOrEqualThan(DateTime.Now, DateTime.Now.AddHours(1), "Less");
            ValidatorHelper.EnsureTimeIsLessOrEqualThan(DateTime.Now, DateTime.Now, "Equal");
        }

        [TestMethod]
        [TestCategory("ValidatorHelper")]
        public void EnsureTimeIsLessThan()
        {
            ValidatorHelper.EnsureTimeIsLessThan(DateTime.Now, DateTime.Now.AddHours(1), "Less");
        }
    }
}
