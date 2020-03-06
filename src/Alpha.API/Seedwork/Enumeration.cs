using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Alpha.API.Seedwork
{
    public class Enumeration : IComparable
    {
        protected Enumeration()
        {
        }

        protected Enumeration(Index index, string displayName)
        {
            Index = index;
            DisplayName = displayName;
        }

        public Index Index { get; }

        public string DisplayName { get; }

        public override string ToString()
        {
            return DisplayName;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();
                var locatedValue = info.GetValue(instance) as T;

                if (locatedValue != null)
                {
                    yield return locatedValue;
                }
            }
        }

        public static bool operator ==(Enumeration lhs, Enumeration rhs)
        {
            // Check for null on left side.
            return lhs?.Equals(rhs) ?? rhs is null;
        }

        public static bool operator !=(Enumeration lhs, Enumeration rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Index.Equals(otherValue.Index);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return Index.GetHashCode();
        }

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            if (firstValue == null) throw new ArgumentNullException(nameof(firstValue));
            if (secondValue == null) throw new ArgumentNullException(nameof(secondValue));

            var absoluteDifference = Math.Abs(firstValue.Index.Value - secondValue.Index.Value);
            return absoluteDifference;
        }

        public static T FromIndex<T>(Index index) where T : Enumeration, new()
        {
            var matchingItem = parse<T, Index>(index, "value", item => item.Index.Equals(index));
            return matchingItem;
        }

        public static T FromDisplayName<T>(string displayName) where T : Enumeration, new()
        {
            var matchingItem = parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
            return matchingItem;
        }

        private static T parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = string.Format(CultureInfo.InvariantCulture, "'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                throw new ApplicationException(message);
            }

            return matchingItem;
        }

        public int CompareTo(object other)
        {
            if (other == null) return -1;
            return Index.Value.CompareTo(((Enumeration)other).Index.Value);
        }
    }
}