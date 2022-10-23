/*

Obiective: înțelegerea tipului de date record si al tipului choice/discriminated union [1,2]

Sarcina 1

Folosind comanda dontnet [3] creați o aplicație consolă.

Sarcina 2

Folosind Visual Studio Code [4]:

implementați un tip de date imutabil pentru a reprezenta o comanda ce conține un contact (nume, prenume, nr. telefon, adresă) și o listă de produse (cod produs și cantitate exprimată în unități sau kg).
cantitatea va fi implementată folosind CShapr Choices [2]
Aplicația consolă trebuie să permită crearea unei comenzi, adăugarea de produse în comandă și specificarea cantității in Kg sau unitați pentru fiecare produs adăugat.

Referințe

[1] https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/discriminated-unions

[2] https://www.nuget.org/packages/CSharp.Choices/

[3] https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet

[4] https://code.visualstudio.com/

*/

namespace Tema1
{
    class ImutabilitateEx
    {
        static void Main(string[] args)
        {

            int opt = 0;

            do
            {
                Console.WriteLine("==============================");
                Console.WriteLine("0.Iesire");
                Console.WriteLine("1.Creare comanda");
                Console.WriteLine("==============================");

                Console.WriteLine("Optiunea: ");
                opt = Convert.ToInt32(Console.ReadLine());

                switch (opt)
                {

                    case 1:

                        int opt1 = 0;
                        List<Produse> listaProduse = new List<Produse>();

                        do
                        {
                            Console.WriteLine("==============================");
                            Console.WriteLine("1. Adaugare produs");
                            Console.WriteLine("2. Plasare comanda");
                            Console.WriteLine("3. Anulare comanda");
                            Console.WriteLine("==============================");

                            Console.WriteLine("Optiunea: ");
                            opt1 = Convert.ToInt32(Console.ReadLine());

                            switch (opt1)
                            {

                                case 1:

                                    string? codProdus;
                                    int unitMasura;

                                    Console.WriteLine("Cod Produs: ");
                                    codProdus = Console.ReadLine();
                                    Console.WriteLine("Unitate de masura: 1-kg/0-unitati");
                                    unitMasura = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Cantitate:");

                                    if (unitMasura == 1)
                                    {
                                        float Kg;
                                        if (!float.TryParse(Console.ReadLine(), out Kg))
                                        {
                                            Console.WriteLine("Not a valid float");
                                        }
                                        else
                                        {
                                            Produse produs = new Produse(codProdus, Kg);
                                            listaProduse.Add(produs);
                                        }
                                    }
                                    else if (unitMasura == 0)
                                    {
                                        int unitati = Convert.ToInt32(Console.ReadLine());
                                        Produse produs = new Produse(codProdus, unitati);
                                        listaProduse.Add(produs);
                                    }

                                    break;

                                case 2:

                                    string? nume;
                                    string? prenume;
                                    string? telefon;
                                    string? adresa;

                                    Console.WriteLine("==============================");
                                    Console.WriteLine("Nume: ");
                                    nume = Console.ReadLine();
                                    Console.WriteLine("Prenume: ");
                                    prenume = Console.ReadLine();
                                    Console.WriteLine("telefon: ");
                                    telefon = Console.ReadLine();
                                    Console.WriteLine("Adresa: ");
                                    adresa = Console.ReadLine();
                                    Console.WriteLine("==============================");

                                    Comanda comanda = new Comanda(nume, prenume, telefon, adresa, listaProduse);

                                    break;

                                case 3:
                                    listaProduse.Clear();
                                    break;
                            }

                        } while (opt1 != 3);
                        break;

                    case 0:
                    default:
                        System.Environment.Exit(1);
                        break;
                }
            } while (opt != 0);

        }
    }

    class Produse
    {

        private readonly string? codProdus;
        private readonly float CantitateKg;
        private readonly int CantitateUnitati;

        public Produse(string? codProdus, float CantitateKg)
        {
            this.codProdus = codProdus;
            this.CantitateKg = CantitateKg;
        }

        public Produse(string? codProdus, int cantitateUnitati)
        {
            this.codProdus = codProdus;
            this.CantitateUnitati = cantitateUnitati;
        }

    }

    class Comanda
    {
        private readonly string? nume;
        private readonly string? prenume;
        private readonly string? telefon;
        private readonly string? adresa;
        private readonly List<Produse> listaProduse;

        public Comanda(string? nume, string? prenume, string? telefon, string? adresa, List<Produse> listaProduse)
        {

            this.nume = nume;
            this.prenume = prenume;
            this.telefon = telefon;
            this.adresa = adresa;
            this.listaProduse = listaProduse;
        }
    }
}