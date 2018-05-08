using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class PayrollPeriodViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Period Year")]
        public int PeriodYear { get; set; }

        [Display(Name = "Period Month")]
        public int PeriodMonth { get; set; }

        public string Description {
            get
            {
                if (PeriodMonth > 0)
                {
                    return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(PeriodMonth) + " " + PeriodYear.ToString();
                }
                else
                {
                    return "No Selected Period";
                }
            }
        }

        [Display(Name = "Begin Date")]
        public DateTime BeginDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Period Status")]
        public bool IsCurrentPeriod { get; set; }

        [Display(Name = "Status")]
        public bool IsActivated { get; set; }
    }
}
