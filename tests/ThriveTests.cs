using Godot;
using System;
using System.Collections.Generic;

public class ThriveTests : WAT.Test
{
    public override String Title()
    {
        return "WAT unit tests";
    }

    [Test]
    [RunWith("baseMovement", 1, 0.33f, 0.14f)]
    [RunWith("osmoregulation", 1, 0.84f, 0.24f)]
    [RunWith("def", 0.68f, 0.68f, 0.68f)]
    public void CheckGetBarColor(String name, float r, float g, float b)
    {
        Color tested = BarHelper.GetBarColour(SegmentedBar.Type.ATP, name, true);
        Color result = new Color(r, g, b);
        Assert.IsEqual(result ,tested);
    }

    [Test]
    [RunWith(0, "basic",1,100)]
    [RunWith(0, "toxin", 1, 100)]
    [RunWith(0, "pilus", 1, 100)]
    [RunWith(50, "basic", 2, 50)]
    [RunWith(50, "toxin", 2, 75)]
    [RunWith(50, "pilus", 2, 75)]
    [RunWith(100, "basic", 1, 0)]
    [RunWith(200, "basic", 1, 0)]
    public void CheckHPAfterDamage(float amount, String name, float resistance, float result)
    {
       Microbe microbe = new MicrobeResistanceStub(resistance);

       microbe.Damage(amount,name);
        float hp = microbe.Hitpoints;
        Assert.IsEqual(result,hp);
    }

    [Test]
    [RunWith(0,false)]
    [RunWith(50, false)]
    [RunWith(99, false)]
    [RunWith(100, true)]
    [RunWith(101, true)]
    public void CheckIfDead(float damage, bool result)
    {
        Microbe microbe = new MicrobeStub();
        microbe.Damage(damage,"basic");
        Assert.IsTrue(microbe.Dead == result);
    }

    [Test]
    [RunWith(0,0, -300,0, -300)]
    [RunWith(0, 10, -300, 0, -300)]
    [RunWith(-10, 0, -300, 0, -300)]
    [RunWith(10, 10, -300, 0, -300)]
    public void CheckConvertToWorld(int x, int y, float vx, float vy, float vz)
    {
        CompoundCloudPlane ccp = new CompoundCloudPlane();
        Vector3 vec = ccp.ConvertToWorld(x, y);
        

        Assert.IsTrue(new Vector3(vx,vy,vz) == vec);
    }

    [Test]
    [RunWith(0, 0, 0, 0)]
    [RunWith(10, -10, 0, 0.0375)]
    [RunWith(-10, 0, -0.0375, 0.0375)]
    [RunWith(0,10, 0, 0)]
    [RunWith(100, 10, 0, 0)]
    public void CheckFluidVelocity(float x, float y, float rx, float ry)
    {
        Node world = new Node();
        FluidSystem fs = new FluidSystem(world);
        Vector2 vec = fs.VelocityAt(new Vector2(x, y));
        GD.Print(vec);

        Assert.IsTrue(new Vector2(rx,ry) == vec);
    }


}
