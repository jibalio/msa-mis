namespace MSAMISUserInterface {
    public class Enumeration {

        public class AdjTypes
        {
            public static int CashBond = 1;
            public static int Cola = 2;
            public static int Thirteenth = 3;
            public static int CashAdvance = 4;
            public static int EmergencyAllowance = 5;
        }


        public class BasicPayStatus {
            public static int Future = 2;
            public static int Past = 0;
            public static int Active = 1;
        }

        public class ContribStatus {
            public static int Future = 2;
            public static int Past = 0;
            public static int Active = 1;
        }

        public class ContribType {
            public static int Sss = 1;
            public static int WithTax = 2;
            public static int Rates = 3;
        }

        public class HolidayType {
            public static int Regular = 0;
            public static int Special = 1;
        }

        public class HolidayTrans {
            public static int Fixed = 0;
            public static int Movable = 1;
        }


        public class Schedule {
            public static int Active = 1;
            public static int Dismissed = 2;
            public static int Pending = 3;
        }

        public class RequestType {
            public static int Assignment = 1;
            public static int Dismissal = 2;
        }

        public class AddressType {
            public static int Birthplace = 1;
            public static int TemporaryAddress = 2;
            public static int PermanentAddress = 3;
        }

        public class GuardStatus {
            public static int Inactive = 0;
            public static int Active = 1;
            public static int PendingPayroll = 2;           // This guard cannot be archived
            public static int PendingAssignment = 3;        // This guard cannot be archived.
        }
        
        public class PayrollStatus {
            public static int Pending = 0;
            public static int Approved = 2;                 // Objects are already serialized when approved.
        }

        public class ReportType {
            public static int Injury = 1;
            public static int Accident = 2;
            public static int Complaint = 3;
        }

        public class RequestStatus {
            public static int Pending = 1;
            public static int Approved = 2;
            public static int Active = 3;
            public static int Inactive = 4;
            public static int Declined = 5;
        }
        public class Involvement {
            public static int Involved = 1;
            public static int Witness = 2;
        }
        
        public class AssignmentStatus {
            public static int Active = 1;
            public static int Inactive = 2;
            public static int Pending = 3;
        }
   
        public class ScheduleStatus {
            public static int All = 0;
            public static int Scheduled = 1;
            public static int Unscheduled = 2;
        }
        public class DutyDetailStatus {
            public static int Active = 1;
            public static int Inactive = 2;
        }

        public class ClientStatus {
            public static int Active = 1;
            public static int Inactive = 0;
        }
    }



 }

