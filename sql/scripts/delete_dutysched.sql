     delete from attendance;
        alter table attendance auto_increment = 1;

        
        delete from msadb.dutydetails;
        alter table msadb.dutydetails auto_increment = 1;

        delete from msadb.sduty_assignment;
        alter table msadb.sduty_assignment auto_increment = 1;

        delete from msadb.request_assign;
        alter table msadb.request_assign auto_increment = 1;
        
        
        delete from msadb.request_unassign;
        alter table msadb.request_unassign auto_increment = 1;
                
        delete from msadb.request;
        alter table msadb.request auto_increment = 1;

        

        delete from msadb.adjustment_log;
        alter table msadb.adjustment_log auto_increment = 1;

        delete from msadb.payroll;
        alter table msadb.payroll auto_increment = 1;

        DELETE FROM msadb.period; 
        alter table msadb.period auto_increment = 1;

        delete from mysql.event;

            -- RESET ALL GUARDS TO INACTIEF
            update msadb.guards set gstatus=2;
            
            delete from personsinvolved;
            alter table personsinvolved auto_increment = 1;
            delete from msadb.incidentreport;
        alter table msadb.incidentreport auto_increment = 1;