using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpTable : MonoBehaviour {

    [System.Serializable]
    public class LevelUpConfig
    {
        public int score;
        public float playerSizeIncrease;
        public float playerSpeedIncrease;
        public float pickupSpeedIncrease;
        public float cameraZoomIncrease;

        public LevelUpConfig(int score, float playerSizeIncrease, float playerSpeedIncrease, float pickupSpeedIncrease, float cameraZoomIncrease)
        {
            this.score = score;
            this.playerSizeIncrease = playerSizeIncrease;
            this.playerSpeedIncrease = playerSpeedIncrease;
            this.pickupSpeedIncrease = pickupSpeedIncrease;
            this.cameraZoomIncrease = cameraZoomIncrease;
        }
    }

    [SerializeField]
    public List<LevelUpConfig> config = new List<LevelUpConfig>();
}
