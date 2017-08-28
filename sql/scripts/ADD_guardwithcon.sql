call init_checkdate_all();
INSERT INTO `msadb`.`request` (`RequestType`, `CID`, `DateEntry`,`rstatus`) VALUES ('1', '16', '2017-08-25','1');
INSERT INTO `msadb`.`request_assign`  ( `ContractStart`, `ContractEnd`, `streetno`, `streetname`, `brgy`, `city`,`noguards`,`rid`) VALUES ('2017-08-25', '2017-08-27', '1', '1', '1', '1', '2', '1');
UPDATE `msadb`.`request` SET `RStatus`='2', ProcessedBy='3' WHERE `RID`='1';
INSERT INTO `msadb`.`sduty_assignment` (`GID`, `RAID`, `AStatus`, `AssignedOn`, `cid`) VALUES ('161', '1', '3', 
                                '2017-08-25', '16');
INSERT INTO `msadb`.`sduty_assignment` (`GID`, `RAID`, `AStatus`, `AssignedOn`, `cid`) VALUES ('168', '1', '3', 
                                '2017-08-25', '16');
UPDATE `msadb`.`request` SET `RStatus`='3', ProcessedBy='3' WHERE `RID`='1';
call init_status_clientstatus()  ;
call msadb.init_checkdate_assignmentstatus();
call init_status_clientstatus()  ;
INSERT IGNORE INTO `msadb`.`period` 
                            (`GID`, `month`, `period`, `year`, `cid`) VALUES 
                            ('161', '8', '2', '2017', '16');
call msadb.init_checkdate_assignmentstatus();
INSERT IGNORE INTO `msadb`.`period` 
                            (`GID`, `month`, `period`, `year`, `cid`) VALUES 
                            ('161', '8', '2', '2017', '16');
INSERT IGNORE INTO `msadb`.`period` 
                            (`GID`, `month`, `period`, `year`, `cid`) VALUES 
                            ('161', '8', '2', '2017', '16');
INSERT IGNORE INTO `msadb`.`period` 
                            (`GID`, `month`, `period`, `year`, `cid`) VALUES 
                            ('161', '8', '2', '2017', '16');
INSERT IGNORE INTO `msadb`.`attendance` (`DID`, `date`, `PID`) VALUES ('1','2017-08-25 00:00:00','1'),
('1','2017-08-26 00:00:00','1'),
('1','2017-08-27 00:00:00','1');
call msadb.init_checkdate_assignmentstatus();
INSERT IGNORE INTO `msadb`.`period` 
                            (`GID`, `month`, `period`, `year`, `cid`) VALUES 
                            ('161', '8', '2', '2017', '16');
INSERT IGNORE INTO `msadb`.`attendance` (`DID`, `date`, `PID`) VALUES ('1','2017-08-25 00:00:00','1'),
('1','2017-08-26 00:00:00','1'),
('1','2017-08-27 00:00:00','1');
INSERT IGNORE INTO `msadb`.`period` 
                            (`GID`, `month`, `period`, `year`, `cid`) VALUES 
                            ('161', '8', '2', '2017', '16');
INSERT IGNORE INTO `msadb`.`attendance` (`DID`, `date`, `PID`) VALUES ('1','2017-08-25 00:00:00','1'),
('1','2017-08-26 00:00:00','1'),
('1','2017-08-27 00:00:00','1');
INSERT IGNORE INTO `msadb`.`period` 
                            (`GID`, `month`, `period`, `year`, `cid`) VALUES 
                            ('161', '8', '2', '2017', '16');
INSERT IGNORE INTO `msadb`.`attendance` (`DID`, `date`, `PID`) VALUES ('1','2017-08-25 00:00:00','1'),
('1','2017-08-26 00:00:00','1'),
('1','2017-08-27 00:00:00','1');
UPDATE `msadb`.`attendance` SET `TimeIn`='01:00 AM', `TimeOut`='09:00 AM'  WHERE `AtID`='1';
UPDATE `msadb`.`attendance` SET `TimeIn`='01:00 AM', `TimeOut`='09:00 AM'  WHERE `AtID`='2';
UPDATE `msadb`.`attendance` SET `TimeIn`='01:00 AM', `TimeOut`='09:00 AM'  WHERE `AtID`='3';
UPDATE `msadb`.`period` SET `certby`='Briones, Jasp' WHERE `GID`='161' AND month='8' AND period='2' AND year='2017';
INSERT IGNORE INTO `msadb`.`period` 
                            (`GID`, `month`, `period`, `year`, `cid`) VALUES 
                            ('161', '8', '2', '2017', '16');
INSERT IGNORE INTO `msadb`.`attendance` (`DID`, `date`, `PID`) VALUES ('1','2017-08-25 00:00:00','1'),
('1','2017-08-26 00:00:00','1'),
('1','2017-08-27 00:00:00','1')
