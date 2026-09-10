List<string> items = new();
List<int> prices = new();

while (true)
{
    for (int i = 0; i < items.Count; i++)
        Console.WriteLine($"{i + 1}. {items[i]} - {prices[i]}");

    string input = Console.ReadLine()!;

    if (input.ToLower().Equals("dyrast"))
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
}