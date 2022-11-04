using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Button _start;
    [SerializeField] Button _quit;
    [SerializeField] GameFacade _facade;

    private void Awake()
    {
        _start.onClick.AddListener(() =>_facade.StartBattle());

        _quit.onClick.AddListener(() => _facade.Quit());
    }

}