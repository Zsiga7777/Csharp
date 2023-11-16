using IOlibrary;
int szam1 = ExtendentConsole.ReadInteger("Kérek egy számot: ");
int szam2 = ExtendentConsole.ReadInteger("Kérek egy másik számot: ");


Console.WriteLine();

int Osszead(int szam1, int szam2) => szam1 + szam2;

int Kivon(int szam1, int szam2) => szam1 - szam2;

int Szoroz(int szam1, int szam2)  => szam1 * szam2;
double Oszt(int szam1, int szam2) => szam1 / (double)(szam2);
