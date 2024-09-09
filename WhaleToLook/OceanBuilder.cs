using System.Collections.Generic;

namespace WhaleToLook;

public class OceanBuilder
{
    public Ocean? Ocean { get; private set; }

    readonly List<OceanBuilder> neighboors = [];
    readonly List<FishSchool> schools = [];

    public void AddOcean(OceanBuilder ocean)
        => neighboors.Add(ocean);
    
    public void AddSchool(FishSchool school)
        => schools.Add(school);
    
    public void Build()
        => Ocean = new Ocean(neighboors, schools);
}