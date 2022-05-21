using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IComponent
{
    void Create();
}

public class Composite : IComponent
{
    private List<IComponent> bands = new List<IComponent>();

    public void Add(IComponent component)
    {
        bands.Add(component);
    }

    public void Remove(IComponent component)
    {
        bands.Remove(component);
    }

    public void Create()
    {
        //use SpawnAssotiation
    }
}

