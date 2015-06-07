using RoomBooking.SharedKernel.Events;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RoomBooking.SharedKernel.Validation
{
    public static class AssertionConcern
    {
        public static bool IsSatisfiedBy(params DomainNotification[] validations)
        {
            var notificationsNotNull = validations.Where(validation => validation != null);
            NotifyAll(notificationsNotNull);

            return notificationsNotNull.Count().Equals(0);
        }

        private static void NotifyAll(IEnumerable<DomainNotification> notifications)
        {
            notifications.ToList().ForEach(validation =>
            {
                DomainEvent.Raise<DomainNotification>(validation);
            });
        }

        public static DomainNotification AssertLength(string stringValue, int minimum, int maximum, string message)
        {
            int length = stringValue.Trim().Length;

            return (length < minimum || length > maximum) ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        public static DomainNotification AssertMatches(string pattern, string stringValue, string message)
        {
            Regex regex = new Regex(pattern);

            return (!regex.IsMatch(stringValue)) ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        public static DomainNotification AssertNotEmpty(string stringValue, string message)
        {
            return (stringValue == null || stringValue.Trim().Length == 0) ?
                new DomainNotification("AssertArgumentNotEmpty", message) : null;
        }

        public static DomainNotification AssertNotNull(object object1, string message)
        {

            return (object1 == null) ?
                new DomainNotification("AssertArgumentNotNull", message) : null;
        }

        public static DomainNotification AssertTrue(bool boolValue, string message)
        {
            return (!boolValue) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }
    }
}
