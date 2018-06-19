namespace P03.Detail_Printer.Abstracts
{
    using System.Text;
    using P03.Detail_Printer.Abstracts.Contracts;

    public abstract class Worker : IWorker
    {
        public Worker(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public virtual string PrintWorkerInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.GetType().Name}: ").AppendLine($"{this.Name}");

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
