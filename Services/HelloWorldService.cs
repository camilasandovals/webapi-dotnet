public class HelloWorldService : IHelloWorldService
{
    public string GetHelloWorld()
    {
        return "Hello World!";
    }

    public string GetHelloWorld2() //this method wont be visible
    {
        return "Hello World2!";
    }
}

public interface IHelloWorldService
{
    string GetHelloWorld();
}