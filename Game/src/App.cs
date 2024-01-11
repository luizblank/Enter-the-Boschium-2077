public static class App
{
    public static
    private static IApp app = null;
    private static void init()
    {
        if (app is not null)
            return;
        
        app = new IApp();
    }

    public static void Open()
    {
        throw new System.NotImplementedException();
    }
    public static void Close()
    {
        throw new System.NotImplementedException();
    }

    public static void Frame()
    {
        throw new System.NotImplementedException();
    }
}
