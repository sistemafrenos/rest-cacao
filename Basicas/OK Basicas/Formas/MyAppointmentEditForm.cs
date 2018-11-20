using System;
using System.Windows.Forms;

using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;

using HK;
using HK.Formas;
// ...

namespace DevExpress.XtraScheduler.Demos {
	public partial class MyAppointmentEditForm : DevExpress.XtraEditors.XtraForm {
		SchedulerControl control;
		Appointment apt;
		bool openRecurrenceForm = false;
		int suspendUpdateCount;
		private DevExpress.XtraEditors.CheckEdit checkAllDay;
		// Note that the MyAppointmentFormController class is inherited from
		// the AppointmentFormController one to add custom properties.
		// See its declaration at the end of this file.
		MyAppointmentFormController controller;

		public MyAppointmentEditForm(SchedulerControl control, Appointment apt, bool openRecurrenceForm) {
			this.openRecurrenceForm = openRecurrenceForm;
			this.controller = new MyAppointmentFormController(control, apt);
			this.apt = apt;
			this.control = control;
			//
			// Required for Windows Form Designer support
			//
			SuspendUpdate();
			InitializeComponent();
            this.KeyPreview = true;
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(MyAppointmentEditForm_KeyDown);
            this.txCustomName.ButtonClick += new XtraEditors.Controls.ButtonPressedEventHandler(txCustomName_ButtonClick);
            this.txSubject.ButtonClick += new XtraEditors.Controls.ButtonPressedEventHandler(txSubject_ButtonClick);
			ResumeUpdate();
			UpdateForm();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        void txSubject_ButtonClick(object sender, XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades f = new FrmBuscarEntidades();
            f.BuscarClientes("");
            if(f.DialogResult== System.Windows.Forms.DialogResult.OK )
            {
                Cliente cliente = (Cliente)f.registro;
                if(cliente !=null )
                {
                    this.txSubject.Text = cliente.RazonSocial;
                }
            }
        }

        void txCustomName_ButtonClick(object sender, XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades f = new FrmBuscarEntidades();
            f.BuscarCotizaciones("");
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Cotizacion item = (Cotizacion)f.registro;
                if (item != null)
                {
                    this.txSubject.Text = item.RazonSocial;
                    this.txCustomName.Text = item.Numero;
                }
            }
        }

