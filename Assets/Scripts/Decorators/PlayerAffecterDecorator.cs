using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface Affect
{
    public abstract void DoAffect(Player player);
}

public class DoNothing : Affect
{
    public void DoAffect(Player player)
    {
        // do nothing
    }
}


public abstract class PlayerAffecterDecorator : Affect
{
    protected Affect _affect;

    public PlayerAffecterDecorator(Affect affect)
    {
        this._affect = affect;
    }

    public void SetAffect(Affect affect)
    {
        this._affect = affect;
    }

    public virtual void DoAffect(Player player)
    {
        if (_affect != null)
        {
            this._affect.DoAffect(player);
        }
    }
}

public class DoDamage : PlayerAffecterDecorator
{
    public DoDamage(Affect affect) : base(affect)
    {
    }

    public override void DoAffect(Player player)
    {
        base.DoAffect(player);
        player.GetDamage(0.2f);
    }
}

public class SlowDown : PlayerAffecterDecorator
{
    public SlowDown(Affect affect) : base(affect)
    {
    }

    public override void DoAffect(Player player)
    {
        base.DoAffect(player);
        player.GetSlowDowned(0.3f);
    }
}

