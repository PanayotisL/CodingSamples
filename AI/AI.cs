using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AI : MonoBehaviour
{
    
    private AgentActions agentScript;

    private string AgentName;
    private string EnemyName;
   
    public GameObject HealthKit;
    public GameObject PowerUpObj;

    private GameObject EnemyObject;

    private AgentActions EnemyScript;

    enum State { Wander, MoveToEnemy, MoveToHealthKit, MoveToPowerUp, Attack, FleeFrom };

    State currentState;

  

  
    void Start()
    {
        //Fetching infromation from AgentActions script
        agentScript = this.gameObject.GetComponent<AgentActions>();

        //Applying the same properties to the second enemy
        EnemyObject = agentScript.Enemy;

        //Creating a second enemy and assigning it as an enemy
        EnemyScript = EnemyObject.GetComponent<AgentActions>();

        //Assigning the enemy
        AgentName = this.gameObject.name;

        // Specifying and setting the enemies
        if (AgentName == "AIAgent2")
        {
            EnemyName = "AIAgent1";
        }

        else
        { 
            EnemyName = "AIAgent2";

        }
        //Set enemies to begin in state random wander
        currentState = State.Wander;


   
    }


    
    void Update()
    {

        
        //Checking to see of the enemy is in view, if the enemies have the power up if for what their health is
        if (agentScript.IsObjectInView(EnemyName) && agentScript.HasPowerUp == EnemyScript.HasPowerUp && agentScript.CurrentHitPoints > 25 && EnemyScript.CurrentHitPoints > 25)

        {
            //Seetting the enemy to attack of the other enemy is within view
            if (agentScript.IsInAttackRange(EnemyObject))
                currentState = State.Attack;
            //Setting the enemy to locate the other enemy
            else
                currentState = State.MoveToEnemy;
        }
        //Otherwise if the enemy is in view and the current enemy has a health less than the other enemy set the current enemy to flee
        else if (agentScript.IsObjectInView(EnemyName) && agentScript.CurrentHitPoints < 25)
        {
            currentState = State.FleeFrom;
        }
        //If the current enemies health is less than the other enemy search for the health kit, but if the enemy is in view set the current enemy to flee while the other enemy is wandering
        else if (agentScript.CurrentHitPoints < 25)
        {
            if (agentScript.IsObjectInView("Health Kit"))
                currentState = State.MoveToHealthKit;
            else if (agentScript.IsObjectInView(EnemyName))
                currentState = State.FleeFrom;
            else
                currentState = State.Wander;
        }

        //If the power up is in the enemies view and the power up has not been collected before then it will move the enemy towards the power up and collect it
        else if (agentScript.IsObjectInView("Power Up") && agentScript.HasPowerUp == false)
        {
            currentState = State.MoveToPowerUp;
        }
        //If all above states are not used then default back to the enemies to wander 
        else 
        {
            currentState = State.Wander;
        }


        //Creating a multi optional methods for behaviour 
        switch (currentState)
        {
            //Sets the enemy to random wander around the map
            case State.Wander:

                this.agentScript.RandomWander();
                Debug.Log("Random");
                break;

            //Sets the enemies if in view to move towards each other
            case State.MoveToEnemy:

                EnemyObject = agentScript.GetObjectInView(EnemyName);
                Debug.Log("LocatedEnemy");
                //Bug Trying to find an object that doesn't exist occured during testing, gameobject argument is null
                agentScript.MoveTo(EnemyObject);
                Debug.Log("MoveToEnemy");


                break;
            //Sets the enemies to move to the health kit if the health kit is within view
            case State.MoveToHealthKit:

                GameObject HealthKitObject = agentScript.GetObjectInView("HealthKit");
                agentScript.MoveTo(HealthKit);
                Debug.Log("MoveToHealthKit");

                break;
            //Sets the enemies to move towards the power up if within view
            case State.MoveToPowerUp:

                GameObject PowerUpObject = agentScript.GetObjectInView("PowerUpObj");
                agentScript.MoveTo(PowerUpObj);
                Debug.Log("MoveToPowerUp");

                break;
            //Sets the enemies to attack one another
            case State.Attack:

                agentScript.AttackEnemy(EnemyObject);
                Debug.Log("AttackEnemy");

                break;
            //Sets the enemies to flee for one another
            case State.FleeFrom:

                agentScript.Flee(EnemyObject);
                Debug.Log("Flee!");
                
                break;

        }



    }

}

  

