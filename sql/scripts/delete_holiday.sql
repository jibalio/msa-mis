delete from msadb.holiday;
delete from msadb.holiday_instance;

alter table msadb.holiday_instance 
auto_increment = 1;
alter table msadb.holiday
auto_increment = 1;