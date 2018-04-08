using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Brick : MonoBehaviour {
	
	public AudioClip breakSound;			// 
	public Sprite[] damagedSprites;			// Array of damaged brick sprites
	public static int breakableCount = 0;	// Holds number of breakable bricks at any given time
	
	private int timesHit;					// Stores how many times the brick has been hit
	private LevelManager levelManager;		// Instantiates a level manager
	private bool isBreakable;				// Checks brick's tag to see if it is breakable
	
	// Use this for initialization
	void Start () 
	{
		isBreakable = (this.tag == "Breakable");
		
		if (isBreakable)
		{ breakableCount ++; 	/*print (breakableCount);*/ }
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	// Precondition:  Must be passed a Collision2D object
	// Postcondition: If brick is breakable, HandleHits is called
	void OnCollisionEnter2D (Collision2D collision)
	{		
		if (isBreakable)
		{ 
			HandleHits(); 	
//			print (breakableCount);
		}
	}
	
	// Precondition:  None
	// Postcondition: Updates number of times brick has been hit
	//				  If at maxHits destroys brick
	//				  Updates total number of breakable bricks in scene
	void HandleHits ()
	{
		// Increments number of times brick has been hit
		timesHit ++;
		
		// Sets max hits equal to sprite array lenght +1
		int maxHits = damagedSprites.Length + 1;	// Holds how many times the brick can be hit
		
		if (timesHit >= maxHits)
		{
			float volume = 0.1f;	// Tones volume down
			
			breakableCount--;
//			Debug.Log(breakableCount);
			AudioSource.PlayClipAtPoint (breakSound, transform.position, volume);
			// Tells LevelManager a brick was destroyed
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		}
		else
		{ LoadSprites(); }
	}
	
	// Precondition:  None
	// Postcondition: Updates brick sprite when damaged
	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;	// Holds index of damaged sprite based on number of times original can be hit
		
		if (damagedSprites[spriteIndex])
		{ this.GetComponent<SpriteRenderer>().sprite = damagedSprites[spriteIndex]; }
		else { Debug.LogError("Brick sprite not loaded"); }
	}
}