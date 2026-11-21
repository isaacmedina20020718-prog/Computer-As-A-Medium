using TMPro;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public int points = 0;
    public TMP_Text PointsText;
    // Start is called once before the first execution of Update after the
    //MonoBehaviour is created
    public void AddPoints(int amount)
    {
        points += amount;
        PointsText.text = "Points: " + points;
    }
    // Update is called once per frame
    void Update()
    {
        PointsText.text = "Points: " + points;
    }
}
