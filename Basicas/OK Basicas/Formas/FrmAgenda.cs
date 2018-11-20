using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;
using HK;
using HK.Clases;
using DevExpress.XtraScheduler.Demos;


namespace HK.Formas
{
    public partial class FrmAgenda : Form
    {
        DatosEntities data = new DatosEntities(OK.CadenaConexion);
        List<Agenda> lista = new List<Agenda>();
        public FrmAgenda()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmAgenda_Load);
        }

        void FrmAgenda_Load(object sender, EventArgs e)
        {
            lista = (from x in data.Agendas
                                select x).ToList();            
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 150;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 50;
            this.agendaBindingSource.DataSource = lista;
            this.schedulerControl.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(schedulerControl1_EditAppointmentFormShowing);
            this.CenterToScreen();
        }

        void schedulerControl1_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {
            Appointment apt = e.Appointment;
            bool openRecurrenceForm = apt.IsRecurring && schedulerStorage.Appointments.IsNewAppointment(apt);

            MyAppointmentEditForm f = new MyAppointmentEditForm((SchedulerControl)sender, apt, openRecurrenceForm);
            e.DialogResult = f.ShowDialog();
            e.Handled = true;

            if (apt.Type == AppointmentType.Pattern && schedulerControl.SelectedAppointments.Contains(apt))
                schedulerControl.SelectedAppointments.Remove(apt);            
            schedulerControl.Refresh();
            
        }

        private void schedulerControl_PreparePopupMenu(object sender, PreparePopupMenuEventArgs e)
        {
            e.Menu.Items[0].Caption = "Nuevo Evento";
            e.Menu.Items[1].Caption = "Reservar Dia Completo";
            e.Menu.Items[2].Caption = "Ir al dia de Hoy";
            e.Menu.Items[3].Caption = "Ir a una fecha";
            e.Menu.Items[4].Caption = "Cambiar Vista";
        }
    }
}
