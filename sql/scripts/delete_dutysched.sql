use msadb;
delete from request_assign;
delete from request_unassign;
delete from request;
delete from dutydetails;
delete from sduty_assignment;
delete from incidentreport;

alter table request_assign auto_increment=1;
alter table request_unassign auto_increment=1;
alter table request auto_increment=1;
alter table request_assign auto_increment=1;
alter table sduty_assignment auto_increment=1;
alter table incidentreport auto_increment=1;