using Server;
using Server.Items;


public class PlainTobaccoApple : BaseTobaccoFlavoured
{
    public override void OnSmoke(Mobile m)
    {
        m.SendMessage("Jablkowy dym tytoniowy napelnia twoje pluca.");

        m.Emote("*wypuszcza z ust kleby fajkowego dymu roztaczajac jablkowy aromat*");
        Effects.SendLocationParticles(EffectItem.Create(m.Location, m.Map, EffectItem.DefaultDuration), 0x3728, 1, 13, 9965);
        m.PlaySound(0x15F);
        m.RevealingAction();
    }

    [Constructable]
    public PlainTobaccoApple() : this(1)
    {
    }

    [Constructable]
    public PlainTobaccoApple(int amount) : base(amount)
    {
        Name = "tyton pospolity";
        Hue = 2129;
        Flavour = TobaccoFlavour.Apple;
    }

    public PlainTobaccoApple(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);

        writer.Write((int)0); // version
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);

        int version = reader.ReadInt();
    }
}

public class PlainTobaccoPear : BaseTobaccoFlavoured
{
    public override void OnSmoke(Mobile m)
    {
        m.SendMessage("Gruszkowy dym tytoniowy napelnia twoje pluca.");

        m.Emote("*wypuszcza z ust kleby fajkowego dymu roztaczajac gruszkowy aromat*");
        m.PlaySound(0x15F);
        m.RevealingAction();
    }

    [Constructable]
    public PlainTobaccoPear() : this(1)
    {
    }

    [Constructable]
    public PlainTobaccoPear(int amount) : base(amount)
    {
        Name = "tyton pospolity";
        Hue = 2129;
        Flavour = TobaccoFlavour.Pear;
    }

    public PlainTobaccoPear(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);

        writer.Write((int)0); // version
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);

        int version = reader.ReadInt();
    }
}

public class PlainTobaccoLemon : BaseTobaccoFlavoured
{
    public override void OnSmoke(Mobile m)
    {
        m.SendMessage("Cytrusowy dym tytoniowy napelnia twoje pluca.");

        m.Emote("*wypuszcza z ust kleby fajkowego dymu roztaczajac cytrusowy aromat*");
        m.PlaySound(0x15F);
        m.RevealingAction();
    }

    [Constructable]
    public PlainTobaccoLemon() : this(1)
    {
    }

    [Constructable]
    public PlainTobaccoLemon(int amount) : base(amount)
    {
        Name = "tyton pospolity";
        Hue = 2129;
        Flavour = TobaccoFlavour.Lemon;
    }

    public PlainTobaccoLemon(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);

        writer.Write((int)0); // version
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);

        int version = reader.ReadInt();
    }
}