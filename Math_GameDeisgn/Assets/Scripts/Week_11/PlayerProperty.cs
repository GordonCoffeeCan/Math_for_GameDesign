using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour {

    public string playerAccount = "";
    public enum Occupation {
        Warrior,
        Mage,
        Paladin,
        Hunter,
        Shaman,
        Druid
    }
    public Occupation occupation;
    public int level = 0;
    public int health = 0;
    public enum Weapon {
        Sword,
        Firelock,
        TwohandedSwords,
        Wand,
        Crossbow,
    }
    public Weapon weapon;
    public int enemyKilled = 0;
    public int score = 0;
    public float gameTime = 0;

    public enum GameResult {
        Win,
        Lose
    }
    public GameResult gameResult;

    // Use this for initialization
    void Start () {
        occupation = (Occupation)Random.Range(0, 6);
        level = Random.Range(1, 61);
        health = level * (50 + level);
        weapon = (Weapon)Random.Range(0, 5);
        enemyKilled = Random.Range(1, 21);
        score = enemyKilled * 10;
        gameTime = Random.Range(180, 951);
        gameResult = (GameResult)Random.Range(0, 2);

        Tinylytics.AnalyticsManager.LogCustomMetric("Player Account", this.playerAccount);
        Tinylytics.AnalyticsManager.LogCustomMetric("Occupation", this.occupation.ToString());
        Tinylytics.AnalyticsManager.LogCustomMetric("Level", this.level.ToString());
        Tinylytics.AnalyticsManager.LogCustomMetric("Health", this.health.ToString());
        Tinylytics.AnalyticsManager.LogCustomMetric("Weapon", this.weapon.ToString());
        Tinylytics.AnalyticsManager.LogCustomMetric("Enemies Killed", this.enemyKilled.ToString());
        Tinylytics.AnalyticsManager.LogCustomMetric("Score", this.score.ToString());
        Tinylytics.AnalyticsManager.LogCustomMetric("Win or Lose?", this.gameResult.ToString());
        Tinylytics.AnalyticsManager.LogCustomMetric("Game Time", this.gameTime.ToString() + " Second");

        if (level >= 30 && gameResult == GameResult.Lose) {
            Tinylytics.AnalyticsManager.LogCustomMetric("Game Rate", "This Game is TOO HARD!");
        } else if(level <= 15 && gameResult == GameResult.Win) {
            Tinylytics.AnalyticsManager.LogCustomMetric("Game Rate", "This Game is TOO EASY!");
        }else {
            Tinylytics.AnalyticsManager.LogCustomMetric("Game Rate", "This Game is nice Balanced!");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
