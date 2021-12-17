using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxPlayerHealth;
    public static int playerHealth;
    //private LevelManager levelManager;
    public bool isDead;
    //private LifeManager lifeManager;

    Text text;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
