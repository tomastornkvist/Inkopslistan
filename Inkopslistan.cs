List<string> items = [];
List<int> prices = [];

bool firstTime = true;
bool sorted = false;

// An eternal loop that keeps the program running
while (true)
{
    int index;

    if (sorted)
        PrintSortedItems();
    else
        PrintItems(items, prices);
    PrintUsage();

    string input;

    do
    {
        input = Console.ReadLine()!.Trim();
    } while (input.Length <= 0);

    // Avsluta programmet
    if (input.ToLower().Equals("avsluta"))
        break;

    // Visa listan sorterad efter pris
    if (input.ToLower().Equals("sortera"))
        sorted = true;

    // Visa dyraste varan
    else if (input.ToLower().Equals("dyrast"))
        PrintMostExpensive();

    // Visa billigaste varan
    else if (input.ToLower().Equals("billigast"))
        PrintLeastExpensive();

    // Ta bort en vara
    else if (int.TryParse(input, out index))
    {
        if (!RemoveItem(index - 1))
            Console.WriteLine("Den varan finns inte.");
    }

    // Lägg till en vara
    else
    {
        int price;

        Console.Write("Ange varans pris: ");

        if (int.TryParse(Console.ReadLine(), out price))
            AddItem(input, price);
        else
            Console.Write("Priset måste vara i hela kronor. ");
    }
}

// Prints the item list sorted on price
void PrintSortedItems()
{
    List<string> sortedItems = [];
    List<int> sortedPrices = [];

    for (int i = 0; i < prices.Count; i++)
    {
        int j;
        for (j = 0; j < sortedPrices.Count; j++)
        {
            if (prices[i] < sortedPrices[j])
                break;
        }
        sortedPrices.Insert(j, prices[i]);
        sortedItems.Insert(j, items[i]);
    }

    PrintItems(sortedItems, sortedPrices);
    sorted = false;
}

// Prints the item list
void PrintItems(List<string> _items, List<int> _prices)
{
    if (_items.Count > 0)
    {
        Console.WriteLine();
        Console.WriteLine("Varor");
        Console.WriteLine("--------------");
    }

    int totalPrice = 0;

    for (int i = 0; i < _items.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {_items[i]} - {_prices[i]} kr");
        totalPrice += _prices[i];
    }

    if (_prices.Count > 0)
        Console.WriteLine($"Totalt: {totalPrice} kr");
}

// Informs the user of what to do
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
    Console.WriteLine("DYRAST/BILLIGAST visar dyraste/billigaste varan.");
    Console.WriteLine("SORTERA visar listan sorterad efter pris.");
    Console.WriteLine("AVSLUTA stänger ner programmet.");
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
    }
}

// Prints the cheapest item
void PrintLeastExpensive()
{
    int selected = -1;

    for (int i = 0; i < prices.Count; i++)
    {
        if (selected < 0 || prices[i] < prices[selected])
            selected = i;
    }

    if (selected >= 0)
        Console.WriteLine($"Billigaste varan är {selected + 1}. {items[selected]} - {prices[selected]} kr");
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

// Inserts a new item in the list, sorted based on price
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
