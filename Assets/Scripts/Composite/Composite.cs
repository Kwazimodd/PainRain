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

    public void Add(Band band)
    {
        bands.Add(band);
    }

    public void Remove(Band band)
    {
        bands.Remove(band);
    }

    public void Create()
    {
        //use SpawnAssotiation
    }
}

