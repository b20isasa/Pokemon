using Newtonsoft.Json;

public class LoopModell
{
    public List<NesladeElement> abilities;  // 
    public string id { get; set; }
    public string name { get; set; }
    [JsonProperty("url")] // för att kunna byta från "url" till "image". 
    public string image { get; set; }

}

public class NesladeElement
{
    public Ability ability { get; set; }
}

public class Ability
{
    public string Name { get; set; }
    public string url { get; set; }
}
