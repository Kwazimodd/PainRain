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
    private List<Band> bands = new List<Band>();

    public void Add(Band band)
    {
        bands.Add(band);
    }

    public void Remove(Band band)
    {
        bands.Remove(band);
    }

    public List<Band> GetBands()
    {
        return bands;
    }

    public void Create()
    {
        foreach (var item in bands)
        {
            //create assotiation
        }
    }
}

public class Leaf : IComponent
{
    public void Create()
    {
        //create band
    }
}

