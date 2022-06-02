[System.Serializable]
public class SettingsData
{
    public float SliderValue;

    public SettingsData(SliderController Slider)
    {
        SliderValue = Slider.SliderValue;
    }
}
