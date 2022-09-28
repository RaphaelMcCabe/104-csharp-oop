// See https://aka.ms/new-console-template for more information



Console.WriteLine(Supermath.Lerp(0f, 100f, 0.1f));


public static class Supermath
{
    public static float Lerp(float from, float to, float t)
    {
        return from + (to - from) * t;
    }

}