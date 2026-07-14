
//this method is able to be accessed by ALL scripts in the project because it's static. Doesn't need a using statement
//when making static classes, everything have to be static.
//not good to store variables in static.
public static class Utilities
{
    public static string DEVICE_ID;
    public static float CalculateValues(float input1,float input2)
    {
        return input1 * input2;
    }
}

