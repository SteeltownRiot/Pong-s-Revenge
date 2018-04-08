/*
 * Author: John Hopson
 * steeltownriot@gmail.com
 * 
 * Created: 22 January 2017
 * Last updated: 5 February 2017
 * 
 * Details:
 * - Level manager that loads each level or quits the application
*/
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class LevelManager : MonoBehaviour
    {

        // Precondition:  Level name must be passed as a string
        // Postcondition: 
        public void LoadLevel(string name)
        {
            // Sets breakableCount to zero at start of level
            Brick.breakableCount = 0;
            SceneManager.LoadScene(name);
        }

        public void Test()
        {
            print("Fun");
        }

        // Precondition:  None
        // Postcondition: Game terminates
        public void QuitRequest()
        {
            Application.Quit();
        }

        // Precondition:  None
        // Postcondition: If all bricks are destroyed, calls LoadNextLevel
        public void BrickDestroyed()
        {
            if (Brick.breakableCount <= 0)
            {
                LoadNextLevel();
            }
        }

        // Precondition:  None
        // Postcondition: Next level loaded
        public void LoadNextLevel()
        {
            // Sets breakableCount to zero at start of each level
            Brick.breakableCount = 0;
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}