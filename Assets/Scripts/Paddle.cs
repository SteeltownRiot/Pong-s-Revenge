using UnityEngine;

namespace Assets.Scripts
{
    public class Paddle : MonoBehaviour {

        public bool autoPlay = false;	//
	
        private Ball ball;	// 

        // Use this for initialization
        void Start () 
        {
            ball = GameObject.FindObjectOfType<Ball>();
        }
	
        // Update is called once per frame
        void Update () 
        {
            if (!autoPlay)
            {
                MoveNormally();
            }
            else
            {
                PlayTest();
            }
        }
	
        void MoveNormally ()
        {
            Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);	// Holds x, y, z position of the mouse
            float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;		// Holds mouse position in world units
		
            // Limits paddle's x coordinate to the game space
            paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1f, 15f);
            this.transform.position = paddlePos;
        }
	
        void PlayTest()
        {
            Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);	// Holds x, y, z position of the mouse
            Vector3 ballPos = ball.transform.position;		// Holds ball position in world units

            // Limits paddle's x coordinate to the game space
            paddlePos.x = Mathf.Clamp(ballPos.x, 1f, 15f);
            this.transform.position = paddlePos;
        }
    }
}
