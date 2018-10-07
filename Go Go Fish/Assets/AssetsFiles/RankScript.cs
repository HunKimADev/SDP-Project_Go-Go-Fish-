using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RankScript : MonoBehaviour {

    public GameObject rank;
    public GameObject score;
    public void SetScore(string score, string rank)
    {
        this.rank.GetComponent<Text>().text = rank;
        this.score.GetComponent<Text>().text = score;
    }
}
