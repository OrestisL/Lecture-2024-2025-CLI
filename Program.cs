namespace CLI_NTUA_2024;

public class Program
{
    static void Main(string[] args)
    {
        Cube cube1 = new Cube(1.0, 2.0, 3.0, "Cube 1");
        Console.WriteLine(Cube.NumberOfCubes);
        Cube cube2 = new Cube(2.0, 3.0, 4.0, "Cube 2");
        Console.WriteLine(Cube.NumberOfCubes);
        Cube cube3 = Cube.Add(cube1, cube2);
        Console.WriteLine(Cube.NumberOfCubes);
        Console.WriteLine(cube3.ToString());

        MakeCube();
        Console.WriteLine(Cube.NumberOfCubes);

        //Utilities.SaveDataToJson("cube3", cube3.Data);
        CubeData cubeData = new();
        Utilities.LoadDataFromJson<CubeData>("cube3", out cubeData);

        Cube cube4 = new Cube(cubeData);
        Console.WriteLine(cube4.ToString());
    }

    private static void MakeCube() 
    {
        Cube cube = new Cube(0.0, 0.0, 0.0, "Cube");
        Console.WriteLine(Cube.NumberOfCubes);
    }
}
