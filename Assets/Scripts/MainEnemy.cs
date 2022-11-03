using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemy : MonoBehaviour
{

    #region Variables
    public int difficulty;
    public float moveTimer;
    public int[] location;
    public bool camUse;
    private bool canMove;
    private bool aiChange;
    private int hour;
    private int currentHour;
    private GameControl gc;
    #endregion

    void Start()
    {
        //Make the AI not move immediately upon start
        canMove = false;

        //Read the GameControl script for what AI level to set
        if(gameObject.name == "Bonnie")
        {
            difficulty = gc.difficulty[0];
        }
        if(gameObject.name == "Chica")
        {
            difficulty = gc.difficulty[1];
        }
        if (gameObject.name == "Freddy")
        {
            difficulty = gc.difficulty[2];
        }
        if (gameObject.name == "Foxy")
        {
            difficulty = gc.difficulty[3];
        }
    }

    void Update()
    {
        //Use GameControl's hour
        hour = gc.hour;
        
        //Run AI movement check
        if (canMove)
        {
            StartCoroutine(Movement());
        }

        //Run processes that only update per hour
        if(currentHour != hour)
        {
            //Increase difficulty throughout night
            if(hour == 2)
            {
                if(gameObject.name == "Bonnie")
                {
                    difficulty += 1;
                }
            }
            //These increase in AI level at these specific hours
            if(hour == 3 || hour == 4)
            {
                if(gameObject.name == "Bonnie" || gameObject.name == "Chica" || gameObject.name == "Foxy")
                {
                    difficulty += 1;
                }
            }

            //Do these updates once then wait until the next hour
            currentHour = hour;
        }
    }

    //copied over from FNaF, staggers the enemies
    public IEnumerator Setup()
    {
        yield return new WaitForSeconds(moveTimer);
        canMove = true;
    }

    public IEnumerator Movement()
    {
        canMove = false;
        //AI can only move if their AI is better than a d20 roll
        if(difficulty >= Random.Range(1, 20))
        {
            //DO MOVEMENT - Haven't solved yet
        }
        //Prevents AI from moving for their move timer
        yield return new WaitForSeconds(moveTimer);
        //Lets them roll to move again
        canMove = true;
    }
}
