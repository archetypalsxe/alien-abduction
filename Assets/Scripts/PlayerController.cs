using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

  /**
   * Used for updating the display of the score
   */
  public Text scoreText;

  public float sizeIncrease = 0.3f;

  public int scoreLevelThreshold = 5;

  public float laserPickupTime = 0.01f;

  public float maxSize = 40f;

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
  public float speedMultiplier = 1.1f;
  public float pickupSpeedMultiplier = 1.1f;

  protected float pickupScore = 0f;


  /**
   * The force when on a mobile device
   */
  protected float mobileForce = 180.0f;

  /**
   * How many of the pickups have been collected
   */
  private int pickupsRemaining;

    public int level = 0;
    private LevelUpTable levelUpTable;
    public float growAnimationDurationSeconds = .3f;

    /**
     * Called when the game is started, the first frame
     */
	void Start()
	{
        SetScoreText();
        winText.text = "";
        levelUpTable = GetComponent<LevelUpTable>();
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
          float highScore = HighScoreStorage.GetHighScore();
          if(pickupScore >= highScore) {
              winText.text = "Congratulations! High score: " + pickupScore;
              if(pickupScore != highScore) {
                  HighScoreStorage.SetHighScore(pickupScore);
              }
          } else {
              winText.text = "Out of Time! Your score was: " + pickupScore;
          }
        }
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
              if (isBigEnough(collisionObject)) {
                   if(collisionObject.gameObject.GetComponent<PickUpController>().isTriggered()) {
                   } else {
                      collisionObject.gameObject.GetComponent<PickUpController>().setTriggered();
                      StartCoroutine(waitForTrigger(collisionObject));
                   }
              } else {
              }
          }
        } else {
        }
    }

    void OnTriggerExit (Collider collisionObject) {
        PickUpController controller = collisionObject.gameObject.GetComponent<PickUpController>();
        if(controller) {
            controller.setNotTriggered();
        } else {
            Debug.LogWarning("Object did not have pickup controller");
        }
    }

    void pickUpObtained(float score)
    {
        pickupScore += score;
        if (pickupScore >= levelUpTable.config[level].score)
            {
            if (level < levelUpTable.config.Count)
            {
                levelUp();
            } else
            {
            }
        }
        SetScoreText();
    }

    protected void SetScoreText ()
    {
        //pickupsRemaining = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        scoreText.text = "Score: " + pickupScore.ToString ();
    }

    protected bool isBigEnough(Collider collisionObject) {
        float playerWidth = GetComponent<Renderer>().bounds.size.x;

        //Try the parent renderer
        Transform parent = collisionObject.gameObject.transform.parent;
        if(parent) {
            Renderer parentRenderer = parent.gameObject.GetComponent<Renderer>();
            if(parentRenderer) {
                return parentRenderer.bounds.size.x <= playerWidth;
            }
        }

        //Current Renderer
        Renderer currentRenderer = collisionObject.gameObject.GetComponent<Renderer>();
        if(currentRenderer) {
            return currentRenderer.bounds.size.x <= playerWidth;
        }

        //Child Renderer
        Renderer childRenderer = collisionObject.gameObject.GetComponentInChildren<Renderer>();
        if(childRenderer) {
            return childRenderer.bounds.size.x <= playerWidth;
        }


        // Fall back to current collision object
        return collisionObject.bounds.size.x <= playerWidth;
    }

    protected void levelUp() {
        if (transform.localScale.x < maxSize)
        {
            level++;
            PickUpController.globalAbductSpeedOffset += levelUpTable.config[level].pickupSpeedIncrease;
            Camera.main.GetComponent<CameraController>().heightOffset += levelUpTable.config[level].cameraZoomIncrease;
            StartCoroutine(StartLevelUp(levelUpTable.config[level].playerSizeIncrease, levelUpTable.config[level].playerSpeedIncrease));
        }
    }

    IEnumerator StartLevelUp(float sizeIncrease, float playerSpeedIncrease)
    {
        Vector3 finalSize = transform.localScale + new Vector3(sizeIncrease, 0, sizeIncrease);
        float finalSpeed = speed + playerSpeedIncrease;
        float timeLeft = growAnimationDurationSeconds;
        while(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            transform.localScale += new Vector3(sizeIncrease, 0, sizeIncrease) * (Time.deltaTime/growAnimationDurationSeconds);
            speed += playerSpeedIncrease * Time.deltaTime / growAnimationDurationSeconds;
            yield return 0;
        }
        speed = finalSpeed;
        transform.localScale = finalSize;
    }

    IEnumerator waitForTrigger(Collider collisionObject) {
        PickUpController pickUpController = collisionObject.gameObject.GetComponent<PickUpController>();
        pickUpController.StartShaking();
        yield return new WaitForSeconds(laserPickupTime);
        if(pickUpController.isTriggered()) {
            abductObject(collisionObject);
            pickUpObtained(collisionObject.gameObject.GetComponent<PickUpController>().pointValue);
        }
    }

    protected void abductObject(Collider collisionObject) {
        PickUpController controller = collisionObject.gameObject.GetComponent<PickUpController>();
        if(controller) {
            controller.Animate(pickupSpeedMultiplier * (level + 1));
        }
    }
}
