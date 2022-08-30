
public interface IAdapter 
{
    void SetData <T> (T data , string name);
    T GetData <T> (string name);   
}
