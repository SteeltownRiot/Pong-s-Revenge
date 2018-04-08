using UnityEngine;

namespace Assets.Scripts
{
    public class LoseCollider : MonoBehaviour
    {
        private LevelManager levelManager;	// Instantiates the level manager
	
        // Precondition:  Must be passed a Collider2D object
        // Postcondition: 
        void OnTriggerEnter2D (Collider2D trigger)
        {
            // Allows lose collider to find the level manager
            levelManager = GameObject.FindObjectOfType<LevelManager>();
		
            levelManager.LoadLevel("Lose");
        }
    }
}