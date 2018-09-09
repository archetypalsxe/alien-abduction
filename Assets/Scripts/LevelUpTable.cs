using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpTable : MonoBehaviour {

    [System.Serializable]
    public class LevelUpConfig
    {
        public int score;
        public float sizeIncrease;

        public LevelUpConfig(int score, float size)
        {
            this.score = score;
            this.sizeIncrease = size;
        }
    }

    [SerializeField]
    public List<LevelUpConfig> config = new List<LevelUpConfig>();
}
