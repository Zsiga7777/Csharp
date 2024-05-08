
    public abstract class Vehicle
    {
    //Az öröklött osztályban felüldefiniálhatom  (override)
    // de nem vagyok köteles ezt megtenni
    public virtual void Horn()
    {
        Console.Beep(1000, 800);
    }

    public abstract void Error();
    }

