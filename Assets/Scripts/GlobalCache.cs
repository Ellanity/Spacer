public class GlobalCache
{
    public static GlobalCache Inst = new GlobalCache();
    public int Gold = 123532465;
    public int Gems = 0;

    public int ShipTexture = 0;
    public int ShipBought = 1;
    
    public int Score = 0;
    public int MaxScore = 0;

    public bool BossDefeated = false;
    public float PlayerAngle = 0f;
}
