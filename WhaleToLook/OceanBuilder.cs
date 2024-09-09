using System.Collections.Generic;

namespace WhaleToLook;

public class OceanBuilder
{
    public Ocean? Ocean { get; private set; }

    readonly List<OceanBuilder> neighboors = [];
    readonly List<FishSchool> schools = [];

    public void AddOcean(OceanBuilder ocean)
        => neighboors.Add(ocean);

    public void AddOceans(IEnumerable<OceanBuilder> ocean)
        => neighboors.AddRange(ocean);
    
    public void AddSchool(FishSchool school)
        => schools.Add(school);

    public void AddSchools(IEnumerable<FishSchool> school)
        => schools.AddRange(school);
    
    public Ocean Build()
        => Ocean = new Ocean(neighboors, schools);
}