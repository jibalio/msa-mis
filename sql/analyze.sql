CREATE DATABASE  IF NOT EXISTS `msadb` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `msadb`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win32 (AMD64)
--
-- Host: 127.0.0.1    Database: msadb
-- ------------------------------------------------------
-- Server version	5.7.13-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `address`
--

DROP TABLE IF EXISTS `address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `address` (
  `AID` int(11) NOT NULL AUTO_INCREMENT,
  `GID` int(11) DEFAULT NULL,
  `AType` int(11) DEFAULT NULL,
  `Country` varchar(45) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `StreetNo` varchar(45) DEFAULT NULL,
  `Brgy` varchar(45) DEFAULT NULL,
  `Street` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`AID`),
  KEY `Guard-Add_idx` (`GID`),
  CONSTRAINT `Guard-Add` FOREIGN KEY (`GID`) REFERENCES `guards` (`GID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `adjustments`
--

DROP TABLE IF EXISTS `adjustments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `adjustments` (
  `AdjID` int(11) NOT NULL AUTO_INCREMENT,
  `PID` int(11) DEFAULT NULL,
  `AdjType` int(11) DEFAULT NULL,
  `AdjDate` varchar(45) DEFAULT NULL,
  `Value` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`AdjID`),
  KEY `Adj-Payroll_idx` (`PID`),
  CONSTRAINT `Adj-Payroll` FOREIGN KEY (`PID`) REFERENCES `payroll` (`PID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `at`
--

