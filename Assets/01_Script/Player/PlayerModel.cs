using System.Numerics;

public class PlayerModel
{
    public int heart;
    public float jumpPower = 20f;
    public int atackPower = 1;
    public bool isLanding = false;
    public bool isGuarding = false;
    public float guardCooltime = 3f;

    public bool HeartChange(int h)
    {
        heart += h;
        if (heart < 1)
            return false;
        else
            return true;
    }
    


}
