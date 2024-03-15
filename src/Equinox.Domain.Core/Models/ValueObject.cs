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
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the current object is equal to the obj parameter; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            /// Check if the object is of type T and assign it to a variable of type T.
            var valueObject = obj as T;
            /// Call the protected abstract method EqualsCore to perform the comparison.
            return EqualsCore(valueObject);
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
            /// Call the protected abstract method GetHashCodeCore to generate the hash code.
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
       
