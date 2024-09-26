using System;

public class ItemDatabase
{
	public Equipment[] itemDb;

	public ItemDatabase()
	{
        EquipmentData();
	}

	private void EquipmentData()
	{
        itemDb = new Equipment[]
        {
            new Equipment("훈련용 갑옷", "천으로 만들어져 가벼운 훈련복입니다.", 5, 0, 1000, EquipmentType.Armor),
            new Equipment("강철 갑옷", "강철로 제작된 튼튼한 갑옷입니다.", 9, 0, 2000, EquipmentType.Armor),
            new Equipment("멋쟁이 갑옷", "멋과 방어력 모두 챙긴 갑옷입니다.", 15, 0, 3500, EquipmentType.Armor),
            new Equipment("낡은 장검", "오래된 평범하고 낡은 검입니다.", 0, 2, 600, EquipmentType.Weapon),
            new Equipment("청동 손도끼", "고대 전사들이 사용하던 도끼입니다.", 0, 5, 1500, EquipmentType.Weapon),
            new Equipment("장군의 창", "전설 속 장군이 사용했다는 창입니다.", 0, 7, 2500, EquipmentType.Weapon)
        };
    }
}
