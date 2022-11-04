using Code.Entities.Ships;
using Code.Entities.Ships.Enemies;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    [SerializeField] EnemySpawner _enemySpawner;
    [SerializeField] ShipInstaller _shipInstaller;
    [SerializeField] ScoreView _scoreView;

    bool _isPlaying;

    public void StartBattle()
    {
        if (_isPlaying == true) return;
        _scoreView.Reset();
        _shipInstaller.CreateMenu();
        _enemySpawner.Create();
        _isPlaying = true;

    }

    public void Quit()
    {
        if (_isPlaying == false) return;
        _shipInstaller.QuitGame();
        _enemySpawner.QuitGame();
        _isPlaying = false;
    }


}
