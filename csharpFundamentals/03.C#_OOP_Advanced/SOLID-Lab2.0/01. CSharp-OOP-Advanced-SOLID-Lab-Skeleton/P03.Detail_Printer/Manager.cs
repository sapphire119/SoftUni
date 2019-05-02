using P03.Detail_Printer.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Worker
    {
        private ICollection<string> documents;

        public Manager(string name, ICollection<string> documents) 
            : base(name)
        {
            this.documents = documents;
        }

        public IReadOnlyCollection<string> Documents => (IReadOnlyCollection<string>)this.documents;

        public override string PrintWorkerInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.PrintWorkerInfo())
                .Append("=> ")
                .AppendLine(string.Join(", ", this.Documents));

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
