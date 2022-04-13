using PKHeX.Core;

const uint Seeds = 10;

Console.Write("Please enter your target seed: 0x");
string Input = Console.ReadLine();
uint Seed;
while (!uint.TryParse(Input, System.Globalization.NumberStyles.AllowHexSpecifier, null, out Seed))
{
    Console.WriteLine($"Unable to coerce 0x{Input} as a valid seed!");
    Console.Write("Please enter your target seed: 0x");
    Input = Console.ReadLine();
}
uint[][] results = new uint[Seeds][];
LCRNG rng = RNG.LCRNG;
uint cnt = 0;
for (uint i = 0; i < results.Length; i++)
{
    do
    {
        cnt++;
        Seed = rng.Prev(Seed);
    } while ((Seed >> 16) != 0);
    results[i] = new uint[] { Seed, cnt };
}
Console.WriteLine($"\n{Seeds} Closest 16-bit Seeds:");
foreach (uint[] r in results)
{
    Console.WriteLine($"Seed: 0x{r[0]:X4} | Distance to target: {r[1]}{String.Concat(Enumerable.Repeat(" ", cnt.ToString().Length - r[1].ToString().Length))} | Distance from seed 0: {r[0]}");
}
Console.WriteLine("\nPress [ENTER] to exit:");
Console.ReadLine();
