using UnityEngine;

public class Consumer : MonoBehaviour 
{
    private IAdapter _playerPrefDataAdapter;

    private void Awake()
    {
        _playerPrefDataAdapter = new PlayerPrefDataAdapter();

        var data = new Data("dato", 3);

        _playerPrefDataAdapter.SetData(data, "dato");
        Debug.Log(data.Dato1 + " ," + data.Dato2);


        var data1 = _playerPrefDataAdapter.GetData<Data>("dato");
        Debug.Log(data1.Dato1 + " ,  " +  data1.Dato2);
    }
}