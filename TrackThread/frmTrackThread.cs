using System;
using System.Threading;
using System.Windows.Forms;

namespace TrackThread
{
    public partial class frmTrackThread : Form
    {
        public frmTrackThread()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            btnRun.Enabled = false;
            lblStatus.Text = "-Thread Starts -";
            lblStatus.Refresh();
            Console.WriteLine("-Thread Starts-");

            Thread threadA = new Thread(MyThreadClass.Thread1);
            Thread threadB = new Thread(MyThreadClass.Thread2);
            Thread threadC = new Thread(MyThreadClass.Thread1);
            Thread threadD = new Thread(MyThreadClass.Thread2);

            threadA.Name = "Thread A Process";
            threadB.Name = "Thread B Process";
            threadC.Name = "Thread C Process";
            threadD.Name = "Thread D Process";

            threadA.Priority = ThreadPriority.Highest;
            threadB.Priority = ThreadPriority.Normal;
            threadC.Priority = ThreadPriority.AboveNormal;
            threadD.Priority = ThreadPriority.BelowNormal;

            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();

            // Block the calling thread until each thread terminates
            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            Console.WriteLine("-End of Thread-");
            lblStatus.Text = "-End of Thread-";
            btnRun.Enabled = true;
        }
    }
}
