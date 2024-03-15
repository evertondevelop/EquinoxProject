namespace Equinox.Domain.Core.Models
{
    /// <summary>
    /// Abstract base class for Value Objects that need to implement equality comparisons.
    /// </summary>
    /// <typeparam name="T">The type of the derived Value Object.</typeparam>
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        /// <summary>
        /// Determines whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>True if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }

            return EqualsCore(other);
        }

        /// <summary>
        /// Performs the actual equality comparison for the derived Value Object.
        /// </summary>
        /// <param name="other">The other Value Object to compare with the current object.</param>
        /// <returns>True if the current object is equal to the other parameter; otherwise, false.</returns>
        protected abstract bool EqualsCore(T other);

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        /// <summary>
        /// Generates the hash code for the derived Value Object.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        protected abstract int GetHashCodeCore();

        /// <summary>
        /// Equality operator for Value Objects.
        /// </summary>
        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Inequality operator for Value Objects.
        /// </summary>
        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !(left == right);
        }
    }
}
