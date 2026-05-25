using Character;
using Core.AbilitySystem;
using Core.AbilitySystem.Attribute;
using UnityEngine;

[RequireComponent(typeof(EquipmentComponent))]
[RequireComponent(typeof(AbilitySystemComponent))]
public class PlayerCharacter : CharacterBase
{
    [SerializeField] private Transform model;
    [SerializeField] private float rotationSmoothing = 15f;
    [SerializeField] private float initialMoveSpeed = 5f;

    private AbilitySystemComponent _asc;

    protected virtual void Awake()
    {
        _asc = GetComponent<AbilitySystemComponent>();

        var charSet = new CharacterAttributeSet();
        charSet.speed = new AttributeData { BaseValue = initialMoveSpeed, CurrentValue = initialMoveSpeed };
        _asc.AddAttributeSet(charSet);
    }

    public override void MoveDelta(Vector3 normailizedDirection, float delta)
    {
        if (normailizedDirection.sqrMagnitude > 0.01f)
        {
            float speed = _asc.GetCurrentValue(CharacterAttributeSet.Speed);
            transform.position += normailizedDirection * (speed * delta);
            Quaternion target = Quaternion.LookRotation(normailizedDirection);
            model.rotation = Quaternion.Slerp(model.rotation, target, rotationSmoothing * delta);
        }
    }

    public override void StopMoving()
    {
    }
}
