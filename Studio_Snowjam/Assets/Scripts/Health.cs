using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Health : MonoBehaviour
{
    [SerializeField] private int curHealth;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private bool startMaxHealth = true;
    [SerializeField] private bool isNPC = true;
    [SerializeField] private bool isDead;

    public Image[] toasts;
    public powerUps powerups;

    // Start is called before the first frame update
    void Start()
    {
        if (startMaxHealth)
        {
            curHealth = maxHealth;
        }
    }

    public ref int CurrentHealth()
    {
        return ref curHealth;
    }

    public ref int MaxHealth()
    {
        return ref maxHealth;
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
    public void Damage(int damage)
    {
        // Updates health
        curHealth -= damage;
        
        // Prevents health over maximum
        if (curHealth > maxHealth)
        {
//            powerups.setAttack();
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
            Destroy(gameObject);
            
            if (!isNPC)
            {
                toasts[0].enabled = false; 
                // TODO: Death animation? 
                // TODO: Game over
            }
        }
    }

    // Heals a player or NPC
    public void Heal(int health)
    {
        Damage(-health);
    }
}