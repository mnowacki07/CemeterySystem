using CemeterySystem.DBModels;
using CemeterySystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EmailNotifierWindowsService
{
    public partial class Service1 : ServiceBase
    { 
        private Timer timer1 = null;
      
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // temporary: send a message every ten seconds
            timer1 = new Timer();
            this.timer1.Interval = 10000;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.Tick);
            timer1.Enabled = true;
           
;            
           
        }

        private void Tick(object sender, ElapsedEventArgs a) {

            DateTime dateNow = DateTime.Today;

            // where the payment period is less than 30 days
            DateTime compareDate = dateNow.AddDays(30);

            List<BurialPlace> listPlaces = new BurialPlaceService().getBy(x => x.PaymentDate <= compareDate);
        
            List<Guid> listPlacesId = listPlaces.Select(x => x.BurialPlaceID).ToList();
            List<DeadPerson> listDeadPerson = new DeadPersonService().getBy(x => listPlacesId.Contains(x.BurialPlaceID));
            List<Guid?> listFamilyId = listDeadPerson.Select(x => x.FamilyMemberID).ToList();

            List<ApplicationUser> listUser = new UserService().getBy(x => listFamilyId.Contains(x.FamilyMemberID));

           
            List<String> emails= listUser.Select(x => x.Email).ToList();
           

            EmailService service = new EmailService();

            service.sendMail(emails);

        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
        }
    }
}
