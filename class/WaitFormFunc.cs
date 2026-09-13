using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistry.Class
{
    internal class WaitFormFunc
    {
        WaitForm wait;
        Thread thread;

        public void Show()
        {
            thread = new Thread(new ThreadStart(loadingProcess));
            thread.Start();
        }
        public void Show(Form parent)
        {
            thread = new Thread(new ParameterizedThreadStart(loadingProcess));
            thread.Start(parent);
        }

        public void Close()
        {
            if(wait != null)
            {
                wait.BeginInvoke(new ThreadStart(wait.CloseWaitForm));
                wait = null;
                thread = null;
            }
        }

        private void loadingProcess()
        {
            wait = new WaitForm();
            wait.ShowDialog();
        }

        private void loadingProcess(object parent)
        {
            Form p = parent as Form;
            wait = new WaitForm(p);
            wait.ShowDialog();
        }
    }
}
