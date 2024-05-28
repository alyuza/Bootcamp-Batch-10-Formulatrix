class GameController : IDisposable
{
  // public List<int> totalCards;
  // public List<object> allCards;
  // public ExternalResource externalResource;
  private bool disposed = false;
  protected virtual void Dispose(bool disposing)
  {
    if (!disposed)
    {
      if (disposing)
      {
        Console.WriteLine("managed resource deleted");
      }
      disposed = true;
      Console.WriteLine("unmanaged resource deleted");
    }
  }

  ~GameController()
  {
    Dispose(disposing: false);
  }

  public void Dispose()
  {
    Dispose(disposing: true);
    GC.SuppressFinalize(this);
  }
}

public class ExternalResource()
{

}