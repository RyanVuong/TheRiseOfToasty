using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Health : MonoBehaviour
{
    [SerializeField] private int curHealth;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private bool isDead;
    
    public Image[] toasts;
    public Sprite fullToast;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < toasts.Length; i++)
        {
            toasts[i].enabled = i < curHealth;
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        
        if (curHealth > 3)
        {
            curHealth = 3;
        } 
        else if (curHealth < 1)
        {
            isDead = true;
        }
        
        if (isDead)
        {
            toasts[0].enabled = false;
            // TODO: Death animation? 
        }
    }
}