namespace _10._The_Heigan_Dance
{
    public class AffectedColumns
    {
        private int startingRow;
        private int endingRow;
        private int startingColumn;
        private int endingColumn;

        public AffectedColumns() {}

        public AffectedColumns(int startingColumn, int endingColumn, int startingRow, int endingRow)
        {
            this.StartingAffectedRow = startingRow;
            this.EndingAffectedRow = endingRow;
            this.StartinAffectedColumn = startingColumn;
            this.EndingAffectedColumn = endingColumn;
        }

        public int StartingAffectedRow
        {
            get
            {
                return this.startingRow;
            }
            set
            {
                this.startingRow = value;
            }
        }

        public int EndingAffectedRow
        {
            get
            {
                return this.endingRow;
            }
            set
            {
                this.endingRow = value;
            }
        }

        public int StartinAffectedColumn
        {
            get
            {
                return this.startingColumn;
            }
            set
            {
                this.startingColumn = value;
            }
        }

        public int EndingAffectedColumn
        {
            get
            {
                return this.endingColumn;
            }
            set
            {
                this.endingColumn = value;
            }
        }
    }
}
