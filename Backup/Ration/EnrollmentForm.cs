using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Ration
{
    public partial class EnrollmentForm : Form
    {
		// Constructor
        string getName;
        public EnrollmentForm(AppData data,string user)
        {
            getName = user;
            InitializeComponent();
			Data = data;										// Keep reference to the data
			ExchangeData(true);									// Init data with default control values;
			Data.OnChange += delegate { ExchangeData(false); };	// Track data changes to keep the form synchronized
        }

		// Simple dialog data exchange (DDX) implementation.
        public void ExchangeData(bool read)
        {
            if (read)
            {	// read values from the form's controls to the data object
                Data.EnrolledFingersMask = EnrollmentControl.EnrolledFingerMask;
                Data.MaxEnrollFingerCount = EnrollmentControl.MaxEnrollFingerCount;
				Data.Update();
			}
            else
            {	// read values from the data object to the form's controls
                EnrollmentControl.EnrolledFingerMask = Data.EnrolledFingersMask;
                EnrollmentControl.MaxEnrollFingerCount = Data.MaxEnrollFingerCount;
            }
        }
        byte[] buf = null;
        public void OnEnroll(Object Control, int Finger, DPFP.Template Template, ref DPFP.Gui.EventHandlerStatus Status)
        {
			if (Data.IsEventHandlerSucceeds)
			{
				Data.Templates[Finger-1] = Template;             // store a finger template
                Template.Serialize(ref buf);
				ExchangeData(true);								// update other data
			}
			else
				Status = DPFP.Gui.EventHandlerStatus.Failure;	// force a "failure" status
		}

        public void OnDelete(Object Control, int Finger, ref DPFP.Gui.EventHandlerStatus Status)
        {
            if (Data.IsEventHandlerSucceeds) {
                Data.Templates[Finger-1] = null;			    // clear the finger template
                FileInfo fi = new FileInfo("C:\\FingerTemplate\\" + getName + ".fpt");
                fi.Delete();
				ExchangeData(true);								// update other data
			}
			else
				Status = DPFP.Gui.EventHandlerStatus.Failure;	// force a "failure" status
		}

		private AppData Data;

        private void EnrollmentControl_Load(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            NewUser.finger = buf;
            this.Close();
        }	// Reference to the application data object
    }
}