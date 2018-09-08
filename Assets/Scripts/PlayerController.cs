﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

  /**
   * Used for updating the display of the score
   */
  public Text scoreText;

  public float sizeIncrease = 0.3f;

  public int scoreLevelThreshold = 5;

  /**
   * The text that is displayed when you collect all of the pickups
   */
  public Text winText;

  // The controller of the level
  public LevelController levelController;

  /**
   * Multiplier of the ball movement, makes the ball move faster
   */
  public float speed = 10.0f;

  protected int pickUpsObtained = 0;

  /**
   * The force when on a mobile device
   */
  protected float mobileForce = 180.0f;

  /**
   * How many of the pickups have been collected
   */
  private int pickupsRemaining;

  /**
   * Called when the game is started, the first frame
   */
	void Start()
	{
        SetScoreText();
        winText.text = "";
	}

    /**
     * Called every frame update
     */
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true) {
            Application.Quit();
        }
        /*if(this.levelController.isTimeOut()) {
          winText.text = "Out of Time!!!";
          this.levelController.repeatLevel();
        }*/
    }

    /**
     * Happens when physics are applied to the component. Applies force
     * to the object
     */
	void FixedUpdate ()
	{
        if (SystemInfo.deviceType == DeviceType.Handheld) {
            /*Vector3 movement = new Vector3 (
                Input.acceleration.x,
                0.0f,
                Input.acceleration.y
            );*/
        } else {
            if(Input.GetKey(KeyCode.UpArrow)) {
                transform.position += Vector3.forward * this.speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.DownArrow)) {
                transform.position += Vector3.back * this.speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.LeftArrow)) {
                transform.position += Vector3.left * this.speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.RightArrow)) {
                transform.position += Vector3.right * this.speed * Time.deltaTime;
            }
        }
	}

    /**
     * When the player game colides into something. Tests to see if it is
     * a pickup object, and if it is, deactivate it
     */
    void OnTriggerEnter (Collider collisionObject)
    {
        if(!this.levelController.isTimeOut()) {
          if (collisionObject.gameObject.CompareTag("Pick Up")) {
              Debug.Log("Pick up!");
              if (isBigEnough(collisionObject)) {
                  collisionObject.gameObject.SetActive (false);
                  pickUpObtained();
              } else {
                Debug.Log("Not Big enough!");
              }
          }
        }
    }

    void pickUpObtained() {
          pickUpsObtained++;
          if (pickUpsObtained % scoreLevelThreshold == 0) {
              levelUp();
          }
          SetScoreText();
    }

    protected void SetScoreText ()
    {
        //pickupsRemaining = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        scoreText.text = "Score: " + pickUpsObtained.ToString ();
    }

    protected bool isBigEnough(Collider collisionObject) {
        return collisionObject.gameObject.GetComponent<Renderer>().bounds.size.x <= GetComponent<Renderer>().bounds.size.x;
    }

    protected void levelUp() {
        transform.localScale += new Vector3(sizeIncrease, 0, sizeIncrease);
    }

    protected void advanceLevel() {
        levelController.advanceLevel();
    }
}
