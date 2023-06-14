using System.Numerics;

public class PlayerModel
{
    public int heart=3;
    public float jumpPower = 20f;
    public int atackPower = 1;
    public bool isLanding = false;
    public bool isGuarding = false;
    public bool isAlive = true;
    public float guardCooltime = 3f;


    public bool HeartChange(int h)
    {
        heart += h;
        if (heart > 0)
            return true;
        else
            return false;
    }
    


}
