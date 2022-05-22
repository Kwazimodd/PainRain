class Director
{
    private IBuilder builder;

    public IBuilder Builder { set { builder = value; } }

    public void BuildMinimalBand()
    {
        switch (UnityEngine.Random.Range(0,4))
        {
            case 0:
                builder.BuildPartA();
                break;
            case 1:
                builder.BuildPartB();
                break;
            case 2:
                builder.BuildPartC();
                break;
            case 3:
                builder.BuildPartD();
                break;
        }
    }

    public void BuildFullBand()
    {
        builder.BuildPartA();
        builder.BuildPartB();
        builder.BuildPartC();
        builder.BuildPartD();
    }

    public void BuildRandomBand()
    {
        if (UnityEngine.Random.Range(0, 2) == 1)
        {
            builder.BuildPartA();
        }
        if (UnityEngine.Random.Range(0, 2) == 1)
        {
            builder.BuildPartB();
        }
        if (UnityEngine.Random.Range(0, 2) == 1)
        {
            builder.BuildPartC();
        }
        if (UnityEngine.Random.Range(0, 2) == 1)
        {
            builder.BuildPartD();
        }
    }
}

