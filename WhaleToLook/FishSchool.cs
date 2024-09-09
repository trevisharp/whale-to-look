using System.Collections.Generic;

namespace WhaleToLook;

public class FishSchool(int fishes, params Ocean[] neighboors)
{
    public int Fishes => fishes;

    public IEnumerable<Ocean> Neighbors => neighboors;
}