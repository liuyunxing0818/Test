using UnityEngine;
using UnityEngine.UI;

public class CoinCalculation : MonoBehaviour
{
    // 直接收集的金币数量
    private int coinsCollected;
    // 是否使用金币加倍道具
    private bool multiplierUsed;
    // 加倍道具的倍数
    private int multiplierValue;
    // 角色技能额外获得的金币数量
    private int skillBonus;
    // 游戏距离获得的金币奖励
    private int distanceBonus;
    // 总金币数量
    private int totalCoins;

    // 显示总金币数量的文本
    public Text totalCoinsText;

    // 收集金币的方法
    public void CollectCoin()
    {
        coinsCollected++;
    }

    // 使用倍数道具的方法
    public void UseMultiplier(int multiplier)
    {
        multiplierUsed = true;
        multiplierValue = multiplier;
    }

    // 触发角色技能的方法
    public void TriggerSkill(int bonus)
    {
        skillBonus += bonus;
    }

    // 根据距离增加金币奖励的方法
    public void AddDistanceBonus(int bonus)
    {
        distanceBonus += bonus;
    }

    // 结算金币的方法
    public void CalculateTotalCoins()
    {
        int multiplierCoins;
        if (multiplierUsed)
        {
            // 如果使用倍数道具，计算道具加成后的金币数量
            multiplierCoins = coinsCollected * multiplierValue;
        }
        else
        {
            multiplierCoins = coinsCollected;
        }

        // 计算总金币数量，将道具加成、角色技能奖励和距离奖励的金币数量累加
        totalCoins = multiplierCoins + skillBonus + distanceBonus;

        // 在 UI 上显示总金币数量
        if (totalCoinsText != null)
        {
            totalCoinsText.text = "本场游戏获得的金币数量为: " + totalCoins;
        }
    }
}