using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private Player player;


    protected override void Start()
    {
        base.Start();


        player = GetComponent<Player>();
    }


    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);

        player.DamageEffect();
    }


    protected override void Die()
    {
        base.Die();

       player.Die();
    }
    
    public void ConsumeItem(Item item)
    {
        if (item is not FoodItem food) return;
        
        Debug.Log($"[PlayerStats] Comeu {food.itemName}, recuperou {food.healthRestored} de vida.");
        base.RecoverHealth(food.healthRestored);
    }
}
