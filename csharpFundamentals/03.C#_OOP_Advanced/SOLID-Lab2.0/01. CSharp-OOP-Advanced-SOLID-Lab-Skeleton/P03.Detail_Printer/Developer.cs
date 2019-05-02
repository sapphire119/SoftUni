namespace P03.Detail_Printer
{
    using System.Text;
    using P03.Detail_Printer.Abstracts;

    public class Developer : Worker
    {
        public Developer(string name, string languge) 
            : base(name)
        {
            this.Languge = languge;
        }

        public string Languge { get; private set; }

        public override string PrintWorkerInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.PrintWorkerInfo())
                .AppendLine($" {this.Languge}");

            string result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
