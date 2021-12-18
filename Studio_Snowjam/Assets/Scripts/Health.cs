using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
[System.Serializable]

public class Health : MonoBehaviour
{
    [SerializeField] private int curHealth;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private bool startMaxHealth = true;
    [SerializeField] private bool isNPC = true;
    [SerializeField] private bool isDead;
    [SerializeField] private bool isHappy;
    [SerializeField] private bool isSad;
    [SerializeField] private bool isBoss;

    public Image[] toasts;

    private static readonly int Health1 = Animator.StringToHash("Health");
    // public powerUps powerups;

    // Start is called before the first frame update
    void Start()
    {
        if (startMaxHealth)
        {
            curHealth = maxHealth;
        }
        GetComponent<Animator>().SetInteger(Health1, curHealth);
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
            curHealth = maxHealth;
        } 

        // Sets dead if character dies
        else if (curHealth < 1)
        {
            isDead = true;
        }

        // Get health in state machine
        GetComponent<Animator>().SetInteger(Health1, curHealth);


        if (isNPC)
        {
            // Dont kill them when they are happy!
            if (curHealth == 2)
            {
                GameObject.Find("Canvas").transform.GetChild(1).gameObject.GetComponent<ScoreKeeper>().AddScore(50);
            } 
            else if (!isBoss && curHealth == 0)
            {
                GameObject.Find("Canvas").transform.GetChild(1).gameObject.GetComponent<ScoreKeeper>().SubScore(100);
            }
        }




        // Action
        if (isDead)
        {
            // player
            if (!isNPC)
            {
                // Remove last toast icon on screen
                toasts[0].enabled = false;
                
                // Destroys Toasty
                // Destroy(gameObject);
                
                // Turns on the game over screen
                GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            }
            
            // boss
            else if (isBoss)
            {
                Destroy(gameObject);
                
                // Turns on the game over screen
                GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            }
            
            // regular npcs
            else
            {
                Destroy(gameObject);
            }
        }
    }

    // Heals a player or NPC
    public void Heal(int health)
    {
        Damage(-health);
    }

    public int getCurHealth()
    {
        return curHealth;
    }
}