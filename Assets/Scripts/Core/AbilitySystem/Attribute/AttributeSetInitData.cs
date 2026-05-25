using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.AbilitySystem.Attribute
{
    [Serializable]
    public sealed class AttributeSetInitData
    {
        [SerializeField]
        private string attributeSetTypeName;

        [SerializeField]
        private List<AttributeFieldInitData> attributes = new();

        public Type GetAttributeSetType()
        {
            if (string.IsNullOrEmpty(attributeSetTypeName))
            {
                return null;
            }

            return Type.GetType(attributeSetTypeName);
        }
    }
}
