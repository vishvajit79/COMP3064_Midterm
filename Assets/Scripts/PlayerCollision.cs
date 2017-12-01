using UnityEngine;
using System.Collections;

//////////////////////////////////////////////////////////////////////// 
//                    COMP3064 CRN13899 Midterm                       //
//                       Friday, December 1, 2017                     //
//                    Instructor: Przemyslaw Pawluk                   //
//                     Vishvajit Kher  - 101015270                    //
//                    vishvajit.kher@georgebrown.ca                   //
////////////////////////////////////////////////////////////////////////

public class PlayerCollision : MonoBehaviour {

	// PRIVATE INSTANCE VARIABLES
	private AudioSource[] _audioSources;
	private AudioSource _islandSound;
	private AudioSource _cloudSound;
	
	// PUBLIC INSTANCE VARIABLES
	public UIController gameController;
	
	// Use this for initialization
	void Start () {
		// Initialize the audioSources array
		this._audioSources = gameObject.GetComponents<AudioSource> ();
		this._cloudSound = this._audioSources [1];
		this._islandSound = this._audioSources [2];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*Implement function that will:
    
	- Collect gem (reuse object)
	- Add points when gem collected
	- Decrease life number if collided with jey or cat 
	- Debug.Log each collision
	 */

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //If collision with green gem
        if (collision.gameObject.tag.Equals("gem"))
        {
            Debug.Log("<101015270> Collision with Gem");
            Player.Instance.ScoreValue += 10;
            collision.gameObject.GetComponent<GemManager>().Reset();
        }

        //If collision with green red gem
        if (collision.gameObject.tag.Equals("redgem"))
        {
            Debug.Log("<101015270> Collision with Gem");
            Player.Instance.ScoreValue += 5;
            collision.gameObject.GetComponent<GemManager>().Reset();
        }

        //If collision with green enemy
        if (collision.gameObject.tag.Equals("ENEMY"))
        {
            Debug.Log("<101015270> Collision with Enemy");
            Player.Instance.LivesValue -= 1;
            collision.gameObject.GetComponent<JeyManager>().Reset();
        }
    }

}
