using UnityEngine;

public abstract class Person 
{
    public abstract string IntroductionPhrase();
}

public class ConstructionWorker : Person
{
    public override string IntroductionPhrase()
    {
        return "I am a construction Worker";
    }
}

public class Wizard : Person
{
    public override string IntroductionPhrase()
    {
        return "I am a wizard";
    }
}
