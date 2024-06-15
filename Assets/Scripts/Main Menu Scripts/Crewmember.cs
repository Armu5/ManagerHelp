using UnityEngine;

[System.Serializable]
public class CrewMember
{
    public string name;
    public string cardInfo;
    public int cost;
    public Sprite image;

    public CrewMember(string name, string cardInfo, int cost, Sprite image)
    {
        this.name = name;
        this.cardInfo = cardInfo;
        this.cost = cost;
        this.image = image;
    }
}
