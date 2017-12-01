using UnityEngine;
using System.Collections;

//////////////////////////////////////////////////////////////////////// 
//                    COMP3064 CRN13899 Midterm                       //
//                       Friday, December 1, 2017                     //
//                    Instructor: Przemyslaw Pawluk                   //
//                     Vishvajit Kher  - 101015270                    //
//                    vishvajit.kher@georgebrown.ca                   //
////////////////////////////////////////////////////////////////////////

public class BackgroundManager : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
    [SerializeField]
	public float speed = 5f;
    //add more variables if needed
    [SerializeField]
    private float startX;
    [SerializeField]
    private float endX;


    //PRIVATE INSTANCE VARIABLES
    private Transform _transform;
	private Vector2 _currentPosition;


	
	// Use this for initialization
	void Start () {
		// Make a reference with the Transform Component
		this._transform = gameObject.GetComponent<Transform> ();
        _currentPosition = _transform.position;
		
		// Reset the Ocean Sprite to the Top
		this.Reset ();
	}
	
    // Update is called once per frame
    void Update()
    {
        _currentPosition = _transform.position;
        //move background from right to left
        _currentPosition -= new Vector2(speed, 0);

        //check if we need to reset
        if (_currentPosition.x < endX)
        {
            //reset
            Reset();
        }
        //apply changes
        _transform.position = _currentPosition;

    }
	
    //Resets the current position of the background
	public void Reset() {
        _currentPosition = new Vector2(startX, 0);
    }
}
