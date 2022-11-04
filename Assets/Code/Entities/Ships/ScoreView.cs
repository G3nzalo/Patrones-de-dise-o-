using Code.Entities.Ships.Common;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _txt;

    private int _currentScore;

    public void AddScore(TEAMS killedTeam, int amount)
    {
        if (killedTeam != TEAMS.ENEMY)
        {
            return;
        }
        _currentScore += amount;
        _txt.SetText("Score: " +  _currentScore.ToString());
    }

    public void Reset()
    {
        _currentScore = 0;
        _txt.SetText("Score: " + " ");

    }
}