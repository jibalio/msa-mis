use msadb;
delete from request_assign;
delete from request_unassign;
delete from attendance;
alter table attendance auto_increment=1;
delete from request;
delete from dutydetails;
delete from sduty_assignment;
delete from incidentreport;
delete from adjustment_log;
alter table adjustment_log auto_increment = 1;
delete from payroll;
alter table payroll auto_increment=1;
DELETE FROM `msadb`.`period`; 
alter table period auto_increment=1;


alter table request_assign auto_increment=1;
alter table request_unassign auto_increment=1;
alter table request auto_increment=1;
alter table request_assign auto_increment=1;
alter table sduty_assignment auto_increment=1;
alter table incidentreport auto_increment=1;