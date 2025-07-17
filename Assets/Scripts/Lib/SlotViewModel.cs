namespace Lib
{
    public class SlotViewModel
    {
        public int dataIndex { get; private set; }
        public bool hasData => dataIndex >= 0;

        public SlotViewModel(int dataIndex)
        {
            this.dataIndex = dataIndex;
        }

        public SlotViewModel()
        {
            dataIndex = -1;
        }

        private void SetDataIndex(int index) => dataIndex = index;
    }
}