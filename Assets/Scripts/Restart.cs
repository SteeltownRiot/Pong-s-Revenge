/*
 * Author: John Hopson
 * steeltownriot@gmail.com
 * 
 * Created: 7 April 2018
 * Last updated: 7 April 2018
 * 
 * Details:
 * - Level manager that restarts the game
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    public string name = "Start";
    // Precondition:  Level name must be passed as a string
    // Postcondition: 
    public void LoadLevel()
    {
        // Sets breakableCount to zero at start of level
        Brick.breakableCount = 0;
        SceneManager.LoadScene("Start");
    }
}
