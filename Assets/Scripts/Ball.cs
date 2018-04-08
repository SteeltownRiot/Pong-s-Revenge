using UnityEngine;

namespace Assets.Scripts
{
    public class Ball : MonoBehaviour {

        private Paddle paddle;				// Instantiating a paddle
        private Vector3 paddleToBallVector;	// Holds distance between paddle and ball
        private bool hasStarted = false;
	
        // Use this for initialization
        void Start () 
        {
            // Allows ball call to find the paddle
            paddle = GameObject.FindObjectOfType<Paddle>();	
		
            // Calculates the paddle to ball vector
            paddleToBallVector = this.transform.position - paddle.transform.position;
        }
	
        // Update is called once per frame
        void Update () 
        {
            if (!hasStarted)
            {
                // Sticks the ball to the paddle
                this.transform.position = paddle.transform.position + paddleToBallVector;
			
                // Wait for user to click to launch ball
                if (Input.GetMouseButtonDown(0))
                {
                    hasStarted = true;
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                }
            }
        }
	
        // Precondition:  Must be passed a Collision2D object
        // Postcondition: Plays ball bounce sound
        //				  Changes ball velocity slightly
        public void OnCollisionEnter2D(Collision2D collision)
        {
            // Randomly assign two small vector corrections
            Vector2 velocityTweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		
            if (hasStarted)
            {
                GetComponent<AudioSource>().Play();
			
                // Nudges ball's velocity with each hit
                GetComponent<Rigidbody2D>().velocity += velocityTweak;
            }
        }
    }
}