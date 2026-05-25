using System;
using System.Collections.Generic;
using Core.AbilitySystem.Attribute;
using UnityEngine;

namespace Core.AbilitySystem
{
    public class AbilitySystemComponent : MonoBehaviour
    {
        private readonly Dictionary<Type, AttributeSet> _spawnedAttributeSets = new();
        private readonly Dictionary<int, AttributeEffect> _activeEffects = new();

        /// <summary>같은 타입의 AttributeSet은 하나만 등록 가능.</summary>
        public bool AddAttributeSet(AttributeSet set)
        {
            return _spawnedAttributeSets.TryAdd(set.GetType(), set);
        }

        public void RemoveAttributeSet(AttributeSet set)
        {
            _spawnedAttributeSets.Remove(set.GetType());
        }

        /// <summary>핸들이 가리키는 어트리뷰트의 BaseValue를 반환.</summary>
        public float GetBaseValue(AttributeHandle handle)
        {
            return TryGetData(handle, out AttributeData data) ? data.BaseValue : 0f;
        }

        /// <summary>핸들이 가리키는 어트리뷰트의 CurrentValue를 반환.</summary>
        public float GetCurrentValue(AttributeHandle handle)
        {
            return TryGetData(handle, out AttributeData data) ? data.CurrentValue : 0f;
        }

        /// <summary>핸들이 가리키는 어트리뷰트의 BaseValue를 설정.</summary>
        public void SetBaseValue(AttributeHandle handle, float value)
        {
            if (!TryGetData(handle, out AttributeData data))
                return;
            data.BaseValue = value;
            TrySetData(handle, data);
        }

        private bool TryGetData(AttributeHandle handle, out AttributeData data)
        {
            if (_spawnedAttributeSets.TryGetValue(handle.SetType, out AttributeSet set))
                return handle.TryGetData(set, out data);
            data = default;
            return false;
        }

        private bool TrySetData(AttributeHandle handle, AttributeData data)
        {
            if (_spawnedAttributeSets.TryGetValue(handle.SetType, out AttributeSet set))
                return handle.TrySetData(set, data);
            return false;
        }
    }
}
