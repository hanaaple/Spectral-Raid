using System;
using UnityEngine;

namespace Core.AbilitySystem.Attribute
{
    [Serializable]
    public struct AttributeId : IEquatable<AttributeId>
    {
        [SerializeField]
        private string value;

        public string Value => value;

        public AttributeId(string value)
        {
            this.value = value;
        }

        public bool Equals(AttributeId other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            return obj is AttributeId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return value != null ? value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return value;
        }

        public static bool operator ==(AttributeId left, AttributeId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AttributeId left, AttributeId right)
        {
            return !left.Equals(right);
        }
    }
}
