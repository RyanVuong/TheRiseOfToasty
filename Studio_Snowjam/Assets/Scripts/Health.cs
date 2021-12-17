using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Health : MonoBehaviour
{
    [SerializeField] private int curHealth;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private bool isDead;
    [SerializeField] private bool isNPC;
    
    public Image[] toasts;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Only for the PC: Update UI health to curHealth
        if (!isNPC)
        {
            for (var i = 0; i < toasts.Length; i++)
            {
                toasts[i].enabled = i < curHealth;
            }
        }
    }

    // Damages a player or NPC
    public void DamagePlayer(int damage)
    {
        // Updates health
        curHealth -= damage;
        
        // Prevents health over maximum
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        } 
        // Sets dead if character dies
        else if (curHealth < 1)
        {
            isDead = true;
        }
        // Action
        if (isDead)
        {
            if (!isNPC)
            {
                toasts[0].enabled = false; 
                // TODO: Death animation? 
            }
        }
    }

    // Heals a player or NPC
    public void HealPlayer(int health)
    {
        DamagePlayer(-health);
    }
}