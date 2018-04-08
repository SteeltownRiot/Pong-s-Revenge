using UnityEngine;

namespace Assets.Scripts
{
    public class MusicPlayer : MonoBehaviour {

        static MusicPlayer _instance = null;	// Class-level music player
	
        void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            { 
                _instance = this;
                GameObject.DontDestroyOnLoad(gameObject);
            }
        }
	
        // Use this for initialization
        void Start () 
        {

        }
	
        // Update is called once per frame
        void Update () 
        {
	
        }
    }
}
