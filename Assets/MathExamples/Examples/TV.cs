using UnityEngine;

public class TV
{
    private bool isOn = false;
    private int volume = 10;
    private int channel = 1;

    public void PowerToggle()
    {
        isOn = !isOn; // flips the sign of the bool
    }

    public void SetChannel(int newChannel)
    {
        if (isOn && newChannel > 0 && newChannel <= 100)
        {
            channel = newChannel;
        }
        else
        {
            Debug.Log("Tv is off, or channel is invalid.");
        }
    }
    
    public void AdjustVolume(int change)
    {
        if (isOn)
        {
            volume = Mathf.Clamp(volume + change, 0, 100);
        }
        else
        {
            // tv is off
        }
    }

}
/// <summary>
/// 
/// </summary>
public class TVRemote : MonoBehaviour
{
    private void Start()
    {
        TV myTv = new TV();

        myTv.PowerToggle();
        myTv.SetChannel(5);
        myTv.AdjustVolume(10);
        myTv.PowerToggle(); // turn it back off
    }
}


