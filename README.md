# Commander

Like the ASP.NET MVC Controller, but for Console Applications.

## Basic Usage

Similar to the Controller from ASP.NET MVC, we create a class in which to inherit from Controller, and specify which methods will correspond to the commands, using the attributes.

```C#
[Command("chat")]
public class ChatController : Controller
{
  [Command("new room")]
  public void NewRoom(string name)
  {
    Console.WriteLine($"Room '{name}' successfully created");
  }
}
```

*For more detailed examples, please take a look at the Chiral.Commander.Tests project.*

### Console Execution

Following the example above, the command shown below will invoke the corresponding method "NewRoom" of the class "ChatController".

```
$ chat new room agartha
$ Room 'agartha' successfully created
```

## Project Status

This project is currently under development and is not considered stable.

## License

MIT
