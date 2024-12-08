using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SortingLib;

namespace Sortihm
{
    public partial class FormMain : Form
    {
        #region DATA MEMBERS
        private int[] arrInitialData; // initial array
        private int[] arrSortedData; // sorted array
        private string orderBy; // asc or desc order
        private string sortType; // sorting algorithm
        #endregion

        #region CONSTRUCTORS
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion

        #region EVENTS
        private void FormMain_Load(object sender, EventArgs e)
        {
            cbbxSortType.SelectedIndex = 0; // default All
            btnExecute.Enabled = false; // enabled when data filled
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            // make array length based on nud (1000-10000)
            arrInitialData = new int[(int)nudQuantity.Value]; 
            FillArrayWithRandomData((int)nudQuantity.Value);

            // enable execution
            btnExecute.Enabled = true;

            // clear outputs - redisplay data
            lblRt1.Text = "-";
            lblRt2.Text = "-";
            lblRt3.Text = "-";
            lblRt4.Text = "-";
            lblRt5.Text = "-";

            listBoxInitialData.Items.Clear();
            listBoxSortedData.Items.Clear();
            arrSortedData = null;

            DisplayDataInitial();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            // check order type
            if (rbAsc.Checked)
            {
                orderBy = "ASC";
            }
            if (rbDesc.Checked)
            {
                orderBy = "DESC";
            }

            // check sorting algorithm
            sortType = cbbxSortType.SelectedItem.ToString();

            // sort inital data
            arrSortedData = SortTheArray((int[])arrInitialData.Clone(), sortType, orderBy);

            // redisplay sorted data
            listBoxSortedData.Items.Clear();
            DisplayDataSorted();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // reset input
            nudQuantity.Value = 1000;

            rbAsc.Checked = true;
            rbDesc.Checked = false;

            cbbxSortType.SelectedIndex = 0;

            btnExecute.Enabled = false;

            lblRt1.Text = "-";
            lblRt2.Text = "-";
            lblRt3.Text = "-";
            lblRt4.Text = "-";
            lblRt5.Text = "-";

            listBoxInitialData.Items.Clear();
            listBoxSortedData.Items.Clear();
            arrInitialData = null;
            arrSortedData = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region METHODS
        private void DisplayDataInitial()
        {
            string oneRow = "";
            for (int i = 0; i < arrInitialData.Length; i++)
            {
                if (i % 10 == 0 && i != 0) // enter per 10 data
                {
                    listBoxInitialData.Items.Add(oneRow);
                    oneRow = "";
                }
                oneRow += $"{arrInitialData[i].ToString()}\t"; // tab
            }
        }

        private void DisplayDataSorted()
        {
            string oneRow = "";
            for (int i = 0; i < arrSortedData.Length; i++)
            {
                if (i % 10 == 0 && i != 0) // new line per 10 data
                {
                    listBoxSortedData.Items.Add(oneRow);
                    oneRow = "";
                }
                oneRow += $"{arrSortedData[i].ToString()}\t"; // tab each data
            }
        }

        private int[] SortTheArray(int[] arr, string type, string order)
        {
            int[] sortedArray; // sorted array
            int[] cloneArr = (int[])arr.Clone(); // initial array clone
            switch (type) // based on sorting algorithm
            {
                case "All":
                    // recursive all sorting algorithm - return sorted data from merge sort
                    SortTheArray(cloneArr, "Bubble Sort", order);
                    SortTheArray(cloneArr, "Insertion Sort", order);
                    SortTheArray(cloneArr, "Selection Sort", order);
                    SortTheArray(cloneArr, "Radix Sort", order);
                    return SortTheArray(cloneArr, "Merge Sort", order);
                case "Bubble Sort":
                    // start stopwatch - bubble sort with selected order - end stopwatch - display time and sorted array
                    Stopwatch sw1 = Stopwatch.StartNew();
                    sortedArray = order == "ASC" ? BubbleSort.SortAsc(cloneArr) : BubbleSort.SortDesc(cloneArr);
                    sw1.Stop();
                    lblRt1.Text = $"{sw1.Elapsed.TotalMilliseconds} ms";
                    return sortedArray;
                case "Insertion Sort":
                    // start stopwatch - insertion sort with selected order - end stopwatch - display time and sorted array
                    Stopwatch sw2 = Stopwatch.StartNew();
                    sortedArray = order == "ASC" ? InsertionSort.SortAsc(cloneArr) : InsertionSort.SortDesc(cloneArr);
                    sw2.Stop();
                    lblRt2.Text = $"{sw2.Elapsed.TotalMilliseconds} ms";
                    return sortedArray;
                case "Selection Sort":
                    // start stopwatch - selection sort with selected order - end stopwatch - display time and sorted array
                    Stopwatch sw3 = Stopwatch.StartNew();
                    sortedArray = order == "ASC" ? SelectionSort.SortAsc(cloneArr) : SelectionSort.SortDesc(cloneArr);
                    sw3.Stop();
                    lblRt3.Text = $"{sw3.Elapsed.TotalMilliseconds} ms";
                    return sortedArray;
                case "Radix Sort":
                    // start stopwatch - radix sort with selected order - end stopwatch - display time and sorted array
                    Stopwatch sw4 = Stopwatch.StartNew();
                    sortedArray = order == "ASC" ? RadixSort.SortAsc(cloneArr) : RadixSort.SortDesc(cloneArr);
                    sw4.Stop();
                    lblRt4.Text = $"{sw4.Elapsed.TotalMilliseconds} ms";
                    return sortedArray;
                case "Merge Sort":
                    // start stopwatch - merge sort with selected order - end stopwatch - display time and sorted array
                    Stopwatch sw5 = Stopwatch.StartNew();
                    sortedArray = order == "ASC" ? MergeSort.SortAsc(cloneArr) : MergeSort.SortDesc(cloneArr);
                    sw5.Stop();
                    lblRt5.Text = $"{sw5.Elapsed.TotalMilliseconds} ms";
                    return sortedArray;
                default:
                    // if not match cases - as error handler
                    MessageBox.Show("Please Select One of the Avaiable Sorting Algorithm!");
                    return null;
            }
        }

        private void FillArrayWithRandomData(int size)
        {
            // error handler if initial array null
            if (arrInitialData.Length == 0) throw new ArgumentNullException("The Array Cannot be Null");

            // fill initial array with number between 0 - 10000
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                arrInitialData[i] = random.Next(0, 10001);
            }
        }
        #endregion
    }
}
