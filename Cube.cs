namespace CLI_NTUA_2024;

public class Cube : ISumable<Cube>
{
    public static int NumberOfCubes = 0;
    private CubeData _data = new();
    public CubeData Data { get { return _data; } }
    public string Name { get { return _data.Name; } }
    public double CenterX { get { return _data.X; } }
    public double CenterY { get { return _data.Y; } }
    public double CenterZ { get { return _data.Z; } }

    public Cube(double centerX, double centerY, double centerZ, string name)
    {
        _data.X = centerX;
        _data.Y = centerY;
        _data.Z = centerZ;
        _data.Name = name;
        NumberOfCubes++;
    }

    public Cube(CubeData data)
    {
        _data = data;
        NumberOfCubes++;
    }
    ~Cube() 
    {
        NumberOfCubes--;
    }

    public static Cube Add(Cube item1, Cube item2)
    {
        return new Cube(item1.CenterX + item2.CenterX,
                        item1.CenterY + item2.CenterY,
                        item1.CenterZ + item2.CenterZ,
                        "new cube from adding 2 cubes");
    }

    public override string ToString()
    {
      return string.Format("{0} at ({1}, {2}, {3})", 
                            _data.Name, _data.X, 
                            _data.Y, _data.Z);
    }
}

[Serializable]
public class CubeData
{
    public string Name { get; set; } = "";
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}
