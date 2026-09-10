List<string> items = new();
List<int> prices = new();

bool firstTime = true;
bool simpleMessage = false;

// An eternal loop that keeps the program running
while (true)
{
    int index;

    PrintItems();
    PrintUsage();
    simpleMessage = false;

    string input = Console.ReadLine()!;

    // Avsluta programmet
    if (input.ToLower().Equals("avsluta"))
        break;

    // Visa dyraste varan
    if (input.ToLower().Equals("dyrast"))
        PrintMostExpensive();

    // Visa billigaste varan
    else if (input.ToLower().Equals("billigast"))
        PrintLeastExpensive();

    // Ta bort en vara
    else if (int.TryParse(input, out index))
    {
        if (!RemoveItem(index - 1))
        {
            Console.WriteLine("Den varan finns inte.");
            simpleMessage = true;
        }
    }

    // Lägg till en vara
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

// Prints the item list
void PrintItems()
{
    if (simpleMessage)
        return;

    if (items.Count > 0)
    {
        Console.WriteLine();
        Console.WriteLine("Varor");
        Console.WriteLine("--------------");
    }

    for (int i = 0; i < items.Count; i++)
        Console.WriteLine($"{i + 1}. {items[i]} - {prices[i]} kr");
}

// Informs the user of what to do
void PrintUsage()
{
    if (!simpleMessage)
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
        Console.WriteLine("DYRAST/BILLIGAST visar dyraste/billigaste varan.");
        Console.WriteLine("AVSLUTA stänger ner programmet.");
    }
    Console.Write("Vad vill du göra: ");
}

// Prints the most expensive item
void PrintMostExpensive()
{
    int selected = -1;

    for (int i = 0; i < prices.Count; i++)
    {
        if (selected < 0 || prices[i] > prices[selected])
            selected = i;
    }

    if (selected >= 0)
    {
        Console.WriteLine($"Dyraste varan är {selected + 1}. {items[selected]} - {prices[selected]} kr");
        simpleMessage = true;
    }
}

// Prints the most expensive item
void PrintLeastExpensive()
{
    int selected = -1;

    for (int i = 0; i < prices.Count; i++)
    {
        if (selected < 0 || prices[i] < prices[selected])
            selected = i;
    }

    if (selected >= 0)
    {
        Console.WriteLine($"Billigaste varan är {selected + 1}. {items[selected]} - {prices[selected]} kr");
        simpleMessage = true;
    }
}

// Removes the item in position index
bool RemoveItem(int index)
{
    if (index < 0 || index >= items.Count)
        return false;

    items.RemoveAt(index);
    prices.RemoveAt(index);
    return true;
}

// Adds a new item at the end of the list
// If the item already exists, update the price
void AddItem(string item, int price)
{
    int index = items.FindIndex(m => item.ToLower().Equals(m.ToLower()));

    if (index < 0)
    {
        items.Add(item);
        prices.Add(price);
    }
    else
        prices[index] = price;
}
