using System;

namespace RoomBooking.Core.Helpers
{
    public static class ValidatorHelper
    {
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
            if (startDate <= endDate)
                throw new Exception(errorMessage);
        }

        public static void EnsureDateIsLessOrEqualThan(DateTime startDate, DateTime endDate, string errorMessage)
        {
            if (startDate >= endDate)
                throw new Exception(errorMessage);
        }

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
            if (startHour <= endHour)
                throw new Exception(errorMessage);
        }

        public static void EnsureHourIsLessOrEqualThan(int startHour, int endHour, string errorMessage)
        {
            if (startHour >= endHour)
                throw new Exception(errorMessage);
        }
    }
}
