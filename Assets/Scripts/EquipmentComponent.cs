using UnityEngine;

public class EquipmentComponent : MonoBehaviour
{
    // TODO: 임시 1개 장착 웨폰
    // 이후
    public WeaponInstance currentWeapon;


    // Weapon Instance를 생성 합니다.
    public void Equip(WeaponData weaponData)
    {
        // weaponData 기반으로 Instance 생성

        // 스탯 생성?
    }

    public void Unequip()
    {
        Destroy(currentWeapon);
        currentWeapon = null;
        // 스탯 제거
    }

    private void UnequipInternal()
    {

    }
}
