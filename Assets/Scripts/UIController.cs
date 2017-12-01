using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;

//////////////////////////////////////////////////////////////////////// 
//                    COMP3064 CRN13899 Midterm                       //
//                       Friday, December 1, 2017                     //
//                    Instructor: Przemyslaw Pawluk                   //
//                     Vishvajit Kher  - 101015270                    //
//                    vishvajit.kher@georgebrown.ca                   //
////////////////////////////////////////////////////////////////////////

public class UIController : MonoBehaviour {

	// PRIVATE INSTANCE VARIABLES
	private int _scoreValue;
	private int _livesValue;
	
	[SerializeField]
	private AudioSource _gameOverSound;

    // PUBLIC INSTANCE VARIABLES
    public int cloudNumber = 3;
	public JeyManager jey;
	public CatManager cat;
	public PlayerManager bird;
	public GemManager gem;
    public GemManager redgem;
	public Text LivesLabel;
	public Text ScoreLabel;
	public Text GameOverLabel;
	public Text HighScoreLabel;
	public Button RestartButton;
	


	// Use this for initialization
	void Start () {
        Player.Instance.gameController = this;
        this._initialize ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//PRIVATE METHODS ++++++++++++++++++
	
	//Initial Method
	private void _initialize() {
        Player.Instance.ScoreValue = 0;
        Player.Instance.LivesValue = 3;


        //Make sure that:
        //bird, cat, jey and gems are visible and working
        //Game over label, high score and button are not visible
        jey.gameObject.SetActive(true);
        cat.gameObject.SetActive(true);
        gem.gameObject.SetActive(true);
        redgem.gameObject.SetActive(true);
        bird.gameObject.SetActive(true);
        GameOverLabel.gameObject.SetActive(false);
        HighScoreLabel.gameObject.SetActive(false);
        LivesLabel.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(false);

	}
	
	public void _endGame() {
        //Display information about score earned
        //Show game over label, high score label and button
        //Make sure that bird, cat, jey and gems are not visible and do not interact
        jey.gameObject.SetActive(false);
        cat.gameObject.SetActive(false);
        gem.gameObject.SetActive(false);
        bird.gameObject.SetActive(false);
        redgem.gameObject.SetActive(false);
        GameOverLabel.gameObject.SetActive(true);
        HighScoreLabel.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }
	
	// PUBLIC METHODS
	
	public void RestartButtonClick() {
		Debug.Log ("<101015270> Restart");
        //Implement restrat of the game
        SceneManager.
            LoadScene(
                SceneManager.GetActiveScene().name);
    }

    public void UpdateUI()
    {
        LivesLabel.text = "Health: " + Player.Instance.LivesValue;
        ScoreLabel.text = "Score: " + Player.Instance.ScoreValue;
        HighScoreLabel.text = "High Score: " + Player.Instance.ScoreValue;
    }
}