        void MyAppointmentEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Cancelar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F12:
                    this.Aceptar.PerformClick();
                    e.Handled = true;
                    break;
            }
        }

        void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


		protected AppointmentStorage Appointments { get { return control.Storage.Appointments; } }
        protected internal bool IsNewAppointment { get { return controller != null ? controller.IsNewAppointment : true; } }
		protected bool IsUpdateSuspended { get { return suspendUpdateCount > 0; } }

		protected void SuspendUpdate() {
			suspendUpdateCount++;
		}
		protected void ResumeUpdate() {
			if (suspendUpdateCount > 0)
				suspendUpdateCount--;
		}
		private void btnAddRec_Click(object sender, System.EventArgs e) {
			OnRecurrenceButton();
		}

		void OnRecurrenceButton() {
			ShowRecurrenceForm();
		}

		void ShowRecurrenceForm() {

			if (!control.SupportsRecurrence)
				return;

			// Prepare to edit appointment's recurrence.
			Appointment editedAptCopy = controller.EditedAppointmentCopy;
			Appointment editedPattern = controller.EditedPattern;
			Appointment patternCopy = controller.PrepareToRecurrenceEdit();

			AppointmentRecurrenceForm dlg = new AppointmentRecurrenceForm(patternCopy, control.OptionsView.FirstDayOfWeek, controller);

			// Required for skins support.
			dlg.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;

			DialogResult result = dlg.ShowDialog(this);
			dlg.Dispose();

			if (result == DialogResult.Abort)
				controller.RemoveRecurrence();
			else
				if (result == DialogResult.OK) {
					controller.ApplyRecurrence(patternCopy);
					if (controller.EditedAppointmentCopy != editedAptCopy)
						UpdateForm();
				}
			UpdateIntervalControls();
		}

        void Aceptar_Click(object sender, EventArgs e)
        {
			// Required to check appointment's conflicts.
			if (!controller.IsConflictResolved())
				return;

			controller.Subject = txSubject.Text;
			controller.SetStatus(edStatus.Status);
			controller.SetLabel(edLabel.Label);
			controller.AllDay = this.checkAllDay.Checked;
			controller.Start = this.dtStart.DateTime.Date + this.timeStart.Time.TimeOfDay;
			controller.End = this.dtEnd.DateTime.Date + this.timeEnd.Time.TimeOfDay;
			controller.CustomName = txCustomName.Text;
			controller.CustomStatus = txCustomStatus.Text;

			// Save all changes made to the appointment edited in a form.
			controller.ApplyChanges();
            
            this.Close();
		}

		void UpdateForm() {
			SuspendUpdate();
			try {
				txSubject.Text = controller.Subject;
				edStatus.Status = Appointments.Statuses[controller.StatusId];
				edLabel.Label = Appointments.Labels[controller.LabelId];

				dtStart.DateTime = controller.Start.Date;
				dtEnd.DateTime = controller.End.Date;

				timeStart.Time = DateTime.MinValue.AddTicks(controller.Start.TimeOfDay.Ticks);
				timeEnd.Time = DateTime.MinValue.AddTicks(controller.End.TimeOfDay.Ticks);
				checkAllDay.Checked = controller.AllDay;

				edStatus.Storage = control.Storage;
				edLabel.Storage = control.Storage;

				txCustomName.Text = controller.CustomName;
				txCustomStatus.Text = controller.CustomStatus;
			}
			finally {
				ResumeUpdate();
			}
			UpdateIntervalControls();
		}

		private void MyAppointmentEditForm_Activated(object sender, System.EventArgs e) {
			// Required to show the recurrence form.
			if (openRecurrenceForm) {
				openRecurrenceForm = false;
				OnRecurrenceButton();
			}
		}

		private void dtStart_EditValueChanged(object sender, System.EventArgs e) {
			if (!IsUpdateSuspended)
				controller.Start = dtStart.DateTime.Date + timeStart.Time.TimeOfDay;
			UpdateIntervalControls();
		}
		protected virtual void UpdateIntervalControls() {
			if (IsUpdateSuspended)
				return;

			SuspendUpdate();
			try {
				dtStart.EditValue = controller.Start.Date;
				dtEnd.EditValue = controller.End.Date;
				timeStart.EditValue = controller.Start.TimeOfDay;
				timeEnd.EditValue = controller.End.TimeOfDay;

                Appointment editedAptCopy = controller.EditedAppointmentCopy;
                bool showControls = IsNewAppointment || editedAptCopy.Type != AppointmentType.Pattern;
                dtStart.Enabled = showControls;
                dtEnd.Enabled = showControls;
                bool enableTime = showControls && !controller.AllDay;
                timeStart.Visible = enableTime;
                timeStart.Enabled = enableTime;
                timeEnd.Visible = enableTime;
                timeEnd.Enabled = enableTime;
                checkAllDay.Enabled = showControls;
			}
			finally {
				ResumeUpdate();
			}
		}
		private void timeStart_EditValueChanged(object sender, System.EventArgs e) {
			if (!IsUpdateSuspended)
				controller.Start = dtStart.DateTime.Date + timeStart.Time.TimeOfDay;
			UpdateIntervalControls();
		}
		private void timeEnd_EditValueChanged(object sender, System.EventArgs e) {
			if (IsUpdateSuspended) return;
			if (IsIntervalValid())
				controller.End = dtEnd.DateTime + timeEnd.Time.TimeOfDay;
			else
				timeEnd.EditValue = controller.End.TimeOfDay;
		}
		private void dtEnd_EditValueChanged(object sender, System.EventArgs e) {
			if (IsUpdateSuspended) return;
			if (IsIntervalValid())
				controller.End = dtEnd.DateTime + timeEnd.Time.TimeOfDay;
			else
				dtEnd.EditValue = controller.End.Date;
		}
		bool IsIntervalValid() {
			DateTime start = dtStart.DateTime + timeStart.Time.TimeOfDay;
			DateTime end = dtEnd.DateTime + timeEnd.Time.TimeOfDay;
			return end >= start;
		}

		private void checkAllDay_CheckedChanged(object sender, System.EventArgs e) {
			controller.AllDay = this.checkAllDay.Checked;
			if (!IsUpdateSuspended)
				UpdateAppointmentStatus();

			UpdateIntervalControls();
		}
		void UpdateAppointmentStatus() {
			AppointmentStatus currentStatus = edStatus.Status;
			AppointmentStatus newStatus = controller.UpdateAppointmentStatus(currentStatus);
			if (newStatus != currentStatus)
				edStatus.Status = newStatus;
		}
	}
	public class MyAppointmentFormController : AppointmentFormController {

		public string CustomName { get { return (string)EditedAppointmentCopy.CustomFields["CustomName"]; } set { EditedAppointmentCopy.CustomFields["CustomName"] = value; } }
		public string CustomStatus { get { return (string)EditedAppointmentCopy.CustomFields["CustomStatus"]; } set { EditedAppointmentCopy.CustomFields["CustomStatus"] = value; } }

		string SourceCustomName { get { return (string)SourceAppointment.CustomFields["CustomName"]; } set { SourceAppointment.CustomFields["CustomName"] = value; } }
		string SourceCustomStatus { get { return (string)SourceAppointment.CustomFields["CustomStatus"]; } set { SourceAppointment.CustomFields["CustomStatus"] = value; } }

		public MyAppointmentFormController(SchedulerControl control, Appointment apt)
			: base(control, apt) {
		}

		public override bool IsAppointmentChanged() {
			if (base.IsAppointmentChanged())
				return true;
			return SourceCustomName != CustomName ||
				SourceCustomStatus != CustomStatus;
		}

		protected override void ApplyCustomFieldsValues() {
			SourceCustomName = CustomName;
			SourceCustomStatus = CustomStatus;
		}
	}
}
