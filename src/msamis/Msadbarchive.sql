-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: msadbarchive
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
  `AID` int(11) NOT NULL,
  `GID` int(11) DEFAULT NULL,
  `AType` int(11) DEFAULT NULL,
  `Country` varchar(45) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `StreetNo` varchar(45) DEFAULT NULL,
  `Brgy` varchar(45) DEFAULT NULL,
  `Street` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`AID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address`
--

LOCK TABLES `address` WRITE;
/*!40000 ALTER TABLE `address` DISABLE KEYS */;
INSERT INTO `address` VALUES (3,1,1,'','111','11','1111','1111'),(4,1,2,'','h','11jhqgjhg','wh','hq'),(5,1,3,'','uiwhui','uiwh','uiwh','wqh'),(13,22,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(14,23,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(15,24,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(16,25,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(17,26,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(18,27,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(19,28,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(20,29,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(21,30,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(22,31,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(23,32,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(24,33,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(25,34,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(26,35,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(27,36,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(28,37,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(29,38,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(30,39,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(31,40,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(32,41,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(33,42,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(34,43,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(35,44,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(36,45,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(37,46,1,'3','Davao','Kalamansi','1','KalamansiSt.'),(38,47,1,'','3','1','afd','af'),(39,47,2,'','1','11111111111','1','1'),(40,47,3,'','1','1','1','11'),(41,48,1,'','31231','12','123112','123123'),(42,48,2,'','11','1','1','1'),(43,48,3,'','1','1','1','1');
/*!40000 ALTER TABLE `address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `adjustments`
--

DROP TABLE IF EXISTS `adjustments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `adjustments` (
  `AdjID` int(11) NOT NULL,
  `PID` int(11) DEFAULT NULL,
  `AdjType` int(11) DEFAULT NULL,
  `AdjDate` varchar(45) DEFAULT NULL,
  `Value` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`AdjID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adjustments`
--

LOCK TABLES `adjustments` WRITE;
/*!40000 ALTER TABLE `adjustments` DISABLE KEYS */;
/*!40000 ALTER TABLE `adjustments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `assignment`
--

DROP TABLE IF EXISTS `assignment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `assignment` (
  `AID` int(11) NOT NULL,
  `GID` int(11) DEFAULT NULL,
  `RID` int(11) DEFAULT NULL,
  `AStatus` int(11) DEFAULT NULL,
  PRIMARY KEY (`AID`),
  KEY `Assignment-Guard_idx` (`GID`),
  KEY `Assignment-Request_idx` (`RID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assignment`
--

LOCK TABLES `assignment` WRITE;
/*!40000 ALTER TABLE `assignment` DISABLE KEYS */;
/*!40000 ALTER TABLE `assignment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attendance`
--

DROP TABLE IF EXISTS `attendance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `attendance` (
  `AtID` int(11) NOT NULL,
  `DID` int(11) DEFAULT NULL,
  `Date` varchar(45) DEFAULT NULL,
  `TimeIn` varchar(45) DEFAULT NULL,
  `TimeOut` varchar(45) DEFAULT NULL,
  `AtType` int(11) DEFAULT NULL,
  PRIMARY KEY (`AtID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance`
--

LOCK TABLES `attendance` WRITE;
/*!40000 ALTER TABLE `attendance` DISABLE KEYS */;
/*!40000 ALTER TABLE `attendance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `basicpay`
--

DROP TABLE IF EXISTS `basicpay`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `basicpay` (
  `BPID` int(11) NOT NULL,
  `BasicPayc` int(11) DEFAULT NULL,
  `Start` varchar(45) DEFAULT NULL,
  `End` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`BPID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basicpay`
--

LOCK TABLES `basicpay` WRITE;
/*!40000 ALTER TABLE `basicpay` DISABLE KEYS */;
/*!40000 ALTER TABLE `basicpay` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `client` (
  `CID` int(11) NOT NULL,
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dependents`
--

DROP TABLE IF EXISTS `dependents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dependents` (
  `DeID` int(11) NOT NULL,
  `DRelationship` int(11) DEFAULT NULL,
  `FN` varchar(45) DEFAULT NULL,
  `MN` varchar(45) DEFAULT NULL,
  `LN` varchar(45) DEFAULT NULL,
  `GID` int(11) DEFAULT NULL,
  PRIMARY KEY (`DeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dependents`
--

LOCK TABLES `dependents` WRITE;
/*!40000 ALTER TABLE `dependents` DISABLE KEYS */;
INSERT INTO `dependents` VALUES (1,4,'hghgh','jh','jh',1),(2,5,'j','fgfg','j',1),(3,1,'jb','j','gfdg',1),(9,4,'1','1','1',48),(10,5,'1','1','1',48),(11,1,'1','1','1',48);
/*!40000 ALTER TABLE `dependents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dissmisalrequest`
--

DROP TABLE IF EXISTS `dissmisalrequest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dissmisalrequest` (
  `DisID` int(11) NOT NULL,
  `CID` int(11) DEFAULT NULL,
  `DateEntry` varchar(45) DEFAULT NULL,
  `DID` int(11) DEFAULT NULL,
  `DiStat` int(11) DEFAULT NULL,
  PRIMARY KEY (`DisID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dissmisalrequest`
--

LOCK TABLES `dissmisalrequest` WRITE;
/*!40000 ALTER TABLE `dissmisalrequest` DISABLE KEYS */;
/*!40000 ALTER TABLE `dissmisalrequest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dutydetails`
--

DROP TABLE IF EXISTS `dutydetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dutydetails` (
  `DID` int(11) NOT NULL,
  `AID` int(11) DEFAULT NULL,
  `TimeOut` varchar(45) DEFAULT NULL,
  `TimeIn` varchar(45) DEFAULT NULL,
  `Days` varchar(45) DEFAULT NULL,
  `DStatus` int(11) DEFAULT NULL,
  PRIMARY KEY (`DID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dutydetails`
--

LOCK TABLES `dutydetails` WRITE;
/*!40000 ALTER TABLE `dutydetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `dutydetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `guards`
--

DROP TABLE IF EXISTS `guards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `guards` (
  `GID` int(11) NOT NULL,
  `FN` varchar(45) DEFAULT NULL,
  `MN` varchar(45) DEFAULT NULL,
  `LN` varchar(45) DEFAULT NULL,
  `CivilStatus` int(11) DEFAULT NULL,
  `BDate` varchar(45) DEFAULT NULL,
  `Gender` int(11) DEFAULT NULL,
  `Religion` varchar(45) DEFAULT NULL,
  `ContactNo` varchar(45) DEFAULT NULL,
  `PrevAgency` varchar(45) DEFAULT NULL,
  `SSS` varchar(45) DEFAULT NULL,
  `TIN` varchar(45) DEFAULT NULL,
  `PhilHealth` varchar(45) DEFAULT NULL,
  `LicenseNo` varchar(45) DEFAULT NULL,
  `GStatus` int(11) DEFAULT NULL,
  `Height` varchar(45) DEFAULT NULL,
  `Weight` varchar(45) DEFAULT NULL,
  `EmergencyNo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`GID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `guards`
--

LOCK TABLES `guards` WRITE;
/*!40000 ALTER TABLE `guards` DISABLE KEYS */;
INSERT INTO `guards` VALUES (1,'aaa','aaa','aaa',1,'3/10/2017',1,'1111','555','ui','444 444 444','555 555 555','77-777777777-7','',1,'1 11','111 kg.','5675'),(47,'OO','Objectoriented','Anabelle',1,'12/03/2017',2,'1111','111111111','11111111111111111111111','111 111 111','111 111 111','11-111111111-1','',1,'1 11','111 kg.','11111111111'),(48,'B.','Objectoriented','Anna',1,'12/03/2017',2,'1','11','1111111','111 111 111','111 111 111','11-111111111-1','',1,'1 11','111 kg.','1');
/*!40000 ALTER TABLE `guards` ENABLE KEYS */;
UNLOCK TABLES;

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
  `IID` int(11) NOT NULL,
  `DisID` int(11) DEFAULT NULL,
  `ReportType` int(11) DEFAULT NULL,
  `DateEntry` varchar(45) DEFAULT NULL,
  `PCompleting` varchar(45) DEFAULT NULL,
  `EventDate` varchar(45) DEFAULT NULL,
  `EventLocation` varchar(45) DEFAULT NULL,
  `Description` longtext,
  PRIMARY KEY (`IID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `incidentreport`
--

LOCK TABLES `incidentreport` WRITE;
/*!40000 ALTER TABLE `incidentreport` DISABLE KEYS */;
/*!40000 ALTER TABLE `incidentreport` ENABLE KEYS */;
UNLOCK TABLES;

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
  `PID` int(11) NOT NULL,
  `GID` int(11) DEFAULT NULL,
  `PayDate` varchar(45) DEFAULT NULL,
  `TransactionD` varchar(45) DEFAULT NULL,
  `BasicPay` int(11) DEFAULT NULL,
  `PStatus` int(11) DEFAULT NULL,
  PRIMARY KEY (`PID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payroll`
--

LOCK TABLES `payroll` WRITE;
/*!40000 ALTER TABLE `payroll` DISABLE KEYS */;
/*!40000 ALTER TABLE `payroll` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personsinvolved`
--

DROP TABLE IF EXISTS `personsinvolved`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `personsinvolved` (
  `PIID` int(11) NOT NULL,
  `IID` int(11) DEFAULT NULL,
  `InvolvementType` int(11) DEFAULT NULL,
  `FN` varchar(45) DEFAULT NULL,
  `MN` varchar(45) DEFAULT NULL,
  `LN` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`PIID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personsinvolved`
--

LOCK TABLES `personsinvolved` WRITE;
/*!40000 ALTER TABLE `personsinvolved` DISABLE KEYS */;
/*!40000 ALTER TABLE `personsinvolved` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `requestforassignment`
--

DROP TABLE IF EXISTS `requestforassignment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `requestforassignment` (
  `RID` int(11) NOT NULL,
  `CID` int(11) DEFAULT NULL,
  `DateEntry` datetime DEFAULT NULL,
  `ContractStart` datetime DEFAULT NULL,
  `ContractEnd` datetime DEFAULT NULL,
  `RStatus` int(11) DEFAULT NULL,
  PRIMARY KEY (`RID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `requestforassignment`
--

LOCK TABLES `requestforassignment` WRITE;
/*!40000 ALTER TABLE `requestforassignment` DISABLE KEYS */;
/*!40000 ALTER TABLE `requestforassignment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `requestlocations`
--

DROP TABLE IF EXISTS `requestlocations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `requestlocations` (
  `RLID` int(11) NOT NULL,
  `RID` int(11) DEFAULT NULL,
  `LocationStreetNo` varchar(45) DEFAULT NULL,
  `LocationStreet` varchar(45) DEFAULT NULL,
  `LocationBrgy` varchar(45) DEFAULT NULL,
  `LocationCity` varchar(45) DEFAULT NULL,
  `NoGuards` int(11) DEFAULT NULL,
  PRIMARY KEY (`RLID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `requestlocations`
--

LOCK TABLES `requestlocations` WRITE;
/*!40000 ALTER TABLE `requestlocations` DISABLE KEYS */;
/*!40000 ALTER TABLE `requestlocations` ENABLE KEYS */;
UNLOCK TABLES;

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
/*!50001 VIEW `guardslist` AS select `guards`.`GID` AS `gid`,concat(`guards`.`LN`,', ',`guards`.`FN`,' ',`guards`.`MN`) AS `name`,concat(`address`.`StreetNo`,' ',`address`.`Street`,', ',`address`.`Brgy`,', ',`address`.`City`) AS `contactno`,`guards`.`GStatus` AS `gstatus` from (`address` join `guards` on((`guards`.`GID` = `address`.`GID`))) where ((`address`.`AType` = 1) or (`address`.`AType` = NULL)) */;
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

-- Dump completed on 2017-03-28  0:42:22