DROP TABLE IF EXISTS `at`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `at` (
  `TID` int(11) NOT NULL AUTO_INCREMENT,
  `AID` int(11) DEFAULT NULL,
  `month` int(11) DEFAULT NULL,
  `period` int(11) DEFAULT NULL,
  `year` int(5) DEFAULT NULL,
  PRIMARY KEY (`TID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `attendance`
--

DROP TABLE IF EXISTS `attendance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `attendance` (
  `AtID` int(11) NOT NULL AUTO_INCREMENT,
  `DID` int(11) DEFAULT NULL,
  `Date` varchar(45) DEFAULT NULL,
  `TimeIn` datetime DEFAULT NULL,
  `TimeOut` datetime DEFAULT NULL,
  `night` int(11) DEFAULT NULL,
  `holiday` int(11) DEFAULT NULL,
  `month` int(11) DEFAULT NULL,
  `period` int(11) DEFAULT NULL,
  `year` int(11) DEFAULT NULL,
  `hours` int(11) DEFAULT NULL,
  PRIMARY KEY (`AtID`),
  UNIQUE KEY `unique_index` (`month`,`period`,`year`,`Date`),
  KEY `Attendance-DutyDetails_idx` (`DID`),
  CONSTRAINT `Attendance-DutyDetails` FOREIGN KEY (`DID`) REFERENCES `dutydetails` (`DID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `basicpay`
--

DROP TABLE IF EXISTS `basicpay`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `basicpay` (
  `BPID` int(11) NOT NULL AUTO_INCREMENT,
  `BasicPayc` int(11) DEFAULT NULL,
  `Start` varchar(45) DEFAULT NULL,
  `End` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`BPID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `client` (
  `CID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `ClientStreetNo` varchar(45) DEFAULT NULL,
  `ClientStreet` varchar(45) DEFAULT NULL,
  `ClientBrgy` varchar(45) DEFAULT NULL,
  `ClientCity` varchar(45) DEFAULT NULL,
  `ContactPerson` varchar(45) DEFAULT NULL,
  `ContactNo` varchar(45) DEFAULT NULL,
  `Manager` varchar(45) DEFAULT NULL,
  `CStatus` int(11) DEFAULT NULL,
  PRIMARY KEY (`CID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `dependents`
--

DROP TABLE IF EXISTS `dependents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dependents` (
  `DeID` int(11) NOT NULL AUTO_INCREMENT,
  `DRelationship` int(11) DEFAULT NULL,
  `FN` varchar(45) DEFAULT NULL,
  `MN` varchar(45) DEFAULT NULL,
  `LN` varchar(45) DEFAULT NULL,
  `GID` int(11) DEFAULT NULL,
  PRIMARY KEY (`DeID`),
  KEY `Guards-Dep_idx` (`GID`),
  CONSTRAINT `Guards-Dep` FOREIGN KEY (`GID`) REFERENCES `guards` (`GID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=1587 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `dutydetails`
--

DROP TABLE IF EXISTS `dutydetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dutydetails` (
  `DID` int(11) NOT NULL AUTO_INCREMENT,
  `AID` int(11) DEFAULT NULL,
  `TI_hh` int(2) unsigned zerofill DEFAULT NULL,
  `TI_mm` int(2) unsigned zerofill DEFAULT NULL,
  `TI_period` varchar(3) DEFAULT NULL,
  `TO_hh` int(2) unsigned zerofill DEFAULT NULL,
  `TO_mm` int(2) unsigned zerofill DEFAULT NULL,
  `TO_period` varchar(3) DEFAULT NULL,
  `Mon` int(1) unsigned DEFAULT NULL,
  `Tue` int(1) unsigned DEFAULT NULL,
  `Wed` int(1) unsigned DEFAULT NULL,
  `Thu` int(1) unsigned DEFAULT NULL,
  `Fri` int(1) unsigned DEFAULT NULL,
  `Sat` int(1) unsigned DEFAULT NULL,
  `Sun` int(1) unsigned DEFAULT NULL,
  `DStatus` int(1) unsigned DEFAULT NULL,
  PRIMARY KEY (`DID`),
  KEY `Assignment-Duty_idx` (`AID`),
  CONSTRAINT `Assignment-Duty` FOREIGN KEY (`AID`) REFERENCES `sduty_assignment` (`AID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `guards`
--

DROP TABLE IF EXISTS `guards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `guards` (
  `GID` int(11) NOT NULL AUTO_INCREMENT,
  `FN` varchar(45) DEFAULT NULL,
  `MN` varchar(45) DEFAULT NULL,
  `LN` varchar(45) DEFAULT NULL,
  `GStatus` int(11) DEFAULT NULL,
  `BDate` varchar(45) DEFAULT NULL,
  `Gender` int(11) DEFAULT NULL,
  `Height` varchar(45) DEFAULT NULL,
  `Weight` varchar(45) DEFAULT NULL,
  `Religion` varchar(45) DEFAULT NULL,
  `CivilStatus` int(11) DEFAULT NULL,
  `CellNo` varchar(45) DEFAULT NULL,
  `TelNo` varchar(45) DEFAULT NULL,
  `LicenseNo` varchar(45) DEFAULT NULL,
  `SSS` varchar(45) DEFAULT NULL,
  `TIN` varchar(45) DEFAULT NULL,
  `PhilHealth` varchar(45) DEFAULT NULL,
  `PrevAgency` varchar(45) DEFAULT NULL,
  `PrevAss` varchar(200) DEFAULT NULL,
  `EdAtt` int(11) DEFAULT NULL,
  `Course` varchar(45) DEFAULT NULL,
  `MilitaryTrainings` varchar(200) DEFAULT NULL,
  `EmergencyContact` varchar(45) DEFAULT NULL,
  `EmergencyNo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`GID`)
) ENGINE=InnoDB AUTO_INCREMENT=347 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `guardslist`
--

DROP TABLE IF EXISTS `guardslist`;
/*!50001 DROP VIEW IF EXISTS `guardslist`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `guardslist` AS SELECT 
 1 AS `gid`,
 1 AS `name`,
 1 AS `contactno`,
 1 AS `gstatus`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `incidentreport`
--

DROP TABLE IF EXISTS `incidentreport`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `incidentreport` (
  `IID` int(11) NOT NULL AUTO_INCREMENT,
  `ReportType` int(11) DEFAULT NULL,
  `PCompleting` varchar(45) DEFAULT NULL,
  `EventDate` varchar(45) DEFAULT NULL,
  `EventLocation` varchar(45) DEFAULT NULL,
  `Description` longtext,
  `DateEntry` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`IID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `meta`
--

DROP TABLE IF EXISTS `meta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meta` (
  `meta_id` int(11) NOT NULL,
  `version` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`meta_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `new_view`
--

DROP TABLE IF EXISTS `new_view`;
/*!50001 DROP VIEW IF EXISTS `new_view`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `new_view` AS SELECT 
 1 AS `gid`,
 1 AS `name`,
 1 AS `contactno`,
 1 AS `gstatus`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `payroll`
--

DROP TABLE IF EXISTS `payroll`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payroll` (
  `PID` int(11) NOT NULL AUTO_INCREMENT,
  `GID` int(11) DEFAULT NULL,
  `PayDate` varchar(45) DEFAULT NULL,
  `TransactionD` varchar(45) DEFAULT NULL,
  `BasicPay` int(11) DEFAULT NULL,
  `PStatus` int(11) DEFAULT NULL,
  PRIMARY KEY (`PID`),
  KEY `Payroll-Guards_idx` (`GID`),
  CONSTRAINT `Payroll-Guards` FOREIGN KEY (`GID`) REFERENCES `guards` (`GID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `personsinvolved`
--

DROP TABLE IF EXISTS `personsinvolved`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `personsinvolved` (
  `PIID` int(11) NOT NULL AUTO_INCREMENT,
  `IID` int(11) DEFAULT NULL,
  `InvolvementType` int(11) DEFAULT NULL,
  `FN` varchar(45) DEFAULT NULL,
  `MN` varchar(45) DEFAULT NULL,
  `LN` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`PIID`),
  KEY `Involved-Report_idx` (`IID`),
  CONSTRAINT `Involved-Report` FOREIGN KEY (`IID`) REFERENCES `incidentreport` (`IID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `request`
--

DROP TABLE IF EXISTS `request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `request` (
  `RID` int(11) NOT NULL AUTO_INCREMENT,
  `RequestType` int(11) DEFAULT NULL,
  `CID` int(11) DEFAULT NULL,
  `DateEntry` varchar(45) DEFAULT NULL,
  `RStatus` int(11) DEFAULT NULL,
  PRIMARY KEY (`RID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `request_assign`
--

DROP TABLE IF EXISTS `request_assign`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `request_assign` (
  `RAID` int(11) NOT NULL AUTO_INCREMENT,
  `RID` int(11) DEFAULT NULL,
  `ContractStart` datetime DEFAULT NULL,
  `ContractEnd` datetime DEFAULT NULL,
  `streetno` varchar(11) COLLATE utf8_bin DEFAULT NULL,
  `streetname` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `brgy` varchar(60) COLLATE utf8_bin DEFAULT NULL,
  `city` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `NoGuards` int(11) DEFAULT NULL,
  PRIMARY KEY (`RAID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `request_dismiss`
--

DROP TABLE IF EXISTS `request_dismiss`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `request_dismiss` (
  `RDID` int(11) NOT NULL AUTO_INCREMENT,
  `RID` int(11) DEFAULT NULL,
  PRIMARY KEY (`RDID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `request_unassign`
--

DROP TABLE IF EXISTS `request_unassign`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `request_unassign` (
  `RDID` int(11) NOT NULL AUTO_INCREMENT,
  `RID` int(11) DEFAULT NULL,
  `GID` int(11) DEFAULT NULL,
  `IID` int(11) DEFAULT NULL,
  PRIMARY KEY (`RDID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sduty_assignment`
--

DROP TABLE IF EXISTS `sduty_assignment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sduty_assignment` (
  `AID` int(11) NOT NULL AUTO_INCREMENT,
  `GID` int(11) DEFAULT NULL,
  `RAID` int(11) DEFAULT NULL,
  `AStatus` int(11) DEFAULT NULL,
  PRIMARY KEY (`AID`),
  KEY `Assignment-Guard_idx` (`GID`),
  KEY `Assignment-Request_idx` (`RAID`),
  CONSTRAINT `Assignment-Guard` FOREIGN KEY (`GID`) REFERENCES `guards` (`GID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Final view structure for view `guardslist`
--

/*!50001 DROP VIEW IF EXISTS `guardslist`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `guardslist` AS select `guards`.`GID` AS `gid`,concat(`guards`.`LN`,', ',`guards`.`FN`,' ',`guards`.`MN`) AS `name`,concat(`address`.`StreetNo`,' ',`address`.`Street`,', ',`address`.`Brgy`,', ',`address`.`City`) AS `contactno`,`guards`.`GStatus` AS `gstatus` from (`guards` join `address` on((`guards`.`GID` = `address`.`GID`))) where (`address`.`AType` = 1) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `new_view`
--

/*!50001 DROP VIEW IF EXISTS `new_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `new_view` AS select `guards`.`GID` AS `gid`,concat(`guards`.`LN`,', ',`guards`.`FN`,' ',`guards`.`MN`) AS `name`,concat(`address`.`StreetNo`,' ',`address`.`Street`,', ',`address`.`Brgy`,', ',`address`.`City`) AS `contactno`,`guards`.`GStatus` AS `gstatus` from (`guards` join `address` on((`guards`.`GID` = `address`.`GID`))) where (`address`.`AType` = 1) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-07-03 20:00:35
