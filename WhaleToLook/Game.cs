using System.Linq;
using System.Collections.Generic;
using System;

namespace WhaleToLook;

public class Game
{
    public Ocean[] Oceans { get; private set; } = [];
    public FishSchool[] Schools { get; private set; } = [];

    Game() { }

    public static Game New(int n = 3, int m = 2)
    {
        var game = new Game();
        
        var oceans = Enumerable.Range(0, n * m)
            .Select(x => new OceanBuilder())
            .ToArray();
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                var crr = oceans[i + n * j];

                (int x, int y)[] indexes = [ 
                    (i - 1, j), (i + 1, j),
                    (i, j - 1), (i, j + 1)
                ];
                
                crr.AddOceans(
                    from p in indexes
                    where p.x >= 0 && p.x < n
                    where p.y >= 0 && p.x < m
                    select oceans[p.x + p.y * n]
                );
            }
        }

        game.Oceans = oceans
            .Select(o => o.Build())
            .ToArray();
        
        int ns = n + 1, 
            ms = m + 1;
        
        List<int> fishes = [
            ..from num in Enumerable.Range(0, ns * ms)
            select num / 2 into fish
            orderby Random.Shared.Next()
            select fish
        ];
        int next() {
            int nextValue = fishes[0];
            fishes.RemoveAt(0);
            return nextValue;
        }
            
        var schools = new FishSchool[ns * ms];

        

        game.Schools = schools;

        return game;
    }
}