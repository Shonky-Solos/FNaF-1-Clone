using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public int hour;
    private int currentHour;
    public float power;
    public string displayPower;
    public int usage;
    public int[] difficulty;
    public Image[] hourPictures;

    void Start()
    {
        //Represented in game as 12am but functionally the first hour
        usage = 1;
        hour = -1;
        currentHour = -1;
        //Starts power at 100%
        power = 100;
        StartCoroutine(DoGame());
    }
    void Update()
    {
        // Handles changes ON THE HOUR
        if(currentHour != hour)
        {
            //Change the image of the hour (eg 2am)
            hourPictures[currentHour].enabled = false;
            hourPictures[hour].enabled = true;
            // Make sure any changes happen before here
            currentHour = hour;
        }
        //Run down power proportional to power usage by player
        power -= usage / 6 * Time.deltaTime;
        //Shows power as a percentage without decimals
        displayPower = Mathf.FloorToInt(power).ToString();
    }

    //Called on button press, plays first night with lowest difficulty
    public void NewGame()
    {
        difficulty[0] = 0;
        difficulty[1] = 0;
        difficulty[2] = 0;
        difficulty[3] = 0;
    }

    public IEnumerator DoGame()
    {
        //Updates hour every 90s, or wins/loses game
        hour += 1;
        yield return new WaitForSeconds(90);
        //Increase hour then start timer again
        if(hour != 6 && power > 0)
        {
            StartCoroutine(DoGame());
        }
        if(hour == 6)
        {
            // WIN THE GAME
        }
        if(hour != 6 && power <= 0)
        {
            // LOSE
        }
    }
}
