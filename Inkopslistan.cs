List<string> items = new();
List<int> prices = new();

bool firstTime = true;

// An eternal loop that keeps the program running
while (true)
{
    int index;

    PrintItems();

    PrintUsage();
    string input = Console.ReadLine()!;

    if (input.ToLower().Equals("avsluta"))
        break;

    if (input.ToLower().Equals("dyrast"))
        PrintMostExpensive();

    else if (int.TryParse(input, out index))
        RemoveItem(index);

    else
    {
        int price;

        while (true)
        {
            Console.Write("Ange varans pris: ");

            if (int.TryParse(Console.ReadLine(), out price))
            {
                AddItem(input, price);
                break;
            }
            else
                Console.Write("Priset måste vara i hela kronor. ");
        }
    }
}

void PrintItems()
{
    for (int i = 0; i < items.Count; i++)
        Console.WriteLine($"{i + 1}. {items[i]} - {prices[i]}");
}

void PrintUsage()
{
    if (!firstTime)
    {
        Console.WriteLine("");
        Console.WriteLine("---------------------------------------------");
    }
    else
        firstTime = false;

    Console.WriteLine("Skriv namnet på en ny vara för att lägga till i inköpslistan.");
    Console.WriteLine("Numret på en befintlig vara tar bort den.");
    Console.WriteLine("DYRAST visar dyraste varan.");
    Console.WriteLine("AVSLUTA stänger ner programmet.");
    Console.Write("Vad vill du göra: ");
}

void PrintMostExpensive()
{
    int selected = -1;

    for (int i = 0; i < prices.Count; i++)
    {
        if (selected < 0)
            selected = i;
        else if (prices[i] > prices[selected])
            selected = i;
    }

    if (selected >= 0)
        Console.WriteLine($"Dyraste varan är {selected + 1}. {items[selected]} - {prices[selected]}");
}

void RemoveItem(int index)
{

}

void AddItem(string input, int price)
{

}
