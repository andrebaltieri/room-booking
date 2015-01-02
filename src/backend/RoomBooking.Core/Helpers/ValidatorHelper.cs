using System;
using System.Collections.Generic;

namespace RoomBooking.Core.Helpers
{
    public static class ValidatorHelper
    {
        #region Nullable
        public static void EnsureIsNotNull(object obj, string errorMessage)
        {
            if (obj == null)
                throw new Exception(errorMessage);
        }
        #endregion

        #region Date
        public static void EnsureDateIsGreaterThan(DateTime startDate, DateTime endDate, string errorMessage)
        {
            if (startDate < endDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureDateIsLessThan(DateTime startDate, DateTime endDate, string errorMessage)
        {
            if (startDate > endDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureDateIsGreaterOrEqualThan(DateTime startDate, DateTime endDate, string errorMessage)
        {
            if (startDate < endDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureDateIsLessOrEqualThan(DateTime startDate, DateTime endDate, string errorMessage)
        {
            if (startDate > endDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureDayOfWeekIsNotWeekend(DateTime date, string errorMessage)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday)
                throw new Exception(errorMessage);
        }

        public static void EnrureListDontHaveDate(IList<DateTime> dateList, DateTime date, string errorMessage)
        {
            if (dateList != null)
            {
                foreach (var item in dateList)
                {
                    if (item.Date == date.Date)
                        throw new Exception(errorMessage);
                }
            }
        }

        public static void EnrureListDontHaveDateAndTime(IList<DateTime> dateList, DateTime date, string errorMessage)
        {
            if (dateList != null)
            {
                foreach (var item in dateList)
                {
                    if (item == date)
                        throw new Exception(errorMessage);
                }
            }
        }
        #endregion

        #region Hour
        public static void EnsureHourIsGreaterThan(int startHour, int endHour, string errorMessage)
        {
            if (startHour < endHour)
                throw new Exception(errorMessage);
        }

        public static void EnsureHourIsLessThan(int startHour, int endHour, string errorMessage)
        {
            if (startHour > endHour)
                throw new Exception(errorMessage);
        }

        public static void EnsureHourIsGreaterOrEqualThan(int startHour, int endHour, string errorMessage)
        {
            if (startHour < endHour)
                throw new Exception(errorMessage);
        }

        public static void EnsureHourIsLessOrEqualThan(int startHour, int endHour, string errorMessage)
        {
            if (startHour > endHour)
                throw new Exception(errorMessage);
        }

        public static void EnsureTotalHourIsLessThan(int startHour, int endHour, int totalHoursAllowed, string errorMessage)
        {
            if ((endHour - startHour) > totalHoursAllowed)
                throw new Exception(errorMessage);
        }
        #endregion

        #region Time
        public static void EnsureTimeIsGreaterThan(DateTime startTime, DateTime endTime, string errorMessage)
        {
            // Prepare dates
            DateTime compareStartDate = new DateTime(1900, 1, 1, startTime.Hour, startTime.Minute, startTime.Second);
            DateTime compareEndDate = new DateTime(1900, 1, 1, endTime.Hour, endTime.Minute, endTime.Second);

            if (compareStartDate <= compareEndDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureTimeIsLessThan(DateTime startTime, DateTime endTime, string errorMessage)
        {
            // Prepare dates
            DateTime compareStartDate = new DateTime(1900, 1, 1, startTime.Hour, startTime.Minute, startTime.Second);
            DateTime compareEndDate = new DateTime(1900, 1, 1, endTime.Hour, endTime.Minute, endTime.Second);

            if (compareStartDate >= compareEndDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureTimeIsGreaterOrEqualThan(DateTime startTime, DateTime endTime, string errorMessage)
        {
            // Prepare dates
            DateTime compareStartDate = new DateTime(1900, 1, 1, startTime.Hour, startTime.Minute, startTime.Second);
            DateTime compareEndDate = new DateTime(1900, 1, 1, endTime.Hour, endTime.Minute, endTime.Second);

            if (compareStartDate < compareEndDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureTimeIsLessOrEqualThan(DateTime startTime, DateTime endTime, string errorMessage)
        {
            // Prepare dates
            DateTime compareStartDate = new DateTime(1900, 1, 1, startTime.Hour, startTime.Minute, startTime.Second);
            DateTime compareEndDate = new DateTime(1900, 1, 1, endTime.Hour, endTime.Minute, endTime.Second);

            if (compareStartDate > compareEndDate)
                throw new Exception(errorMessage);
        }
        #endregion

        #region Integer
        public static void EnsureIsGreaterThan(int value, int comparer, string errorMessage)
        {
            if (value < comparer)
                throw new Exception(errorMessage);
        }

        public static void EnsureIsLessThan(int value, int comparer, string errorMessage)
        {
            if (value > comparer)
                throw new Exception(errorMessage);
        }

        public static void EnsureIsGreaterOrEqualThan(int value, int comparer, string errorMessage)
        {
            if (value < comparer)
                throw new Exception(errorMessage);
        }

        public static void EnsureIsLessOrEqualThan(int value, int comparer, string errorMessage)
        {
            if (value > comparer)
                throw new Exception(errorMessage);
        }
        #endregion

        #region String
        public static void EnsureStringIsNotNullOrEmpty(string value, string errorMessage)
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception(errorMessage);
        }
        #endregion
    }
}
