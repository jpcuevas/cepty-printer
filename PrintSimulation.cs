namespace cepty_printer.simulation.PrintSimulation
{
    public static class PrintSimulation
    {
        public static void SimulatePrinting(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(50); // Simulates the printing time for each character
            }
            Console.WriteLine();
        }
    }
}