using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

  /**
   * Used for updating the display of the score
   */
  public Text scoreText;

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

  protected bool collisionBoundary = false;

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
        if(this.levelController.isTimeOut()) {
          winText.text = "Out of Time!!!";
          this.levelController.repeatLevel();
        }
    }

    /**
     * Happens when physics are applied to the component. Applies force
     * to the object
     */
	void FixedUpdate ()
	{
        if (SystemInfo.deviceType == DeviceType.Handheld) {
            Vector3 movement = new Vector3 (
                Input.acceleration.x,
                0.0f,
                Input.acceleration.y
            );
        } else {
            if(Input.GetKey(KeyCode.UpArrow) && collisionBoundary == false) {
                transform.position += Vector3.forward * this.speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.DownArrow) && collisionBoundary == false) {
                transform.position += Vector3.back * this.speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.LeftArrow) && collisionBoundary == false) {
                transform.position += Vector3.left * this.speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.RightArrow) && collisionBoundary == false) {
                transform.position += Vector3.right * this.speed * Time.deltaTime;
            }
            collisionBoundary = false;
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
              collisionObject.gameObject.SetActive (false);
              SetScoreText();
          }
        }

        if (collisionObject.gameObject.CompareTag("Boundary")) {
            Debug.Log("Hit boundary");
            collisionBoundary = true;
        }
    }

    protected void SetScoreText ()
    {
        pickupsRemaining = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        scoreText.text = "Pickups Left: " + pickupsRemaining.ToString ();
        if (pickupsRemaining <= 0) {
            winText.text = "You Win!";
            this.advanceLevel();
        }
    }

    protected void advanceLevel() {
        levelController.advanceLevel();
    }
}
