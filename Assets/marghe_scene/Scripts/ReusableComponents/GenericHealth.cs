using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    public GameObject canvasToDisappear; // Riferimento al canvas da far scomparire
    //public float fadeDuration = 1f; // Durata del fading in secondi
    public Animator myAnim; // Riferimento all'animator

    public FloatValue maxHealth;
    public float currentHealth; //This means that the value can be changed in the inspector, but not by other scripts


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth.RuntimeValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            myAnim.SetTrigger("death");
        }
    }

    //This method let us heal the player by adding the amount of health we want to heal to the current health
    //If the current health is greater than the max health, we set the current health to the max health
    //Virtual means that we can override this method in other scripts
    public virtual void Heal(float amountToHeal) 
    {
        currentHealth += amountToHeal;
        if (currentHealth > maxHealth.RuntimeValue)
        {
            currentHealth = maxHealth.RuntimeValue;
        }
    }

    //This method let us heal the player directly to the max health
    //Virtual means that we can override this method in other scripts

    public virtual void FullHeal() 
    {
        currentHealth = maxHealth.RuntimeValue;
    }

    //This method decreases the player's health with the amount of damage we want to deal by subtracting it from the current health
    //If the current health is less than 0, we set the current health to 0
    //Virtual means that we can override this method in other scripts
    public virtual void Damage(float amountToDamage) 
    {
        if(currentHealth == 0)
        {
            currentHealth -= amountToDamage;
    
        }
        currentHealth -= amountToDamage;
        if (currentHealth != 0){
            canvasToDisappear.SetActive(true); 
            if (currentHealth < 0) 
            {
                currentHealth = 0; 
            }
        }
    }

    //This method kills the player instantly
    //Virtual means that we can override this method in other scripts
    public virtual void InstantDeath() 
    {
        currentHealth = 0;
    }
}
