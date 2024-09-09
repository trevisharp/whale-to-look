using System.Linq;
using System.Collections.Generic;

namespace WhaleToLook;

public class Ocean(
    IEnumerable<OceanBuilder> neighboors,
    IEnumerable<FishSchool> schools)
{
    public IEnumerable<Ocean> Neighboors => 
        from neighboor in neighboors
        where neighboor.Ocean is not null
        select neighboor.Ocean;

    public IEnumerable<FishSchool> FishSchools => schools;

    public int Fishes => schools.Sum(s => s.Fishes);
}