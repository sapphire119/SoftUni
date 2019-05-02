namespace P03.DetailPrinter
{
    using System;
    using System.Collections.Generic;
    using P03.Detail_Printer.Abstracts;

    public class DetailsPrinter
    {
        private IList<Worker> workers;

        public DetailsPrinter(IList<Worker> workers)
        {
            this.workers = workers;
        }

        public void PrintDetails()
        {
            foreach (Worker worker in this.workers)
            {
                Console.WriteLine(worker.PrintWorkerInfo());
            }
        }
    }
}
