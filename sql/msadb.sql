CREATE DATABASE  IF NOT EXISTS `msadb` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `msadb`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
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
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account` (
  `accid` int(11) NOT NULL AUTO_INCREMENT,
  `uname` varchar(45) DEFAULT NULL,
  `hash` varchar(60) DEFAULT NULL,
  `type` int(1) DEFAULT NULL,
  PRIMARY KEY (`accid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account` VALUES (1,'admin','$2a$10$Z1R3EjdfdyL38Hi5sx6SNeouxq9LspdMSR1uIe5CT7//YhcHTDnyO',1),(2,'clerk','$2a$10$imp8QC1nEzOWieBu5MsFtOV94cAQdindJs/SvWHJPv4JRp32DZgHO',2),(3,'root','$2a$10$UrRQ9T/hHzOW09IrWgdG8OthmnXTR3rkGSn8BEdH/XBMa5zEaaDWK',0);
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;

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
  `Country` varchar(60) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `StreetNo` varchar(45) DEFAULT NULL,
  `Brgy` varchar(45) DEFAULT NULL,
  `Street` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`AID`),
  KEY `Guard-Add_idx` (`GID`),
  CONSTRAINT `Guard-Add` FOREIGN KEY (`GID`) REFERENCES `guards` (`GID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=1039 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address`
--

LOCK TABLES `address` WRITE;
/*!40000 ALTER TABLE `address` DISABLE KEYS */;
INSERT INTO `address` VALUES (1,1,1,'Finland','Kontiolahti','444','Colorado','Artisan'),(2,2,1,'Cyprus','Léfka','8','Debra','Florence'),(3,3,1,'Colombia','Medellín','0','Dawn','Scoville'),(4,4,1,'Papua New Guinea','Kavieng','7690','Sunfield','Pleasure'),(5,5,1,'Canada','Mattawa','882','Sugar','Fairfield'),(6,6,1,'Brazil','Indaial','61','Blackbird','Weeping Birch'),(7,7,1,'Poland','Bolszewo','06','Fallview','Susan'),(8,8,1,'South Korea','Icheon-si','191','Arizona','Waywood'),(9,9,1,'Brazil','Bandeirantes','19706','Moose','Kensington'),(10,10,1,'Morocco','Zerkten','1687','Cody','Schurz'),(11,11,1,'Angola','Lucapa','159','Hintze','Armistice'),(12,12,1,'United States','Yonkers','0','Straubel','Bartelt'),(13,13,1,'France','Valence','836','Mockingbird','Hudson'),(14,14,1,'Indonesia','Satowebrang','35','East','Carberry'),(15,15,1,'Nicaragua','San Ramón','649','Kennedy','Valley Edge'),(16,16,1,'Tanzania','Kabanga','7338','Prentice','Hansons'),(17,17,1,'Thailand','Lap Lae','411','Hoepker','Loftsgordon'),(18,18,1,'China','Shisandaogou','84853','Hintze','Hoepker'),(19,19,1,'Indonesia','Gununggoong','4','Nancy','Reindahl'),(20,20,1,'China','Gantang','30','Mallory','Thompson'),(21,21,1,'Iran','Semīrom','037','Hazelcrest','Montana'),(22,22,1,'Greece','Lidoríki','9779','School','Bluejay'),(23,23,1,'Indonesia','Tlogosadang','10732','Northview','Daystar'),(24,24,1,'New Caledonia','Koumac','0757','Roth','Calypso'),(25,25,1,'Philippines','Tranca','73','Lien','Jackson'),(26,26,1,'China','Aoluguya Ewenke Minzu','27','Comanche','Dunning'),(27,27,1,'Venezuela','Santa Cruz','9056','Springview','Corben'),(28,28,1,'Vietnam','Thị Trấn Bắc Hà','0592','Harbort','Tony'),(29,29,1,'China','Liyang','2','Sheridan','Loeprich'),(30,30,1,'Vietnam','Bằng Lũng','26778','Veith','Ridgeview'),(31,31,1,'Kyrgyzstan','Kara Suu','6','Kenwood','Lotheville'),(32,32,1,'Indonesia','Karangtengah','2','Judy','Reinke'),(33,33,1,'Sweden','Karlstad','334','Dixon','Arapahoe'),(34,34,1,'Pakistan','Sakrand','34422','Fairview','Bunker Hill'),(35,35,1,'Portugal','Duas Igrejas','176','4th','Dahle'),(36,36,1,'Canada','Princeton','4168','Rigney','Manley'),(37,37,1,'Greece','Petroúpolis','60898','Southridge','Maple Wood'),(38,38,1,'Indonesia','Tengah','6','Rusk','Cambridge'),(39,39,1,'Belarus','Kapyl’','061','Mayer','Superior'),(40,40,1,'Indonesia','Tempaling','77695','Beilfuss','Russell'),(41,41,1,'Namibia','Okakarara','201','Buena Vista','Delaware'),(42,42,1,'Azerbaijan','Bakıxanov','83600','Karstens','Dixon'),(43,43,1,'Philippines','Looc','60999','Buell','Straubel'),(44,44,1,'Argentina','La Falda','7','Onsgard','Buhler'),(45,45,1,'Ivory Coast','Lakota','1174','Sloan','Gulseth'),(46,46,1,'China','Jiaoshi','95670','Cordelia','Annamark'),(47,47,1,'Georgia','Batumi','152','Green','Pennsylvania'),(48,48,1,'Indonesia','Timurlorong','3','Moland','Claremont'),(49,49,1,'China','Yongtai','03','Claremont','Ryan'),(50,50,1,'France','Saint-Herblain','1','Fairview','Quincy'),(51,51,1,'Brazil','Registro','08233','Comanche','Graedel'),(52,52,1,'China','Yushu','4','Thackeray','Fordem'),(53,53,1,'Sweden','Timrå','4792','Green Ridge','Fairview'),(54,54,1,'Armenia','Horrom','054','Holy Cross','Swallow'),(55,55,1,'Philippines','Labog','8','Coleman','Bellgrove'),(56,56,1,'Poland','Dziergowice','76582','Northview','Everett'),(57,57,1,'France','Angoulême','0','Burrows','Summer Ridge'),(58,58,1,'Philippines','Bigaa','7828','Bluestem','Service'),(59,59,1,'Norway','Arendal','38','Upham','Hagan'),(60,60,1,'Portugal','Portelinha','4','Oak Valley','Nancy'),(61,61,1,'China','Dalianwan','41634','Dovetail','Tennessee'),(62,62,1,'France','Toulon','96476','Oneill','Summit'),(63,63,1,'United States','Jacksonville','246','2nd','Kingsford'),(64,64,1,'United States','Boston','8170','Pine View','Milwaukee'),(65,65,1,'Italy','Messina','1','Scott','Old Gate'),(66,66,1,'China','Tianhekou','715','Fieldstone','Bunting'),(67,67,1,'Portugal','Baguim do Monte','01028','Cherokee','Aberg'),(68,68,1,'Brazil','Tarauacá','86869','Dorton','Di Loreto'),(69,69,1,'China','Weiguo','10','Montana','Wayridge'),(70,70,1,'Greece','Anthoúsa','90936','Troy','Hazelcrest'),(71,71,1,'Indonesia','Gogosuket','1','West','Merry'),(72,72,1,'China','Hengliang','4','Acker','Surrey'),(73,73,1,'Honduras','San Marcos','64','Clemons','Moland'),(74,74,1,'Sweden','Luleå','122','Loftsgordon','Jenifer'),(75,75,1,'Indonesia','Teluk Pinang','5624','Northwestern','Alpine'),(76,76,1,'China','Fengcheng','32428','Monica','Park Meadow'),(77,77,1,'Indonesia','Poja','95106','Aberg','Canary'),(78,78,1,'Portugal','Aldeia de Além','34073','Michigan','Bobwhite'),(79,79,1,'Indonesia','Rukunlima Bawah','5573','Shelley','Waubesa'),(80,80,1,'China','Helang','4712','Cambridge','Riverside'),(81,81,1,'Colombia','Puerto Colombia','393','Shopko','West'),(82,82,1,'Mauritania','Zouérat','858','Village Green','Portage'),(83,83,1,'Russia','Koygorodok','32','Crest Line','Forest Dale'),(84,84,1,'Serbia','Ilandža','333','Debs','Anhalt'),(85,85,1,'United States','Boston','01','Comanche','Riverside'),(86,86,1,'France','Montpellier','464','Superior','Troy'),(87,87,1,'France','Paris 17','018','Hoepker','Clyde Gallagher'),(88,88,1,'Czech Republic','Nýdek','49','Laurel','Raven'),(89,89,1,'Argentina','Córdoba','4','Arapahoe','Warner'),(90,90,1,'China','Xazgat','7714','Dryden','Waubesa'),(91,91,1,'Finland','Riihimäki','78694','Thackeray','Ridge Oak'),(92,92,1,'Finland','Kirkkonummi','8920','Helena','Bobwhite'),(93,93,1,'China','Yongding','28394','Bellgrove','Schiller'),(94,94,1,'Russia','Stodolishche','9','Roth','Buena Vista'),(95,95,1,'Democratic Republic of the Congo','Uvira','30','Montana','Mandrake'),(96,96,1,'Ivory Coast','Soubré','927','Randy','Vermont'),(97,97,1,'Ukraine','Savran’','1142','Jackson','Green Ridge'),(98,98,1,'Israel','Herzliyya','1','Stuart','Twin Pines'),(99,99,1,'Peru','Churubamba','10931','Kensington','Haas'),(100,100,1,'China','Gantang','9637','Farmco','Green Ridge'),(101,101,1,'Serbia','Nikolinci','90','Eliot','Onsgard'),(102,102,1,'Mexico','San Isidro','88','Buena Vista','Anzinger'),(103,103,1,'Greece','Káto Glikóvrisi','864','Summit','Loftsgordon'),(104,104,1,'Peru','Llocllapampa','46489','Troy','Onsgard'),(105,105,1,'South Korea','Cheongju-si','841','Maryland','Bellgrove'),(106,106,1,'Indonesia','Semongkat','8007','American','Meadow Valley'),(107,107,1,'Japan','Nishi-Tokyo-shi','80','Thackeray','Mayer'),(108,108,1,'Thailand','Huai Yot','35','Blaine','Doe Crossing'),(109,109,1,'France','Arbois','2','Corben','Continental'),(110,110,1,'China','Tongyangdao','43502','Ridge Oak','Golf View'),(111,111,1,'France','Lille','23731','Ramsey','Hauk'),(112,112,1,'Poland','Przemęt','02473','Bartillon','Londonderry'),(113,113,1,'Japan','Nakanojōmachi','54324','Everett','Fallview'),(114,114,1,'China','Heze','9830','Ronald Regan','Jay'),(115,115,1,'Sweden','Charlottenberg','94','Pankratz','Manley'),(116,116,1,'Russia','Primorka','795','Tomscot','Schurz'),(117,117,1,'China','Xiaochuan','5','Scoville','East'),(118,118,1,'Colombia','Funza','2','Blaine','Bunting'),(119,119,1,'Philippines','Mailag','96990','Darwin','Bunting'),(120,120,1,'Japan','Inashiki','54','Lakewood','Westerfield'),(121,121,1,'Ethiopia','Debre Mark’os','22','Dapin','Dovetail'),(122,122,1,'United States','Washington','07','Drewry','Northport'),(123,123,1,'Indonesia','Peuteuy','04','Bultman','Canary'),(124,124,1,'China','Fenshui','25','Cordelia','Forster'),(125,125,1,'Palestinian Territory','Banī Zayd','1272','Katie','Dunning'),(126,126,1,'Philippines','Rosario','56487','Pepper Wood','Logan'),(127,127,1,'China','Jiaomingsi','2922','Northwestern','Saint Paul'),(128,128,1,'Brazil','Murici','23782','Valley Edge','Oak'),(129,129,1,'Russia','Khotynets','28598','Everett','Stang'),(130,130,1,'Venezuela','Seboruco','36144','Merry','Hintze'),(131,131,1,'China','Shuangfeng','8','Oakridge','Acker'),(132,132,1,'Portugal','Santa Bárbara de Padrões','41','Acker','Warner'),(133,133,1,'France','Tarbes','735','Anhalt','Hoepker'),(134,134,1,'Faroe Islands','Sandur','9','Loftsgordon','Hoffman'),(135,135,1,'Brazil','Itumbiara','0','Thackeray','Jana'),(136,136,1,'Indonesia','Potlot','1756','Melody','Coolidge'),(137,137,1,'Russia','Glotovka','28','Dorton','Buhler'),(138,138,1,'Russia','Rostov-na-Donu','18683','Morningstar','Dakota'),(139,139,1,'Andorra','la Massana','27932','Moulton','Arrowood'),(140,140,1,'Peru','Cocabamba','95071','Cascade','Burrows'),(141,141,1,'United States','Washington','236','Spenser','Rigney'),(142,142,1,'New Zealand','Wakefield','04','David','Monica'),(143,143,1,'Russia','Verkhnevilyuysk','88','Welch','Linden'),(144,144,1,'Morocco','Smimou','06399','Ilene','Tomscot'),(145,145,1,'Russia','Shchelkovo','24','Bellgrove','Milwaukee'),(146,146,1,'China','Kertai','2','Warbler','Havey'),(147,147,1,'Albania','Gostimë','8','Summerview','Forest'),(148,148,1,'Chile','Chonchi','3','Dennis','Loftsgordon'),(149,149,1,'Indonesia','Bentengjawa','70757','Golf Course','Birchwood'),(150,150,1,'Indonesia','Pasararba','65','Monument','Lawn'),(151,151,1,'Belarus','Mstsislaw','37','Raven','Killdeer'),(152,152,1,'Portugal','Vale Boeiro','54534','Forest Run','Arapahoe'),(153,153,1,'China','Hailin','44','Delaware','Trailsway'),(154,154,1,'China','Huangbei','76','Briar Crest','Florence'),(155,155,1,'Indonesia','Cipesing','70','Dapin','Oakridge'),(156,156,1,'China','Huangtan','52','Montana','Loftsgordon'),(157,157,1,'Portugal','Castanheira','05','Bonner','Victoria'),(158,158,1,'Argentina','Puerto Eldorado','29','Gerald','Oak Valley'),(159,159,1,'China','Huangjinbu','77','Warrior','Grayhawk'),(160,160,1,'Bosnia and Herzegovina','Piskavica','67','Kenwood','Quincy'),(161,161,1,'China','Tangdong','5','Autumn Leaf','Golf'),(162,162,1,'Brazil','Catalão','22753','Superior','Loeprich'),(163,163,1,'Sweden','Oskarshamn','577','Larry','Monument'),(164,164,1,'Japan','Toyota','5623','Bluestem','Autumn Leaf'),(165,165,1,'Indonesia','Belang','701','8th','Northport'),(166,166,1,'Indonesia','Bualu','60797','Melvin','Towne'),(167,167,1,'Indonesia','Daleman','1','Thompson','Amoth'),(168,168,1,'Philippines','Pidigan','4814','Prentice','International'),(169,169,1,'China','Damu','69374','Schmedeman','Garrison'),(170,170,1,'Libya','Al Jadīd','582','Logan','Rigney'),(171,171,1,'Russia','Setun’','5','Superior','Gulseth'),(172,172,1,'Brazil','Fortaleza','306','Anthes','Lakeland'),(173,173,1,'United States','Tucson','4','Ludington','Stephen'),(174,174,1,'France','Villeneuve-d\'Ascq','97881','Rieder','Glacier Hill'),(175,175,1,'China','Aihua','8','John Wall','Dahle'),(176,176,1,'Nicaragua','El Rosario','43459','Dahle','Stephen'),(177,177,1,'Czech Republic','Doudleby nad Orlicí','36','Mifflin','Fisk'),(178,178,1,'Finland','Kuusjoki','29','Green Ridge','Butternut'),(179,179,1,'China','Shiyaogou','9','Jenna','Aberg'),(180,180,1,'China','Erping','56175','Heath','Troy'),(181,181,1,'China','Huayang','2174','Forest','Del Sol'),(182,182,1,'Israel','Gedera','903','Fuller','Commercial'),(183,183,1,'Ukraine','Luzhany','5','Bay','Spaight'),(184,184,1,'Honduras','Quimistán','46','Elmside','Waywood'),(185,185,1,'Portugal','Maiorca','07501','Forest Dale','Westend'),(186,186,1,'Portugal','Pisões','591','Arapahoe','Forest Run'),(187,187,1,'China','Dongtang','7','Jana','Forest'),(188,188,1,'China','Fuyang','8407','Jenifer','Mcbride'),(189,189,1,'Poland','Lutowiska','5177','Florence','Surrey'),(190,190,1,'Indonesia','Rukem','1','Buell','Mandrake'),(191,191,1,'China','Longxi','99575','Bashford','Hallows'),(192,192,1,'China','Dezhou','71','Schmedeman','Butterfield'),(193,193,1,'China','Yili','6235','Helena','Mosinee'),(194,194,1,'Indonesia','Rawa Satu','7224','Sachs','Pond'),(195,195,1,'Brazil','São João da Boa Vista','681','Lyons','Continental'),(196,196,1,'Poland','Walce','9997','Myrtle','Algoma'),(197,197,1,'Papua New Guinea','Mendi','3581','Crescent Oaks','Summerview'),(198,198,1,'Ecuador','Otavalo','2','Kingsford','Upham'),(199,199,1,'Venezuela','Santa María de Caparo','82197','Colorado','Muir'),(200,200,1,'Bhutan','Lhuentse','4','Almo','Rigney'),(201,201,1,'Oman','Şaḩam','11870','Northview','Dryden'),(202,202,1,'China','Zhaowanzhuang','05301','Southridge','Lindbergh'),(203,203,1,'Uganda','Kyankwanzi','18','Cherokee','Reindahl'),(204,204,1,'Portugal','Alpiarça','11503','Kensington','American'),(205,205,1,'Azerbaijan','Geoktschai','05862','Hooker','Sycamore'),(206,206,1,'China','Wa’erma','88','Becker','Northfield'),(207,207,1,'China','Baiyushan','3','Mayfield','Granby'),(208,208,1,'Russia','Kachkanar','865','Birchwood','Nancy'),(209,209,1,'Zimbabwe','Chitungwiza','1','Old Gate','Anthes'),(210,210,1,'France','Évreux','6449','Kennedy','Pierstorff'),(211,211,1,'Palau','Melekeok Village','85923','Atwood','Manley'),(212,212,1,'China','Wenshao','91791','Paget','Esch'),(213,213,1,'Ukraine','Stari Kuty','167','Green','Steensland'),(214,214,1,'Nigeria','Zungeru','76854','Victoria','Steensland'),(215,215,1,'Greece','Kimméria','45','School','Goodland'),(216,216,1,'Mexico','Lindavista','0261','Golf Course','Sloan'),(217,217,1,'Indonesia','Soreang','9534','Clarendon','Forest Dale'),(218,218,1,'Peru','Turpo','442','Melody','Hudson'),(219,219,1,'Yemen','Al Ma‘allā’','51389','Chive','Talisman'),(220,220,1,'United States','Migrate','422','Iowa','East'),(221,221,1,'South Africa','Richmond','30657','Crowley','Village Green'),(222,222,1,'Greece','Vári','4995','Tennessee','Dunning'),(223,223,1,'China','Lianyuan','9','Portage','Lawn'),(224,224,1,'China','Qinshi','3','Cherokee','Scoville'),(225,225,1,'China','Jiguan','7','Elka','4th'),(226,226,1,'Argentina','Coronel Suárez','23215','Twin Pines','Monument'),(227,227,1,'Canada','Cookshire-Eaton','8','Arapahoe','Old Gate'),(228,228,1,'Canada','Jasper Park Lodge','68864','Northridge','Knutson'),(229,229,1,'Brazil','Várzea da Palma','55011','Sachtjen','Maryland'),(230,230,1,'Colombia','El Doncello','38','Sage','Memorial'),(231,231,1,'China','Guixi','0','Forest Run','Thompson'),(232,232,1,'Indonesia','Padangpanjang','975','Golf','Butternut'),(233,233,1,'China','Jinchuan','462','Glendale','Lien'),(234,234,1,'Russia','Uvarovo','45259','Dawn','Vernon'),(235,235,1,'South Korea','Hongsung','2','Cherokee','Rutledge'),(236,236,1,'Philippines','San Rafael','4815','Cardinal','Esker'),(237,237,1,'Poland','Choroszcz','6','Northport','Hintze'),(238,238,1,'Poland','Kurzętnik','760','Grasskamp','Anzinger'),(239,239,1,'Canada','Lac du Bonnet','1605','Miller','Donald'),(240,240,1,'Argentina','La Falda','02144','Forest Dale','Portage'),(241,241,1,'France','Marseille','30','Mariners Cove','Lighthouse Bay'),(242,242,1,'Vietnam','Văn Giang','93990','Carey','Pine View'),(243,243,1,'Portugal','Arnoia','17756','Kedzie','Redwing'),(244,244,1,'Mongolia','Doloon','95126','Luster','Heffernan'),(245,245,1,'Philippines','Carmen','3','Manufacturers','Norway Maple'),(246,246,1,'Ukraine','Stepanivka','82319','Pankratz','Kim'),(247,247,1,'Spain','Palma De Mallorca','3551','Utah','Service'),(248,248,1,'Indonesia','Grujugan','92177','Carpenter','Longview'),(249,249,1,'Liberia','Kakata','5781','Schiller','Pennsylvania'),(250,250,1,'Poland','Moryń','319','Fallview','Parkside'),(251,251,1,'China','Wushan','22','Homewood','Marquette'),(252,252,1,'Madagascar','Mananjary','944','Mayfield','Bunker Hill'),(253,253,1,'Kenya','Mumias','2338','Menomonie','Acker'),(254,254,1,'Thailand','Suphan Buri','603','Anniversary','Anderson'),(255,255,1,'China','Yunlong','22732','Sage','Welch'),(256,256,1,'Syria','Tasīl','19','Glendale','Russell'),(257,257,1,'Mongolia','Talshand','2999','Annamark','Meadow Valley'),(258,258,1,'Ethiopia','Harar','71','Independence','Rowland'),(259,259,1,'Vietnam','Cai Doi Vam','2417','Trailsway','Mayer'),(260,260,1,'Japan','Mombetsu','63','New Castle','Pearson'),(261,261,1,'Ukraine','Irshava','2','Acker','Green Ridge'),(262,262,1,'Indonesia','Gunungmanik','536','David','Westport'),(263,263,1,'Latvia','Kocēni','9572','Commercial','Westport'),(264,264,1,'Ghana','Wassa-Akropong','4','Vahlen','Warner'),(265,265,1,'Bangladesh','Sarishābāri','69','Doe Crossing','Dottie'),(266,266,1,'Indonesia','Angkimang','0','International','Oriole'),(267,267,1,'Palestinian Territory','Bayt Līd','0','Iowa','Debra'),(268,268,1,'China','Takeshiken','360','4th','Dapin'),(269,269,1,'China','Dongyuan','4624','Buhler','Fallview'),(270,270,1,'France','Périgny','02','Bayside','Crescent Oaks'),(271,271,1,'Cambodia','Kampong Chhnang','173','Dwight','Elka'),(272,272,1,'China','Weishan','6764','School','Cody'),(273,273,1,'Japan','Kashiwazaki','4','Merrick','Schurz'),(274,274,1,'Pakistan','Sobhādero','30','6th','Jackson'),(275,275,1,'Indonesia','Unden','97','Oak','Donald'),(276,276,1,'Russia','Labytnangi','5','Russell','Hooker'),(277,277,1,'China','Qinggang','02','Cascade','Miller'),(278,278,1,'Armenia','Ddmashen','523','Brentwood','Glacier Hill'),(279,279,1,'Russia','Surazh','89','Warbler','Mariners Cove'),(280,280,1,'Russia','Krasnogorskoye','44224','Sundown','Pepper Wood'),(281,281,1,'Canada','Newmarket','9821','Melody','Trailsway'),(282,282,1,'Russia','Bibirevo','11874','Tomscot','Graceland'),(283,283,1,'Dominican Republic','Salcedo','641','Miller','Cambridge'),(284,284,1,'Palestinian Territory','Bayt Ūlā','2','Elka','Bultman'),(285,285,1,'Indonesia','Sumurnanjung','84420','Farmco','Buhler'),(286,286,1,'China','Jinshanpu','53874','2nd','Becker'),(287,287,1,'China','Shijiazhai','69','Pepper Wood','Union'),(288,288,1,'Indonesia','Ciawitali','960','Erie','Emmet'),(289,289,1,'Portugal','Picoto','72','Autumn Leaf','Jana'),(290,290,1,'Russia','Obninsk','4485','Hollow Ridge','Annamark'),(291,291,1,'China','Pukou','09199','Oak','Cordelia'),(292,292,1,'Argentina','San Jorge','6251','Jackson','Mitchell'),(293,293,1,'China','Shiqiao','14','Rieder','Chinook'),(294,294,1,'China','Pingfeng','79','Havey','Alpine'),(295,295,1,'Malaysia','Petaling Jaya','28155','Miller','Browning'),(296,296,1,'Sweden','Ulricehamn','9','Mariners Cove','Ruskin'),(297,297,1,'China','Dafang','97','Judy','Steensland'),(298,298,1,'United States','Alexandria','206','Arizona','Hollow Ridge'),(299,299,1,'Brazil','Orós','01','Red Cloud','Stone Corner'),(300,300,1,'Indonesia','Ciusul','09510','Sutteridge','Nova'),(301,301,1,'American Samoa','Vaitogi','00996','Michigan','Hazelcrest'),(302,302,1,'Philippines','Magsaysay','3380','Oneill','Eagle Crest'),(303,303,1,'Morocco','Oujda','041','Scofield','Prairie Rose'),(304,304,1,'Russia','Nesterovskaya','2508','Meadow Vale','High Crossing'),(305,305,1,'China','Huanggexi','6','Fremont','Haas'),(306,306,1,'China','Xinpeicun','15232','Lake View','Hansons'),(307,307,1,'Sweden','Stockholm','69','Arrowood','Carey'),(308,308,1,'Portugal','Ribamar','5846','Melby','Transport'),(309,309,1,'Russia','Georgiyevsk','19','Autumn Leaf','Esker'),(310,310,1,'Hungary','Nyíregyháza','8','Merrick','Straubel'),(311,311,1,'Afghanistan','Shibirghān','33','Schlimgen','Melvin'),(312,312,1,'Portugal','Telhado','1641','Donald','Hagan'),(313,313,1,'France','Chenôve','02089','Huxley','Merchant'),(314,314,1,'Russia','Pivovarikha','6','Cherokee','Bellgrove'),(315,315,1,'Indonesia','Huilelot','883','Packers','Tony'),(316,316,1,'Argentina','Malvinas Argentinas','226','Gulseth','Scofield'),(317,317,1,'Philippines','Ajuy','28355','Commercial','Ronald Regan'),(318,318,1,'Indonesia','Gombong','1','Roxbury','Dayton'),(319,319,1,'Russia','Perm','3','Sunfield','Loomis'),(320,320,1,'Philippines','Malitubog','606','Arrowood','Macpherson'),(321,321,1,'Brazil','Rio do Sul','3169','Sugar','American'),(322,322,1,'Indonesia','Gungguh','7','Sunfield','Fulton'),(323,323,1,'Macedonia','Čair','4','Oak Valley','Jay'),(324,324,1,'Colombia','Los Andes','3','Hintze','Paget'),(325,325,1,'Russia','Ust’-Ulagan','102','Merry','Pankratz'),(326,326,1,'Sweden','Solna','03','Fairview','Forest Dale'),(327,327,1,'Canada','Gananoque','22','Transport','Declaration'),(328,328,1,'South Africa','Kraaifontein','1049','Fair Oaks','Pierstorff'),(329,329,1,'China','Dafang','61598','Old Gate','Nova'),(330,330,1,'Russia','Verbilki','84','Ryan','Orin'),(331,331,1,'Guatemala','La Reforma','9683','Messerschmidt','Anzinger'),(332,332,1,'China','Nanzhang Chengguanzhen','543','Commercial','1st'),(333,333,1,'Sweden','Solna','63','Forest','Garrison'),(334,334,1,'Portugal','Feteira Grande','58','Eagle Crest','Maywood'),(335,335,1,'Russia','Shar’ya','29275','Bunker Hill','Clemons'),(336,336,1,'Iran','Behbahān','3433','Graedel','Troy'),(337,337,1,'Colombia','Algarrobo','7288','Leroy','Warbler'),(338,338,1,'Philippines','Mabilang','75','Ryan','Bonner'),(339,339,1,'Canada','Fermont','34','Fairfield','Scott'),(340,340,1,'Philippines','Mercedes','2942','Iowa','Twin Pines'),(341,341,1,'Libya','Nālūt','06','Mariners Cove','Delaware'),(342,342,1,'Brazil','Pindamonhangaba','16452','Lukken','Maple'),(343,343,1,'Poland','Łubowo','5112','Schmedeman','Lake View'),(344,344,1,'Vietnam','Tân Sơn','4','West','Hanover'),(345,345,1,'Indonesia','Beutong Ateuh','70558','Merchant','Elgar'),(346,346,1,'China','Zhongshan','90107','Kingsford','Kipling'),(347,1,2,'China','Pingba','4','Vahlen','Pond'),(348,2,2,'United States','Garland','52','New Castle','Vermont'),(349,3,2,'Armenia','Myasnikyan','269','Coolidge','Marquette'),(350,4,2,'Ireland','Swords','4137','Shoshone','Derek'),(351,5,2,'Philippines','Tajao','8','Oak','Golf'),(352,6,2,'United States','San Francisco','2668','Jay','Larry'),(353,7,2,'China','Chengbei','445','Haas','Cottonwood'),(354,8,2,'Malaysia','Kuantan','98698','Dixon','Boyd'),(355,9,2,'China','Gubeikou','83','Schlimgen','Mallory'),(356,10,2,'Belarus','Druya','67','Basil','Buhler'),(357,11,2,'China','Bahaodi','20','Glendale','Magdeline'),(358,12,2,'Sweden','Karlstad','694','4th','Rowland'),(359,13,2,'Brazil','Conde','42139','Schiller','Bartelt'),(360,14,2,'Serbia','Radenković','4','Hoepker','Brentwood'),(361,15,2,'China','Duogongma','35643','Vermont','Parkside'),(362,16,2,'Tanzania','Makumbako','1911','Summit','Vermont'),(363,17,2,'China','Taosha','436','Forest Run','Anhalt'),(364,18,2,'Malaysia','Kota Kinabalu','25965','Huxley','Nancy'),(365,19,2,'Nigeria','Gora','5892','Pawling','Gale'),(366,20,2,'South Korea','Kunsan','31','Superior','Jay'),(367,21,2,'Madagascar','Ankazoabo','48066','Mayer','Holy Cross'),(368,22,2,'Honduras','La Jutosa','2','Sommers','Susan'),(369,23,2,'Argentina','Allen','02021','Katie','Hansons'),(370,24,2,'Jamaica','Port Maria','2800','3rd','Sutherland'),(371,25,2,'Portugal','Almeirim','36641','Manitowish','Rutledge'),(372,26,2,'China','Zhongxing','7399','Lunder','Del Mar'),(373,27,2,'Philippines','Simod','0434','Claremont','Center'),(374,28,2,'Sweden','Kista','0','Melrose','Dunning'),(375,29,2,'Mali','San','26','Stoughton','Macpherson'),(376,30,2,'Vietnam','Tiền Hải','22','Norway Maple','Gale'),(377,31,2,'Brazil','Santa Quitéria do Maranhão','97358','Dwight','Esker'),(378,32,2,'Honduras','Ayapa','9','Steensland','Oriole'),(379,33,2,'China','Shangshaleng','901','Sommers','Nobel'),(380,34,2,'Botswana','Mathambgwane','4131','Porter','Warbler'),(381,35,2,'Djibouti','Tadjoura','8445','Esch','Manitowish'),(382,36,2,'Japan','Ichinohe','89','Hagan','Fremont'),(383,37,2,'Mexico','Loma Alta','865','Artisan','Moose'),(384,38,2,'China','Biaoshan','5','Granby','Northridge'),(385,39,2,'China','Linquan','6','Talmadge','Crest Line'),(386,40,2,'Russia','Belovo','2','Main','Havey'),(387,41,2,'Nicaragua','León','9584','Jay','Waywood'),(388,42,2,'Greece','Neochórion','0','Oxford','Ramsey'),(389,43,2,'Belarus','Vishnyeva','159','Caliangt','Tennyson'),(390,44,2,'Poland','Olesno','62044','Park Meadow','Marcy'),(391,45,2,'Croatia','Bršadin','23716','Gina','Russell'),(392,46,2,'Indonesia','Gedongmulyo','7','Messerschmidt','Golf'),(393,47,2,'Thailand','Lom Sak','081','Pine View','Monument'),(394,48,2,'Slovenia','Senovo','87','Bay','Sugar'),(395,49,2,'Peru','Mollepampa','5','Claremont','Dorton'),(396,50,2,'China','Tangxi','1','Lighthouse Bay','Kropf'),(397,51,2,'Russia','Paratunka','41','Cascade','Memorial'),(398,52,2,'Russia','Novogurovskiy','464','Ilene','Caliangt'),(399,53,2,'Swaziland','Tshaneni','6','Tennessee','Randy'),(400,54,2,'Argentina','Tandil','23170','Dawn','Evergreen'),(401,55,2,'Japan','Mitake','2055','Grover','Helena'),(402,56,2,'Nepal','Nawal','571','Golden Leaf','Hollow Ridge'),(403,57,2,'Mexico','Lazaro Cardenas','5','Bartillon','Sutherland'),(404,58,2,'China','Beishan','09','Kipling','Nelson'),(405,59,2,'Panama','Río Alejandro','93170','Warner','John Wall'),(406,60,2,'Indonesia','Leles','3239','Monterey','Scofield'),(407,61,2,'Ukraine','Kulykiv','40','Daystar','Michigan'),(408,62,2,'China','Jingyang','390','Coleman','Victoria'),(409,63,2,'China','Beijiang','75633','Norway Maple','Caliangt'),(410,64,2,'Vietnam','Thị Trấn Nước Hai','8','Schurz','Northfield'),(411,65,2,'Pakistan','Jahāniān Shāh','5','6th','Buell'),(412,66,2,'Malaysia','Ipoh','24602','Heath','Karstens'),(413,67,2,'Serbia','Sombor','88012','North','Melody'),(414,68,2,'Brazil','Gravataí','98','Merry','Reinke'),(415,69,2,'Philippines','Pola','900','Bowman','Center'),(416,70,2,'Colombia','Guaitarilla','5103','Northridge','Memorial'),(417,71,2,'Russia','Gryaznovskoye','2','Monterey','Debra'),(418,72,2,'China','Baoping','87600','Milwaukee','Independence'),(419,73,2,'Indonesia','Selasari','257','1st','High Crossing'),(420,74,2,'Czech Republic','Zbraslav','540','Cambridge','Monica'),(421,75,2,'China','Changning','19948','Texas','Erie'),(422,76,2,'Serbia','Stepanovićevo','959','Golf Course','7th'),(423,77,2,'Indonesia','Bireun','71','Fuller','Arkansas'),(424,78,2,'Poland','Czarna Białostocka','85707','Lotheville','Mockingbird'),(425,79,2,'China','Fucheng','63605','Rieder','Helena'),(426,80,2,'Sudan','Geneina','920','Eastlawn','Westerfield'),(427,81,2,'Brazil','Lapa','69','Manley','Harbort'),(428,82,2,'Ivory Coast','Vavoua','31','Sugar','Lakewood'),(429,83,2,'Russia','Sobinka','47','Hudson','Stang'),(430,84,2,'Indonesia','Parungjawa','43706','Darwin','Morrow'),(431,85,2,'Poland','Jedlnia-Letnisko','41398','Surrey','Judy'),(432,86,2,'Philippines','Apurawan','14','Pearson','Jana'),(433,87,2,'Brazil','Buritizeiro','029','Novick','Pleasure'),(434,88,2,'Indonesia','Kampungsusah','5','Dennis','Bobwhite'),(435,89,2,'China','Yushu','9','Emmet','Towne'),(436,90,2,'Philippines','Lumil','6','Nova','Killdeer'),(437,91,2,'Norway','Oslo','82','Summerview','Eagan'),(438,92,2,'China','Jianxincun','54679','Schmedeman','Lien'),(439,93,2,'China','Qiganjidie','60','Norway Maple','Iowa'),(440,94,2,'China','Fenghuanglu','473','Parkside','Algoma'),(441,95,2,'China','Xiaoxi','816','Towne','Fremont'),(442,96,2,'Indonesia','Hantara','6','Oxford','Transport'),(443,97,2,'China','Jingmao','020','Kropf','Ronald Regan'),(444,98,2,'China','Lintingkou','91','Nova','Forest Dale'),(445,99,2,'China','Qingping','314','Delladonna','Sage'),(446,100,2,'Poland','Mońki','25','Shoshone','Talisman'),(447,101,2,'Philippines','Santo Domingo','2304','Center','Browning'),(448,102,2,'Iraq','Ar Ruţbah','7','Carberry','Beilfuss'),(449,103,2,'Democratic Republic of the Congo','Kabare','67','Bay','Macpherson'),(450,104,2,'Brazil','Diamantino','683','Eliot','Merchant'),(451,105,2,'Colombia','Ábrego','39409','Vidon','Coolidge'),(452,106,2,'Sweden','Svalöv','397','Marquette','West'),(453,107,2,'Indonesia','Campaka','4819','Redwing','Pierstorff'),(454,108,2,'China','Banqiao','97464','Meadow Vale','Forster'),(455,109,2,'Poland','Krotoszyn','2','Beilfuss','7th'),(456,110,2,'Panama','Nuevo Emperador','735','Melvin','Forest Run'),(457,111,2,'Russia','Neftegorsk','17','Heffernan','Debra'),(458,112,2,'Argentina','San Javier','95','Talisman','Erie'),(459,113,2,'Indonesia','Koanara','3645','Garrison','Vernon'),(460,114,2,'China','Shuitai','2','Erie','Johnson'),(461,115,2,'Yemen','Al Ḩumaydāt','65','Nancy','Lawn'),(462,116,2,'Azerbaijan','Sumqayıt','1','Maple','Aberg'),(463,117,2,'Cuba','Cárdenas','97','Texas','Messerschmidt'),(464,118,2,'Nigeria','Ikang','50509','Forest Dale','Morningstar'),(465,119,2,'Nigeria','Osogbo','18226','Shelley','Michigan'),(466,120,2,'Peru','Camilaca','58342','Linden','Pierstorff'),(467,121,2,'Sweden','Sölvesborg','689','Pepper Wood','Steensland'),(468,122,2,'China','Yuhang','603','Menomonie','Saint Paul'),(469,123,2,'Russia','Amga','23','4th','Manitowish'),(470,124,2,'Philippines','Guijalo','8','Loftsgordon','Anniversary'),(471,125,2,'Indonesia','Dowan','31528','Nobel','Londonderry'),(472,126,2,'Poland','Drawsko','4','Scott','Fair Oaks'),(473,127,2,'Zambia','Lusaka','5006','Magdeline','Eagle Crest'),(474,128,2,'Indonesia','Watuagung','8','Delaware','Rusk'),(475,129,2,'Tanzania','Somanda','501','Maple','Kings'),(476,130,2,'Sweden','Strömsnäsbruk','6504','Meadow Valley','East'),(477,131,2,'China','Bacheng','8978','Carey','Superior'),(478,132,2,'Laos','Không','95557','Colorado','Grayhawk'),(479,133,2,'Ecuador','Manta','6502','Arapahoe','Loftsgordon'),(480,134,2,'Morocco','Tissa','67','Sundown','Knutson'),(481,135,2,'Indonesia','Krajan Nglinggis','9','Vahlen','Cody'),(482,136,2,'Poland','Nowy Dwór Gdański','47','Delladonna','Manufacturers'),(483,137,2,'China','Baitu','4','Merrick','Larry'),(484,138,2,'Democratic Republic of the Congo','Libenge','75','Burrows','Algoma'),(485,139,2,'Finland','Liljendal','0','Continental','Nancy'),(486,140,2,'Brazil','Tabatinga','60131','Barnett','Troy'),(487,141,2,'China','Sanli','41','Corry','Northridge'),(488,142,2,'Japan','Handa','436','Mandrake','Sachs'),(489,143,2,'Togo','Bafilo','0','Talisman','Boyd'),(490,144,2,'Portugal','Canedo','073','Bunker Hill','Butternut'),(491,145,2,'China','Qianshan','9','Green Ridge','Mallard'),(492,146,2,'Yemen','Ta‘izz','2451','7th','Northridge'),(493,147,2,'Indonesia','Krajan Ngerdani','61809','Sunbrook','Manitowish'),(494,148,2,'Sweden','Skinnskatteberg','21','Fisk','Glacier Hill'),(495,149,2,'China','Baitian','39837','Butterfield','Straubel'),(496,150,2,'Kazakhstan','Ridder','228','Banding','Warbler'),(497,151,2,'Poland','Baranów','63861','New Castle','Helena'),(498,152,2,'Morocco','Tiouli','69280','Kedzie','Killdeer'),(499,153,2,'China','Yangxu','8394','Myrtle','Summit'),(500,154,2,'Libya','Al Burayqah','3','Bartelt','Knutson'),(501,155,2,'France','Caen','368','Sugar','Barby'),(502,156,2,'Russia','Ovsyanka','3696','Granby','Roth'),(503,157,2,'Tajikistan','Norak','5619','Forest Run','Melby'),(504,158,2,'China','Chaoshui','2','Cardinal','Pennsylvania'),(505,159,2,'Sierra Leone','Masoyila','48','High Crossing','Green'),(506,160,2,'Peru','Nazca','15','8th','Sutteridge'),(507,161,2,'Laos','Xaysetha','8313','Eastlawn','Park Meadow'),(508,162,2,'Russia','Novyye Gorki','6506','Badeau','Bartillon'),(509,163,2,'Sweden','Stockholm','61','Declaration','Thompson'),(510,164,2,'China','Yuyang','52857','Spohn','Declaration'),(511,165,2,'Kosovo','Kačanik','0912','Cody','Lakewood'),(512,166,2,'New Zealand','Winton','6','Moulton','Warrior'),(513,167,2,'China','Lutou','37619','Waywood','Monterey'),(514,168,2,'Indonesia','Pora','37184','Killdeer','Waubesa'),(515,169,2,'China','Taha Man Zu','52','Memorial','Kenwood'),(516,170,2,'Kyrgyzstan','Chayek','58','Delaware','Clyde Gallagher'),(517,171,2,'Canada','Saint-Eustache','3604','Tennyson','Katie'),(518,172,2,'China','Loujiadian','711','Randy','Lotheville'),(519,173,2,'Brazil','Votorantim','67','Del Sol','Hoard'),(520,174,2,'Kazakhstan','Ush-Tyube','76','Eagle Crest','5th'),(521,175,2,'Japan','Kōchi-shi','45872','Express','Hovde'),(522,176,2,'Indonesia','Taimaman','756','Canary','Granby'),(523,177,2,'Portugal','Alpedrinha','9','Straubel','Montana'),(524,178,2,'Indonesia','Ploso','5635','Fallview','Stephen'),(525,179,2,'Morocco','Tafraout','801','Merchant','Fulton'),(526,180,2,'Palestinian Territory','Dayr Sāmit','2','Park Meadow','Corry'),(527,181,2,'China','Shuinan','062','Mariners Cove','Eastlawn'),(528,182,2,'China','Gujiadian','4','Express','Stuart'),(529,183,2,'Canada','Grand Bank','4','North','Lukken'),(530,184,2,'China','Jidong','58714','Roth','Hoffman'),(531,185,2,'Indonesia','Nanggorak','94993','Grover','Schmedeman'),(532,186,2,'China','Jiangmen','76940','Shasta','Lillian'),(533,187,2,'Ireland','Ballina','82','Glacier Hill','Everett'),(534,188,2,'China','Ruilin','69','Elka','Butterfield'),(535,189,2,'Japan','Yono','0468','Menomonie','Fordem'),(536,190,2,'Ethiopia','Addis Ababa','0703','Lien','Loeprich'),(537,191,2,'Indonesia','Bulubrangsi','7','Melvin','Maryland'),(538,192,2,'Thailand','Yaring','428','Sunfield','Lien'),(539,193,2,'China','Qingzhou','1','Lerdahl','Twin Pines'),(540,194,2,'Japan','Tōkamachi','77','Mayer','La Follette'),(541,195,2,'Gambia','Sun Kunda','781','Manufacturers','Luster'),(542,196,2,'Indonesia','Cipicung','2377','Jackson','Butternut'),(543,197,2,'China','Macheng','08','Continental','Susan'),(544,198,2,'China','Longchi','533','Prentice','Oakridge'),(545,199,2,'South Korea','Imsil','23398','Northwestern','North'),(546,200,2,'Bangladesh','Cox’s Bāzār','56','Warner','Golden Leaf'),(547,201,2,'Sweden','Limmared','752','Warrior','Stuart'),(548,202,2,'China','Banjiang','26930','Maryland','Westridge'),(549,203,2,'Russia','Tselinnoye','6369','Ruskin','Manitowish'),(550,204,2,'Indonesia','Pasirbatang','70186','Sunnyside','Hazelcrest'),(551,205,2,'China','Xindi','5','Marquette','Tomscot'),(552,206,2,'Armenia','Dimitrov','83','Kropf','Westend'),(553,207,2,'Bosnia and Herzegovina','Petkovci','9','Algoma','Corry'),(554,208,2,'China','Taiba','558','Morrow','Crescent Oaks'),(555,209,2,'China','Baolong','1','Amoth','Independence'),(556,210,2,'Philippines','Calamba','23515','Amoth','Saint Paul'),(557,211,2,'Argentina','Huinca Renancó','822','Artisan','Nova'),(558,212,2,'Poland','Złota','092','Drewry','Tony'),(559,213,2,'Latvia','Pļaviņas','5','Schlimgen','Monica'),(560,214,2,'China','Toutuo','5031','Basil','Hanson'),(561,215,2,'Russia','Tuchkovo','80','Mccormick','Shasta'),(562,216,2,'Sweden','Örebro','1540','Vermont','Lyons'),(563,217,2,'Sweden','Eslöv','73','Park Meadow','Miller'),(564,218,2,'Senegal','Ziguinchor','93','Hudson','Michigan'),(565,219,2,'Bolivia','Vallegrande','8516','Ronald Regan','Westport'),(566,220,2,'El Salvador','San Antonio del Monte','9','Grim','Kropf'),(567,221,2,'China','Hanghuadian','04508','Badeau','Rockefeller'),(568,222,2,'Kazakhstan','Derzhavīnsk','05393','Forest','Heath'),(569,223,2,'China','Shuangchahe','68177','Ilene','Morning'),(570,224,2,'Japan','Nakanojōmachi','36548','Forest','Macpherson'),(571,225,2,'Portugal','Castedo','016','Sunbrook','Eliot'),(572,226,2,'China','Zhaocun','196','Schlimgen','Packers'),(573,227,2,'Nigeria','Oke Mesi','18','Maryland','New Castle'),(574,228,2,'Ivory Coast','Bouaflé','5398','Holmberg','Hagan'),(575,229,2,'United States','Pittsburgh','130','Artisan','Spaight'),(576,230,2,'Canada','Grande Prairie','4','Annamark','Forest Run'),(577,231,2,'Mexico','Primero de Mayo','539','Thompson','Nova'),(578,232,2,'Russia','Donskoye','13','Green Ridge','Sommers'),(579,233,2,'China','Daxindian','83','Magdeline','Towne'),(580,234,2,'Peru','Laramate','45119','Darwin','Dahle'),(581,235,2,'Cuba','Sagua la Grande','4','Redwing','Pankratz'),(582,236,2,'Vanuatu','Isangel','7234','La Follette','Blaine'),(583,237,2,'China','Xinxing','5','Reindahl','Sunnyside'),(584,238,2,'Ireland','Templeogue','3974','Grim','Vera'),(585,239,2,'Indonesia','Cieurih Satu','7','Eggendart','Mandrake'),(586,240,2,'France','Istres','04676','Heath','Grim'),(587,241,2,'Argentina','Villa María','77225','David','Amoth'),(588,242,2,'Indonesia','Sungai Raya','3','Stone Corner','Ronald Regan'),(589,243,2,'Bolivia','San Borja','49245','Clarendon','Fallview'),(590,244,2,'China','Xinsheng','17670','Briar Crest','Rowland'),(591,245,2,'China','Longnan','3630','Corry','American Ash'),(592,246,2,'China','Caozhen','654','Comanche','Golf View'),(593,247,2,'Honduras','Petoa','0','Grover','Nancy'),(594,248,2,'Poland','Sieradza','4','Macpherson','Heath'),(595,249,2,'France','Grenoble','3','Lakeland','Loftsgordon'),(596,250,2,'Serbia','Uzdin','051','Portage','Kropf'),(597,251,2,'Germany','Chemnitz','9913','Scott','Oriole'),(598,252,2,'Mexico','La Libertad','1954','Hansons','Ridge Oak'),(599,253,2,'China','Shenkou','79','Pankratz','Shoshone'),(600,254,2,'Brazil','Vilhena','5443','Fairfield','Macpherson'),(601,255,2,'Philippines','Naguilian','530','Meadow Ridge','Swallow'),(602,256,2,'China','Anfu','460','Gina','Annamark'),(603,257,2,'Brazil','Poço Verde','8946','Springs','5th'),(604,258,2,'Czech Republic','Dobratice','007','Florence','Sloan'),(605,259,2,'Russia','Shcherbinka','41017','Barby','David'),(606,260,2,'China','Minle','410','Saint Paul','Mallard'),(607,261,2,'Czech Republic','Bukovany','2','Sycamore','Jana'),(608,262,2,'China','Gaopi','9','Warbler','Meadow Ridge'),(609,263,2,'Poland','Rachanie','48','Raven','Steensland'),(610,264,2,'Philippines','Calamba','805','Hagan','Bluejay'),(611,265,2,'Ukraine','Horodyshche','33','Orin','Haas'),(612,266,2,'United States','Atlanta','72','Carberry','Moose'),(613,267,2,'China','Darenzhuang','439','Scott','Duke'),(614,268,2,'Iran','Bandar-e Māhshahr','19657','Hauk','Cherokee'),(615,269,2,'Indonesia','Gunungkendeng','3','Crowley','Lunder'),(616,270,2,'Russia','Rumyantsevo','89370','Mockingbird','Hansons'),(617,271,2,'Russia','Promyshlennovskiy','690','New Castle','Village'),(618,272,2,'Russia','Uritsk','03731','Rutledge','Rutledge'),(619,273,2,'Sudan','Al Mijlad','6327','Messerschmidt','Westridge'),(620,274,2,'Brazil','Arcos','98','Macpherson','Sugar'),(621,275,2,'China','Dongzhou','63','Basil','Armistice'),(622,276,2,'Honduras','Sulaco','1','Heath','Oriole'),(623,277,2,'Greece','Erátyra','695','Cascade','Sutherland'),(624,278,2,'Philippines','Pulilan','71','Hoffman','Karstens'),(625,279,2,'Poland','Opoczno','417','Tomscot','School'),(626,280,2,'China','Xikou','048','Annamark','Westerfield'),(627,281,2,'Poland','Koronowo','68694','Morningstar','Crest Line'),(628,282,2,'Canada','Bridgewater','57944','6th','Swallow'),(629,283,2,'Ecuador','Machachi','7','Tomscot','Waxwing'),(630,284,2,'Japan','Sakata','3','Main','Eastwood'),(631,285,2,'Kazakhstan','Khromtau','9','4th','Hazelcrest'),(632,286,2,'Russia','Vladikavkaz','05','Oneill','Texas'),(633,287,2,'Brazil','Piracanjuba','69358','Coolidge','Luster'),(634,288,2,'Czech Republic','Heřmanův Městec','4382','Hansons','Northview'),(635,289,2,'Indonesia','Pericik','685','Burrows','American'),(636,290,2,'Portugal','Paço','75','Shasta','Anthes'),(637,291,2,'Poland','Kamionka','941','Becker','Commercial'),(638,292,2,'Russia','Ishkhoy-Yurt','0642','Clove','Dawn'),(639,293,2,'Poland','Złotniki Kujawskie','068','Debra','Hoepker'),(640,294,2,'Russia','Ostrogozhsk','6','Lake View','Goodland'),(641,295,2,'Ukraine','Askaniya Nova','693','Service','Artisan'),(642,296,2,'Brazil','Pôrto Barra do Ivinheima','9836','Forest Dale','Annamark'),(643,297,2,'Portugal','Ifanes','1362','Comanche','Corben'),(644,298,2,'South Korea','Pubal','198','Butternut','Becker'),(645,299,2,'United States','Portland','1','Jackson','Moulton'),(646,300,2,'Serbia','Donji Dobrić','5','Tomscot','Mosinee'),(647,301,2,'Indonesia','Tiro','2','Sherman','Montana'),(648,302,2,'Peru','Carabamba','613','Hallows','Magdeline'),(649,303,2,'France','Angers','9118','Jenifer','Merchant'),(650,304,2,'Namibia','Tsumeb','3','Kings','Carberry'),(651,305,2,'China','Pujiang','990','Redwing','Bellgrove'),(652,306,2,'Portugal','Montijo','145','Bluejay','Merchant'),(653,307,2,'Brazil','Sumaré','74','Graedel','Shelley'),(654,308,2,'Philippines','Bacong','88','Kedzie','Erie'),(655,309,2,'Indonesia','Sukasada','53667','Basil','Del Mar'),(656,310,2,'Russia','Ust’-Abakan','35','Becker','Maple'),(657,311,2,'Vietnam','Hai Riêng','35818','Bartillon','Texas'),(658,312,2,'China','Anfeng','4','Moose','Homewood'),(659,313,2,'United States','Phoenix','85178','Maple','Pepper Wood'),(660,314,2,'Russia','Nizhnyaya Tura','76','Bunker Hill','Luster'),(661,315,2,'Indonesia','Kalianget','0385','Colorado','Dawn'),(662,316,2,'China','Haokou','151','Golf View','Moland'),(663,317,2,'Belarus','Vishnyeva','6698','Rockefeller','Talmadge'),(664,318,2,'Serbia','Trstenik','5568','School','Brickson Park'),(665,319,2,'Poland','Piotrków Kujawski','0','Dennis','Mandrake'),(666,320,2,'China','Gongjiahe','9','Forest','Red Cloud'),(667,321,2,'Philippines','San Jose','210','Lillian','Northfield'),(668,322,2,'Philippines','Oroquieta','40815','Swallow','Scott'),(669,323,2,'Pakistan','Jahāniān Shāh','07007','Ridgeview','Meadow Vale'),(670,324,2,'Indonesia','Sukasari','24','Tennyson','Bartillon'),(671,325,2,'China','Lukou','9','Marcy','Eggendart'),(672,326,2,'Iran','Tīrān','67174','Talisman','Westridge'),(673,327,2,'Argentina','Libertador General San Martín','118','Village Green','Comanche'),(674,328,2,'Indonesia','Krajan Baru','33','Bartelt','Lindbergh'),(675,329,2,'Brazil','Vinhedo','26934','Mockingbird','Graceland'),(676,330,2,'Indonesia','Kotabaru','75958','Northfield','Russell'),(677,331,2,'Indonesia','Sananrejo','067','Messerschmidt','East'),(678,332,2,'Indonesia','Pendawanbaru','758','Jackson','Walton'),(679,333,2,'Russia','Nikolina Gora','7','Center','Jana'),(680,334,2,'Russia','Dostoyevka','343','Buhler','Burrows'),(681,335,2,'China','Aqqan','9557','Roth','Del Mar'),(682,336,2,'Sweden','Haninge','7','Grasskamp','Sycamore'),(683,337,2,'South Africa','Balfour','1','Melrose','Jenifer'),(684,338,2,'Indonesia','Mauloo','167','Upham','Bluejay'),(685,339,2,'Germany','Essen','6','Warner','Lyons'),(686,340,2,'Russia','Kharp','50','Prairie Rose','Mendota'),(687,341,2,'Honduras','El Paraíso','3','Memorial','Steensland'),(688,342,2,'Turks and Caicos Islands','Cockburn Town','7162','Harper','Northridge'),(689,343,2,'China','Tangxia','79','Northview','Kensington'),(690,344,2,'China','Xincheng Chengguanzhen','79723','Ohio','Schlimgen'),(691,345,2,'Estonia','Tabasalu','45798','Kingsford','Division'),(692,346,2,'Moldova','Briceni','5424','Washington','Moose'),(693,1,3,'Japan','Kitakami','47','High Crossing','Pine View'),(694,2,3,'Iran','Eqlīd','77','Harbort','Kennedy'),(695,3,3,'Brazil','Ibiá','2952','Meadow Ridge','Bunting'),(696,4,3,'China','Zhuting','60','Gerald','Mcguire'),(697,5,3,'United States','Lexington','2441','Lakewood Gardens','Straubel'),(698,6,3,'China','Shunhe','8607','Packers','Marcy'),(699,7,3,'Indonesia','Kuniran','1','Lakeland','Center'),(700,8,3,'Japan','Kamiichi','787','Bay','Prentice'),(701,9,3,'France','Senlis','39','Sachtjen','Johnson'),(702,10,3,'Japan','Ōgaki','2','Lillian','Mcguire'),(703,11,3,'Philippines','Magsalangi','03086','Elmside','Springview'),(704,12,3,'Indonesia','Talun','6212','Talmadge','Transport'),(705,13,3,'Albania','Otllak','740','Corben','Surrey'),(706,14,3,'Indonesia','Feondari','28','Hooker','Birchwood'),(707,15,3,'Poland','Kraków','7236','Shoshone','Orin'),(708,16,3,'Indonesia','Kuma','468','Laurel','American'),(709,17,3,'France','Hyères','3','Ramsey','Chinook'),(710,18,3,'Sierra Leone','Sumbuya','87031','Messerschmidt','Warbler'),(711,19,3,'Niger','Niamey','242','Dennis','Packers'),(712,20,3,'Ghana','Akim Swedru','8','Sullivan','Bobwhite'),(713,21,3,'China','Wulin','5','Buell','Packers'),(714,22,3,'Pakistan','Kunjāh','1099','Elmside','Welch'),(715,23,3,'Bolivia','Jorochito','25','Mesta','Maywood'),(716,24,3,'Colombia','Ríohacha','0206','Buell','Weeping Birch'),(717,25,3,'Argentina','Comandante Luis Piedra Buena','51','Gerald','Loftsgordon'),(718,26,3,'Mexico','San Sebastian','3275','Dakota','Swallow'),(719,27,3,'Uzbekistan','Kitob','9','Parkside','Mayer'),(720,28,3,'China','Ruoqiang','4474','Blaine','Gulseth'),(721,29,3,'Czech Republic','Sadov','7','Rowland','Cardinal'),(722,30,3,'Dominican Republic','El Puerto','30970','Upham','Welch'),(723,31,3,'Norway','Porsgrunn','4940','Pleasure','Washington'),(724,32,3,'Indonesia','Cigaleuh Kulon','35','Grim','Del Mar'),(725,33,3,'Japan','Kameda-honchō','6','Doe Crossing','Nevada'),(726,34,3,'Nigeria','Mafa','83589','Twin Pines','Boyd'),(727,35,3,'Haiti','Mirebalais','85892','Autumn Leaf','Emmet'),(728,36,3,'China','Gucheng','9774','Lotheville','Kedzie'),(729,37,3,'Jordan','‘Izrā','63258','Corben','Fulton'),(730,38,3,'Brazil','Itapetinga','7','Sunnyside','Holy Cross'),(731,39,3,'China','Erdaocha','02047','Judy','Almo'),(732,40,3,'Tunisia','La Goulette','13','Johnson','Little Fleur'),(733,41,3,'France','Mende','0062','Waubesa','Victoria'),(734,42,3,'Indonesia','Tutul','38','Bowman','Swallow'),(735,43,3,'Poland','Leśnica','0124','Ridge Oak','Park Meadow'),(736,44,3,'Serbia','Senta','7023','Melvin','Erie'),(737,45,3,'Jamaica','Gordon Town','42503','Morning','Oxford'),(738,46,3,'Bangladesh','Muktāgācha','50','Melody','Claremont'),(739,47,3,'Indonesia','Sumberkenanga','0','Clarendon','Coolidge'),(740,48,3,'Czech Republic','Řehlovice','4','Dapin','Forster'),(741,49,3,'Thailand','Ban Na San','77','Stoughton','Grasskamp'),(742,50,3,'Portugal','Veiga','8523','Eggendart','Boyd'),(743,51,3,'China','Anzihao','68809','Ryan','Bellgrove'),(744,52,3,'China','Yushang','70','Harbort','Cody'),(745,53,3,'Brazil','Jaguaribe','13809','Toban','Golf View'),(746,54,3,'Russia','Kommunar','087','Jay','Stang'),(747,55,3,'Vietnam','Thị Trấn Vạn Hà','8','Spenser','Corry'),(748,56,3,'Japan','Sukumo','4','Sachs','Bartillon'),(749,57,3,'Philippines','Paagahan','44','Commercial','Forster'),(750,58,3,'Nigeria','Abakaliki','7730','Northridge','Fallview'),(751,59,3,'Russia','Irtyshskiy','247','Burrows','Anthes'),(752,60,3,'United Kingdom','Middleton','20','Brown','Ilene'),(753,61,3,'Honduras','Liure','25074','Ronald Regan','Bluestem'),(754,62,3,'Spain','Palma De Mallorca','48623','Kingsford','Daystar'),(755,63,3,'Peru','Canchayllo','833','Autumn Leaf','Nevada'),(756,64,3,'Portugal','Alburitel','7713','Mcguire','Sommers'),(757,65,3,'Denmark','Frederiksberg','3','Ridge Oak','Del Sol'),(758,66,3,'China','Xiaofayi','81205','Sullivan','Service'),(759,67,3,'France','Amiens','9','Anderson','Dovetail'),(760,68,3,'China','Mengla','50471','Anzinger','Forest Run'),(761,69,3,'France','Paris 06','3580','Portage','Coleman'),(762,70,3,'China','Xijiang','18777','Warbler','Ruskin'),(763,71,3,'Tanzania','Uyovu','88373','Manufacturers','Thompson'),(764,72,3,'Madagascar','Mananara','37777','Bonner','Independence'),(765,73,3,'Philippines','Buenlag','470','Victoria','Hermina'),(766,74,3,'Brazil','Estrela','958','Green','Marquette'),(767,75,3,'China','Tengqiao','23','Lillian','Manufacturers'),(768,76,3,'Japan','Ishiki','9','Manufacturers','Union'),(769,77,3,'Canada','St. Catharines','69','Hoard','Beilfuss'),(770,78,3,'Brazil','Biritiba Mirim','87','Milwaukee','Bartelt'),(771,79,3,'Argentina','San Ramón de la Nueva Orán','738','Bluejay','Menomonie'),(772,80,3,'Thailand','Bang Nam Priao','5178','Swallow','Dwight'),(773,81,3,'China','Liucun','4546','Iowa','Vahlen'),(774,82,3,'Indonesia','Pagelaran','72164','Westerfield','Shasta'),(775,83,3,'Brazil','Porto União','6368','Alpine','Kingsford'),(776,84,3,'Chile','Rengo','6','Straubel','Muir'),(777,85,3,'Panama','San Ignacio de Tupile','1','Meadow Valley','High Crossing'),(778,86,3,'China','Chunjiang','9171','Sloan','Swallow'),(779,87,3,'Sweden','Örnsköldsvik','206','Union','Melby'),(780,88,3,'Denmark','Frederiksberg','4383','Dixon','Declaration'),(781,89,3,'Guatemala','Chiantla','6375','Beilfuss','Gulseth'),(782,90,3,'Indonesia','Pelem','3730','Dixon','2nd'),(783,91,3,'Russia','Rognedino','35','Farragut','Evergreen'),(784,92,3,'Mexico','Miguel Hidalgo','63','Spohn','Jana'),(785,93,3,'Dominican Republic','Nizao','7524','Gateway','New Castle'),(786,94,3,'Indonesia','Karanglo','66','Butternut','Forster'),(787,95,3,'Poland','Krynice','9','Stoughton','John Wall'),(788,96,3,'Poland','Wola Filipowska','0','Evergreen','Red Cloud'),(789,97,3,'China','Hanfeng','7','Magdeline','Warrior'),(790,98,3,'Japan','Kamaishi','89179','Monument','Butternut'),(791,99,3,'Jamaica','Williamsfield','299','Warrior','Butternut'),(792,100,3,'China','Dazhou','9615','Schiller','Lillian'),(793,101,3,'China','Jingshan','67068','Almo','Thierer'),(794,102,3,'Poland','Dębica','8','Cardinal','Sauthoff'),(795,103,3,'China','Xianyi','981','Pearson','Pankratz'),(796,104,3,'France','Roissy Charles-de-Gaulle','3071','American','Butterfield'),(797,105,3,'Chile','Villa Presidente Frei, Ñuñoa, Santiago, Chile','42','Crowley','Leroy'),(798,106,3,'Indonesia','Caringin Lor','35679','Waubesa','Monument'),(799,107,3,'China','Xigaoshan','57','Mesta','Pine View'),(800,108,3,'Poland','Jedlińsk','0033','Maryland','Sommers'),(801,109,3,'Paraguay','Fram','4542','Cherokee','Coleman'),(802,110,3,'Canada','Peachland','6793','Maywood','Cascade'),(803,111,3,'Pakistan','Miān Channūn','00286','Hayes','6th'),(804,112,3,'Portugal','Santo Adrião Vizela','85','Sunbrook','Morningstar'),(805,113,3,'China','Nankai','33225','Eggendart','Carey'),(806,114,3,'China','Jinniu','2','Linden','Cody'),(807,115,3,'Czech Republic','Opařany','50953','Talisman','Lawn'),(808,116,3,'China','Jieguanting','95','Harbort','Spaight'),(809,117,3,'China','Jiawu','44177','Brown','Bartillon'),(810,118,3,'Russia','Strezhevoy','56','Novick','Corscot'),(811,119,3,'China','Fujia','536','Meadow Valley','Dakota'),(812,120,3,'Angola','Caluquembe','143','Forest Dale','Swallow'),(813,121,3,'Philippines','San Ramon','684','Northland','Blue Bill Park'),(814,122,3,'China','Shihuajian','2','Monument','Myrtle'),(815,123,3,'China','Tadou','190','Swallow','Bay'),(816,124,3,'Ukraine','Zalesnoye','02','Valley Edge','Mitchell'),(817,125,3,'France','Cesson-Sévigné','87664','Merry','Hazelcrest'),(818,126,3,'Niger','Maradi','78','Lerdahl','Vermont'),(819,127,3,'Japan','Hikari','061','Sunfield','High Crossing'),(820,128,3,'Indonesia','Campraksanta','0','Twin Pines','Lyons'),(821,129,3,'Portugal','Cova da Iria','9','Barby','Kingsford'),(822,130,3,'Azerbaijan','Altıağac','56268','Valley Edge','Sherman'),(823,131,3,'Tanzania','Kidodi','603','South','Meadow Ridge'),(824,132,3,'Russia','Maromitsa','3','Anzinger','Heath'),(825,133,3,'Philippines','Nampicuan','9600','Bashford','Cambridge'),(826,134,3,'China','Bangjun','56','Shoshone','Granby'),(827,135,3,'Indonesia','Krajan','95','Continental','Continental'),(828,136,3,'China','Chifeng','787','Little Fleur','Southridge'),(829,137,3,'Portugal','Cobre','354','Mcguire','Reinke'),(830,138,3,'Canada','Saint-Bruno','86915','Mallory','Loeprich'),(831,139,3,'France','Vincennes','069','Cherokee','Magdeline'),(832,140,3,'China','Hanjiaji','864','Myrtle','Talmadge'),(833,141,3,'Belarus','Lyozna','191','Northridge','Tomscot'),(834,142,3,'Indonesia','Jungkat Selatan','19564','Knutson','Farmco'),(835,143,3,'China','Qilin','2','Lillian','Calypso'),(836,144,3,'Brazil','Macaíba','1','Carberry','1st'),(837,145,3,'Thailand','Wichit','0','Old Shore','Independence'),(838,146,3,'Thailand','Mae Sot','186','Talmadge','Loeprich'),(839,147,3,'United States','Miami','8','Sommers','Browning'),(840,148,3,'Japan','Shinjō','6','Kinsman','Schiller'),(841,149,3,'China','Duodaoshi','180','Buell','Cambridge'),(842,150,3,'China','Duyang','68537','Valley Edge','Ronald Regan'),(843,151,3,'Portugal','Alverca do Ribatejo','70','Moland','Bay'),(844,152,3,'Comoros','Nioumamilima','01303','Hoard','Oak'),(845,153,3,'Ukraine','Zaliznychne','4','Shelley','Park Meadow'),(846,154,3,'China','Liushan','4','Bultman','Starling'),(847,155,3,'Japan','Mihara','49','Shasta','Northland'),(848,156,3,'Russia','Proletarskiy','837','Fallview','Lotheville'),(849,157,3,'China','Baihe','143','Golf View','Blaine'),(850,158,3,'Greece','Kými','05694','Commercial','Westend'),(851,159,3,'Brazil','Marechal Deodoro','666','Southridge','Knutson'),(852,160,3,'Canada','Lumby','600','Service','Hoard'),(853,161,3,'Philippines','Cabugao','22','Graceland','Bartelt'),(854,162,3,'Ethiopia','Sirre','71','Macpherson','Oriole'),(855,163,3,'China','Longxi','836','Prairieview','Sundown'),(856,164,3,'Russia','Yablochnyy','76','Barby','Sugar'),(857,165,3,'Tanzania','Kihurio','482','Golf View','Lukken'),(858,166,3,'Turkmenistan','Saýat','409','Thompson','Cascade'),(859,167,3,'China','Heitan','45160','Linden','Hansons'),(860,168,3,'Mexico','Emiliano Zapata','3202','Schlimgen','Everett'),(861,169,3,'Portugal','Ferreiros','506','Oak Valley','Marcy'),(862,170,3,'Indonesia','Kampungmasjid','1','Main','Mccormick'),(863,171,3,'Ireland','Dún Laoghaire','353','Clyde Gallagher','Elmside'),(864,172,3,'China','Meishan','474','Bultman','Eggendart'),(865,173,3,'Chad','Massakory','081','3rd','Iowa'),(866,174,3,'China','Yanshang','02','Mandrake','Golf Course'),(867,175,3,'China','Shentang','661','Center','Luster'),(868,176,3,'Poland','Brudzeń Duży','36','Rieder','Merry'),(869,177,3,'Sweden','Flen','95','Cardinal','Fallview'),(870,178,3,'Equatorial Guinea','Río Campo','20400','Derek','Mariners Cove'),(871,179,3,'Sweden','Älmhult','1392','Brentwood','Scott'),(872,180,3,'France','Palaiseau','28225','Stuart','Forster'),(873,181,3,'China','Jinchuan','7274','Heath','Warrior'),(874,182,3,'Kazakhstan','Sayaq','56','Aberg','Debra'),(875,183,3,'Greece','Makrochóri','9967','Delladonna','Summit'),(876,184,3,'Uruguay','Soriano','71524','Clyde Gallagher','Porter'),(877,185,3,'Belarus','Orsha','7','High Crossing','Talmadge'),(878,186,3,'China','Xiaba','6131','Orin','American'),(879,187,3,'China','Gyangkar','51','South','Continental'),(880,188,3,'South Africa','Bothaville','95265','Schurz','Pierstorff'),(881,189,3,'Poland','Wielki Kack','1872','Elgar','Jana'),(882,190,3,'Peru','Yanac','45541','Lukken','Oneill'),(883,191,3,'Nigeria','Igbo-Ukwu','2','Haas','Brown'),(884,192,3,'Zambia','Mansa','3','Crest Line','Lakeland'),(885,193,3,'China','Maoping','56081','Petterle','Heath'),(886,194,3,'Guatemala','Cuilco','89','Sunfield','Bellgrove'),(887,195,3,'Brazil','Piúma','44658','Namekagon','Oak'),(888,196,3,'China','Duowa','94','Oxford','Arapahoe'),(889,197,3,'Philippines','Rominimbang','6739','Anhalt','Arapahoe'),(890,198,3,'Venezuela','Sabaneta','05','Mariners Cove','Anthes'),(891,199,3,'Indonesia','Lokuuy','43','Chinook','Logan'),(892,200,3,'Peru','Pozuzo','37264','Grayhawk','Riverside'),(893,201,3,'Portugal','Vinhais','1','Anhalt','Scott'),(894,202,3,'China','Liuqiao','570','Thackeray','2nd'),(895,203,3,'Malaysia','Kuala Lumpur','1760','Eastwood','Oneill'),(896,204,3,'Poland','Mnich','79','Lerdahl','Jana'),(897,205,3,'Indonesia','Pondokwungu','54516','Dovetail','Towne'),(898,206,3,'Botswana','Kopong','04','1st','Almo'),(899,207,3,'Poland','Pierzchnica','240','Moulton','Namekagon'),(900,208,3,'Indonesia','Mandikbatu','29244','Fair Oaks','Little Fleur'),(901,209,3,'Poland','Reszel','207','Northwestern','Thackeray'),(902,210,3,'Germany','Hannover','9','Green','Elka'),(903,211,3,'Mozambique','Chibuto','3581','Vermont','Algoma'),(904,212,3,'Russia','Debesy','423','Sutteridge','Main'),(905,213,3,'Indonesia','Harjamukti','69803','Burrows','North'),(906,214,3,'China','Hoit Taria','9894','Everett','Drewry'),(907,215,3,'Croatia','Predavac','71','Ohio','Sugar'),(908,216,3,'United States','Cincinnati','52','Moulton','Kings'),(909,217,3,'Norway','Sandefjord','11825','Sachs','Reinke'),(910,218,3,'Pakistan','Rājo Khanāni','74','Huxley','Northport'),(911,219,3,'Falkland Islands','Stanley','6118','West','Lyons'),(912,220,3,'Indonesia','Gampengrejo','0','Lindbergh','Dwight'),(913,221,3,'Indonesia','Cipaku','3053','Crownhardt','Fuller'),(914,222,3,'Argentina','Unión','94243','Katie','Fair Oaks'),(915,223,3,'China','Sanxi','60','Tony','Talmadge'),(916,224,3,'China','Kuanghe','5','Thackeray','Holy Cross'),(917,225,3,'Portugal','São João dos Montes','04','Anniversary','Elmside'),(918,226,3,'Portugal','Nossa Senhora de Machede','35','Golf Course','Doe Crossing'),(919,227,3,'China','Liulin','8226','Lakewood Gardens','Buena Vista'),(920,228,3,'Sweden','Järfälla','230','Eggendart','Sloan'),(921,229,3,'Poland','Malbork','978','Old Shore','Logan'),(922,230,3,'Indonesia','Wolofeo','4049','Eggendart','Vera'),(923,231,3,'South Korea','Songwon','441','4th','Donald'),(924,232,3,'China','Shangyi','1','Schmedeman','Melvin'),(925,233,3,'China','Weitang','4708','Stephen','Hansons'),(926,234,3,'United Kingdom','Buckland','12','Nevada','Porter'),(927,235,3,'Peru','Taurija','45','Bay','Sunbrook'),(928,236,3,'Japan','Fukuroi','81','Sunfield','Chinook'),(929,237,3,'Venezuela','Puerto Ayacucho','39','Springview','Warner'),(930,238,3,'France','Orléans','3271','Esch','Hayes'),(931,239,3,'Poland','Borek Wielkopolski','030','Katie','Old Gate'),(932,240,3,'Qatar','Umm Sa‘īd','77174','Scofield','Cascade'),(933,241,3,'Sweden','Kungsbacka','1299','Hermina','Blackbird'),(934,242,3,'Albania','Patos Fshat','5016','Graceland','Shoshone'),(935,243,3,'Netherlands','Apeldoorn','47','Linden','Debra'),(936,244,3,'Indonesia','Tegalsari','3','Judy','Merry'),(937,245,3,'Sweden','Stockholm','5','Mendota','Crownhardt'),(938,246,3,'Argentina','Tres Isletas','532','Oakridge','Summer Ridge'),(939,247,3,'Brazil','Taboão da Serra','35997','Namekagon','Pankratz'),(940,248,3,'China','Yinjiang','0','Macpherson','Melody'),(941,249,3,'China','Kuantian','5','Londonderry','Westend'),(942,250,3,'Russia','Kireyevsk','91','Old Shore','Lotheville'),(943,251,3,'Peru','Socota','56980','Sycamore','Northridge'),(944,252,3,'United States','Sacramento','3515','Everett','Lakewood Gardens'),(945,253,3,'Indonesia','Kertasari','3','Sauthoff','1st'),(946,254,3,'Czech Republic','Mikulovice','0397','Dahle','Memorial'),(947,255,3,'China','Yuanhou','671','Randy','Gateway'),(948,256,3,'China','Tongzilin','935','Melody','Trailsway'),(949,257,3,'Nicaragua','Jinotepe','31815','Manufacturers','Marquette'),(950,258,3,'Malaysia','Kuala Lumpur','224','Forest Dale','Glacier Hill'),(951,259,3,'United States','Phoenix','558','Arapahoe','Valley Edge'),(952,260,3,'Indonesia','Salamrejo','75755','Hazelcrest','Jackson'),(953,261,3,'Philippines','Balingasag','87','Derek','Sachtjen'),(954,262,3,'Malaysia','Kuala Lumpur','827','Lukken','Valley Edge'),(955,263,3,'Japan','Wakimachi','0','4th','Bultman'),(956,264,3,'Indonesia','Kuafeu','1','Amoth','Farragut'),(957,265,3,'Jamaica','Portmore','6316','Mendota','Bowman'),(958,266,3,'China','Xin’an','5204','Delaware','Loomis'),(959,267,3,'Portugal','Canhas','999','Oneill','Vera'),(960,268,3,'Sweden','Stockholm','73587','Eagle Crest','Shasta'),(961,269,3,'China','Chonghe','32','Mayfield','Mallard'),(962,270,3,'Luxembourg','Reisdorf','84','Manley','Monument'),(963,271,3,'China','Hujigou','221','Bartillon','Sherman'),(964,272,3,'China','Saxin','743','Buena Vista','Barby'),(965,273,3,'Norway','Larvik','46770','Carioca','5th'),(966,274,3,'Philippines','Damulog','19','Lake View','Lakewood'),(967,275,3,'Canada','Collingwood','939','High Crossing','Evergreen'),(968,276,3,'Indonesia','Bojong','82','Ryan','Anniversary'),(969,277,3,'Bangladesh','Gaurnadi','9','Everett','Corscot'),(970,278,3,'Philippines','Panalingaan','716','Rieder','Sachs'),(971,279,3,'Vietnam','Trảng Bàng','16924','Spohn','Muir'),(972,280,3,'Indonesia','Kedungtulup','453','Scoville','Anderson'),(973,281,3,'France','Longjumeau','27617','Brentwood','Prairieview'),(974,282,3,'China','Leicheng','8','Jana','Nevada'),(975,283,3,'Indonesia','Sriwing','8','Di Loreto','Killdeer'),(976,284,3,'Indonesia','Ekasapta','5032','Larry','North'),(977,285,3,'Thailand','Kaset Sombun','173','Graceland','Anthes'),(978,286,3,'Iran','Dorūd','2479','Waubesa','Anniversary'),(979,287,3,'China','Zhichanghe','0','Continental','Brown'),(980,288,3,'Russia','Yessentukskaya','96497','Surrey','Sutteridge'),(981,289,3,'China','Fenhe','43','Myrtle','Huxley'),(982,290,3,'Brazil','Arapongas','96','Bayside','Miller'),(983,291,3,'Sweden','Smedjebacken','49888','Mallard','Bluejay'),(984,292,3,'Bangladesh','Kishorganj','33','Oriole','Schurz'),(985,293,3,'Sweden','Hisings Kärra','43098','Laurel','Colorado'),(986,294,3,'China','Chunshui','39','Graedel','Quincy'),(987,295,3,'China','Yangxu','32410','Morrow','Roth'),(988,296,3,'Kyrgyzstan','At-Bashi','47266','Dryden','Dawn'),(989,297,3,'Czech Republic','Valašská Polanka','68','Crownhardt','Messerschmidt'),(990,298,3,'Sweden','Mölnlycke','984','Westerfield','Reindahl'),(991,299,3,'Portugal','Santa Bárbara de Padrões','90549','Kennedy','Myrtle'),(992,300,3,'Portugal','Bairro do Margaça','0693','5th','Farragut'),(993,301,3,'Colombia','Buenavista','1','Norway Maple','Warrior'),(994,302,3,'United States','Gainesville','195','Dottie','Washington'),(995,303,3,'Poland','Węgierska Górka','8','Mosinee','Delaware'),(996,304,3,'Indonesia','Selat','52','Old Shore','Hanson'),(997,305,3,'China','Liangguang','791','Clyde Gallagher','Tennessee'),(998,306,3,'Russia','Zhemtala','63211','Dovetail','Glendale'),(999,307,3,'Ireland','Monkstown','91','Merrick','Arizona'),(1000,308,3,'China','Caihua','419','Meadow Ridge','Colorado'),(1001,309,3,'Pakistan','Mandi Bahāuddīn','565','Anzinger','Kennedy'),(1002,310,3,'China','Ganpu','592','Debs','Vera'),(1003,311,3,'Indonesia','Atambua','80','Express','Southridge'),(1004,312,3,'Argentina','Las Toscas','7','Kennedy','Paget'),(1005,313,3,'Madagascar','Ankazondandy','3010','Mesta','Brown'),(1006,314,3,'China','Dongkengkou','44','Susan','Lake View'),(1007,315,3,'Argentina','Concepción del Bermejo','86','Burning Wood','Charing Cross'),(1008,316,3,'Russia','Vishnyakovskiye Dachi','69','Bayside','Hoard'),(1009,317,3,'Japan','Moriyama','87336','Arrowood','Petterle'),(1010,318,3,'Philippines','Cabcaben','63111','Golf Course','Kenwood'),(1011,319,3,'Indonesia','Longka','31128','Sachs','Jana'),(1012,320,3,'Indonesia','Kemendung','8','Schlimgen','Artisan'),(1013,321,3,'Russia','Satinka','16019','Hooker','Killdeer'),(1014,322,3,'Nicaragua','Boaco','7','Rusk','Dixon'),(1015,323,3,'Swaziland','Siteki','901','Merrick','Lyons'),(1016,324,3,'Greece','Géfyra','3177','Roth','Mcbride'),(1017,325,3,'Philippines','Talisay','11','Golf Course','Bunker Hill'),(1018,326,3,'Venezuela','El Cantón','78','Arrowood','Brickson Park'),(1019,327,3,'Egypt','‘Izbat al Burj','866','Moland','School'),(1020,328,3,'Jamaica','Point Hill','7649','Goodland','Del Sol'),(1021,329,3,'Indonesia','Karanganyar','8','Sheridan','Cordelia'),(1022,330,3,'China','Sanxi','1','Gulseth','International'),(1023,331,3,'Egypt','Basyūn','0143','Rigney','Raven'),(1024,332,3,'Sweden','Tierp','8225','Victoria','Mallory'),(1025,333,3,'Nigeria','Ruma','1','Glacier Hill','Prentice'),(1026,334,3,'China','Longzhouwan','0','Reinke','Grayhawk'),(1027,335,3,'Bangladesh','Tungi','454','Spaight','Charing Cross'),(1028,336,3,'Libya','Yafran','2414','Lerdahl','Utah'),(1029,337,3,'China','Longsheng','9','Walton','Ridgeway'),(1030,338,3,'Micronesia','Houk','40910','Tennyson','Dennis'),(1031,339,3,'Philippines','San Ramon','580','Moland','Arapahoe'),(1032,340,3,'Myanmar','Martaban','64961','Clemons','Brickson Park'),(1033,341,3,'Indonesia','Pali','282','Knutson','Golf'),(1034,342,3,'Indonesia','Warung Wetan','9595','Upham','Helena'),(1035,343,3,'Indonesia','Baturaden','20','Haas','Graceland'),(1036,344,3,'Sweden','Vilhelmina','593','Farmco','Knutson'),(1037,345,3,'Philippines','Rizal','27','Buhler','Kennedy'),(1038,346,3,'China','Hepu','0821','Delladonna','Golf View');
/*!40000 ALTER TABLE `address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `adjustment_log`
--

DROP TABLE IF EXISTS `adjustment_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `adjustment_log` (
  `AdjID` int(11) NOT NULL AUTO_INCREMENT,
  `PID` int(11) DEFAULT NULL,
  `AdjType` int(11) DEFAULT NULL,
  `AdjDate` timestamp NULL DEFAULT NULL,
  `Value` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`AdjID`),
  KEY `Adj-Payroll_idx` (`PID`),
  CONSTRAINT `fk_adjustmentlog_payroll` FOREIGN KEY (`PID`) REFERENCES `payroll` (`PID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adjustment_log`
--

LOCK TABLES `adjustment_log` WRITE;
/*!40000 ALTER TABLE `adjustment_log` DISABLE KEYS */;
INSERT INTO `adjustment_log` VALUES (1,1,1,'2017-08-22 03:01:08','150.00'),(2,1,2,'2017-08-22 03:01:08','60.00'),(3,1,3,'2017-08-22 03:01:08','60.00'),(4,1,4,'2017-08-22 03:01:08','0.00'),(5,1,5,'2017-08-22 03:01:08','100.00'),(6,1,4,'2017-08-22 03:01:31','100.00'),(7,1,5,'2017-08-23 09:31:10','10000.00');
/*!40000 ALTER TABLE `adjustment_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attendance`
--

DROP TABLE IF EXISTS `attendance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `attendance` (
  `AtID` int(11) NOT NULL AUTO_INCREMENT,
  `DID` int(11) DEFAULT NULL,
  `PID` int(11) DEFAULT NULL,
  `Date` varchar(45) DEFAULT NULL,
  `TimeIn` varchar(45) DEFAULT '12:00 AM',
  `TimeOut` varchar(45) DEFAULT '12:00 AM',
  PRIMARY KEY (`AtID`),
  UNIQUE KEY `unique_index` (`Date`,`DID`),
  KEY `Attendance-DutyDetails_idx` (`DID`),
  KEY `fk_attendance1_idx` (`PID`),
  CONSTRAINT `Attendance-DutyDetails` FOREIGN KEY (`DID`) REFERENCES `dutydetails` (`DID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_attendance1` FOREIGN KEY (`PID`) REFERENCES `period` (`PID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance`
--

LOCK TABLES `attendance` WRITE;
/*!40000 ALTER TABLE `attendance` DISABLE KEYS */;
INSERT INTO `attendance` VALUES (1,1,1,'2017-08-21 00:00:00','12:00 AM','12:00 AM'),(2,1,1,'2017-08-28 00:00:00','12:00 AM','12:00 AM');
/*!40000 ALTER TABLE `attendance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `basicpay`
--

DROP TABLE IF EXISTS `basicpay`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `basicpay` (
  `BPID` int(11) NOT NULL AUTO_INCREMENT,
  `amount` decimal(6,2) DEFAULT NULL,
  `start` datetime DEFAULT NULL,
  `end` datetime DEFAULT NULL,
  `status` int(1) DEFAULT NULL,
  PRIMARY KEY (`BPID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basicpay`
--

LOCK TABLES `basicpay` WRITE;
/*!40000 ALTER TABLE `basicpay` DISABLE KEYS */;
INSERT INTO `basicpay` VALUES (1,90.00,'1970-01-01 00:00:00','1989-07-01 00:00:00',0),(2,100.00,'1989-07-01 00:00:00','1990-12-01 00:00:00',0),(3,115.00,'1990-12-01 00:00:00','1997-01-01 00:00:00',0),(4,125.00,'1997-01-01 00:00:00','1998-01-01 00:00:00',0),(5,130.00,'1998-01-01 00:00:00','1999-11-01 00:00:00',0),(6,150.00,'1999-11-01 00:00:00','2000-11-01 00:00:00',0),(7,160.00,'2000-11-01 00:00:00','2001-05-01 00:00:00',0),(8,170.00,'2001-05-01 00:00:00','2004-01-01 00:00:00',0),(9,195.00,'2004-01-01 00:00:00','2005-02-05 00:00:00',0),(10,210.00,'2005-02-05 00:00:00','2006-07-27 00:00:00',0),(11,230.00,'2006-07-27 00:00:00','2008-06-16 00:00:00',0),(12,250.00,'2008-06-16 00:00:00','2009-09-18 00:00:00',0),(13,255.00,'2009-09-15 00:00:00','2010-09-01 00:00:00',0),(14,274.00,'2010-09-01 00:00:00','2012-01-01 00:00:00',0),(15,290.00,'2012-01-01 00:00:00','2014-06-01 00:00:00',0),(16,317.00,'2014-06-01 00:00:00','2016-12-16 00:00:00',0),(17,340.00,'2016-12-16 00:00:00',NULL,NULL),(18,530.00,'2017-08-23 00:00:00','9999-12-31 00:00:00',1),(20,1240.00,'2044-06-14 00:00:00','9999-12-31 00:00:00',2);
/*!40000 ALTER TABLE `basicpay` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (1,'Genuity Inc.','865','Real St.','Manresa','Kabacan City','Nickle, Asa Sorum','811-1253','Millman, Fredrick Tierney',0),(2,'Globe Telecom - Abreeza','1450','Felipe Agoncillo St.','Katipunan','Digos City','Kurzinski, Brady Sharr','757-8097','Oberpriller, Anibal Bagdon',0),(3,'Gmall of Toril','3693','Carmen Planas St.','Kaunlaran','Santa Catalina City','Nickless, Carol Voll','351-8333','Fumagalli, Willie Lynch',1),(4,'Comcast Corp.','2721','NAIA Rd.','Don Galo','Basilisa City','Jazwa, Tanner Conchado','118-8983','Washor, Jayson Argue',0),(5,'SkyCable - Cabaguio','803','Capitol Hills Dr. ','Kaunlaran','Santa Maria City','Hushon, Mel Flugum','156-2884','Boisselle, Rosario Pieters',0),(6,'SPX Cargo Forwarders','3456','Burke St.','Dona Josefa','Santa Cruz City','Hellman, Mario Gazitano','138-1562','Jendro, Terry Bianchin',0),(7,'Creative Logistics Corp.','1237','Jose Laurel St.','Dona Josefa','Aleosan City','Macandog, Charlie Diker','440-4023','Falla, Roderick Schweers',0),(8,'Western Union - Bukidnon','3509','Recto Ave.','Loyola Heights','Magsaysay City','Housler, Timothy Zimmermann','791-4640','Havice, Colby Sepulueda',0),(9,'Gemstar-TV Guide International Inc.','1522','Carmen Planas St.','Edang','Sarangani City','Ballog, Rodger Stifflemire','299-9234','Sampley, Bobby Pasquarella',0),(10,'Peoples Energy Corp.','983','Jorge Bocobo St.','Manuyo Dos','Can-avid City','Atterbury, Ramiro Dumpe','316-2955','Kleese, Ahmad Boltz',0),(11,'BellSouth Corporation','1227','Jose Gil St.','Libis Reparo','Salcedo City','Bickman, Lou Hemry','772-8808','Fedd, Arnoldo Elenbaas',0),(12,'AquaLife Inc.','618','Benavidez St.','Katipunan','Lupon','Brabson, Silas Kranawetter','428-3170','Videtto, Trey Stansberry',0),(13,'Convergys Corp.','2339','Scout Limbaga St.','Little Baguio','Panabo City','Battie, Aldo Cueto','386-2873','Eshmon, Floyd Zaccaria',0),(14,'Adobe Systems Incorporated','1279','Bayoran St.','Masambong','Mlang','Straughan, Mario Zavasky','679-1629','Mcdargh, Aldo Has',0),(15,'Ateneo de Davao University','8113','Roxas St.','Roxas','Davao City','Joyce','092345875425','Joyce',0),(16,'AA Fishery - Sta. Cruz','12','Mangga St.','Sta. Maria','Sta. Cruz','John French','238-2837','Joseph Joffre',0);
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contribdetails`
--

DROP TABLE IF EXISTS `contribdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contribdetails` (
  `contrib_id` int(11) NOT NULL AUTO_INCREMENT,
  `date_effective` datetime NOT NULL,
  `date_dissolved` datetime DEFAULT NULL,
  `type` int(1) DEFAULT NULL,
  `status` int(1) DEFAULT NULL,
  PRIMARY KEY (`contrib_id`,`date_effective`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contribdetails`
--

LOCK TABLES `contribdetails` WRITE;
/*!40000 ALTER TABLE `contribdetails` DISABLE KEYS */;
INSERT INTO `contribdetails` VALUES (1,'1970-01-01 00:00:00','2015-05-23 00:00:00',1,0),(2,'1970-01-01 00:00:00','2015-05-23 00:00:00',2,0),(3,'2015-05-23 00:00:00','2017-07-16 00:00:00',1,0),(4,'2015-05-23 00:00:00','2017-01-01 00:00:00',2,0),(5,'2017-07-16 00:00:00','9999-12-31 00:00:00',1,1),(6,'2017-01-01 00:00:00','9999-12-31 00:00:00',2,1),(11,'1970-01-01 00:00:00','2015-04-16 00:00:00',3,0),(12,'2015-04-16 00:00:00','9999-12-31 00:00:00',3,1),(14,'2017-08-30 00:00:00','9999-12-31 00:00:00',2,1),(15,'2090-02-07 00:00:00','9999-12-31 00:00:00',1,2),(16,'2090-02-07 00:00:00','9999-12-31 00:00:00',1,2);
/*!40000 ALTER TABLE `contribdetails` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `dependents`
--

LOCK TABLES `dependents` WRITE;
/*!40000 ALTER TABLE `dependents` DISABLE KEYS */;
INSERT INTO `dependents` VALUES (1,4,'Kathyrn','Artist','Sabeiha',1),(2,5,'Hunter','Pounder','Manjarres',1),(3,6,'Larry','Liskovec','Aery',1),(4,2,'Whitney','Flever','Arruda',1),(5,2,'Christopher','Fiscel','Coomer',1),(6,4,'Vanessa','Puleio','Lightbody',2),(7,5,'Antony','Gastel','Torivio',2),(8,6,'Ervin','Borio','Strnad',2),(9,2,'Edmund','Bergfield','Naccarato',2),(10,2,'Darren','Faron','Schaab',2),(11,4,'Cherlyn','Keomanivong','Kuhnemund',3),(12,5,'Nicky','Mclennon','Pettry',3),(13,6,'Emory','Dellaripa','Prestidge',3),(14,1,'Dot','Dennies','Nogoda',3),(15,4,'Portia','Fantini','Heldt',4),(16,5,'Zackary','Ahl','Rohrscheib',4),(17,6,'Mario','Balogh','Peetoom',4),(18,2,'Dean','Fuesting','Hoosier',4),(19,2,'Rodrick','Romenesko','Patriss',4),(20,2,'Kendrick','Nicley','Lencioni',4),(21,4,'Shellie','Siburt','Mashall',5),(22,5,'Gregory','Pientka','Brevil',5),(23,6,'Kristofer','Tajima','Oien',5),(24,2,'Eloy','Yann','Macdaniel',5),(25,2,'Graham','Zombory','Zhanel',5),(26,4,'Stella','Wrigley','Angerer',6),(27,5,'Winfred','Drozda','Encalade',6),(28,6,'Maxwell','Figgs','Turziano',6),(29,2,'Johnie','Hronick','Killilea',6),(30,4,'Dinah','Cecilio','Avelino',7),(31,5,'Markus','Rossiter','Hosendove',7),(32,6,'Edgar','Fleer','Hatchette',7),(33,2,'Bennie','Allsop','Becherer',7),(34,2,'Bill','Braget','Nani',7),(35,4,'Samara','Schrull','Lewandowsky',8),(36,5,'Stevie','Sandona','Desamito',8),(37,6,'Clifton','Soffel','Sobotka',8),(38,1,'Demetrius','Mcgwin','Bali',8),(39,1,'Salome','Bansbach','Hickernell',8),(40,4,'Roslyn','Kayrouz','Putz',9),(41,5,'Buford','Hoit','Politis',9),(42,6,'Agustin','Vickerman','Featherston',9),(43,2,'Roland','Sesso','Malla',9),(44,2,'Val','Buchetto','Tixier',9),(45,4,'Shelli','Stief','Haggins',10),(46,5,'Alfonso','Schlett','Rataj',10),(47,6,'Tobias','Buroker','Dummermuth',10),(48,1,'Emely','Swiderski','Kocaj',10),(49,1,'Shayna','Koehn','Quesada',10),(50,1,'Jackeline','Sarff','Ure',10),(51,4,'Sol','Smolic','Chervin',11),(52,5,'Marcos','Feibusch','Stottlar',11),(53,6,'Jacinto','Deblieck','Prioletti',11),(54,1,'Sherlene','Strenge','Mallo',11),(55,4,'Kathern','Henthorn','Dilcher',12),(56,5,'Donny','Roff','Leveille',12),(57,6,'Timmy','Waddouds','Mcpartlin',12),(58,1,'Dong','Mcelvy','Silvis',12),(59,1,'Zulema','Hussaini','Presta',12),(60,1,'Evelynn','Hackenberg','Desautels',12),(61,4,'Chanelle','Dack','Giorno',13),(62,5,'Bill','Cables','Ludden',13),(63,6,'Mel','Mcnelley','Manalili',13),(64,1,'Noelle','Limesand','Kayat',13),(65,4,'Marissa','Lafarge','Defino',14),(66,5,'Richard','Brochhausen','Parmenter',14),(67,6,'Santo','Mathisen','Sangiacomo',14),(68,1,'Flo','Ornellas','Schissler',14),(69,4,'Melvina','Enkerud','Bonwell',15),(70,5,'Wes','Glor','Metters',15),(71,6,'Cleveland','Jenney','Hauck',15),(72,1,'Lasonya','Erby','Vulich',15),(73,1,'Eveline','Gucker','Mcinerny',15),(74,4,'Charlie','Burgun','Brasington',16),(75,5,'Buford','Poulos','Ogren',16),(76,6,'Quintin','Patraw','Galasso',16),(77,2,'Kendrick','Summar','Cotto',16),(78,2,'Darrel','Kepp','Hillery',16),(79,4,'Nguyet','Nilsen','Mario',17),(80,5,'Darin','Schreyer','Diana',17),(81,6,'Boyd','Kissack','Waldock',17),(82,1,'Ivey','Nealon','Petrosyan',17),(83,1,'Reta','Piotrowski','Olive',17),(84,1,'Scarlet','Meinberg','Urbani',17),(85,4,'Amee','Yambo','Snead',18),(86,5,'Raleigh','Stoeckel','Heber',18),(87,6,'Trey','Mora','Scattergood',18),(88,2,'Terence','Odin','Baris',18),(89,4,'Bronwyn','Shamsiddeen','Caporiccio',19),(90,5,'Kristofer','Setler','Mcbrien',19),(91,6,'Merlin','Demeo','Bondura',19),(92,1,'Melia','Mccandles','Heminover',19),(93,1,'Anabel','Gemmer','Vilegas',19),(94,4,'Candyce','Sanots','Breiland',20),(95,5,'Hubert','Drozda','Gessert',20),(96,6,'Irwin','Barbrick','Lamontagne',20),(97,2,'Lucas','Gabbett','Casassa',20),(98,4,'Misti','Anick','Bazemore',21),(99,5,'Clinton','Szumigala','Easterlin',21),(100,6,'Brice','Salway','Wachowiak',21),(101,1,'Michelina','Mohler','Boso',21),(102,1,'Dara','Bassetti','Gefroh',21),(103,1,'Babette','Orttenburger','Rieley',21),(104,4,'Ginny','Lacombe','Kitten',22),(105,5,'Young','Byrant','Weisenstein',22),(106,6,'Lawrence','Rados','Vidrio',22),(107,1,'Na','Palumbo','Modest',22),(108,1,'Marylou','Frankie','Flakes',22),(109,4,'Vi','Dunmore','Welding',23),(110,5,'Modesto','Einhorn','Martz',23),(111,6,'Curt','Gutenberg','Sinistore',23),(112,2,'Max','Calpin','Bumm',23),(113,4,'Sunday','Mauney','Pav',24),(114,5,'Zack','Medhus','Rasmuson',24),(115,6,'Donnie','Cicarella','Arthun',24),(116,1,'Tamala','Macha','Kozlik',24),(117,1,'Marsha','Dewolfe','Bulan',24),(118,4,'Sharyl','Pritzel','Sweaney',25),(119,5,'Tory','Adamski','Postert',25),(120,6,'Jerrell','Heckman','Kruczek',25),(121,2,'Alva','Attridge','Debois',25),(122,2,'Darrel','Schunk','Tremillo',25),(123,4,'Ivonne','Chartrand','Flax',26),(124,5,'Reed','Staebell','Derby',26),(125,6,'Adrian','Stampley','Gallaugher',26),(126,2,'Yong','Aharoni','Catherwood',26),(127,4,'Elia','Baters','Wohner',27),(128,5,'Joey','Tobon','Reitler',27),(129,6,'Jeremiah','Mielcarek','Regueira',27),(130,2,'Jesse','Bresee','Gerache',27),(131,4,'Goldie','Marflak','Greenhouse',28),(132,5,'Fredrick','Washman','Wenthold',28),(133,6,'Don','Alcon','Kotzen',28),(134,1,'Kindra','Saraniti','Steinworth',28),(135,1,'Ilse','Whitworth','Arrocho',28),(136,4,'Marisa','Meconi','Maulding',29),(137,5,'Matthew','Shain','Sissom',29),(138,6,'Ervin','Broderson','Caparros',29),(139,1,'Corrie','Keto','Karlinsky',29),(140,1,'Candyce','Gochnour','Basha',29),(141,1,'Becky','Howells','Schapiro',29),(142,4,'Pinkie','Cuffman','Cujas',30),(143,5,'Marcel','Baker','Kienast',30),(144,6,'Graham','Kondracki','Cezil',30),(145,1,'Georgiana','Bantillan','Galyean',30),(146,4,'Yetta','Giampapa','Vogds',31),(147,5,'Terry','Killmon','Formaggioni',31),(148,6,'Glenn','Taschner','Ohl',31),(149,1,'Ping','Pagnello','Deroven',31),(150,4,'Ilda','Cabotage','Steensland',32),(151,5,'Britt','Brace','Newson',32),(152,6,'Elvin','Hettenhausen','Dandridge',32),(153,1,'Rikki','Goody','Giannattasio',32),(154,4,'Creola','Colinger','Molt',33),(155,5,'Duane','Nellum','Lino',33),(156,6,'Andrew','Raulston','Yokota',33),(157,2,'Al','Metevia','Kenley',33),(158,2,'Guillermo','Lyme','Engelsman',33),(159,2,'Alfredo','Geitner','Romeo',33),(160,4,'Rosy','Caminiti','Tovias',34),(161,5,'Wilbur','Kazabi','Lavergne',34),(162,6,'Alfred','Gimbel','Peri',34),(163,1,'Lupita','Laine','Stricklan',34),(164,4,'Iona','Medling','Coner',35),(165,5,'Chadwick','Kiefer','Leimberger',35),(166,6,'Kendrick','Martenez','Delpapa',35),(167,1,'Otelia','Hungate','Grief',35),(168,1,'Blanch','Svehla','Vanostrand',35),(169,1,'Porsha','Winker','Varma',35),(170,4,'Ivonne','Francisque','Eitniear',36),(171,5,'Doug','Cawon','Lehew',36),(172,6,'Branden','Delorenzo','Nevils',36),(173,2,'Mac','Vigueras','Dzubak',36),(174,4,'Evangeline','Pytlewski','Trumps',37),(175,5,'Rodolfo','Weismiller','Leithiser',37),(176,6,'Colby','Lipovsky','Walby',37),(177,2,'Britt','Weyers','Dory',37),(178,2,'Raleigh','Marocco','Tacker',37),(179,2,'Rufus','Cheas','Shober',37),(180,4,'Lannie','Yoshikawa','Tandy',38),(181,5,'Kent','Hornandez','Wrzesinski',38),(182,6,'Valentine','Brande','Sibel',38),(183,1,'Margart','Martens','Loveh',38),(184,1,'Latrisha','Stradling','Bovie',38),(185,4,'Vivan','Latendresse','Samick',39),(186,5,'Garry','Nanda','Zadow',39),(187,6,'Al','Wilk','Eustis',39),(188,2,'Leigh','Braue','Boye',39),(189,2,'Donovan','Atwood','Bloomquist',39),(190,4,'Jeanene','Subler','Canela',40),(191,5,'Oscar','Yaw','Trueman',40),(192,6,'Coy','Massengale','Aquino',40),(193,2,'Winfred','Hrbek','Friemering',40),(194,2,'Pete','Dolejsi','Grit',40),(195,4,'Ariana','Lanfear','Murrey',41),(196,5,'Gavin','Prechtel','Heist',41),(197,6,'Micheal','Hemby','Mcclour',41),(198,2,'Dante','Savio','Schuneman',41),(199,4,'Annabel','Salvadge','Siket',42),(200,5,'Elden','Monroig','Liebermann',42),(201,6,'Nickolas','Roik','Balasubramani',42),(202,1,'Olevia','Watchman','Wojtanowski',42),(203,4,'Kourtney','Belloma','Taubman',43),(204,5,'Tyson','Dihel','Molski',43),(205,6,'Tommy','Enstad','Nagelschmidt',43),(206,2,'Rufus','Avelino','Brissett',43),(207,2,'Stevie','Ammons','Pebbles',43),(208,4,'Annamarie','Wanland','Repenning',44),(209,5,'Benton','Hafeman','Tao',44),(210,6,'Ezekiel','Riggott','Layous',44),(211,1,'Marlys','Delagado','Geidl',44),(212,1,'Shaunda','Laskey','Shippee',44),(213,4,'Jerica','Poska','Kawachi',45),(214,5,'Raleigh','Gebbia','Hilts',45),(215,6,'Anibal','Corrett','Bedoka',45),(216,1,'Siu','Ennett','Wires',45),(217,1,'Dionna','Deerman','Masuda',45),(218,1,'Marta','Flansburg','Arambulo',45),(219,4,'Mabelle','Dietz','Attridge',46),(220,5,'Byron','Coberly','Beydler',46),(221,6,'Randall','Rolf','Marsella',46),(222,2,'Brad','Milby','Puerto',46),(223,2,'Devin','Pullan','Lingren',46),(224,2,'Silas','Christaldi','Murfin',46),(225,4,'Matha','Deats','Foote',47),(226,5,'Dan','Villela','Remmers',47),(227,6,'Michel','Bridgens','Kowald',47),(228,1,'Barabara','Gockley','Sauvage',47),(229,4,'Pauline','Bironas','Bessent',48),(230,5,'Xavier','Romandia','Ando',48),(231,6,'Efrain','Sahota','Granucci',48),(232,1,'Trish','Portales','Trinidad',48),(233,1,'Luise','Dillabough','Cocroft',48),(234,4,'Luciana','Haumesser','Soldner',49),(235,5,'Don','Reddington','Cheatwood',49),(236,6,'Randall','Lashomb','Cassetta',49),(237,1,'Sally','Venneri','Daly',49),(238,1,'Lauralee','Crunkleton','Rickenbacker',49),(239,4,'Kaila','Hronek','Deskins',50),(240,5,'Hobert','Thornberry','Zens',50),(241,6,'Boyd','Longhi','Willamson',50),(242,1,'Sherry','Hockema','Ziyad',50),(243,1,'Valentina','Orttenburger','Kitty',50),(244,1,'Jodie','Trembley','Plasse',50),(245,4,'Neida','Renzoni','Beck',51),(246,5,'Xavier','Benthin','Kotheimer',51),(247,6,'Bret','Delone','Kocourek',51),(248,2,'Gino','Michelini','Fishbein',51),(249,2,'Clifton','Cristiano','Faulcon',51),(250,4,'Ermelinda','Macalma','Paonessa',52),(251,5,'Asa','Francescon','Nybo',52),(252,6,'Bert','Reuber','Wiscombe',52),(253,1,'Amber','Massman','Mizzell',52),(254,1,'Shondra','Farland','Aniol',52),(255,4,'Charity','Gacia','Hupper',53),(256,5,'Grover','Owings','Batimon',53),(257,6,'Edward','Strole','Licause',53),(258,2,'Fritz','Behunin','Artus',53),(259,4,'Matilda','Wekenmann','Epple',54),(260,5,'Kenneth','Fuster','Spratlen',54),(261,6,'Zachariah','Siracusa','Eskelsen',54),(262,1,'Dotty','Whitmarsh','Ferkel',54),(263,4,'Wanda','Miyasaki','Warney',55),(264,5,'Tobias','Felmlee','Lebaron',55),(265,6,'Ike','Dampier','Solo',55),(266,2,'Clyde','Dachs','Phippen',55),(267,2,'Phillip','Wmith','Haushalter',55),(268,2,'Alvin','Broadnay','Boelke',55),(269,4,'Celena','Ifeanyi','Swehla',56),(270,5,'Carmine','Danko','Claucherty',56),(271,6,'Kurt','Delara','Brociner',56),(272,2,'Carol','Tosch','Blackmoore',56),(273,2,'Weston','Mckelvin','Schoenhals',56),(274,4,'Melony','Brzenk','Sprafka',57),(275,5,'Don','Mustoe','Brokaw',57),(276,6,'Garth','Kahana','Spier',57),(277,2,'Hobert','Stancil','Przybyl',57),(278,2,'Ahmad','Menden','Lugardo',57),(279,2,'Benton','Manheim','Keefe',57),(280,4,'Hattie','Mousser','Hamberg',58),(281,5,'Rolando','Wikins','Spancake',58),(282,6,'Grover','Shaer','Vanbramer',58),(283,2,'Calvin','Diers','Valdo',58),(284,4,'Harriett','Prechtl','Titterington',59),(285,5,'Yong','Tutino','Keer',59),(286,6,'Marvin','Naccarato','Profit',59),(287,2,'Lowell','Douthett','Topp',59),(288,4,'Maryann','Knepshield','Mallard',60),(289,5,'Delmar','Djuric','Loreman',60),(290,6,'Ivory','Hushon','Mungia',60),(291,1,'Jana','Cenat','Kindell',60),(292,4,'Carmen','Bodor','Witherington',61),(293,5,'Garfield','Chowdhury','Harjochee',61),(294,6,'Ricky','Genich','Scarce',61),(295,2,'Odis','Vardaman','Wassell',61),(296,2,'Carter','Burnie','Lamudio',61),(297,2,'Josh','Szczesny','Ging',61),(298,4,'January','Mcgoff','Vanalstine',62),(299,5,'Rex','Kuszlyk','Rudeen',62),(300,6,'Tracey','Enock','Felonia',62),(301,1,'Alisa','Dyle','Lembcke',62),(302,1,'Christal','Onukogu','Furubotten',62),(303,4,'Blanche','Yott','Annino',63),(304,5,'Ismael','Vera','Kiflezghie',63),(305,6,'Hector','Crognale','Connell',63),(306,1,'Suzanne','Heybrock','Ape',63),(307,1,'Luciana','Larita','Ecord',63),(308,1,'Danyel','Pettiford','Feliz',63),(309,4,'Tammie','Lampros','Pillitteri',64),(310,5,'Kory','Dumlao','Vandeusen',64),(311,6,'Zackary','Sjolander','Mehling',64),(312,1,'Candace','Neuenswander','Borgert',64),(313,1,'Aiko','Molleur','Beserra',64),(314,4,'Grisel','Lichtman','Britcher',65),(315,5,'Glenn','Lennan','Scandalios',65),(316,6,'Jasper','Dixie','Woodley',65),(317,2,'Mack','Joun','Nagler',65),(318,4,'James','Lavongsar','Branyan',66),(319,5,'Darrel','Aveline','Wick',66),(320,6,'Jackson','Xang','Laurino',66),(321,2,'Chad','Ratzloff','Ballengee',66),(322,2,'Peter','Metzler','Pettie',66),(323,4,'Jana','Keawe','Fajardo',67),(324,5,'Grover','Veeder','Tolden',67),(325,6,'Danilo','Hawthorne','Rumrill',67),(326,1,'Kera','Hartly','Burrichter',67),(327,1,'Blanch','Leek','Ralph',67),(328,1,'Adelia','Rositano','Brodhag',67),(329,4,'Kassandra','Stabile','Keasey',68),(330,5,'Ike','Sanipasi','Cawley',68),(331,6,'Norris','Mathiason','Urso',68),(332,2,'Herman','Corn','Hennick',68),(333,2,'Neville','Combass','Matysiak',68),(334,2,'Renato','Hawke','Antila',68),(335,4,'Andre','Clacher','Smarr',69),(336,5,'Brent','Winikoff','Rutter',69),(337,6,'Carl','Stamey','Sembrat',69),(338,2,'Emory','Galper','Cafasso',69),(339,2,'Deon','Tea','Defrance',69),(340,4,'Rosalee','Bowden','Mortland',70),(341,5,'Walton','Sugiki','Waddell',70),(342,6,'Jack','Pietila','Ferencz',70),(343,1,'Rochelle','Haisten','Koeninger',70),(344,1,'Gene','Dagle','Wrinn',70),(345,4,'Leana','Moffa','Fugo',71),(346,5,'Tory','Seabrooks','Bardo',71),(347,6,'Alvin','Speroni','Skeans',71),(348,2,'Lazaro','Tysinger','Pesek',71),(349,2,'Isidro','Sherrick','Sirpilla',71),(350,2,'Clayton','Creggett','Sally',71),(351,4,'Brittany','Theam','Macallister',72),(352,5,'Matthew','Hinz','Quatrevingt',72),(353,6,'Brock','Autovino','Bedar',72),(354,1,'Verdell','Kossmann','Blanzy',72),(355,1,'Sunday','Quince','Waddle',72),(356,1,'Macy','Deskin','Parmelee',72),(357,4,'Maddie','Steagell','Hiestand',73),(358,5,'Cyril','Kinniburgh','Holzem',73),(359,6,'Danilo','Nurmi','Hayne',73),(360,1,'Verna','Factor','Okray',73),(361,1,'Angeles','Hanebutt','Darius',73),(362,4,'Gaylene','Morn','Konger',74),(363,5,'Tony','Orchard','Bichler',74),(364,6,'Martin','Bienenstock','Tukis',74),(365,1,'Violet','Tullison','Burman',74),(366,1,'Ingeborg','Whitmyre','Chabbez',74),(367,1,'Ericka','Guzzardo','Elman',74),(368,4,'Magdalena','Chrzanowski','Dunay',75),(369,5,'Austin','Datri','Beekman',75),(370,6,'Ivory','Bailon','Sgro',75),(371,1,'Halina','Rossotto','Gormanous',75),(372,1,'Vicki','Addo','Boruff',75),(373,4,'Cherish','Hofmans','Boehmke',76),(374,5,'Johnie','Bonomo','Rocher',76),(375,6,'Rodney','Carriveau','Lembo',76),(376,1,'Reita','Cyler','Michello',76),(377,1,'Melody','Beyda','Quiver',76),(378,4,'Albertine','Slotkin','Evangelo',77),(379,5,'Jayson','Bieler','Gallaspy',77),(380,6,'Enoch','Tekell','Boxton',77),(381,1,'Xiomara','Matto','Hysell',77),(382,4,'Pasty','Gerache','Rollind',78),(383,5,'Jasper','Dishong','Voeks',78),(384,6,'Calvin','Licalzi','Dingee',78),(385,1,'Lia','Greenstreet','Morning',78),(386,1,'Shirlee','Avancena','Murnan',78),(387,1,'Maricruz','Oswald','Mackey',78),(388,4,'Tonisha','Cwalinski','Huus',79),(389,5,'Noel','Delatorre','Kahrer',79),(390,6,'Asa','Tomasson','Attard',79),(391,2,'Ivory','Ellworths','Mickels',79),(392,2,'Emory','Tiangco','Lochen',79),(393,4,'Marna','Couchman','Prukop',80),(394,5,'Julio','Deno','Ockey',80),(395,6,'Al','Boustead','Weitz',80),(396,2,'Donnie','Hadesty','Mabray',80),(397,2,'Aaron','Godkin','Osman',80),(398,4,'Tiffiny','Walzier','Comiso',81),(399,5,'Ira','Almstead','Jeffress',81),(400,6,'Ferdinand','Strausbaugh','Garnica',81),(401,2,'Andrew','Yearous','Luebbers',81),(402,2,'Sammie','Dixon','Mehling',81),(403,2,'Ronald','Bronston','Millare',81),(404,4,'Yvone','Belgrade','Cardin',82),(405,5,'Vincenzo','Zumbach','Albro',82),(406,6,'Quincy','Deed','Baldree',82),(407,2,'Stacy','Garraway','Landreth',82),(408,2,'Cornelius','Rodregez','Vaillencourt',82),(409,2,'Fredrick','Bakko','Perona',82),(410,4,'Florance','Vanroekel','Garrard',83),(411,5,'Bruce','Sessom','Popovec',83),(412,6,'Vernon','Sachez','Boever',83),(413,1,'Angie','Chinweze','Kildoo',83),(414,4,'Lourie','Chum','Worsham',84),(415,5,'Mel','Wigington','Groetsch',84),(416,6,'Valentin','Riffee','Ishihara',84),(417,1,'Cleora','Herrick','Verbasco',84),(418,1,'Cordia','Brugger','Reinfeld',84),(419,4,'Shera','Rabelo','Lafayette',85),(420,5,'Reuben','Connelly','Koterba',85),(421,6,'Pierre','Lunn','Grandin',85),(422,1,'Rachele','Bruh','Dotter',85),(423,1,'Macy','Jamar','Solarski',85),(424,1,'Suzann','Cutler','Zielesch',85),(425,4,'Lakita','Laware','Vanhamlin',86),(426,5,'Grover','Debbins','Muyres',86),(427,6,'Shannon','Curbow','Gahl',86),(428,1,'Lona','Mccaddon','Boldizsar',86),(429,1,'Fredda','Vandyck','Ayre',86),(430,1,'Leann','Olesky','Kaufhold',86),(431,4,'Renay','Dennies','Seen',87),(432,5,'Cleo','Lenger','Barrentine',87),(433,6,'Everett','Krusen','Koral',87),(434,2,'Loyd','Branco','Fineberg',87),(435,4,'Toby','Schiefelbein','Tramble',88),(436,5,'Devin','Deglow','Scalet',88),(437,6,'Bruce','Deland','Keels',88),(438,2,'Branden','Fuchser','Bernt',88),(439,2,'Oren','Grenke','Apela',88),(440,4,'Maggie','Spiney','Hofmans',89),(441,5,'Lupe','Autman','Pair',89),(442,6,'Damon','Adrien','Weisinger',89),(443,1,'Scott','Goon','Readinger',89),(444,4,'Lyla','Beseke','Laundry',90),(445,5,'Bill','Reprogle','Brei',90),(446,6,'Ricky','Eley','Wraight',90),(447,1,'Emiko','Baile','Allessio',90),(448,1,'Esmeralda','Rach','Dellapenna',90),(449,1,'Cinda','Garthwaite','Kaleta',90),(450,4,'Erlene','Mossien','Cozart',91),(451,5,'Miles','Imholte','Decourley',91),(452,6,'Keenan','Davito','Ritzman',91),(453,1,'Jennie','Rienzo','Calvo',91),(454,4,'Ona','Nayes','Squeo',92),(455,5,'Lindsay','Taillefer','Honer',92),(456,6,'Hayden','Botta','Pinnix',92),(457,1,'Adela','Sumruld','Bownds',92),(458,1,'Tammy','Suermann','Midcap',92),(459,4,'Roxana','Krieg','Fegette',93),(460,5,'Jayson','Dashiell','Billegas',93),(461,6,'Weston','Mcowen','Prukop',93),(462,1,'Lettie','Sappington','Lacson',93),(463,4,'Tomeka','Effler','Heffron',94),(464,5,'Jacinto','Gregan','Applin',94),(465,6,'Kory','Eckblad','Maret',94),(466,1,'Nettie','Jakubek','Gremler',94),(467,4,'Debbi','Kalama','Olivares',95),(468,5,'Devin','Rakestraw','Burkhammer',95),(469,6,'Buford','Shima','Blatchford',95),(470,2,'Ferdinand','Keglovic','Acuff',95),(471,4,'Carita','Awbrey','Hamiss',96),(472,5,'Agustin','Piccioni','Reagle',96),(473,6,'Kenneth','Hedtke','Mallak',96),(474,2,'Efren','Seaney','Timpson',96),(475,4,'Georgiana','Chitwood','Stormo',97),(476,5,'Bradly','Whirley','Josten',97),(477,6,'Carlos','Maedke','Pax',97),(478,2,'Chi','Pexton','Glaubke',97),(479,4,'Rosann','Sherling','Maceda',98),(480,5,'Robin','Koehler','Zarzuela',98),(481,6,'Drew','Scudder','Torrens',98),(482,2,'Hal','Mcadoo','Bable',98),(483,4,'Delilah','Bario','Cleveland',99),(484,5,'Weldon','Clippard','Miyasaki',99),(485,6,'Doug','Gregoroff','Kriegshauser',99),(486,1,'Regan','Branter','Peasel',99),(487,1,'Kelsie','Nikach','Whiddon',99),(488,4,'Audrie','Tirk','Mlenar',100),(489,5,'Perry','Odhner','Rummler',100),(490,6,'Ezra','Patchell','Crosiar',100),(491,2,'Wyatt','Beaumonte','Tellman',100),(492,2,'Moises','Wubbel','Schuetze',100),(493,4,'Brooke','Schuppert','Sankaran',101),(494,5,'Calvin','Joosten','Aye',101),(495,6,'Theo','Cabebe','Becklund',101),(496,1,'Maryann','Padol','Boeck',101),(497,4,'Zita','Enns','Yslava',102),(498,5,'Clifton','Koenigsfeld','Inafuku',102),(499,6,'Ward','Mork','Terhark',102),(500,1,'Selina','Buccieri','Eden',102),(501,1,'Darby','Roehrig','Cree',102),(502,4,'Alexandria','Strandberg','Gjorven',103),(503,5,'Darron','Nanni','Cudd',103),(504,6,'Derek','Scelsi','Tiede',103),(505,1,'Elna','Slaght','Mccrane',103),(506,4,'Georgia','Graczyk','Greening',104),(507,5,'Carol','Waldren','Cereceres',104),(508,6,'Kory','Katis','Mackey',104),(509,2,'Ryan','Calvary','Kenngott',104),(510,2,'Alvin','Zanchez','Lafevre',104),(511,4,'Tiara','Hirz','Cupe',105),(512,5,'Gus','Catalina','Gorham',105),(513,6,'Philip','Adkerson','Mcduff',105),(514,2,'Buford','Seabrooks','Plumber',105),(515,2,'Delbert','Bohan','Scheidel',105),(516,4,'Cindy','Sauber','Bostian',106),(517,5,'Sebastian','Mersinger','Heilig',106),(518,6,'Oswaldo','Ortmeyer','Harper',106),(519,1,'Mireya','Carrino','Mollicone',106),(520,4,'Cathern','Freitas','Guinther',107),(521,5,'Maxwell','Kachel','Coyier',107),(522,6,'Oswaldo','Zakes','Feris',107),(523,2,'Irving','Garofolo','Mcclod',107),(524,4,'Lashon','Rawlings','Lafevers',108),(525,5,'Fred','Takai','Dagel',108),(526,6,'Kendrick','Siebens','Lowek',108),(527,2,'Doug','Vreugdenhil','Hames',108),(528,2,'Josue','Whittley','Eldrige',108),(529,4,'Bernetta','Crisman','Dari',109),(530,5,'Jaime','Minus','Touhey',109),(531,6,'Matt','Wenner','Orn',109),(532,2,'Nicky','Sieving','Simoneau',109),(533,4,'Aisha','Schuelke','Sobota',110),(534,5,'Glenn','Mika','Valintine',110),(535,6,'Hipolito','Heatley','Cardonia',110),(536,1,'Michelina','Battis','Bhalla',110),(537,4,'Maryanna','Dyke','Horney',111),(538,5,'Merlin','Layher','Furney',111),(539,6,'Johnny','Massey','Quincel',111),(540,1,'Kamala','Heitland','Tyacke',111),(541,1,'Lucie','Rastelli','Fosser',111),(542,1,'Maude','Kemple','Smutzler',111),(543,4,'Sarina','Sawney','Dawley',112),(544,5,'Daron','Wiginton','Camancho',112),(545,6,'Delmer','Gremler','Manfredini',112),(546,1,'Kyra','Bisby','Russi',112),(547,4,'Olimpia','Landborg','Gehris',113),(548,5,'Roy','Felsted','Mundschau',113),(549,6,'Donovan','Sette','Toala',113),(550,2,'Ronald','Shindorf','Tewa',113),(551,4,'Hiedi','Gruver','Hamett',114),(552,5,'Israel','Ferron','Battis',114),(553,6,'Tory','Mordue','Sandholm',114),(554,2,'Keven','Belko','Gugliotti',114),(555,4,'Regan','Polemeni','Leandry',115),(556,5,'Hayden','Perone','Wetherington',115),(557,6,'Billy','Falor','Frazzano',115),(558,1,'Sofia','Musumeci','Geddes',115),(559,1,'Laci','Schilawski','Scharpman',115),(560,4,'Yaeko','Buntjer','Partlow',116),(561,5,'Donnie','Turdo','Loarca',116),(562,6,'Timothy','Hussy','Craiger',116),(563,1,'Winifred','Mcclaine','Athans',116),(564,1,'Martin','Carlson','Pinion',116),(565,4,'Angelena','Sieligowski','Griesbaum',117),(566,5,'Prince','Kloska','Toepel',117),(567,6,'Linwood','Alfero','Santellan',117),(568,1,'Anne','Pardoe','Iwami',117),(569,1,'Shu','Huff','Lachowicz',117),(570,4,'Christal','Italiano','Cuckler',118),(571,5,'Alonso','Thorman','Garder',118),(572,6,'Genaro','Merten','Lace',118),(573,1,'Lottie','Garfinkle','Drish',118),(574,1,'Tobi','Braunstein','Burnsed',118),(575,1,'Elma','Fontenelle','Kucel',118),(576,4,'Sherita','Dolberry','Gurry',119),(577,5,'Mervin','Kruppa','Vriens',119),(578,6,'Ferdinand','Medaries','Tole',119),(579,1,'Tanika','Vipperman','Majeske',119),(580,1,'Cristi','Donald','Brigance',119),(581,1,'Cierra','Hennard','Essery',119),(582,4,'Lilian','Lehew','Kalmen',120),(583,5,'Willy','Steerman','Alessandro',120),(584,6,'Rafael','Harlan','Sadri',120),(585,1,'Minerva','Helling','Oroz',120),(586,1,'Judy','Hazelip','Wence',120),(587,4,'Stacia','Tlatelpa','Jaradat',121),(588,5,'Kendrick','Kosorog','Norkus',121),(589,6,'Edwardo','Coryea','Hodes',121),(590,1,'Kandis','Machlin','Tronaas',121),(591,1,'Alix','Almond','Siskey',121),(592,4,'Saran','Ngov','Burrill',122),(593,5,'Hans','Baughn','Doty',122),(594,6,'Terence','Wackerbarth','Cords',122),(595,2,'Roscoe','Martinez','Holtgrefe',122),(596,2,'Angel','Wurster','Sanda',122),(597,4,'Richelle','Bukowski','Messa',123),(598,5,'Andre','Callendar','Sarraga',123),(599,6,'Randell','Karjala','Frediani',123),(600,2,'Stewart','Arenson','Uniacke',123),(601,2,'Ignacio','Werthman','Armillei',123),(602,2,'Domingo','Lanze','Staberg',123),(603,4,'Florinda','Henthorn','Hannem',124),(604,5,'Leonard','Tudman','Rosel',124),(605,6,'Thurman','Mcvoy','Giang',124),(606,2,'Houston','Krzywicki','Hannold',124),(607,2,'Earle','Witherbee','Becker',124),(608,4,'In','Doxtater','Melito',125),(609,5,'Kenton','Shirkey','Stroble',125),(610,6,'Xavier','Faggs','Hebner',125),(611,2,'Bo','Vlashi','Peerbolt',125),(612,4,'Maryalice','Rexwinkle','Kalis',126),(613,5,'Emory','Coverdell','Sofia',126),(614,6,'Duncan','True','Corzine',126),(615,1,'Tashia','Castlen','Pierceall',126),(616,4,'Charlie','Miskell','Thraen',127),(617,5,'Glenn','Vovak','Ballmer',127),(618,6,'Grover','Stum','Stagman',127),(619,2,'Genaro','Blady','Decraene',127),(620,4,'Amira','Diffenderfer','Amorello',128),(621,5,'Nicolas','Cafagno','Heidkamp',128),(622,6,'Fredrick','Oliff','Chernay',128),(623,1,'Phyliss','Kleftogiannis','Kaarlela',128),(624,4,'Marquitta','Wrobliski','Aliotta',129),(625,5,'Xavier','Luhmann','Navas',129),(626,6,'Dino','Mithcell','Robella',129),(627,2,'Blaine','Pennig','Kipps',129),(628,4,'Lynette','Amble','Disarufino',130),(629,5,'Edwardo','Evanchyk','Agreste',130),(630,6,'Lazaro','Blakeman','Nikolic',130),(631,2,'Weldon','Halder','Trotochaud',130),(632,4,'Freida','Stephco','Possick',131),(633,5,'Darron','Keyon','Schoessow',131),(634,6,'Guadalupe','Reph','Betties',131),(635,2,'Matthew','Schamel','Proano',131),(636,2,'Will','Meirick','Barze',131),(637,4,'Adriana','Berrocal','Hazy',132),(638,5,'Gavin','Maggard','Brofft',132),(639,6,'Marcos','Piecuch','Wakefield',132),(640,1,'Lela','Rudzinski','Bierner',132),(641,1,'Zoe','Jaussen','Ludgate',132),(642,4,'Cathy','Murdoch','Donnely',133),(643,5,'Asa','Poelman','Ohta',133),(644,6,'Jerry','Schoffstall','Monares',133),(645,2,'Will','Damico','Lalone',133),(646,2,'Alexis','Rossin','Mozdzierz',133),(647,4,'Hang','Pettus','Detering',134),(648,5,'Isidro','Behen','Oxborrow',134),(649,6,'Domingo','Polansky','Booze',134),(650,2,'Kenneth','Tinnell','Poppenhagen',134),(651,2,'Lou','Minus','Adie',134),(652,4,'Virgen','Irizarri','Malueg',135),(653,5,'Sammy','Sherles','Seier',135),(654,6,'Rolf','Thistle','Prosser',135),(655,2,'Paul','Phinazee','Jarriett',135),(656,4,'Sam','Mckinney','Rase',136),(657,5,'Winfred','Kaut','Smoley',136),(658,6,'Bennie','Lecato','Isaacson',136),(659,2,'Lacy','Dezarn','Milholland',136),(660,4,'Erna','Knoepke','Varron',137),(661,5,'Jere','Coan','Willmott',137),(662,6,'Paul','Cleverly','Hongisto',137),(663,1,'Joleen','Hempel','Fetters',137),(664,1,'Tula','Rubloff','Stepter',137),(665,1,'Raymond','Olson','Gadbury',137),(666,4,'Zena','Wisz','Steffenhagen',138),(667,5,'Jesus','Hunsinger','Manly',138),(668,6,'Darin','Araujo','Dannunzio',138),(669,2,'Roman','Bering','Hentges',138),(670,4,'Gertude','Tresch','Koppen',139),(671,5,'Antony','Hirschy','Wicklund',139),(672,6,'Daren','Pillot','Fjetland',139),(673,2,'Randal','Wrights','Klavetter',139),(674,2,'Randal','Pavy','Shine',139),(675,2,'Oswaldo','Glowski','Napoles',139),(676,4,'Dionne','Bottone','Elhassan',140),(677,5,'Wilton','Ciccolini','Dekeyzer',140),(678,6,'Julius','Callaham','Coachman',140),(679,1,'Marry','Pesto','Golder',140),(680,1,'Love','Cardeiro','Woodrum',140),(681,1,'Jackeline','Pfleiderer','Garnes',140),(682,4,'Evie','Chvilicek','Zegarelli',141),(683,5,'Hector','Englund','Mahanna',141),(684,6,'Mac','Bolebruch','Weyers',141),(685,1,'Mirian','Vea','Corderman',141),(686,1,'Aline','Lillich','Kouns',141),(687,4,'Sheryl','Huelsman','Balling',142),(688,5,'Lino','Buroker','Stodgell',142),(689,6,'Adam','Holtzer','Printz',142),(690,1,'Claribel','Sitterson','Patry',142),(691,4,'Venice','Bisges','Buxton',143),(692,5,'Johnny','Macdonell','Trometter',143),(693,6,'August','Rotenberry','Ludera',143),(694,2,'Tyrell','Mccarns','Brocklebank',143),(695,2,'Walker','Frija','Arnwine',143),(696,4,'Tracee','Kagey','Bloom',144),(697,5,'Rosario','Wida','Hetz',144),(698,6,'Martin','Manatt','Kosak',144),(699,2,'Rickey','Camposano','Villaluz',144),(700,2,'Moshe','Sheller','Upole',144),(701,2,'Neville','Zwicker','Forslund',144),(702,4,'Antonio','Degollado','Catena',145),(703,5,'Lane','Blackaby','Basil',145),(704,6,'Kevin','Angelilli','Iltzsch',145),(705,1,'Marlys','Ranieri','Enzor',145),(706,1,'Avelina','Raco','Halsall',145),(707,1,'Neta','Baillie','Handcock',145),(708,4,'Charity','Vessar','Belen',146),(709,5,'Devin','Geanopulos','All',146),(710,6,'Donn','Melillo','Knilands',146),(711,1,'Penni','Arichabala','Folkman',146),(712,4,'Zandra','Arollo','Masenten',147),(713,5,'Landon','Antinarelli','Chianese',147),(714,6,'Walter','Baich','Elswick',147),(715,1,'Jaimee','Ohlsen','Wittig',147),(716,1,'Valerie','Floros','Bellis',147),(717,4,'Samatha','Rumpf','Cork',148),(718,5,'Ernesto','Travis','Werline',148),(719,6,'Damon','Cossa','Miglorie',148),(720,1,'Katina','Rehmer','Pursley',148),(721,1,'Shizue','Mracek','Mclay',148),(722,1,'Mayola','Kaua','Rafiq',148),(723,4,'Shana','Ober','Buol',149),(724,5,'Francis','Bussom','Cutno',149),(725,6,'Dong','Naeher','Rambousek',149),(726,1,'Michell','Santilukka','Dobkin',149),(727,1,'Cristi','Yaegle','Sexauer',149),(728,1,'Shery','Daschofsky','Cerrello',149),(729,4,'Lindsey','Ziencina','Dubson',150),(730,5,'Isaiah','Schnider','Aispuro',150),(731,6,'Ramiro','Novinger','Volk',150),(732,2,'Ira','Drabant','Dalmau',150),(733,2,'Zackary','Gauci','Platter',150),(734,4,'Theo','Tosto','Avelino',151),(735,5,'Lucas','Guasp','Lucken',151),(736,6,'Reyes','Algier','Acosto',151),(737,2,'Clyde','Staebler','Gochanour',151),(738,2,'Alan','Tomb','Harlan',151),(739,4,'Aaron','Pollutro','Reefer',152),(740,5,'Tyrell','Wolk','Taney',152),(741,6,'Isreal','Bendig','Samoyoa',152),(742,2,'Renato','Mcglew','Grajek',152),(743,4,'Winifred','Heydel','Tartaglia',153),(744,5,'Garfield','Merlette','Goldade',153),(745,6,'Terry','Fleischner','Coates',153),(746,1,'Shantel','Sperka','Jagielski',153),(747,1,'Gene','Duensing','Marchionni',153),(748,4,'Lyndia','Seecharan','Ruppert',154),(749,5,'Rickey','Ishman','Ezell',154),(750,6,'Jim','Rico','Dehne',154),(751,1,'Minh','Kovarik','Kardas',154),(752,1,'Melony','Meginnes','Muss',154),(753,1,'Han','Isgur','Shoun',154),(754,4,'Xuan','Ide','Bonanni',155),(755,5,'Marco','Tromba','Buzzanca',155),(756,6,'Kent','Berbes','Gaut',155),(757,2,'Cyril','Quarnstrom','Kincaide',155),(758,2,'Paul','Rosol','Rudell',155),(759,4,'Ariane','Leners','Parris',156),(760,5,'Keenan','Colder','Teskey',156),(761,6,'Alden','Haggar','Smallman',156),(762,1,'Rossana','Heagy','Stevener',156),(763,1,'Rose','Waley','Nori',156),(764,4,'Hope','Bultema','Minutillo',157),(765,5,'Leif','Abrell','Cerroni',157),(766,6,'Markus','Villescas','Kellaway',157),(767,2,'Whitney','Yamashiro','Scates',157),(768,2,'Hoyt','Hillan','Zmuda',157),(769,4,'Maudie','Feyen','Mingioni',158),(770,5,'Graham','Fyffe','Holtsclaw',158),(771,6,'Chi','Leclear','Geibel',158),(772,1,'Karoline','Swinson','Brownsword',158),(773,1,'Johnsie','Sevy','Verges',158),(774,4,'Britany','Dastrup','Zakarian',159),(775,5,'Mckinley','Nemzek','Lomack',159),(776,6,'Herb','Arbeiter','Dielman',159),(777,2,'Kasey','Mound','Ligget',159),(778,4,'Kathyrn','Butter','Kist',160),(779,5,'Max','Ramesh','Junes',160),(780,6,'Stephan','Copus','Bihl',160),(781,1,'Julienne','Garwin','Gonzelas',160),(782,1,'Minerva','Staffen','Kostick',160),(783,4,'Danille','Fineran','Sharps',161),(784,5,'Ahmad','Kahal','Citroni',161),(785,6,'Mickey','Whiddon','Vitek',161),(786,2,'Napoleon','Newburn','Sterns',161),(787,2,'Scottie','Belnap','Arriaga',161),(788,2,'Pete','Okel','Hauber',161),(789,4,'Latonia','Jurkovich','Robichard',162),(790,5,'Devin','Golds','Guarnieri',162),(791,6,'Vernon','Waage','Cleghorn',162),(792,1,'Retha','Lenzini','Wesolick',162),(793,1,'Tambra','Millstein','Sandles',162),(794,4,'Brittanie','Daigle','Flicek',163),(795,5,'Aaron','Messina','Kovack',163),(796,6,'Abram','Klinger','Glockner',163),(797,2,'Bruno','Holdorf','Sampang',163),(798,4,'Cathryn','Brunfield','Tomme',164),(799,5,'Dan','Cram','Nipps',164),(800,6,'Randell','Mugge','Fingerman',164),(801,1,'Melony','Feulner','Hulsman',164),(802,1,'Joellen','Liendo','Morefield',164),(803,4,'Willette','Dolmajian','Kasper',165),(804,5,'Julius','Spreng','Clawson',165),(805,6,'Lino','Wittrup','Hoaglin',165),(806,2,'Erik','Barile','Pangle',165),(807,4,'Reta','Shido','Bulan',166),(808,5,'Alonso','Lehtinen','Hnot',166),(809,6,'Lemuel','Stonebarger','Edgin',166),(810,1,'Reynalda','Landor','Koeck',166),(811,1,'Tera','Heidtbrink','Leahey',166),(812,4,'Marta','Vandekieft','Skalak',167),(813,5,'Tyrell','Thames','Jendras',167),(814,6,'Eloy','Ensell','Brough',167),(815,1,'Robbyn','Woulard','Schultz',167),(816,1,'Salina','Unterzuber','Irving',167),(817,4,'Anette','Mccathran','Humbles',168),(818,5,'Abraham','Taunton','Sandate',168),(819,6,'Les','Berni','Bognuda',168),(820,1,'Misti','Herlong','Going',168),(821,4,'Fredericka','Varuzzo','Schehr',169),(822,5,'Shaun','Pravata','Vignarath',169),(823,6,'Bruno','Pasto','Marushia',169),(824,1,'Lurlene','Maushardt','Stuesse',169),(825,4,'Veola','Wendte','Ihrig',170),(826,5,'Dong','Heinandez','Brueck',170),(827,6,'Freeman','Jamal','Jolls',170),(828,1,'Margarette','Rea','Printz',170),(829,4,'Sophia','Eagen','Meirick',171),(830,5,'Guillermo','Tutas','Gallishaw',171),(831,6,'Francisco','Pailthorpe','Beyea',171),(832,1,'Shonna','Robeson','Duane',171),(833,4,'Ardell','Manino','Pleet',172),(834,5,'Guadalupe','Parone','Jordon',172),(835,6,'Rosario','Pounds','Lasane',172),(836,1,'Latonia','Cortez','Pavone',172),(837,1,'Dion','Leisey','Wedman',172),(838,4,'Lina','Sampang','Zolocsik',173),(839,5,'Rodolfo','Jaegers','Kears',173),(840,6,'Vicente','Himelstein','Lesley',173),(841,2,'Arlie','Hendershott','Cartez',173),(842,2,'Joseph','Mackowiak','Remey',173),(843,4,'Vannessa','Wollman','Burrichter',174),(844,5,'Vernon','Casada','Olshan',174),(845,6,'Josef','Matsui','Macola',174),(846,1,'Rina','Goodsite','Duemmel',174),(847,1,'Renae','Chaligoj','Mccollum',174),(848,4,'Deidre','Jupiter','Acy',175),(849,5,'Daren','Sieger','Engberg',175),(850,6,'Sherman','Mccartney','Rooker',175),(851,2,'Calvin','Tuorto','Dumesnil',175),(852,4,'Aracelis','Piatek','Figueiras',176),(853,5,'Rodolfo','Swallows','Heimark',176),(854,6,'Rigoberto','Eveleigh','Mclaine',176),(855,2,'Waylon','Scullawl','Weirauch',176),(856,4,'Lenita','Poster','Henretta',177),(857,5,'Phillip','Moodie','Gojmerac',177),(858,6,'Gus','Voth','Bluth',177),(859,2,'Zachery','Tritto','Drungo',177),(860,2,'Lanny','Companion','Archut',177),(861,4,'Tammera','Sozio','Adloff',178),(862,5,'Mervin','Falconio','Rodberg',178),(863,6,'Jacinto','Stamer','Balcerzak',178),(864,2,'Carmen','Kvaternik','Lamoreux',178),(865,2,'Waylon','Brandorff','Karwoski',178),(866,4,'Sherita','Gustafson','Breitbach',179),(867,5,'Roland','Penninger','Tuschhoff',179),(868,6,'Alvaro','Haab','Desha',179),(869,1,'Athena','Michalowski','Eberts',179),(870,1,'Carrol','Maroni','Mcgarrah',179),(871,4,'Pam','Kastens','Hadesty',180),(872,5,'Miles','Secky','Seminario',180),(873,6,'Hoyt','Burtschi','Clunie',180),(874,1,'Cecelia','Stears','Munhall',180),(875,4,'Latosha','Lewandowsky','Dekenipp',181),(876,5,'Long','Laurange','Mcgorry',181),(877,6,'Grover','Bailiff','Guedjian',181),(878,1,'Nu','Cujas','Huus',181),(879,1,'Sebrina','Sigala','Foglesong',181),(880,1,'Chantelle','Waltos','Kocab',181),(881,4,'Terra','Lefton','Introini',182),(882,5,'Garret','Lohman','Laforest',182),(883,6,'Josef','Nicolaus','Gorglione',182),(884,2,'Malcolm','Petrouits','Krome',182),(885,2,'Weston','Rach','Honn',182),(886,4,'Anika','Shatzer','Magallanez',183),(887,5,'Claudio','Bruffee','Licor',183),(888,6,'Elvis','Posnick','Redemer',183),(889,2,'Tommy','Marsh','Channell',183),(890,2,'Hollis','Scanio','Noriega',183),(891,4,'Ewa','Fergoson','Jobes',184),(892,5,'Valentin','Rhode','Pinion',184),(893,6,'Weston','Maglioli','Hett',184),(894,1,'Kristyn','Mckearin','Beaudreau',184),(895,1,'Inocencia','Hairster','Tarbell',184),(896,4,'Delorse','Lovig','Reveles',185),(897,5,'Hank','Delfi','Dekrey',185),(898,6,'Leigh','Matusiewicz','Ausby',185),(899,2,'Freeman','Stange','Traynham',185),(900,4,'Blythe','Yopp','Hofe',186),(901,5,'Alva','Laplant','Saluto',186),(902,6,'Bryce','Varquez','Verigan',186),(903,1,'Zella','Moisa','Dubin',186),(904,4,'Ollie','Charvet','Fallon',187),(905,5,'Carlos','Pagels','Jiron',187),(906,6,'Lee','Ribsamen','Reicks',187),(907,2,'Lorenzo','Clucas','Gossett',187),(908,4,'Angela','Cardon','Eastmond',188),(909,5,'Irving','So','Spoerl',188),(910,6,'Sid','Bucknell','Mccurren',188),(911,2,'Thurman','Politi','Gedo',188),(912,4,'Fredda','Fuse','Loeser',189),(913,5,'Stevie','Fleischhacker','Pfohl',189),(914,6,'Rolando','Bechler','Gilden',189),(915,1,'Kendra','Hathaway','Darosa',189),(916,1,'Michelina','Norsworthy','Potthoff',189),(917,1,'Josie','Butta','Diamante',189),(918,4,'Liane','Utsler','Eichberg',190),(919,5,'Rolando','Paulseth','Ceranski',190),(920,6,'Ahmad','Reilly','Goecke',190),(921,1,'Katharine','Haessly','Sheler',190),(922,4,'Irish','Mordecai','Loker',191),(923,5,'Leandro','Poties','Miran',191),(924,6,'Gus','Blazon','Taj',191),(925,2,'Mohammed','Russwurm','Schlagel',191),(926,4,'Quyen','Burtch','Bolda',192),(927,5,'Homer','Hotaki','Cobham',192),(928,6,'Douglass','Koenigsman','Mcgunnigle',192),(929,2,'Kim','Urik','Gamberg',192),(930,2,'Peter','Rosati','Escutia',192),(931,2,'Mario','Pendergrass','Risha',192),(932,4,'Macie','Tienda','Cipolla',193),(933,5,'Hosea','Mcclee','Merel',193),(934,6,'Antony','America','Begor',193),(935,1,'Winnie','Fahrendorff','Ballantine',193),(936,1,'Amie','Cabrera','Atchley',193),(937,1,'Caridad','Abruzzino','Frankford',193),(938,4,'Carlos','Gilbert','Beaudet',194),(939,5,'Emil','Limes','Matsen',194),(940,6,'Michel','Woolard','Schubert',194),(941,2,'Aubrey','Onkst','Amigo',194),(942,4,'Breanna','Kindl','Shimizu',195),(943,5,'Scot','Turinetti','Wolzen',195),(944,6,'Elden','Herre','Kerksiek',195),(945,2,'Randall','Jarchow','Cothren',195),(946,4,'Kathrin','Dimpson','Hetland',196),(947,5,'Ferdinand','Brendlinger','Left',196),(948,6,'Dalton','Caterino','Andalora',196),(949,2,'Mathew','Lett','Sternberger',196),(950,2,'Julius','Waldock','Koonz',196),(951,4,'Joannie','Maleszka','Andelman',197),(952,5,'Bryce','Geiselman','Riggott',197),(953,6,'Clayton','Calandra','Zaccaria',197),(954,2,'Mel','Sparhawk','Parisian',197),(955,4,'Clarice','Watt','Scherrer',198),(956,5,'Weldon','Matrey','Hebsch',198),(957,6,'Hector','Waxman','Komp',198),(958,2,'Norris','Brittman','Sowle',198),(959,2,'Rene','Bosley','Izzi',198),(960,4,'Marcella','Honer','Aery',199),(961,5,'Genaro','Carothers','Agtarap',199),(962,6,'Zack','Watanabe','Parrigan',199),(963,2,'Gilbert','Perking','Rinkus',199),(964,2,'Ezra','Hummel','Harre',199),(965,4,'Hilaria','Brocious','Bires',200),(966,5,'Garry','Mcleese','Bialik',200),(967,6,'Winston','Blackshire','Coggins',200),(968,2,'Joaquin','Szeto','Fuell',200),(969,2,'Jim','Flahive','Greek',200),(970,2,'Hubert','Roadcap','Trainor',200),(971,4,'Gidget','Windish','Pownell',201),(972,5,'Bruce','Mcbratney','Mcchain',201),(973,6,'Brooks','Prevot','Torrico',201),(974,1,'Sherri','Boustead','Puentes',201),(975,1,'Tia','Gatley','Virelli',201),(976,4,'Gail','Yerbich','Migliaccio',202),(977,5,'Pat','Brubach','Buchenau',202),(978,6,'Ramiro','Kaplowitz','Sienicki',202),(979,2,'Arlie','Partlow','Essman',202),(980,2,'Kristofer','Pinkham','Sieczkowski',202),(981,4,'Nelly','Thorburn','Kress',203),(982,5,'Gerry','Slaugh','Parmalee',203),(983,6,'Donn','Durousseau','Giaccone',203),(984,2,'Ryan','Volpert','Dillinger',203),(985,2,'Cleo','Birr','Guesman',203),(986,4,'Etsuko','Frankl','Hibbetts',204),(987,5,'Roderick','Bhan','Dueitt',204),(988,6,'Douglas','Rabil','Dohman',204),(989,1,'Jazmin','Spohn','Moorhead',204),(990,1,'Nadene','Youtsey','Esch',204),(991,4,'Magali','Tennyson','Lorr',205),(992,5,'Renaldo','Stonis','Severance',205),(993,6,'Grant','Mikolajczyk','Prehm',205),(994,2,'Chad','Conda','Mcclane',205),(995,2,'Lucio','Hellman','Shinabarger',205),(996,4,'Shawanda','Benns','Lahr',206),(997,5,'Danial','Zeller','Ledden',206),(998,6,'Walter','Smithmyer','Kevelin',206),(999,1,'Rossana','Bost','Pentecost',206),(1000,1,'Karleen','Hokkanen','Szalankiewicz',206),(1001,4,'Gena','Field','Drones',207),(1002,5,'Dante','Carriker','Forchione',207),(1003,6,'Freeman','Briese','Jane',207),(1004,2,'Ward','Hardemon','Massey',207),(1005,2,'Marcos','Cortez','Gracey',207),(1006,4,'Rebecka','Urbino','Dluhy',208),(1007,5,'Lucas','Hershnowitz','Kinnaman',208),(1008,6,'Leopoldo','Rouselle','Legerski',208),(1009,1,'Angeles','Braaten','Pedro',208),(1010,1,'Shanta','Haire','Benedetti',208),(1011,4,'Toya','Detlefs','Birkhead',209),(1012,5,'Hubert','Blasl','Bowhall',209),(1013,6,'Thanh','Herron','Fenger',209),(1014,2,'Kim','Shike','Faucette',209),(1015,2,'Vern','Arzaga','Leever',209),(1016,4,'Cleora','Koroch','Oakden',210),(1017,5,'Samual','Defranceschi','Ogan',210),(1018,6,'Oliver','Caliman','Nicoles',210),(1019,2,'Adrian','Michelini','Laviolette',210),(1020,2,'Royce','Arceo','Driscoll',210),(1021,4,'Loma','Ure','Chaderton',211),(1022,5,'Johnie','Frontis','Lipira',211),(1023,6,'Douglass','Traverse','Heu',211),(1024,2,'Gaylord','Ou','Harvick',211),(1025,4,'Maryjane','Cieslak','Bemrose',212),(1026,5,'Alonzo','Suto','Bourn',212),(1027,6,'Bobby','Charpia','Brainerd',212),(1028,2,'Lincoln','Milovich','Freshwater',212),(1029,4,'Franchesca','Bessent','Ceraos',213),(1030,5,'Mario','Sliman','Lincicome',213),(1031,6,'Howard','Caraway','Prabel',213),(1032,1,'Yesenia','Biorkman','Passaro',213),(1033,4,'Vernia','Hebdon','Breeman',214),(1034,5,'Coy','Hilzer','Debutts',214),(1035,6,'Dalton','Pickel','Coarsey',214),(1036,2,'Mauro','Cusimano','Andersson',214),(1037,2,'Ed','Vore','Kietzman',214),(1038,4,'Cathern','Tinajero','Ahluwalia',215),(1039,5,'Christopher','Pellicone','Aguino',215),(1040,6,'Terrence','Mikel','Parriera',215),(1041,1,'Tiana','Kotek','Machle',215),(1042,1,'Sherlyn','Ellifritz','Sidwell',215),(1043,4,'Toshiko','Powley','Miga',216),(1044,5,'Long','Affeltranger','Lackie',216),(1045,6,'Sergio','Coarsey','Murnan',216),(1046,2,'Elmo','Denni','Kinnaman',216),(1047,4,'Sheron','Reicks','Weinman',217),(1048,5,'Elvis','Bassano','Morar',217),(1049,6,'Thanh','Mikelson','Rise',217),(1050,2,'Rupert','Sangalli','Willier',217),(1051,2,'Ernesto','Szeto','Shappell',217),(1052,4,'Valeria','Catalanotto','Cullens',218),(1053,5,'Derick','Goines','Vilello',218),(1054,6,'Aaron','Youkanaa','Banta',218),(1055,2,'Royce','Latting','Eledge',218),(1056,4,'Wesley','Mongolo','Delerme',219),(1057,5,'Hung','Verdiguel','Ledyard',219),(1058,6,'Jerrell','Voeks','Guzowski',219),(1059,2,'Jefferey','Brezinka','Tirone',219),(1060,4,'Cheryle','Malo','Dougher',220),(1061,5,'Clinton','Delosier','Desamparo',220),(1062,6,'Scotty','Glab','Stankiewicz',220),(1063,2,'Oliver','Rehfeld','Newbraugh',220),(1064,2,'Jasper','Guecho','Lohden',220),(1065,2,'Jim','Mazzariello','Readenour',220),(1066,4,'Elnora','Oudker','Johnke',221),(1067,5,'Freddie','Cassetty','Reppucci',221),(1068,6,'Carter','Tille','Elieff',221),(1069,1,'Daria','Shallcross','Loudermilk',221),(1070,1,'Wesley','Muller','Tripoli',221),(1071,4,'Bette','Zank','Jetty',222),(1072,5,'Raymon','Wittenborn','Turnblom',222),(1073,6,'Lenard','Bounleut','Meginnes',222),(1074,1,'Georgeann','Gillon','Morando',222),(1075,1,'Francis','Trethewey','Nothstein',222),(1076,4,'Herta','Theurer','Mcquiston',223),(1077,5,'Aldo','Lame','Tenbusch',223),(1078,6,'Lino','Sieracki','Bouret',223),(1079,2,'Derick','Poppo','Frenner',223),(1080,4,'Sasha','Sepeda','Champa',224),(1081,5,'Rolf','Lawery','Gordo',224),(1082,6,'Devin','Wunner','Stump',224),(1083,2,'Mckinley','Kortkamp','Gosser',224),(1084,4,'Stephenie','Martinolli','Brletich',225),(1085,5,'Guadalupe','Spalla','Hennard',225),(1086,6,'Boyd','Frakes','Lovenduski',225),(1087,2,'Freddie','Smallidge','Oki',225),(1088,2,'Clyde','Kohnert','Hammill',225),(1089,2,'Darell','Dez','Culliver',225),(1090,4,'Sallie','Swiney','Hoon',226),(1091,5,'Jospeh','Creach','Hendrick',226),(1092,6,'Marcos','Stinar','Adriano',226),(1093,1,'Kristan','Cuther','Soren',226),(1094,1,'Tori','Shreeve','Horoschak',226),(1095,4,'Mitzie','Schmeidler','Whitehill',227),(1096,5,'Hollis','Beauprez','Lagle',227),(1097,6,'Kenton','Sawer','Renderos',227),(1098,1,'Tai','Sertuche','Shullick',227),(1099,1,'Salome','Angelone','Franz',227),(1100,1,'Zana','Mallon','Damron',227),(1101,4,'Roslyn','Stratos','Onofre',228),(1102,5,'Jefferey','Hape','Sparger',228),(1103,6,'Raleigh','Rudlong','Virostko',228),(1104,1,'Fredda','Benham','Wittrup',228),(1105,4,'Marget','Nienhuis','Gettys',229),(1106,5,'Zachery','Coach','Sigmon',229),(1107,6,'Humberto','Mattes','Surprise',229),(1108,2,'Jon','Kebe','Kokoszka',229),(1109,2,'Howard','Coronel','Easly',229),(1110,4,'Maria','Tencer','Ober',230),(1111,5,'Ferdinand','Naysmith','Lauridsen',230),(1112,6,'Pat','Royea','Faren',230),(1113,2,'Jesus','Dail','Fincham',230),(1114,2,'Jayson','Knoble','Bazata',230),(1115,4,'Kindra','Saults','Ramberg',231),(1116,5,'Palmer','Wiggington','Mostowy',231),(1117,6,'Hobert','Zerhusen','Vanoni',231),(1118,2,'Bert','Cappetta','Aiken',231),(1119,2,'Homer','Cushingberry','Mcchristion',231),(1120,4,'Suzann','Gonnella','Devier',232),(1121,5,'Jacques','Llewlyn','Lazaro',232),(1122,6,'Shelton','Parzych','Spring',232),(1123,1,'Magali','Nani','Wesely',232),(1124,1,'Alina','Sinclaire','Herforth',232),(1125,4,'Etsuko','Bruyere','Rindels',233),(1126,5,'Lou','Magliacane','Vee',233),(1127,6,'Devin','Dolak','Blevins',233),(1128,2,'Aldo','Salinas','Schmoyer',233),(1129,4,'Emelda','Misenti','Rovira',234),(1130,5,'Josh','Carne','Lied',234),(1131,6,'Rosario','Ebesu','Leiferman',234),(1132,1,'Abbey','Duker','Consiglio',234),(1133,4,'Erna','Cintora','Sario',235),(1134,5,'Derek','Predom','Gesick',235),(1135,6,'Neville','Pavelich','Mielcarek',235),(1136,1,'Delta','Maggi','Hopkin',235),(1137,1,'Marti','Ragle','Vermette',235),(1138,4,'Jennie','Scipioni','Forkell',236),(1139,5,'Sherman','Espina','Bjorgen',236),(1140,6,'Rudy','Pillot','Englade',236),(1141,1,'Katrina','Vampa','Deanes',236),(1142,1,'Colene','Rattell','Salminen',236),(1143,1,'Sherlyn','Guilfoil','Frankhouser',236),(1144,4,'Tori','Hornandez','Brosh',237),(1145,5,'Darin','Mews','Arnow',237),(1146,6,'Robbie','Renshaw','Hollifield',237),(1147,2,'Myles','Lohrke','Pullian',237),(1148,2,'Oscar','Zaic','Adamitis',237),(1149,2,'Daren','Synowiec','Schwertner',237),(1150,4,'Delorse','Mumaugh','Pluemer',238),(1151,5,'Teddy','Villata','Amiot',238),(1152,6,'Joel','Papp','Fanno',238),(1153,2,'Ignacio','Raggs','Wittlin',238),(1154,4,'Kanesha','Sagers','Radosevich',239),(1155,5,'Michale','Emel','Moenius',239),(1156,6,'Stevie','Shazier','Thady',239),(1157,1,'Maribel','Nicholls','Closter',239),(1158,4,'Lekisha','Bayless','Medina',240),(1159,5,'Jamaal','Lantaff','Hoblit',240),(1160,6,'Barney','Stubblefield','Goodwine',240),(1161,2,'Wes','Monterrosa','Falcone',240),(1162,2,'Donovan','Bicklein','Kimbel',240),(1163,4,'Hilda','Coodey','Yetto',241),(1164,5,'Alonzo','Flournoy','Kachel',241),(1165,6,'Delmar','Hemmingsen','Heinzen',241),(1166,2,'Prince','Lauterbach','Dunklin',241),(1167,2,'Scot','Bordwine','Amparan',241),(1168,4,'Zetta','Necaise','Garcias',242),(1169,5,'Hosea','Letko','Vardeman',242),(1170,6,'Hubert','Polakis','Copenhaver',242),(1171,2,'Chet','Landacre','Moronta',242),(1172,2,'Gavin','Akbar','Shingleur',242),(1173,4,'Rosetta','Bierut','Har',243),(1174,5,'Raul','Laverdure','Tody',243),(1175,6,'Clarence','Bertog','Surkamer',243),(1176,1,'Orpha','Heavin','Lashbrook',243),(1177,1,'Aundrea','Drungo','Hefferan',243),(1178,4,'Luis','Castrogiovann','Sachtleben',244),(1179,5,'Zack','Rehnquist','Gurwell',244),(1180,6,'Edward','Mallet','Jupiter',244),(1181,1,'Jeana','Minix','Stjuste',244),(1182,1,'Dawn','Vanetten','Neidig',244),(1183,4,'Collene','Proenza','Hunsinger',245),(1184,5,'Cleo','Lathim','Keagle',245),(1185,6,'Les','Kreinhagen','Gitzen',245),(1186,2,'Rory','Panico','Highley',245),(1187,4,'Ardelia','Diddle','Strimling',246),(1188,5,'Raleigh','Blattel','Terstage',246),(1189,6,'Brent','Drisdelle','Colson',246),(1190,1,'Vernice','Moorhead','Hoefflin',246),(1191,1,'Madison','Benwell','Reech',246),(1192,1,'Felicia','Lelli','Randle',246),(1193,4,'Ginny','Mannick','Vizcarra',247),(1194,5,'Palmer','Mesrobian','Stiliner',247),(1195,6,'Maxwell','Ashing','Danchetz',247),(1196,1,'Vicenta','Seling','Shufford',247),(1197,1,'Zelma','Panias','Cutcher',247),(1198,1,'Austin','Esty','Snide',247),(1199,4,'Doris','Therrell','Kruse',248),(1200,5,'Jacques','Merkl','Stehle',248),(1201,6,'Max','Slatter','Pestano',248),(1202,2,'Darrel','Paganini','Ramsier',248),(1203,4,'Laila','Macisaac','Carragher',249),(1204,5,'Lino','Godard','Otero',249),(1205,6,'Renato','Farbman','Scriber',249),(1206,1,'Carlene','Thompkins','Wyles',249),(1207,1,'Franchesca','Gaetani','Myntti',249),(1208,4,'Nancie','Mcgaha','Searing',250),(1209,5,'Kasey','Speers','Passarelli',250),(1210,6,'Jesus','Muzacz','Hoylton',250),(1211,1,'Rosie','Marez','Emmert',250),(1212,1,'Katlyn','Gagnon','Robeck',250),(1213,4,'Allyn','Spevacek','Ronnfeldt',251),(1214,5,'Virgil','Lefevers','Nebergall',251),(1215,6,'Bobby','Loker','Cristina',251),(1216,1,'Tillie','Burkard','Saindon',251),(1217,4,'Rheba','Lessey','Ihrig',252),(1218,5,'Willy','Andon','Nattiah',252),(1219,6,'Enoch','Szocki','Dibartolo',252),(1220,1,'Shandra','Sand','Hollinghurst',252),(1221,1,'Carmel','Halstrom','Harcourt',252),(1222,4,'Manuela','Mclay','Gravit',253),(1223,5,'Jeremiah','Knestrick','Faggins',253),(1224,6,'Jerry','Noonon','Salvaggio',253),(1225,2,'Demarcus','Tinlin','Swicegood',253),(1226,4,'Tisa','Ginns','Farm',254),(1227,5,'Earle','Schoemaker','Lutkus',254),(1228,6,'Markus','Mccaddon','Trabert',254),(1229,1,'Hassie','Leyra','Kijek',254),(1230,1,'Noriko','Lapenta','Hiestand',254),(1231,4,'Bethel','Gusky','Propp',255),(1232,5,'Fritz','Heroth','Byon',255),(1233,6,'Marcel','Swarner','Arya',255),(1234,2,'Marty','Schweiger','Londo',255),(1235,2,'Hunter','Tropp','Casamento',255),(1236,2,'Carter','Diffenderfer','Endris',255),(1237,4,'Krishna','Brickman','Naderi',256),(1238,5,'Royal','Delgreco','Averitte',256),(1239,6,'Hobert','Nakamoto','Kanta',256),(1240,2,'Manual','Daleske','Such',256),(1241,4,'Magali','Buetow','Arcadipane',257),(1242,5,'Jess','Dullen','Ptacek',257),(1243,6,'Mauro','Smutz','Wilbers',257),(1244,1,'Annie','Donerson','Osher',257),(1245,1,'Malorie','Wittenberg','Viscera',257),(1246,1,'Willow','Defrance','Precella',257),(1247,4,'Jolanda','Shatzer','Ohs',258),(1248,5,'Alfonso','Pieroni','Points',258),(1249,6,'Barney','Favor','Garnes',258),(1250,2,'Andrew','Stlouise','Siegfried',258),(1251,4,'Loan','Smigaj','Tibbits',259),(1252,5,'Branden','Hieb','Bitterman',259),(1253,6,'Moshe','Rayne','Picasso',259),(1254,2,'Lowell','Marxen','Sirmon',259),(1255,2,'Dane','Drader','Lovisone',259),(1256,4,'Joslyn','Hildred','Manygoats',260),(1257,5,'Marshall','Rusak','Boever',260),(1258,6,'Ike','Macknight','Sovie',260),(1259,2,'Jacques','Brignoni','Dinius',260),(1260,4,'Yi','Cashwell','Kocieda',261),(1261,5,'Randal','Egland','Flitton',261),(1262,6,'Humberto','Brohl','Kalloch',261),(1263,2,'Danny','Tirri','Maalouf',261),(1264,2,'Filiberto','Campagna','Thibeau',261),(1265,4,'Billye','Geanopulos','Waldren',262),(1266,5,'Keith','Pingrey','Mcilroy',262),(1267,6,'Derick','Tuell','Huxford',262),(1268,1,'Magali','Wolfer','Pruneau',262),(1269,1,'Kara','Gerosa','Sare',262),(1270,1,'Malika','Hogstrum','Gammons',262),(1271,4,'Chiquita','Llarena','Stehle',263),(1272,5,'Amado','Depaolo','Sages',263),(1273,6,'Damon','Krantz','Bynoe',263),(1274,1,'Deloris','Syphers','Holst',263),(1275,1,'Ewa','Marso','Lanosa',263),(1276,4,'Lissette','Riopelle','Luersen',264),(1277,5,'Jerald','Welti','Kanekuni',264),(1278,6,'Weldon','Mcgill','Moede',264),(1279,2,'Filiberto','Koes','Tastet',264),(1280,4,'Lenna','Ridgnal','Resch',265),(1281,5,'Sammie','Beath','Duhart',265),(1282,6,'Ronald','Ehler','Papen',265),(1283,1,'Caryl','Swatloski','Forstner',265),(1284,4,'Erma','Monnerjahn','Petersdorf',266),(1285,5,'Mario','Kiedrowski','Radsky',266),(1286,6,'Charley','Bindrup','Leavenworth',266),(1287,2,'Leonard','Mccarroll','Mainello',266),(1288,2,'Delbert','Miolen','Sackey',266),(1289,2,'Brock','Jeppson','Mautner',266),(1290,4,'Ruth','Gauntt','Poissant',267),(1291,5,'Aldo','Dolhon','Boyack',267),(1292,6,'Wilton','Shiro','Hauptmann',267),(1293,1,'Olga','Erskine','Cheslock',267),(1294,4,'Cherrie','Barthe','Fulginiti',268),(1295,5,'Javier','Baldridge','Daniello',268),(1296,6,'Gerry','Donald','Izaquirre',268),(1297,2,'Ezekiel','Teece','Pi',268),(1298,2,'Mel','Fillip','Delucian',268),(1299,2,'Rufus','Majestic','Bebo',268),(1300,4,'Donna','Blannon','Retek',269),(1301,5,'Glenn','Gooch','Dillenburg',269),(1302,6,'Alfonzo','Boyes','Chrispen',269),(1303,2,'Walton','Osentowski','Buonaiuto',269),(1304,4,'Shirley','Gasquet','Crossno',270),(1305,5,'Kenneth','Mondo','Rauscher',270),(1306,6,'Alan','Ficklin','Carback',270),(1307,1,'Miriam','Terzo','Gennusa',270),(1308,4,'Darlene','Morningstar','Bourdages',271),(1309,5,'Everett','Rahaim','Vogds',271),(1310,6,'Walker','Sonkens','Bitzel',271),(1311,2,'Jasper','Okray','Faso',271),(1312,4,'Cassy','Delrossi','Kuchta',272),(1313,5,'Pedro','Sanschagrin','Hagar',272),(1314,6,'Clinton','Mattioli','Frever',272),(1315,2,'Derek','Holibaugh','Philipose',272),(1316,2,'Alan','Compau','Tasma',272),(1317,4,'Cheryll','Naclerio','Murdough',273),(1318,5,'Merlin','Milledge','Bockrath',273),(1319,6,'Tory','Humason','Lain',273),(1320,2,'Donnie','Laakso','Duncomb',273),(1321,2,'Tyson','Chaleun','Nelles',273),(1322,4,'Corene','Bergenstock','Simoson',274),(1323,5,'Chi','Stegeman','Naborg',274),(1324,6,'Mack','Martinell','Holje',274),(1325,1,'Brenna','Madigan','Kammerer',274),(1326,4,'Marg','Mccubbins','Ostberg',275),(1327,5,'Lincoln','Cahue','Fannon',275),(1328,6,'Ike','Baccouche','Mastalski',275),(1329,2,'Mickey','Ollivier','Moussette',275),(1330,2,'Erwin','Koh','Adamaitis',275),(1331,2,'Tony','Orozco','Mattiace',275),(1332,4,'Edyth','Jaeschke','Carey',276),(1333,5,'Rodolfo','Rushiti','Conlans',276),(1334,6,'Hassan','Glendenning','Ramroop',276),(1335,1,'Nam','Posada','Able',276),(1336,1,'Jammie','Franzi','Meager',276),(1337,1,'Jennie','Cassaro','Mcgahan',276),(1338,4,'Roseanna','Keidong','Zarlengo',277),(1339,5,'Kenton','Chowansky','Saville',277),(1340,6,'Marcel','Bulla','Wienecke',277),(1341,2,'Cristopher','Sala','Hasbrouck',277),(1342,2,'Erick','Candon','Cheffer',277),(1343,4,'Rosena','Maffia','Eleby',278),(1344,5,'Amado','Calverley','Lembke',278),(1345,6,'Salvatore','Broyles','Gutenberger',278),(1346,2,'Connie','Harvey','Oyster',278),(1347,2,'Tony','Haynes','Arrizola',278),(1348,4,'Flora','Hagele','Frizzell',279),(1349,5,'Trenton','Champ','Kath',279),(1350,6,'Tracy','Homme','Crager',279),(1351,1,'Leda','Blakes','Privado',279),(1352,1,'Melony','Vieweg','Lenius',279),(1353,1,'Lara','Yerry','Bezner',279),(1354,4,'Ressie','Serafin','Bullinger',280),(1355,5,'Hubert','Stmichel','Nida',280),(1356,6,'Jasper','Eske','Spradley',280),(1357,2,'Bryce','Rohs','Muzacz',280),(1358,2,'Shaun','Longbottom','Rounsville',280),(1359,2,'Kristofer','Makowski','Creecy',280),(1360,4,'Jenice','Shabot','Mohn',281),(1361,5,'Ervin','Zaremski','Mile',281),(1362,6,'Donnie','Lojek','Starrett',281),(1363,2,'Alfonso','Sansoucy','Cookerly',281),(1364,2,'Renaldo','Duley','Javor',281),(1365,4,'Bea','Ellingwood','Bohman',282),(1366,5,'Terrence','Minero','Prately',282),(1367,6,'Coy','Kernagis','Jerko',282),(1368,2,'Bradford','Ordaz','Whitney',282),(1369,4,'Mitzi','Vinciguerra','Cuny',283),(1370,5,'Theo','Sidell','Lyford',283),(1371,6,'Ramiro','Coopage','Eiesland',283),(1372,1,'Pamila','Lunger','Wheeles',283),(1373,1,'Takisha','Dahlberg','Wozny',283),(1374,1,'Erica','Sibgert','Allemand',283),(1375,4,'Malvina','Broenneke','Hucks',284),(1376,5,'Wes','Cammack','Buentello',284),(1377,6,'Kim','Bugos','Tewani',284),(1378,2,'Israel','Vient','Gerardo',284),(1379,2,'Alva','Petrina','Dana',284),(1380,4,'Merri','Zahran','Wrenn',285),(1381,5,'Sid','Klafehn','Pangallo',285),(1382,6,'Landon','Rosencranz','Boushie',285),(1383,1,'Milagro','Seguin','Pounds',285),(1384,1,'Malka','Gip','Cosca',285),(1385,1,'Laila','Moher','Weinkauf',285),(1386,4,'Chiquita','Binienda','Sitt',286),(1387,5,'Marlon','Demonett','Journot',286),(1388,6,'Freddie','Laumeyer','Killmer',286),(1389,2,'Forrest','Mcgeady','Lukens',286),(1390,2,'Waldo','Hovick','Surratt',286),(1391,4,'Hsiu','Kollmeyer','Rossano',287),(1392,5,'Alexis','Mcphearson','Mulvahill',287),(1393,6,'Edmund','Sowers','Hodges',287),(1394,1,'Lynsey','Reigner','Dvorsky',287),(1395,1,'Betsey','Gercak','Schuessler',287),(1396,4,'Aimee','Whary','Hedding',288),(1397,5,'Kevin','Hyberger','Schriner',288),(1398,6,'Dante','Figg','Olgin',288),(1399,2,'Edmund','Matushevsky','Raybould',288),(1400,2,'Sammie','Pizzulo','Irizarry',288),(1401,4,'Rosalinda','Beighley','Manis',289),(1402,5,'Will','Frack','Nwankwo',289),(1403,6,'Tomas','Ket','Luallen',289),(1404,2,'Ian','Jimmison','Harkema',289),(1405,4,'Renay','Pinera','Michna',290),(1406,5,'Hosea','Dipasquale','Mosqueda',290),(1407,6,'Malcolm','Rummans','Annicchiarico',290),(1408,1,'Gennie','Wimpy','Platas',290),(1409,4,'Georgette','Muenkel','Kaawa',291),(1410,5,'Jaime','Burvine','Hillebrand',291),(1411,6,'Jake','Haskett','Ettinger',291),(1412,1,'Tiffani','Shampine','Tinucci',291),(1413,1,'Valentine','Redeker','Liveoak',291),(1414,4,'Tammie','Delangel','Monterroso',292),(1415,5,'Mac','Tinner','Chelton',292),(1416,6,'Roderick','Killary','Braver',292),(1417,1,'Myrna','Goud','Wannarka',292),(1418,4,'Ivette','Doelling','Maderas',293),(1419,5,'Aaron','Dampier','Eitniear',293),(1420,6,'Richard','Hurley','Viscardi',293),(1421,2,'Stephan','Koshiol','Savini',293),(1422,2,'Renato','Skyers','Goodhart',293),(1423,4,'Marylou','Weishaupt','Pross',294),(1424,5,'Elden','Crose','Belmonte',294),(1425,6,'Randal','Brashear','Lentine',294),(1426,2,'Markus','Klare','Flood',294),(1427,2,'Abram','Suchla','Eroman',294),(1428,2,'Bo','Lammie','Lagoni',294),(1429,4,'Francoise','Hamnon','Strachan',295),(1430,5,'Oliver','Baron','Brandler',295),(1431,6,'Antony','Pair','Vaughn',295),(1432,2,'Angel','Cheser','Hustace',295),(1433,4,'Karine','Backstrom','Holdridge',296),(1434,5,'Alexis','Blasco','Dong',296),(1435,6,'Lonny','Vauters','Demar',296),(1436,1,'Shyla','Lerud','Pezina',296),(1437,1,'Elizbeth','Abercrombie','Poto',296),(1438,4,'Lilia','Kisor','Affeld',297),(1439,5,'Gilbert','Ajello','Sampieri',297),(1440,6,'Isiah','Litt','Pechar',297),(1441,2,'Lawrence','Flament','Ellingsen',297),(1442,4,'Stacey','Balcorta','Hazelhurst',298),(1443,5,'Alva','Caldarella','Toft',298),(1444,6,'Edward','Risden','Pandolfi',298),(1445,1,'Rowena','Dinizio','Gaboriault',298),(1446,1,'Shavonda','Legnon','Pitpitan',298),(1447,4,'Verlie','Mullinix','Solarzano',299),(1448,5,'Michale','Seybold','Chiappetta',299),(1449,6,'Florencio','Ammons','Nanda',299),(1450,2,'Shaun','Colony','Galic',299),(1451,4,'Pamila','Gatchalian','Marrujo',300),(1452,5,'Efrain','Castellow','Balasko',300),(1453,6,'Mario','Mackert','Norment',300),(1454,2,'Zachariah','Olwin','Coerver',300),(1455,4,'Winter','Mcentyre','Riemer',301),(1456,5,'Lucas','Carothers','Chopelas',301),(1457,6,'Roland','Ragain','Chaidy',301),(1458,2,'Denny','Hof','Lepre',301),(1459,4,'Stella','Dellaripa','Gershon',302),(1460,5,'Chang','Sanda','Leyra',302),(1461,6,'Wilton','Hawrylak','Liljenquist',302),(1462,2,'Rickey','Froehle','Huddy',302),(1463,4,'Lupita','Egelhoff','Bussert',303),(1464,5,'Zachary','Laszlo','Langreck',303),(1465,6,'Rick','Ible','Wall',303),(1466,2,'Mohammad','Koeninger','Schoemer',303),(1467,4,'Easter','Lauretta','Hickey',304),(1468,5,'Lane','Earing','Olano',304),(1469,6,'Virgil','Diestel','Bustad',304),(1470,1,'Elmer','Deare','Eighmy',304),(1471,4,'Erna','Graleski','Villar',305),(1472,5,'Travis','Otteman','Chaviano',305),(1473,6,'Oren','Schreiner','Kilness',305),(1474,2,'Willy','Fosnaugh','Allie',305),(1475,2,'Carl','Roskovensky','Venturino',305),(1476,2,'William','Bertrand','Fennell',305),(1477,4,'Mariella','Polvino','Wasmus',306),(1478,5,'Dalton','Trover','Weill',306),(1479,6,'Agustin','Kizzie','Troxler',306),(1480,1,'Azalee','Sher','Orvis',306),(1481,1,'Peter','Coin','Scranton',306),(1482,1,'Magan','Oathout','Rummage',306),(1483,4,'Katheleen','Falso','Stufflebeam',307),(1484,5,'Waldo','Garding','Feezor',307),(1485,6,'Morton','Karban','Rainey',307),(1486,1,'Michell','Caulder','Vieira',307),(1487,1,'Olga','Tedford','Gillund',307),(1488,1,'Lurlene','Driessen','Taintor',307),(1489,4,'Erlinda','Huntoon','Guiterrez',308),(1490,5,'Jaime','Ideue','Rimm',308),(1491,6,'Josef','Haruta','Blumenberg',308),(1492,1,'Alvera','Medler','Lozaya',308),(1493,1,'Roslyn','Stelmach','Carinio',308),(1494,4,'Khadijah','Campany','Outlaw',309),(1495,5,'Chester','Patik','Mcelravy',309),(1496,6,'Mickey','Vaughn','Towlson',309),(1497,2,'Bennie','Somerset','Stford',309),(1498,2,'Quincy','Contee','Gugliotti',309),(1499,4,'Candance','Harrow','Hatstat',310),(1500,5,'Ivory','Shukla','Bartlone',310),(1501,6,'Mario','Balaam','Pottebaum',310),(1502,1,'Holley','Harington','Boundy',310),(1503,1,'Stacia','Truslow','Miracle',310),(1504,4,'Lucile','Donivan','Kaczynski',311),(1505,5,'Sammie','Herendeen','Bellemy',311),(1506,6,'Marty','Cunniff','Szitar',311),(1507,2,'Lee','Higuchi','Kleinschmidt',311),(1508,2,'Royal','Stoeber','Chauvin',311),(1509,4,'Lue','Jackett','First',312),(1510,5,'Thurman','Obermiller','Marlene',312),(1511,6,'Isidro','Augspurger','Ammons',312),(1512,1,'Sang','Zoldak','Frische',312),(1513,4,'Cyndi','Detty','Fayne',313),(1514,5,'Scot','Magby','Burleigh',313),(1515,6,'Michal','Pfander','Coby',313),(1516,2,'Garfield','Cancio','Rundquist',313),(1517,2,'Darwin','Vorwaller','Spurlin',313),(1518,4,'Charleen','Magone','Warp',314),(1519,5,'Matt','Sasportas','Maxfield',314),(1520,6,'Joey','Robusto','Abdin',314),(1521,1,'Florence','Byan','Yamagata',314),(1522,1,'Latricia','Braband','Brandolini',314),(1523,4,'Kelsey','Worstel','Forsthoffer',315),(1524,5,'Lucius','Shaban','Sifre',315),(1525,6,'Dwight','Scholes','Maciak',315),(1526,2,'Marcos','Westpfahl','Medin',315),(1527,2,'Chadwick','Roussell','Briden',315),(1528,4,'Blanch','Celedon','Soulliere',316),(1529,5,'Theo','Alcivar','Harouff',316),(1530,6,'Percy','Petkus','Dsouza',316),(1531,1,'Leigh','Michniak','Quintana',316),(1532,1,'Andra','Baranowski','Devereaux',316),(1533,4,'Michelle','Filler','Wiltse',317),(1534,5,'Aldo','Mellberg','Fie',317),(1535,6,'Lucas','Zieglen','Wieloch',317),(1536,2,'Lupe','Mullenaux','Bittinger',317),(1537,2,'Keenan','Scialdone','Schecter',317),(1538,2,'Stacy','Wayts','Calabretta',317),(1539,4,'Lavenia','Belyoussian','Miene',318),(1540,5,'Donte','Garriott','Capetl',318),(1541,6,'Kenneth','Komlos','Scsarpisnato',318),(1542,1,'Apolonia','Cucinella','Gadbury',318),(1543,1,'Claribel','Botterbusch','Eckelman',318),(1544,4,'Georgiana','Saab','Buckaloo',319),(1545,5,'Terrell','Difrancisco','Yuenger',319),(1546,6,'Pete','Paulik','Vanwyck',319),(1547,1,'Lilian','Mcilroy','Ridpath',319),(1548,1,'Evelyn','Reedholm','Casada',319),(1549,1,'Leone','Mackimmie','Michniak',319),(1550,4,'Phylis','Lout','Sipes',320),(1551,5,'Russ','Tarlton','Lapoint',320),(1552,6,'Dave','Eischeid','Mavity',320),(1553,1,'Esta','Sczbecki','Greninger',320),(1554,4,'Cindi','Jahoda','Scolieri',321),(1555,5,'Valentin','Juarbe','Qureshi',321),(1556,6,'Edwardo','Tuberman','Taray',321),(1557,2,'Erasmo','Hosier','Santilli',321),(1558,2,'Louis','Ariaza','Kartman',321),(1559,2,'Clyde','Ehrenberg','Lazzeri',321),(1560,4,'Toby','Geres','Pullen',322),(1561,5,'Bennett','Cerreta','Debernardi',322),(1562,6,'Fredrick','Foxworthy','Carlisle',322),(1563,1,'Cathleen','Peteuil','Tartt',322),(1564,1,'Caterina','Sept','Bokman',322),(1565,4,'Ione','Sien','Matousek',323),(1566,5,'Jimmy','Navan','Kounthapanya',323),(1567,6,'Keenan','Seara','Sturdy',323),(1568,2,'Lanny','Hedemann','Tosches',323),(1569,2,'Andre','Yendell','Hardridge',323),(1570,2,'Herb','Fabel','Danner',323),(1571,4,'Kanesha','Busa','Hunsaker',324),(1572,5,'Tracy','Dufrene','Osegueda',324),(1573,6,'Young','Rousey','Malagon',324),(1574,1,'Darla','Hangartner','Wongus',324),(1575,1,'Beaulah','Bogucki','Detrick',324),(1576,4,'Renita','Perks','Halima',325),(1577,5,'Virgilio','Kopps','Sabad',325),(1578,6,'Trey','Gogocha','Groskreutz',325),(1579,1,'Irma','Juckett','Byker',325),(1580,4,'Carlene','Hean','Vincent',326),(1581,5,'Keven','Abajian','Kasack',326),(1582,6,'Jacinto','Mausser','Olliver',326),(1583,1,'Angelita','Raveling','Borlin',326),(1584,4,'Farrah','Boulds','Ziedan',327),(1585,5,'Francisco','Lamudio','Rosencrans',327),(1586,6,'Donny','Secrease','Alamillo',327);
/*!40000 ALTER TABLE `dependents` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dutydetails`
--

LOCK TABLES `dutydetails` WRITE;
/*!40000 ALTER TABLE `dutydetails` DISABLE KEYS */;
INSERT INTO `dutydetails` VALUES (1,1,01,00,'AM',10,00,'AM',1,0,0,0,0,0,0,1);
/*!40000 ALTER TABLE `dutydetails` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `guards`
--

LOCK TABLES `guards` WRITE;
/*!40000 ALTER TABLE `guards` DISABLE KEYS */;
INSERT INTO `guards` VALUES (1,'Kendra','Villa','Garcia',2,'7/2/1991',2,'5 11','105 kg.','Protestant',1,'+63 586 878 3991','212-7719.','09-5378006-4','09-5378006-4','203-122-508','24-540287196-7','Rockwell Automation Inc',NULL,2,NULL,NULL,'Lemuel Mazar','09405624067'),(2,'Hattie','Casado','Gonzalez',2,'6/4/1980',2,'5 11','78 kg.','Roman Catholic',1,'+63 788 161 8748','212-8973.','09-1775070-8','09-1775070-8','958-607-584','40-672857162-5','RGS Energy Group Inc',NULL,3,NULL,NULL,'Garry Kiester','09686067754'),(3,'Theresia','Martinez','Rodriguez',2,'3/6/1992',2,'5 11','117 kg.','Protestant',1,'+63 580 453 9509','212-6936.','09-5748648-8','09-5748648-8','239-442-534','53-581327423-1','National Commerce Financial Corporation',NULL,2,NULL,NULL,'Max Wicketts','09626704938'),(4,'Marcella','Mateo','Fernandez',2,'8/4/1977',2,'5 11','75 kg.','Islam',1,'+63 412 302 3661','212-5678.','09-2454578-3','09-2454578-3','235-940-804','80-943195172-7','Lands\' End Inc.',NULL,3,NULL,NULL,'Delbert Guidice','09165311571'),(5,'Ericka','Salvador','Lopez',2,'4/2/1991',2,'5 11','116 kg.','Islam',1,'+63 647 260 2888','212-4672.','09-2006950-3','09-2006950-3','132-828-295','68-433279276-4','Equity Office Properties Trust',NULL,3,NULL,NULL,'Abram Hemsley','09461684688'),(6,'Shawnna','Sosa','Martinez',2,'7/25/1983',2,'5 11','115 kg.','Islam',1,'+63 766 563 6908','212-9973.','09-4544495-4','09-4544495-4','266-598-707','48-509458184-7','Cadence Design Systems, Inc.',NULL,3,NULL,NULL,'Wilfredo Gromer','09222739828'),(7,'Margherita','Herrero','Sanchez',2,'3/24/1973',2,'5 11','109 kg.','Islam',1,'+63 151 392 5188','212-1432.','09-3056529-7','09-3056529-7','726-983-304','24-136793825-0','Safeguard Scientifics Inc.',NULL,3,NULL,NULL,'Dave Gaertner','09284157901'),(8,'Zenaida','Moreno','Perez',2,'9/2/1987',2,'5 11','81 kg.','Islam',1,'+63 708 996 8626','212-4752.','09-6964795-3','09-6964795-3','982-153-113','28-490058937-7','Maxtor Corporation',NULL,3,NULL,NULL,'Lorenzo Turell','09504477967'),(9,'Cassandra','Carmona','Gomez',2,'10/12/1979',2,'5 11','95 kg.','Roman Catholic',1,'+63 847 692 4655','212-6578.','09-8289724-6','09-8289724-6','902-859-823','25-977481916-5','Oxford Health Plans Inc',NULL,3,NULL,NULL,'Darrel Brookskennedy','09227688352'),(10,'Vallie','Rivero','Acosta',2,'8/11/1997',2,'5 11','110 kg.','Protestant',1,'+63 238 763 2970','212-2524.','09-1918522-2','09-1918522-2','892-701-873','48-403237383-4','DST Systems, Inc.',NULL,3,NULL,NULL,'Tyson Stagner','09727327143'),(11,'Allyn','Roman','Jimenez',2,'9/22/1991',2,'5 11','94 kg.','Protestant',1,'+63 617 358 6034','212-4821.','09-3503636-0','09-3503636-0','795-443-538','27-159590832-5','Walt Disney Co',NULL,3,NULL,NULL,'Isidro Batterson','09698655975'),(12,'Margert','Amador','Ruiz',2,'7/23/1990',2,'5 11','88 kg.','Protestant',1,'+63 158 682 2415','212-7486.','09-7714008-0','09-7714008-0','123-250-125','23-631430801-1','Louisiana-Pacific Corporation',NULL,3,NULL,NULL,'Garry Imbriale','09785629135'),(13,'Erlinda','Varela','Hernandez',2,'4/12/1979',2,'5 11','94 kg.','Protestant',1,'+63 133 298 9239','212-6740.','09-2260641-4','09-2260641-4','858-514-160','94-372421726-4','Host Marriott Corp.',NULL,3,NULL,NULL,'Jaime Faggett','09162910599'),(14,'Lavada','Marrero','Diaz',2,'2/17/1987',2,'5 11','93 kg.','Roman Catholic',1,'+63 389 741 2020','212-3928.','09-7664973-1','09-7664973-1','288-331-807','37-332684716-5','Pathmark Stores Inc.',NULL,2,NULL,NULL,'Edgar Cambell','09528568870'),(15,'Malisa','Bernal','Moreno',2,'11/16/1979',2,'5 11','86 kg.','Islam',1,'+63 346 277 2221','212-7887.','09-2438548-6','09-2438548-6','988-577-177','92-325478457-0','Ames Department Stores, Inc.',NULL,3,NULL,NULL,'Jack Barela','09947996967'),(16,'Aileen','Estevez','Alvarez',2,'2/27/1997',2,'5 11','114 kg.','Islam',1,'+63 242 544 3721','212-3463.','09-3299259-4','09-3299259-4','885-271-868','20-145092461-0','Advance Auto Parts, Inc.',NULL,2,NULL,NULL,'Antonia Hernanders','09310312528'),(17,'Jhepoy','Velazquez','Agoncillo',2,'1/13/1988',1,'5 11','116 kg.','Islam',1,'+63 801 861 5170','212-5197.','09-3370159-1','09-3370159-1','276-602-324','74-673666410-4','Linens \'n Things Inc.',NULL,2,NULL,NULL,'Richard Holcomb','09118698173'),(18,'Quyen','Avila','Romero',2,'11/10/1994',1,'5 11','108 kg.','Protestant',1,'+63 465 435 8136','212-6587.','09-5027254-4','09-5027254-4','912-764-256','12-149785201-4','Unified Western Grocers Inc',NULL,2,NULL,NULL,'Napoleon Inglin','09715072301'),(19,'Carman','Esteve','Alonso',2,'10/18/1974',1,'5 11','78 kg.','Islam',1,'+63 223 872 9624','212-4533.','09-3077852-7','09-3077852-7','688-500-646','41-639927274-2','H.B. Fuller Company',NULL,2,NULL,NULL,'Elden Venuto','09173246690'),(20,'Leatha','Quesada','Gutierrez',2,'11/19/1983',2,'5 11','83 kg.','Islam',1,'+63 542 447 2954','212-1846.','09-9632238-3','09-9632238-3','810-487-192','65-733193270-0','Centex Corp.',NULL,2,NULL,NULL,'Omer Earehart','09884024124'),(21,'Sana','Barroso','Navarro',2,'5/19/1994',1,'5 11','77 kg.','Protestant',1,'+63 173 932 5627','212-3114.','09-9770285-0','09-9770285-0','281-807-591','53-665819171-2','Crompton Corp.',NULL,3,NULL,NULL,'Rudy Hausauer','09843931759'),(22,'Mellissa','Alarcon','Torres',2,'5/12/1985',2,'5 11','91 kg.','Roman Catholic',1,'+63 344 513 8890','212-8719.','09-4206881-4','09-4206881-4','544-252-978','54-671227514-1','State Street Corp.',NULL,2,NULL,NULL,'Roland Frederick','09564009026'),(23,'Jaquelyn','Camara','Dominguez',2,'11/12/1994',2,'5 11','101 kg.','Islam',1,'+63 491 580 3923','212-8128.','09-7156113-3','09-7156113-3','502-306-156','60-722540566-0','Markel Corporation',NULL,2,NULL,NULL,'Manual Larabel','09874605845'),(24,'Elaine','Carrasco','Vazquez',2,'8/15/1972',2,'5 11','108 kg.','Roman Catholic',1,'+63 664 354 7140','212-5390.','09-1577692-1','09-1577692-1','890-702-156','80-368162362-4','Snap-On Inc',NULL,3,NULL,NULL,'Valentin Lanini','09338637867'),(25,'Maris','Contreras','Ramos',2,'11/18/1994',2,'5 11','104 kg.','Roman Catholic',1,'+63 406 423 6437','212-6116.','09-5596949-5','09-5596949-5','550-369-272','49-348525268-4','Boston Scientific Corporation',NULL,2,NULL,NULL,'Fritz Delatorre','09189458641'),(26,'Signe','Paredes','Gil',2,'10/5/1996',1,'5 11','96 kg.','Protestant',1,'+63 387 772 8777','212-5644.','09-1580210-0','09-1580210-0','516-200-668','89-651034603-1','Dell Computer Corporation',NULL,2,NULL,NULL,'Francisco Nakamoto','09641666146'),(27,'Joana','Fuentes','Ramirez',2,'6/22/1979',2,'5 11','103 kg.','Islam',1,'+63 293 604 9473','212-3170.','09-3018801-7','09-3018801-7','309-365-588','93-398139547-4','Alleghany Corporation',NULL,2,NULL,NULL,'Berry Zabielski','09744881029'),(28,'Sena','Moran','Serrano',2,'6/3/1973',2,'5 11','90 kg.','Roman Catholic',1,'+63 130 980 4047','212-1652.','09-2391945-8','09-2391945-8','927-839-151','95-922134370-3','Pharmacia Corp',NULL,2,NULL,NULL,'Otha Coulthard','09971253998'),(29,'Reynalda','Garcia','Blanco',2,'7/9/1973',2,'5 11','108 kg.','Protestant',1,'+63 460 201 2843','212-9134.','09-5796047-2','09-5796047-2','575-202-697','17-711369506-2','Ceridian Corp.',NULL,2,NULL,NULL,'Keenan Siskind','09521724882'),(30,'Waneta','Tomas','Suarez',2,'10/15/1978',2,'5 11','106 kg.','Roman Catholic',1,'+63 294 420 5939','212-2729.','09-8631964-5','09-8631964-5','327-716-789','91-320887270-8','Sierra Pacific Resources',NULL,2,NULL,NULL,'Clayton Laven','09219335471'),(31,'Ricki','Riera','Molina',2,'3/6/1979',1,'5 11','78 kg.','Islam',1,'+63 981 689 4566','212-4127.','09-3472923-4','09-3472923-4','365-868-734','18-880281782-5','StanCorp Financial Group Inc',NULL,2,NULL,NULL,'Omer Dreier','09780383623'),(32,'Perry','Montoya','Morales',2,'9/22/1973',1,'5 11','100 kg.','Protestant',1,'+63 276 745 2980','212-2638.','09-3380731-8','09-3380731-8','303-230-452','43-694520801-7','John Hancock Financial Services Inc.',NULL,3,NULL,NULL,'Jerrell Vollucci','09367104239'),(33,'Emilia','Domenech','Ortega',2,'8/15/1987',2,'5 11','113 kg.','Roman Catholic',1,'+63 332 949 1676','212-3839.','09-9893865-4','09-9893865-4','236-496-467','56-205464893-3','NSTAR',NULL,2,NULL,NULL,'Coleman Blackmoore','09971228065'),(34,'Beatriz','Ponce','Delgado',2,'4/2/1990',2,'5 11','102 kg.','Roman Catholic',1,'+63 839 283 4259','212-6454.','09-3863301-3','09-3863301-3','363-348-360','69-137207426-6','US Oncology Inc',NULL,3,NULL,NULL,'Zachary Jungers','09850236271'),(35,'Candy','Andreu','Castro',2,'5/1/1994',2,'5 11','78 kg.','Protestant',1,'+63 292 483 8037','212-1343.','09-4515148-5','09-4515148-5','921-738-554','28-868706234-4','Dean Foods Company',NULL,2,NULL,NULL,'Lemuel Heimerl','09948642560'),(36,'Ernestine','Quintana','Ortiz',2,'8/16/1997',2,'5 11','103 kg.','Islam',1,'+63 929 439 8089','212-6206.','09-6949635-7','09-6949635-7','712-550-568','53-281795907-4','DQE Inc.',NULL,3,NULL,NULL,'Garfield Desanto','09597641129'),(37,'Irma','Alvarez','Rubio',2,'10/12/1995',2,'5 11','76 kg.','Roman Catholic',1,'+63 667 441 8467','212-7919.','09-7655628-0','09-7655628-0','135-832-947','69-227940479-0','Berkshire Hathaway Inc.',NULL,2,NULL,NULL,'Kasey Alvernaz','09790688480'),(38,'Evia','Moral','Marin',2,'2/9/1978',2,'5 11','102 kg.','Roman Catholic',1,'+63 826 565 3171','212-6733.','09-8575622-4','09-8575622-4','267-283-694','36-777493909-7','Vectren Corporation',NULL,3,NULL,NULL,'Eloy Gropper','09556316665'),(39,'Salley','Santiago','Sanz',2,'11/24/1996',2,'5 11','105 kg.','Protestant',1,'+63 236 133 1151','212-4627.','09-2762661-6','09-2762661-6','808-313-219','84-593972821-1','Black Hills Corporation',NULL,3,NULL,NULL,'Normand Angelo','09678510871'),(40,'Jay-ar','Santos','Arcinas',2,'3/27/1984',1,'5 11','90 kg.','Islam',1,'+63 434 798 4664','212-3076.','09-7838544-8','09-7838544-8','997-498-316','70-259755521-4','Georgia Gulf Corporation',NULL,2,NULL,NULL,'Terrence Fickle','09490793267'),(41,'Laurice','Pozo','Iglesias',2,'1/25/1986',2,'5 11','116 kg.','Protestant',1,'+63 196 616 5685','212-3432.','09-4431185-5','09-4431185-5','863-766-982','67-465225882-1','Stanley Works',NULL,3,NULL,NULL,'Mckinley Cardoza','09612974015'),(42,'Ashton','Polo','Medina',2,'7/3/1986',1,'5 11','114 kg.','Islam',1,'+63 169 222 6731','212-4467.','09-8356721-3','09-8356721-3','904-544-691','44-218783046-4','Target Corp.',NULL,3,NULL,NULL,'Hosea Vanscoter','09229868705'),(43,'Keren','Llorente','Garrido',2,'3/7/1974',2,'5 11','92 kg.','Islam',1,'+63 343 663 9511','212-5847.','09-6646558-7','09-6646558-7','856-495-400','72-165899727-5','Reliance Steel & Aluminum Co.',NULL,2,NULL,NULL,'Brice Horsch','09149553130'),(44,'Alba','Escobar','Santos',2,'6/24/1979',2,'5 11','97 kg.','Protestant',1,'+63 680 137 3950','212-2939.','09-5686937-6','09-5686937-6','850-249-774','35-670486826-1','M & T Bank Corporation',NULL,2,NULL,NULL,'Royce Steinhoff','09976305972'),(45,'Mike','Ballesteros','Castillo',2,'8/21/1975',1,'5 11','115 kg.','Roman Catholic',1,'+63 709 633 8105','212-1048.','09-1416901-6','09-1416901-6','888-857-528','93-553207745-6','Toys \'R\' Us Inc',NULL,3,NULL,NULL,'Jackson Seacord','09344307089'),(46,'Berna','Dominguez','Cortes',2,'11/13/1972',2,'5 11','103 kg.','Protestant',1,'+63 636 904 9214','212-1006.','09-3703372-5','09-3703372-5','633-520-302','37-625192334-6','Charter One Financial Inc.',NULL,2,NULL,NULL,'Ferdinand Keneally','09861599331'),(47,'Antoinette','Vazquez','Lozano',2,'7/5/1992',2,'5 11','103 kg.','Roman Catholic',1,'+63 942 341 4174','212-6089.','09-4832964-6','09-4832964-6','844-239-621','83-301322796-6','CNF Inc.',NULL,2,NULL,NULL,'Jayson Macnaught','09311885089'),(48,'Araceli','Dela Cruz','Guerrero',2,'8/24/1992',2,'5 11','115 kg.','Protestant',1,'+63 764 131 7633','212-3163.','09-3561055-5','09-3561055-5','133-500-178','51-942159794-8','The Lubrizol Corporation',NULL,3,NULL,NULL,'Sebastian Donavan','09357244085'),(49,'Joni','Hernando','Cano',2,'7/14/1988',1,'5 11','119 kg.','Roman Catholic',1,'+63 883 503 2648','212-8003.','09-2573601-3','09-2573601-3','658-476-400','53-715538007-8','Circuit City Stores Inc.',NULL,3,NULL,NULL,'Weston Lessor','09986327013'),(50,'Carman','Mora','Prieto',2,'8/8/1980',1,'5 11','98 kg.','Islam',1,'+63 840 255 7841','212-5514.','09-3983528-8','09-3983528-8','244-209-762','14-586055419-5','Sports Authority Inc',NULL,3,NULL,NULL,'Charley Golida','09372365535'),(51,'Sybil','Heredia','Mendez',2,'6/11/1973',1,'5 11','118 kg.','Protestant',1,'+63 914 564 5710','212-3974.','09-4529323-2','09-4529323-2','568-638-552','34-204980747-4','Newmont Mining Corporation',NULL,3,NULL,NULL,'Winfred Gerdeman','09277217301'),(52,'Janina','Dela Fuente','Calvo',2,'8/5/1979',2,'5 11','77 kg.','Roman Catholic',1,'+63 375 350 6792','212-9179.','09-5530805-8','09-5530805-8','227-201-411','55-806814913-4','NTL Incorporated',NULL,2,NULL,NULL,'Anton Caufield','09316007735'),(53,'Mee','Silva','Cruz',2,'7/13/1987',1,'5 11','109 kg.','Islam',1,'+63 349 650 4547','212-6442.','09-3868311-0','09-3868311-0','811-244-484','38-398976682-1','Gemstar-TV Guide International Inc.',NULL,2,NULL,NULL,'Weston Salatino','09373191990'),(54,'Chloe','Aragon','Gallego',2,'5/4/1994',2,'5 11','97 kg.','Protestant',1,'+63 558 667 9712','212-2233.','09-1364188-3','09-1364188-3','698-410-272','53-861886284-7','Public Service Enterprise Group Inc.',NULL,2,NULL,NULL,'Trenton Zullo','09549087573'),(55,'Betsey','Cortes','Vidal',2,'5/16/1987',2,'5 11','78 kg.','Protestant',1,'+63 746 125 4844','212-1753.','09-8415775-2','09-8415775-2','879-542-902','86-624543997-2','Staples Inc',NULL,3,NULL,NULL,'Robin Meneus','09440886980'),(56,'Ricki','Dela Cruz','Leon',2,'11/21/1987',1,'5 11','78 kg.','Islam',1,'+63 459 781 1940','212-2898.','09-4128258-8','09-4128258-8','401-916-371','71-948785832-6','Temple-Inland Inc',NULL,3,NULL,NULL,'Jayson Friedman','09731807757'),(57,'Clelia','Herrera','Herrera',2,'9/11/1996',1,'5 11','94 kg.','Protestant',1,'+63 646 970 9186','212-4391.','09-6365381-0','09-6365381-0','672-879-411','54-706572854-3','International Paper Co.',NULL,3,NULL,NULL,'Arnulfo Cool','09587805415'),(58,'Dinah','Velasco','Marquez',2,'4/8/1980',2,'5 11','95 kg.','Roman Catholic',1,'+63 414 308 8749','212-4274.','09-9946378-3','09-9946378-3','949-677-253','50-329218642-4','New Jersey Resources Corporation',NULL,2,NULL,NULL,'Glenn Hartsook','09680823065'),(59,'Charleen','Vallejo','Ang',2,'7/8/1981',2,'5 11','100 kg.','Islam',1,'+63 165 960 9322','212-7999.','09-2380467-6','09-2380467-6','366-940-221','38-983821380-7','Fidelity National Financial Inc.',NULL,2,NULL,NULL,'Ignacio Rylant','09211164847'),(60,'Lucille','Cano','Cabrera',2,'8/26/1988',2,'5 11','108 kg.','Islam',1,'+63 487 689 7010','212-4144.','09-6807313-6','09-6807313-6','883-587-222','35-165733283-1','Albertson\'s, Inc.',NULL,3,NULL,NULL,'Hollis Kedia','09814044152'),(61,'Catheryn','Marti','Flores',2,'7/8/1997',2,'5 11','81 kg.','Islam',1,'+63 855 783 9283','212-9531.','09-2372518-7','09-2372518-7','125-749-380','41-987854859-0','Champion Enterprises Inc.',NULL,3,NULL,NULL,'Rickey Wanda','09849362382'),(62,'Emelda','Roca','Campos',2,'7/25/1987',2,'5 11','89 kg.','Islam',1,'+63 904 875 5116','212-5878.','09-6287564-2','09-6287564-2','437-625-362','73-236869106-3','Comcast Corp.',NULL,3,NULL,NULL,'Terrell Baumgarten','09492801046'),(63,'Dixie','Caceres','Vega',2,'11/11/1980',1,'5 11','115 kg.','Protestant',1,'+63 698 483 7902','212-4554.','09-4903348-4','09-4903348-4','621-483-337','72-430596963-0','Atmos Energy Corporation',NULL,3,NULL,NULL,'Adrian Kopiasz','09374166460'),(64,'Lyla','Gallego','Diez',2,'10/25/1988',2,'5 11','83 kg.','Islam',1,'+63 721 473 3678','212-9160.','09-9457851-8','09-9457851-8','905-820-763','40-193195996-8','AdvancePCS, Inc.',NULL,3,NULL,NULL,'Brice Kluender','09308269830'),(65,'Maryln','Sola','Fuentes',2,'5/21/1994',2,'5 11','117 kg.','Islam',1,'+63 770 443 5334','212-1050.','09-1625257-1','09-1625257-1','432-274-228','48-618439830-6','Pitney Bowes Inc.',NULL,2,NULL,NULL,'Drew Ricke','09202169095'),(66,'Mabelle','Galvez','Carrasco',2,'3/6/1980',2,'5 11','92 kg.','Protestant',1,'+63 894 982 5865','212-7962.','09-9628949-4','09-9628949-4','616-967-924','59-989536503-3','Paccar Inc',NULL,2,NULL,NULL,'Jimmy Spurling','09948641287'),(67,'Trisha','Oliver','Caballero',2,'5/27/1990',2,'5 11','92 kg.','Protestant',1,'+63 271 140 2303','212-6380.','09-6648918-8','09-6648918-8','780-521-582','53-845855823-5','Harley-Davidson Inc.',NULL,2,NULL,NULL,'Randal Hohney','09121675898'),(68,'Jennette','Castillo','Nieto',2,'1/20/1979',2,'5 11','111 kg.','Protestant',1,'+63 393 300 4020','212-6514.','09-5326808-0','09-5326808-0','957-561-978','55-897387213-6','Tesoro Petroleum Corp.',NULL,2,NULL,NULL,'Daren Stach','09713173619'),(69,'Pansy','Blasco','Reyes',2,'5/12/1986',2,'5 11','93 kg.','Roman Catholic',1,'+63 166 979 8319','212-5423.','09-8738310-3','09-8738310-3','282-766-970','65-489711590-8','Banta Corporation',NULL,2,NULL,NULL,'Marcel Seger','09193726147'),(70,'Ena','Carbonell','Aguilar',2,'8/15/1994',2,'5 11','91 kg.','Roman Catholic',1,'+63 600 421 5471','212-2182.','09-4018567-2','09-4018567-2','234-620-294','42-561234841-1','Pepsi Bottling Group Inc.',NULL,2,NULL,NULL,'Jesse Maden','09828602411'),(71,'Marietta','Cuevas','Pascual',2,'2/2/1976',2,'5 11','112 kg.','Protestant',1,'+63 413 837 7331','212-4624.','09-9903475-1','09-9903475-1','150-407-154','11-484038784-1','Hillenbrand Industries Inc.',NULL,3,NULL,NULL,'Andrew Caldarone','09619770955'),(72,'Rossana','Vidal','Herrero',2,'8/9/1978',2,'5 11','106 kg.','Roman Catholic',1,'+63 282 490 4077','212-8683.','09-5944993-6','09-5944993-6','182-814-876','68-742429048-5','Avnet, Inc.',NULL,3,NULL,NULL,'Lenard Roessler','09930605919'),(73,'Palma','Moya','Santana',2,'8/4/1972',1,'5 11','100 kg.','Protestant',1,'+63 334 788 3443','212-1448.','09-6268915-6','09-6268915-6','563-383-472','88-403113096-1','USG Corporation',NULL,2,NULL,NULL,'Dean Kerson','09323318746'),(74,'Loan','Prieto','Lorenzo',2,'1/7/1986',1,'5 11','96 kg.','Roman Catholic',1,'+63 962 821 6770','212-9888.','09-3134520-8','09-3134520-8','994-469-876','27-907811643-7','Milacron Inc.',NULL,3,NULL,NULL,'Efren Moors','09841596386'),(75,'Clarita','Bosch','Hidalgo',2,'2/9/1992',2,'5 11','103 kg.','Roman Catholic',1,'+63 788 112 1193','212-7698.','09-3450012-1','09-3450012-1','261-477-405','76-766588223-4','Commercial Metals Co.',NULL,3,NULL,NULL,'Xavier Pendry','09728247795'),(76,'Latina','Carretero','Montero',2,'11/4/1972',2,'5 11','94 kg.','Islam',1,'+63 234 632 3109','212-2037.','09-5565652-6','09-5565652-6','271-356-371','14-121429075-3','Georgia Gulf Corporation',NULL,2,NULL,NULL,'Gus Muckelvaney','09252471870'),(77,'Tori','Camacho','Buencamino',2,'8/4/1979',2,'5 11','75 kg.','Protestant',1,'+63 755 303 7483','212-1511.','09-8734729-0','09-8734729-0','607-739-528','92-610212254-5','Kellogg Company',NULL,3,NULL,NULL,'Carol Aslinger','09556324376'),(78,'Frances','Calero','Gimenez',2,'4/2/1983',2,'5 11','117 kg.','Protestant',1,'+63 461 459 2510','212-2476.','09-6580272-0','09-6580272-0','897-964-142','30-716291339-5','Dreyer\'s Grand Ice Cream, Inc.',NULL,3,NULL,NULL,'Rocco Simoniello','09494861667'),(79,'Laci','Bravo','Ferrer',2,'8/21/1972',1,'5 11','75 kg.','Protestant',1,'+63 186 874 2607','212-2685.','09-3418289-3','09-3418289-3','991-475-949','68-503533967-2','Walgreen Co',NULL,3,NULL,NULL,'Douglass Urguhart','09990964767'),(80,'Lachelle','Castilla','Duran',2,'5/2/1996',2,'5 11','98 kg.','Roman Catholic',1,'+63 277 586 2668','212-8970.','09-6637818-4','09-6637818-4','804-332-731','33-382473930-2','Sears Roebuck & Co',NULL,3,NULL,NULL,'Hoyt Ratel','09188096712'),(81,'Tegan','Diaz','Vicente',2,'10/15/1995',1,'5 11','108 kg.','Roman Catholic',1,'+63 469 288 3872','212-6545.','09-1904065-3','09-1904065-3','894-439-381','97-946075726-3','Benchmark Electronics, Inc.',NULL,2,NULL,NULL,'Ron Fuchs','09768561131'),(82,'Georgia','Juarez','Benitez',2,'10/23/1986',2,'5 11','85 kg.','Islam',1,'+63 236 906 6114','212-9750.','09-4876036-0','09-4876036-0','521-146-136','74-357964379-5','MPS Group Inc.',NULL,3,NULL,NULL,'Toby Ticer','09317763296'),(83,'Alix','Calderon','Mora',2,'2/27/1986',1,'5 11','78 kg.','Protestant',1,'+63 294 732 6185','212-6080.','09-5556950-7','09-5556950-7','489-599-925','31-955946117-3','Amgen Inc.',NULL,3,NULL,NULL,'Rocco Brantner','09965771527'),(84,'Beverlee','Villalba','Santiago',2,'10/25/1982',2,'5 11','80 kg.','Roman Catholic',1,'+63 699 355 1919','212-5075.','09-3529252-7','09-3529252-7','196-873-116','53-258888289-2','Countrywide Credit Industries Inc.',NULL,2,NULL,NULL,'Scottie Celius','09242716058'),(85,'Rosalia','Mendoza','Arias',2,'4/10/1989',2,'5 11','108 kg.','Roman Catholic',1,'+63 787 299 9523','212-1352.','09-4986295-6','09-4986295-6','855-850-582','34-178076138-5','Progressive Corporation',NULL,2,NULL,NULL,'Manual Jhonston','09861774314'),(86,'Monica','Trujillo','Vargas',2,'11/21/1976',1,'5 11','85 kg.','Islam',1,'+63 686 917 9419','212-3021.','09-6362623-8','09-6362623-8','675-292-581','57-420853265-2','Berkshire Hathaway Inc.',NULL,3,NULL,NULL,'Kendrick Tonrey','09301614698'),(87,'Clotilde','Carrera','Carmona',2,'4/11/1991',2,'5 11','77 kg.','Roman Catholic',1,'+63 689 141 6543','212-9850.','09-5573533-1','09-5573533-1','347-839-247','28-256459452-1','Peoples Energy Corp.',NULL,3,NULL,NULL,'Roy Zenisek','09556655409'),(88,'Kera','Vila','Crespo',2,'4/5/1989',2,'5 11','102 kg.','Protestant',1,'+63 799 253 6113','212-2916.','09-5622645-1','09-5622645-1','986-775-446','18-739278500-7','Dollar Tree Stores, Inc.',NULL,3,NULL,NULL,'Logan Schaal','09315488113'),(89,'Katharina','Torres','Roman',2,'9/22/1991',2,'5 11','114 kg.','Roman Catholic',1,'+63 815 142 3490','212-5332.','09-2750104-0','09-2750104-0','272-690-565','31-337305923-3','Equifax Inc.',NULL,3,NULL,NULL,'Arnoldo Dubis','09210455304'),(90,'Kimiko','Roldan','Pastor',2,'2/27/1993',1,'5 11','80 kg.','Protestant',1,'+63 587 226 7883','212-8558.','09-4638277-6','09-4638277-6','240-340-337','81-236444775-1','Scientific-Atlanta Inc',NULL,3,NULL,NULL,'Alvin Iennaco','09677653242'),(91,'Bobbye','De la Cerna','Soto',2,'1/2/1986',1,'5 11','118 kg.','Islam',1,'+63 613 695 6113','212-3667.','09-2738637-2','09-2738637-2','197-830-670','66-398017327-8','Carpenter Technology Corp.',NULL,2,NULL,NULL,'Connie Livengood','09578896953'),(92,'Freeda','Leal','Saez',2,'3/26/1986',2,'5 11','96 kg.','Roman Catholic',1,'+63 173 516 8781','212-4586.','09-9275300-3','09-9275300-3','836-543-342','44-732981604-6','Barnes & Noble, Inc.',NULL,3,NULL,NULL,'Chadwick Cippina','09746368019'),(93,'Belinda','Salgado','Velasco',2,'7/26/1981',2,'5 11','100 kg.','Roman Catholic',1,'+63 877 791 6751','212-8981.','09-8290420-4','09-8290420-4','495-457-494','89-710836299-3','Shaw Group Inc',NULL,3,NULL,NULL,'Royal Inferrera','09830313384'),(94,'Micheline','Font','Soler',2,'2/5/1996',2,'5 11','115 kg.','Roman Catholic',1,'+63 989 392 7844','212-7686.','09-6749639-6','09-6749639-6','357-788-258','11-755787298-2','Carpenter Technology Corp.',NULL,3,NULL,NULL,'Garfield Belding','09860792554'),(95,'Isabelle','Rojas','Moya',2,'11/25/1975',2,'5 11','93 kg.','Roman Catholic',1,'+63 256 417 6330','212-7954.','09-2796884-7','09-2796884-7','872-430-417','11-728410664-6','Milacron Inc.',NULL,3,NULL,NULL,'Antony Pavey','09808403613'),(96,'Yolando','Marin','Esteban',2,'9/12/1997',1,'5 11','90 kg.','Roman Catholic',1,'+63 768 825 4323','212-3059.','09-4008833-0','09-4008833-0','162-329-936','86-566718581-4','NTL Incorporated',NULL,3,NULL,NULL,'Raymon Fillerup','09251942425'),(97,'Lavada','Menendez','Parra',2,'8/10/1974',2,'5 11','116 kg.','Roman Catholic',1,'+63 936 232 3083','212-1383.','09-6040451-7','09-6040451-7','824-660-549','53-834172553-2','Apple Computer, Inc.',NULL,2,NULL,NULL,'Herman Haglund','09883273298'),(98,'Florene','Lazaro','Bravo',2,'1/8/1979',2,'5 11','118 kg.','Protestant',1,'+63 604 976 4051','212-1971.','09-6069248-6','09-6069248-6','379-566-665','55-716743354-1','Johnson Controls Inc.',NULL,3,NULL,NULL,'Fred Donis','09303836714'),(99,'Teressa','Casas','Gallardo',2,'6/27/1995',2,'5 11','119 kg.','Roman Catholic',1,'+63 245 203 4390','212-1223.','09-2137890-2','09-2137890-2','486-673-715','87-531175604-3','Anheuser-Busch Companies, Inc.',NULL,3,NULL,NULL,'Anton Manglona','09400993612'),(100,'Nicolasa','Santamaria','Rojas',2,'5/26/1972',2,'5 11','78 kg.','Islam',1,'+63 411 785 5168','212-2151.','09-6552966-8','09-6552966-8','928-526-699','95-638984163-6','Rockwell Automation Inc',NULL,3,NULL,NULL,'Tommy Schlussel','09211397114'),(101,'Lynda','Medina','Pardo',2,'10/22/1972',2,'5 11','76 kg.','Islam',1,'+63 624 180 1596','212-6975.','09-5221134-7','09-5221134-7','384-119-955','21-594742130-5','HCA Inc.',NULL,2,NULL,NULL,'Bo Petrilli','09449687632'),(102,'Maude','Merino','Merino',2,'11/20/1973',2,'5 11','119 kg.','Protestant',1,'+63 951 475 2158','212-3645.','09-1461904-5','09-1461904-5','206-771-365','26-283726670-0','Eastman Chemical Company',NULL,2,NULL,NULL,'Larry Ballesteros','09558110539'),(103,'Libby','Naranjo','Franco',2,'5/5/1996',2,'5 11','87 kg.','Protestant',1,'+63 864 245 4472','212-3134.','09-2403565-5','09-2403565-5','638-471-374','73-351630842-5','Frontier Oil Corp',NULL,2,NULL,NULL,'Gino Sakamaki','09441944245'),(104,'Maile','Campos','Espinosa',2,'5/22/1981',2,'5 11','98 kg.','Islam',1,'+63 844 454 6290','212-8078.','09-2799327-6','09-2799327-6','384-851-244','79-609073401-6','Tektronix Inc',NULL,3,NULL,NULL,'Delbert Cichosz','09626328630'),(105,'Wendy','Aranda','Izquierdo',2,'5/2/1993',2,'5 11','81 kg.','Protestant',1,'+63 471 240 2027','212-8526.','09-6085243-7','09-6085243-7','832-933-357','47-290709898-6','Nordstrom Inc',NULL,3,NULL,NULL,'Ryan Mayette','09883056667'),(106,'Ronna','Pelaez','Lara',2,'9/12/1980',2,'5 11','89 kg.','Protestant',1,'+63 842 634 6645','212-5875.','09-3368092-8','09-3368092-8','398-122-969','14-683932028-3','Constellation Emergy Group Inc.',NULL,3,NULL,NULL,'Bernie Colonnese','09405555547'),(107,'Floretta','Ramos','Rivas',2,'6/21/1995',2,'5 11','91 kg.','Islam',1,'+63 159 282 2695','212-6532.','09-7636513-7','09-7636513-7','676-388-883','22-514378673-5','Watsco Inc',NULL,2,NULL,NULL,'Hung Dember','09464507454'),(108,'Candace','Gimeno','Silva',2,'10/25/1988',2,'5 11','89 kg.','Roman Catholic',1,'+63 217 806 1918','212-9676.','09-3865201-5','09-3865201-5','409-391-969','30-382957333-1','The Clorox Co.',NULL,3,NULL,NULL,'Mike Costin','09912651720'),(109,'Rufina','De','Rivera',2,'7/25/1981',2,'5 11','92 kg.','Roman Catholic',1,'+63 905 964 9094','212-9822.','09-6836567-2','09-6836567-2','118-234-208','71-513664846-7','Spherion Corp',NULL,3,NULL,NULL,'Marshall Hollar','09918110865'),(110,'Demetrius','Exposito','Casado',2,'11/21/1976',1,'5 11','75 kg.','Roman Catholic',1,'+63 794 746 6808','212-6137.','09-4947824-1','09-4947824-1','319-670-863','13-277698535-8','Visteon Corporation',NULL,2,NULL,NULL,'Curt Sang','09246356941'),(111,'Tianna','Lopez','Arroyo',2,'6/17/1987',2,'5 11','97 kg.','Protestant',1,'+63 132 265 9002','212-1625.','09-9649361-7','09-9649361-7','510-448-406','30-485134023-0','Bowater Incorporated',NULL,3,NULL,NULL,'Charley Freil','09391372418'),(112,'Annabelle','Mata','Redondo',2,'11/9/1994',2,'5 11','92 kg.','Islam',1,'+63 452 462 8212','212-6859.','09-3522135-7','09-3522135-7','267-360-575','83-831940453-7','Black Hills Corporation',NULL,3,NULL,NULL,'Pat Hulette','09901339298'),(113,'Maragaret','Pañares','Camacho',2,'4/26/1986',2,'5 11','114 kg.','Roman Catholic',1,'+63 309 988 2742','212-5991.','09-8506333-0','09-8506333-0','275-918-207','51-511938042-8','U.S. Industries Inc.',NULL,2,NULL,NULL,'Tad Hovis','09666354493'),(114,'Arnette','Rio','Rey',2,'3/9/1978',2,'5 11','75 kg.','Roman Catholic',1,'+63 171 151 9598','212-5066.','09-9313989-8','09-9313989-8','750-778-761','65-380741226-0','Amerada Hess Corporation',NULL,2,NULL,NULL,'Odis Hornig','09413744452'),(115,'Brittany','Padilla','Vera',2,'6/13/1980',2,'5 11','111 kg.','Roman Catholic',1,'+63 281 719 4856','212-4111.','09-1900406-4','09-1900406-4','682-944-381','71-591959470-2','Hughes Supply Inc.',NULL,3,NULL,NULL,'Rickie Hindin','09196408853'),(116,'Monique','Montes','Otero',2,'6/2/1995',2,'5 11','81 kg.','Islam',1,'+63 987 684 5763','212-6017.','09-7865761-2','09-7865761-2','563-871-338','64-123008052-7','Standard Pacific Corp.',NULL,3,NULL,NULL,'Luther Yeung','09696677129'),(117,'Caryl','Sanchez','Luque',2,'5/12/1986',2,'5 11','87 kg.','Islam',1,'+63 783 843 2414','212-2927.','09-2659989-5','09-2659989-5','751-197-874','37-291197815-8','Jabil Circuit Inc.',NULL,2,NULL,NULL,'Peter Waldall','09122133891'),(118,'Louetta','Hurtado','Galan',2,'2/19/1996',2,'5 11','101 kg.','Protestant',1,'+63 270 607 4836','212-2553.','09-8026413-3','09-8026413-3','878-462-378','97-570938217-8','FPL Group Inc.',NULL,3,NULL,NULL,'Ward Pistorius','09286623777'),(119,'Alice','Olivares','Montes',2,'1/10/1972',2,'5 11','93 kg.','Roman Catholic',1,'+63 934 895 1193','212-8320.','09-6290338-7','09-6290338-7','507-383-625','87-486850466-1','JDS Uniphase Corp.',NULL,3,NULL,NULL,'Hayden Adrovel','09458272438'),(120,'Delicia','Jimenez','Rios',2,'6/4/1988',2,'5 11','103 kg.','Roman Catholic',1,'+63 573 702 3442','212-3285.','09-2885009-8','09-2885009-8','661-962-191','44-493000626-2','Caremark Rx Inc.',NULL,2,NULL,NULL,'Jack Reginal','09206926411'),(121,'Clara','Reyes','Sierra',2,'2/5/1996',2,'5 11','83 kg.','Islam',1,'+63 875 759 7247','212-1359.','09-1742539-4','09-1742539-4','768-275-908','71-592556967-8','BB&T Corporation',NULL,3,NULL,NULL,'Mack Brumm','09126183192'),(122,'Kirstie','Villanueva','Segura',2,'8/19/1979',2,'5 11','109 kg.','Islam',1,'+63 775 129 2951','212-5060.','09-6172057-6','09-6172057-6','743-360-481','97-249097160-7','Jefferson-Pilot Co.',NULL,2,NULL,NULL,'Adrian Maendel','09330899412'),(123,'Joanne','Neri','Carrillo',2,'6/27/1983',2,'5 11','92 kg.','Islam',1,'+63 313 859 5601','212-9600.','09-8781376-8','09-8781376-8','904-726-903','87-511238457-7','BMC Software, Inc.',NULL,3,NULL,NULL,'Abraham Webre','09574441820'),(124,'Taren','Salinas','Marcos',2,'3/20/1981',2,'5 11','94 kg.','Protestant',1,'+63 611 946 2238','212-3476.','09-5666775-3','09-5666775-3','374-694-656','28-818692783-8','Brown Shoe Company, Inc.',NULL,2,NULL,NULL,'Donald Starley','09224089562'),(125,'Cody','Nieto','Marti',2,'3/10/1973',1,'5 11','119 kg.','Protestant',1,'+63 482 311 7014','212-4500.','09-5558202-4','09-5558202-4','436-184-326','63-986791423-0','Toys \'R\' Us Inc',NULL,2,NULL,NULL,'Bradford Delmoro','09574865116'),(126,'Lashon','Garrido','Soriano',2,'10/1/1988',1,'5 11','106 kg.','Protestant',1,'+63 913 159 7641','212-8780.','09-1828048-5','09-1828048-5','359-501-743','27-911572354-5','Maxxam Inc.',NULL,3,NULL,NULL,'Titus Spoden','09540820634'),(127,'Eugenia','Cuesta','Mendoza',2,'3/25/1975',2,'5 11','89 kg.','Roman Catholic',1,'+63 278 359 2283','212-7024.','09-3929495-7','09-3929495-7','307-418-663','29-712331242-2','Nike Inc',NULL,2,NULL,NULL,'Douglass Louria','09845805145'),(128,'Kiersten','Cabrera','Robles',2,'1/9/1974',2,'5 11','88 kg.','Roman Catholic',1,'+63 168 848 5643','212-1060.','09-7987877-7','09-7987877-7','656-529-515','46-498756724-2','Marriott International Inc.',NULL,2,NULL,NULL,'Santo Verdino','09246015976'),(129,'Vernice','Gutierrez','Bernal',2,'2/27/1992',2,'5 11','92 kg.','Roman Catholic',1,'+63 516 398 6476','212-6644.','09-4553542-7','09-4553542-7','171-272-860','54-790036068-3','Primedia Inc',NULL,2,NULL,NULL,'Dalton Hauff','09915039760'),(130,'Jolanda','Pascual','Vila',2,'6/13/1991',2,'5 11','110 kg.','Protestant',1,'+63 504 378 6462','212-7260.','09-5869192-1','09-5869192-1','123-419-399','76-974350504-0','Gannett Co., Inc.',NULL,2,NULL,NULL,'Jamar Mcneary','09277451349'),(131,'Venita','Blanco','Valero',2,'8/7/1988',2,'5 11','114 kg.','Roman Catholic',1,'+63 887 944 2951','212-9409.','09-3072575-5','09-3072575-5','368-161-878','81-705541197-2','First American Financial Corp.',NULL,3,NULL,NULL,'Oren Dambrosia','09864084385'),(132,'Valentina','Collado','Palacios',2,'3/2/1982',2,'5 11','112 kg.','Protestant',1,'+63 712 295 1588','212-1516.','09-4626408-0','09-4626408-0','686-814-834','52-764882822-1','Levi Strauss & Co.',NULL,2,NULL,NULL,'Marlin Dagraca','09424582772'),(133,'Penny','Alfonso','Exposito',2,'3/19/1985',2,'5 11','118 kg.','Islam',1,'+63 750 670 2499','212-5649.','09-2849631-4','09-2849631-4','565-937-307','57-536468717-7','PNM Resources Inc',NULL,2,NULL,NULL,'Jeramy Bratten','09444306052'),(134,'Betsey','Correa','Benito',2,'2/16/1996',2,'5 11','94 kg.','Islam',1,'+63 497 850 2251','212-5070.','09-1619979-1','09-1619979-1','147-183-251','27-402715481-0','Sports Authority Inc',NULL,2,NULL,NULL,'Waylon Massoni','09609075135'),(135,'Maryam','Gomez','Andres',2,'10/10/1987',2,'5 11','92 kg.','Protestant',1,'+63 162 299 2183','212-1950.','09-5091356-2','09-5091356-2','575-940-124','52-720213506-3','Allegheny Energy, Inc.',NULL,2,NULL,NULL,'Lanny Orsak','09968586673'),(136,'Glynis','Izquierdo','Varela',2,'1/11/1997',2,'5 11','89 kg.','Roman Catholic',1,'+63 655 389 9297','212-9073.','09-7173986-7','09-7173986-7','732-316-739','40-819521026-6','Great Plains Energy Inc.',NULL,3,NULL,NULL,'Bo Carrus','09335185470'),(137,'Louetta','Franco','Pereira',2,'4/8/1987',2,'5 11','108 kg.','Islam',1,'+63 683 581 3701','212-4971.','09-6359202-3','09-6359202-3','356-667-889','74-616675629-2','Sempra Energy',NULL,2,NULL,NULL,'Robert Accardi','09504754279'),(138,'Alta','Rey','Macias',2,'4/26/1983',2,'5 11','97 kg.','Protestant',1,'+63 280 406 8297','212-5567.','09-3858397-2','09-3858397-2','200-687-713','25-270424216-6','Hub Group Inc.',NULL,2,NULL,NULL,'Dale Villarin','09929309490'),(139,'Phylis','Rosa','Guerra',2,'8/3/1977',2,'5 11','91 kg.','Islam',1,'+63 197 380 4021','212-2817.','09-2675682-7','09-2675682-7','622-530-942','76-366392241-4','Avon Products, Inc.',NULL,2,NULL,NULL,'Timothy Froese','09591757909'),(140,'Dominga','Aguilera','Heredia',2,'5/14/1994',2,'5 11','88 kg.','Roman Catholic',1,'+63 336 521 9737','212-2933.','09-5536019-0','09-5536019-0','753-332-158','25-195099385-2','Illinois Tool Works Inc.',NULL,3,NULL,NULL,'Virgil Riedmayer','09930213374'),(141,'Charleen','Pulido','Bueno',2,'9/18/1974',2,'5 11','110 kg.','Protestant',1,'+63 673 595 8255','212-6235.','09-6700384-8','09-6700384-8','829-891-406','24-681064373-1','Progress Energy Inc',NULL,2,NULL,NULL,'Humberto Guffy','09327783550'),(142,'Inell','Saez','Roldan',2,'2/8/1987',2,'5 11','83 kg.','Roman Catholic',1,'+63 553 889 4642','212-5924.','09-9234427-3','09-9234427-3','655-456-216','22-482892547-6','Silicon Graphics Inc',NULL,3,NULL,NULL,'Branden Forrester','09243254577'),(143,'Caitlyn','Santana','Mateo',2,'4/7/1997',2,'5 11','88 kg.','Islam',1,'+63 840 896 9884','212-8769.','09-5442935-7','09-5442935-7','129-799-986','41-929148703-2','Hughes Supply Inc.',NULL,2,NULL,NULL,'Theron Wipfli','09667159176'),(144,'Georgina','Manzano','Villar',2,'2/26/1974',2,'5 11','100 kg.','Protestant',1,'+63 823 860 9962','212-3463.','09-7752504-6','09-7752504-6','479-530-259','63-425323211-6','Protective Life Corp',NULL,2,NULL,NULL,'Edward Inglin','09274010785'),(145,'Shirlene','Leon','Contreras',2,'6/22/1988',2,'5 11','118 kg.','Roman Catholic',1,'+63 586 578 8212','212-1529.','09-5755104-5','09-5755104-5','266-408-331','47-902255777-7','AT&T Corp.',NULL,3,NULL,NULL,'Bennett Mcclure','09479664505'),(146,'Leeanna','Hidalgo','Miranda',2,'9/1/1996',2,'5 11','119 kg.','Protestant',1,'+63 704 738 4292','212-8199.','09-3865246-3','09-3865246-3','412-339-488','71-723584313-7','Dole Food Company, Inc.',NULL,2,NULL,NULL,'Carol Fie','09474384768'),(147,'Keith','Anton','Guillen',2,'10/1/1978',1,'5 11','99 kg.','Roman Catholic',1,'+63 609 375 4414','212-8112.','09-9947639-8','09-9947639-8','343-338-823','97-586940170-4','Systemax Inc.',NULL,3,NULL,NULL,'Norman Brunecz','09351565301'),(148,'Avery','Cordoba','Mateos',2,'5/6/1984',1,'5 11','117 kg.','Protestant',1,'+63 827 615 4602','212-7214.','09-3138890-5','09-3138890-5','398-937-737','68-327508115-7','Carpenter Technology Corp.',NULL,3,NULL,NULL,'Alvin Craighead','09604460900'),(149,'Alisa','Sanz','Escudero',2,'7/9/1986',2,'5 11','114 kg.','Protestant',1,'+63 242 393 5413','212-3396.','09-8955445-1','09-8955445-1','635-475-716','28-542644549-2','Bell Microproducts Inc.',NULL,3,NULL,NULL,'Sammy Halo','09942858230'),(150,'Jessenia','Cobo','Aguilera',2,'5/18/1987',2,'5 11','111 kg.','Islam',1,'+63 972 788 4226','212-7052.','09-5713769-7','09-5713769-7','282-138-176','65-127434811-6','Cintas Corp.',NULL,2,NULL,NULL,'Pedro Gimse','09573265479'),(151,'Sebrina','Duran','Menendez',2,'5/27/1986',2,'5 11','92 kg.','Protestant',1,'+63 308 860 9247','212-7018.','09-2167353-0','09-2167353-0','381-995-912','24-587639929-8','Citizens Communications Co.',NULL,3,NULL,NULL,'Elijah Kew','09486927890'),(152,'Julissa','Pacheco','Casas',2,'9/15/1978',2,'5 11','76 kg.','Islam',1,'+63 157 322 5470','212-6487.','09-5842722-8','09-5842722-8','478-977-596','35-896232746-8','Comverse Technology Inc.',NULL,3,NULL,NULL,'Johnie Hunten','09853833450'),(153,'Shirlene','Mohamed','Aparicio',2,'4/9/1996',2,'5 11','88 kg.','Protestant',1,'+63 623 854 6053','212-5495.','09-6368445-4','09-6368445-4','601-938-284','76-174462301-3','New York Times Company',NULL,3,NULL,NULL,'Thanh Gebhardt','09814281580'),(154,'Blythe','Zapata','Rivero',2,'2/19/1998',2,'5 11','109 kg.','Roman Catholic',1,'+63 854 845 6993','212-7791.','09-3797089-5','09-3797089-5','798-931-913','95-217766921-8','Tribune Company',NULL,2,NULL,NULL,'Jeramy Quintal','09561856001'),(155,'Kellie','Ruiz','Estevez',2,'8/8/1972',2,'5 11','95 kg.','Roman Catholic',1,'+63 352 279 2810','212-4452.','09-7498736-5','09-7498736-5','410-869-302','21-803512389-7','United Technologies Corporation',NULL,2,NULL,NULL,'Clinton Amlin','09703697688'),(156,'Suzann','Gil','Beltran',2,'10/3/1982',2,'5 11','118 kg.','Roman Catholic',1,'+63 289 557 8559','212-1631.','09-9509382-6','09-9509382-6','343-967-300','88-602419083-5','Applera Corporation',NULL,2,NULL,NULL,'Louis Pizzaro','09574685086'),(157,'Kellye','Hernandez','Padilla',2,'1/7/1979',2,'5 11','113 kg.','Islam',1,'+63 633 737 1985','212-2342.','09-4901319-2','09-4901319-2','300-121-503','44-428768308-2','MasTec Inc.',NULL,3,NULL,NULL,'Bruno Nordick','09487161657'),(158,'Joannie','Murillo','Gracia',2,'3/24/1982',2,'5 11','118 kg.','Islam',1,'+63 209 521 6610','212-9623.','09-7233887-0','09-7233887-0','915-714-607','33-232757327-4','Eaton Corporation',NULL,2,NULL,NULL,'Bennett Wiehe','09981731775'),(159,'Krishna','Aparicio','Rico',2,'11/23/1972',2,'5 11','116 kg.','Roman Catholic',1,'+63 353 251 6035','212-7377.','09-3371584-8','09-3371584-8','857-812-777','54-164629429-3','Valero Energy Corporation',NULL,3,NULL,NULL,'Hans Primer','09546683386'),(160,'Abdul','Panlilio','Calderon',2,'6/26/1997',1,'5 11','90 kg.','Roman Catholic',1,'+63 939 304 1751','212-6696.','09-8014518-7','09-8014518-7','737-311-941','76-801203961-0','H.B. Fuller Company',NULL,2,NULL,NULL,'Sammy Elbert','09286969774'),(161,'Margie','Rodrigo','Abad',1,'2/5/1985',2,'5 11','87 kg.','Protestant',1,'+63 603 364 1300','212-4964.','09-2306385-6','09-2306385-6','726-849-298','63-609612327-5','Kohl\'s Corp.',NULL,2,NULL,NULL,'Daryl Hossfeld','09510047990'),(162,'Iliana','Calvo','Galvez',2,'4/25/1986',2,'5 11','117 kg.','Protestant',1,'+63 587 659 1755','212-7283.','09-3820503-8','09-3820503-8','487-913-266','46-870999533-2','AK Steel Holding Corporation',NULL,3,NULL,NULL,'Tracey Wilkie','09343664379'),(163,'Ricki','Jurado','Conde',2,'11/8/1984',1,'5 11','93 kg.','Islam',1,'+63 317 983 2998','212-4347.','09-9581683-4','09-9581683-4','310-364-309','43-255553922-4','Waste Management Inc',NULL,3,NULL,NULL,'Jackson Zupfer','09445826639'),(164,'Aliza','Asensio','Salas',2,'8/1/1983',2,'5 11','97 kg.','Roman Catholic',1,'+63 324 493 1637','212-3029.','09-2889489-3','09-2889489-3','306-587-132','91-195094265-2','WGL Holdings Inc',NULL,3,NULL,NULL,'Lowell Holtgrefe','09120516912'),(165,'Kanesha','Cabello','Jurado',2,'8/24/1980',2,'5 11','108 kg.','Roman Catholic',1,'+63 210 127 8093','212-5762.','09-9153481-4','09-9153481-4','845-208-944','31-950189941-5','Dana Corporation',NULL,2,NULL,NULL,'Britt Mikos','09652237767'),(166,'Magda','Soriano','Quintana',2,'6/9/1993',2,'5 11','113 kg.','Roman Catholic',1,'+63 319 188 4101','212-9201.','09-2560790-7','09-2560790-7','730-710-363','22-972330708-3','Value City Department Stores Inc',NULL,2,NULL,NULL,'Israel Minery','09980936406'),(167,'Jeanette','Pineda','Plaza',2,'6/18/1977',1,'5 11','112 kg.','Islam',1,'+63 850 296 7006','212-1111.','09-4712496-8','09-4712496-8','858-703-718','69-817544957-0','Motorola Inc.',NULL,3,NULL,NULL,'Homer Trueman','09705213513'),(168,'Eliana','Valle','Acosta',2,'1/24/1983',1,'5 11','78 kg.','Roman Catholic',1,'+63 414 214 2931','212-4804.','09-3109694-0','09-3109694-0','856-340-112','40-918873116-6','ITT Industries Inc.',NULL,2,NULL,NULL,'Cornell Tellier','09502592810'),(169,'Kaila','Iglesias','Aranda',2,'7/14/1993',1,'5 11','99 kg.','Roman Catholic',1,'+63 575 546 2583','212-3990.','09-3512439-4','09-3512439-4','982-612-357','20-628162266-1','Kerr-McGee Corporation',NULL,2,NULL,NULL,'Sebastian Pasquarella','09482073478'),(170,'Loree','Marquez','Blazquez',2,'3/9/1991',1,'5 11','90 kg.','Islam',1,'+63 713 185 8934','212-7653.','09-3851112-8','09-3851112-8','800-638-272','69-427121668-0','Advance Auto Parts, Inc.',NULL,3,NULL,NULL,'Willy Rodeman','09914636478'),(171,'Aimee','Ramirez','Roca',2,'1/22/1995',1,'5 11','104 kg.','Islam',1,'+63 797 349 3329','212-8089.','09-3597079-5','09-3597079-5','155-487-582','55-791613632-0','Riverwood Holding Inc.',NULL,2,NULL,NULL,'Chang Haub','09788140302'),(172,'Janell','Parra','Bermudez',2,'6/11/1973',1,'5 11','103 kg.','Protestant',1,'+63 334 267 7972','212-2760.','09-9575044-0','09-9575044-0','998-630-281','30-743499679-2','Brown-Forman Corporation',NULL,3,NULL,NULL,'Jim Kamstra','09377086337'),(173,'Juli','Valverde','Costa',2,'8/27/1977',1,'5 11','96 kg.','Islam',1,'+63 413 549 7305','212-9463.','09-1112247-7','09-1112247-7','538-674-181','47-430383013-1','Dynegy Inc.',NULL,3,NULL,NULL,'Roderick Brundige','09323956702'),(174,'Rona','Otero','Miguel',2,'9/2/1982',1,'5 11','78 kg.','Protestant',1,'+63 532 136 2395','212-1674.','09-1141877-0','09-1141877-0','135-179-432','78-965857993-7','Werner Enterprises Inc',NULL,3,NULL,NULL,'Carol Kasowski','09221728660'),(175,'Alia','Romero','Santamaria',2,'4/13/1990',1,'5 11','83 kg.','Roman Catholic',1,'+63 522 596 7257','212-2906.','09-7282239-3','09-7282239-3','249-197-241','39-668214180-5','Scana Corp.',NULL,2,NULL,NULL,'Joey Sever','09442174671'),(176,'Rolande','Segura','Salazar',2,'8/10/1984',1,'5 11','81 kg.','Roman Catholic',1,'+63 473 168 9424','212-5850.','09-9319692-4','09-9319692-4','732-500-859','70-556279104-6','Duke Energy Corp',NULL,3,NULL,NULL,'Ezekiel Schriver','09377573249'),(177,'Melodie','Gracia','Guzman',2,'10/24/1988',1,'5 11','109 kg.','Islam',1,'+63 613 521 7367','212-3555.','09-3666534-5','09-3666534-5','725-957-476','61-147038477-6','American International Group, Inc.',NULL,3,NULL,NULL,'Cyril Stewart','09404656776'),(178,'Ollie','Macias','Serra',2,'3/25/1972',1,'5 11','109 kg.','Islam',1,'+63 877 600 6512','212-3810.','09-2037066-1','09-2037066-1','317-370-705','20-669148494-6','Pall Corp',NULL,2,NULL,NULL,'Merlin Vidaca','09535171571'),(179,'Marianna','Pereira','Villanueva',2,'2/25/1982',1,'5 11','118 kg.','Protestant',1,'+63 357 495 8789','212-5030.','09-9780643-4','09-9780643-4','994-547-772','85-371419387-3','Computer Sciences Corp.',NULL,3,NULL,NULL,'Kristofer Wainer','09491745425'),(180,'Luna','Maldonado','Cuesta',2,'5/10/1995',1,'5 11','80 kg.','Islam',1,'+63 240 298 5240','212-3409.','09-8758621-6','09-8758621-6','909-702-189','49-530083371-8','Advance Auto Parts, Inc.',NULL,3,NULL,NULL,'Jarrod Paywa','09361909243'),(181,'Jackie','Andres','Manzano',2,'11/8/1987',1,'5 11','82 kg.','Roman Catholic',1,'+63 531 230 8118','212-5700.','09-1190855-7','09-1190855-7','607-644-391','94-176760177-0','U.S. Industries Inc.',NULL,3,NULL,NULL,'Ferdinand Karsnak','09673309968'),(182,'Dana','Prado','Tomas',2,'3/7/1982',1,'5 11','84 kg.','Islam',1,'+63 279 145 3186','212-1059.','09-5527393-0','09-5527393-0','823-313-335','19-516346724-1','Frontier Oil Corp',NULL,2,NULL,NULL,'Javier Brookskennedy','09518214499'),(183,'Candance','Villar','Hurtado',2,'4/6/1991',1,'5 11','89 kg.','Islam',1,'+63 625 815 5106','212-1752.','09-8512315-0','09-8512315-0','386-600-800','89-319879408-6','Peter Kiewit Sons\', Inc.',NULL,3,NULL,NULL,'Raleigh Theuret','09454720743'),(184,'Un','Vicente','Trujillo',2,'8/16/1978',1,'5 11','99 kg.','Islam',1,'+63 650 786 9891','212-6507.','09-9655132-2','09-9655132-2','652-897-878','65-894401514-6','Robert Half International Inc.',NULL,2,NULL,NULL,'Alexis Haar','09113265145'),(185,'Bebe','Soto','Rueda',2,'5/7/1990',1,'5 11','111 kg.','Roman Catholic',1,'+63 877 413 5234','212-2112.','09-2423233-1','09-2423233-1','644-374-394','79-351569117-1','Outback Steakhouse Inc.',NULL,2,NULL,NULL,'Wilton Lheureux','09638078459'),(186,'Isaura','Alba','Pacheco',2,'9/2/1995',1,'5 11','81 kg.','Protestant',1,'+63 397 723 8085','212-1096.','09-5737808-7','09-5737808-7','324-723-761','54-481484516-0','Nordstrom Inc',NULL,2,NULL,NULL,'Rafael Petre','09846735987'),(187,'Tisa','Acosta','Avila',2,'10/26/1993',1,'5 11','100 kg.','Protestant',1,'+63 797 958 8870','212-1174.','09-2389938-0','09-2389938-0','798-304-299','12-454137342-2','Equifax Inc.',NULL,2,NULL,NULL,'Rafael Wieder','09586698244'),(188,'Maudie','Lozano','Simon',2,'10/10/1985',1,'5 11','114 kg.','Protestant',1,'+63 480 691 1551','212-8695.','09-1457238-1','09-1457238-1','121-317-236','82-707274224-0','Genesis Health Ventures Inc.',NULL,2,NULL,NULL,'Johnie Pirone','09633591643'),(189,'Yolando','Requena','Dela Fuente',2,'7/22/1990',1,'5 11','88 kg.','Roman Catholic',1,'+63 775 610 7779','212-9085.','09-3880672-7','09-3880672-7','650-952-296','69-173839738-3','Greif Bros. Corporation',NULL,3,NULL,NULL,'Sherman Swartzell','09871192970'),(190,'Kandy','Rivas','Dela Fuente',2,'2/27/1977',1,'5 11','105 kg.','Islam',1,'+63 543 168 6719','212-4667.','09-1513390-1','09-1513390-1','676-933-600','75-583719298-7','Lockheed Martin Corporation',NULL,3,NULL,NULL,'Lanny Coronel','09206422162'),(191,'Eric','Martos','Dela Fuente',2,'10/7/1986',1,'5 11','94 kg.','Roman Catholic',1,'+63 850 511 9671','212-4716.','09-6790892-1','09-6790892-1','747-792-539','54-614808935-3','Banta Corporation',NULL,3,NULL,NULL,'Palmer Bohmer','09755723461'),(192,'Shaneka','Lorente','Pons',2,'11/7/1974',1,'5 11','83 kg.','Roman Catholic',1,'+63 773 344 7756','212-5462.','09-7406506-6','09-7406506-6','358-921-516','65-485020404-4','Burlington Coat Factory Warehouse Corporation',NULL,3,NULL,NULL,'Alexander Seremet','09361306940'),(193,'Toya','Cruz','Lazaro',2,'6/24/1974',1,'5 11','101 kg.','Roman Catholic',1,'+63 826 541 3202','212-2150.','09-8828898-2','09-8828898-2','387-870-753','40-816794549-6','Clear Channel Communications Inc.',NULL,3,NULL,NULL,'Vernon Faulcon','09498000125'),(194,'Katrina','Simon','Sancho',2,'10/19/1982',1,'5 11','99 kg.','Roman Catholic',1,'+63 473 292 9990','212-7322.','09-9068253-4','09-9068253-4','416-720-577','61-931127975-0','National Commerce Financial Corporation',NULL,3,NULL,NULL,'Elvin Mcgirr','09377684392'),(195,'Portia','Acosta','Mesa',2,'6/27/1982',1,'5 11','91 kg.','Islam',1,'+63 603 161 2803','212-2874.','09-8441335-7','09-8441335-7','258-545-352','68-951075679-3','Trans World Entertainment Corp.',NULL,2,NULL,NULL,'Benton Mellard','09603155461'),(196,'Darcel','Crespo','Del',2,'7/27/1975',1,'5 11','96 kg.','Roman Catholic',1,'+63 665 119 9034','212-5324.','09-8392207-8','09-8392207-8','425-828-189','90-241875111-6','Lyondell Chemical Company',NULL,3,NULL,NULL,'Ezra Grisanti','09456503275'),(197,'Earlene','Cordero','Rio',2,'11/26/1976',1,'5 11','91 kg.','Islam',1,'+63 887 277 5669','212-5378.','09-7324234-6','09-7324234-6','513-993-939','97-215318341-4','BJ Services Company',NULL,3,NULL,NULL,'Renato Turbiner','09855841747'),(198,'Mui','Bautista','Escobar',2,'4/14/1976',1,'5 11','110 kg.','Islam',1,'+63 931 431 6513','212-9711.','09-2548218-1','09-2548218-1','950-915-764','87-355443313-4','Avery Dennison Corporation',NULL,3,NULL,NULL,'Modesto Boarman','09914926522'),(199,'Shawanda','Suarez','Millan',2,'2/21/1997',1,'5 11','99 kg.','Roman Catholic',1,'+63 998 406 5506','212-1541.','09-2930212-5','09-2930212-5','564-848-876','62-966654623-5','Mohawk Industries Inc.',NULL,3,NULL,NULL,'Gregorio Lalka','09724799486'),(200,'Hyun','Silva','Blasco',2,'4/2/1989',1,'5 11','101 kg.','Roman Catholic',1,'+63 903 899 2925','212-4028.','09-7513419-0','09-7513419-0','341-391-466','56-452910186-2','Lennox International Inc.',NULL,3,NULL,NULL,'Zachery Alameda','09183478256'),(201,'Dorothea','Dela Fuente','Alarcon',2,'9/18/1991',1,'5 11','81 kg.','Protestant',1,'+63 100 425 2650','212-3283.','09-2170481-7','09-2170481-7','253-764-701','55-983552288-8','Kohl\'s Corp.',NULL,2,NULL,NULL,'Ken Huelle','09679310956'),(202,'Miss','Ortiz','Luna',2,'9/13/1972',1,'5 11','115 kg.','Islam',1,'+63 152 373 8685','212-3554.','09-8574392-7','09-8574392-7','272-890-721','71-568676680-2','Hormel Foods Corp.',NULL,2,NULL,NULL,'Josue Dibari','09429379725'),(203,'Tonie','Dela Fuente','Quiñones',2,'5/20/1987',1,'5 11','91 kg.','Protestant',1,'+63 250 696 1550','212-6245.','09-4952345-2','09-4952345-2','848-404-161','56-943216067-3','Praxair Inc',NULL,2,NULL,NULL,'Gilbert Paiz','09598488696'),(204,'Margareta','Roig','Zamora',2,'9/3/1974',1,'5 11','84 kg.','Islam',1,'+63 341 137 3324','212-4650.','09-8441060-7','09-8441060-7','674-321-237','88-154070341-6','Lear Corporation',NULL,2,NULL,NULL,'Ryan Geissler','09582957726'),(205,'Janyce','Flores','Salvador',2,'2/13/1985',1,'5 11','113 kg.','Protestant',1,'+63 757 113 2730','212-7376.','09-7360273-0','09-7360273-0','397-819-610','96-324559347-8','U.S. Bancorp',NULL,2,NULL,NULL,'Alan Schreacke','09610263466'),(206,'Natisha','Ojeda','Bermejo',2,'1/14/1995',1,'5 11','117 kg.','Islam',1,'+63 823 165 2679','212-5471.','09-3385326-3','09-3385326-3','373-717-243','97-485301119-2','Universal Health Services Inc',NULL,2,NULL,NULL,'Antony Aliano','09393097264'),(207,'Sammie','Marques','Paredes',2,'6/26/1996',1,'5 11','87 kg.','Roman Catholic',1,'+63 866 915 2403','212-1743.','09-4984443-5','09-4984443-5','406-513-481','53-169749073-3','Landstar System Inc.',NULL,3,NULL,NULL,'Hector Paxman','09561341760'),(208,'Renetta','Pardo','Anton',2,'5/1/1995',1,'5 11','118 kg.','Protestant',1,'+63 443 283 8938','212-9735.','09-7783880-0','09-7783880-0','435-553-252','72-242952778-1','US Oncology Inc',NULL,2,NULL,NULL,'Luther Dischinger','09963489639'),(209,'Kasha','Corral','Ballesteros',2,'5/6/1990',1,'5 11','117 kg.','Roman Catholic',1,'+63 177 137 4534','212-2196.','09-1949890-1','09-1949890-1','839-587-582','52-755272246-6','Unisource Energy Corp',NULL,2,NULL,NULL,'Clemente Mcgirr','09813683654'),(210,'Cordia','Costa','Valverde',2,'8/5/1987',1,'5 11','106 kg.','Islam',1,'+63 491 775 2666','212-4807.','09-6893897-1','09-6893897-1','957-204-520','20-678263244-3','Campbell Soup Co.',NULL,3,NULL,NULL,'Tracey Malkowski','09932205999'),(211,'Wesley','Bonilla','Maldonado',2,'7/17/1986',1,'5 11','100 kg.','Roman Catholic',1,'+63 345 680 1307','212-8150.','09-9839006-8','09-9839006-8','450-745-623','56-743509533-2','Health Net Inc.',NULL,3,NULL,NULL,'Herb Schibi','09151412937'),(212,'Elizabeth','Solis','Bautista',2,'9/4/1982',1,'5 11','84 kg.','Islam',1,'+63 833 139 2587','212-2026.','09-6505760-2','09-6505760-2','410-194-715','97-150732249-1','Kellogg Company',NULL,2,NULL,NULL,'Hunter Suganuma','09581352772'),(213,'Necole','Da','Valle',2,'4/19/1989',1,'5 11','101 kg.','Islam',1,'+63 334 252 4627','212-8874.','09-3680864-8','09-3680864-8','194-493-296','57-223049902-5','Goodrich Corporation',NULL,2,NULL,NULL,'Hayden Pardieck','09649834676'),(214,'Palmira','Quintero','Ponce',2,'1/4/1977',1,'5 11','93 kg.','Protestant',1,'+63 624 740 1642','212-8555.','09-6179615-1','09-6179615-1','172-307-253','74-408364347-3','Vectren Corporation',NULL,3,NULL,NULL,'Nolan Bossen','09714282088'),(215,'Angelika','Del','Rodrigo',2,'9/13/1984',1,'5 11','94 kg.','Protestant',1,'+63 751 440 9858','212-7273.','09-2131844-6','09-2131844-6','251-836-956','84-476076959-6','Cenex Harvest States Cooperatives',NULL,3,NULL,NULL,'Foster Blackler','09281684672'),(216,'Kellie','Arribas','Lorente',2,'5/25/1980',1,'5 11','113 kg.','Protestant',1,'+63 338 877 9959','212-9648.','09-6378622-5','09-6378622-5','284-224-136','94-753305659-1','Eastman Kodak Company',NULL,3,NULL,NULL,'Lucas Pforr','09189972567'),(217,'Joslyn','Reina','Oliva',2,'9/11/1973',1,'5 11','82 kg.','Islam',1,'+63 827 226 6393','212-6101.','09-5934964-4','09-5934964-4','859-352-300','86-380483215-3','Ferro Corp.',NULL,3,NULL,NULL,'Glenn Stinchcomb','09501596486'),(218,'Pura','Rodriguez','Juan',2,'10/23/1974',1,'5 11','101 kg.','Roman Catholic',1,'+63 869 886 7824','212-9624.','09-9494666-4','09-9494666-4','227-964-755','81-754515896-2','Hawaiian Electric Industries Inc.',NULL,3,NULL,NULL,'Daryl Orebaugh','09166904730'),(219,'Andrew','Paz','Cordero',2,'4/21/1997',1,'5 11','118 kg.','Islam',1,'+63 505 195 7858','212-6858.','09-2360350-2','09-2360350-2','145-243-179','41-413312084-5','PolyOne Corp',NULL,3,NULL,NULL,'Terrence Abdallah','09727493445'),(220,'Ernestine','Alcaraz','Mas',2,'11/11/1972',1,'5 11','111 kg.','Islam',1,'+63 805 409 7583','212-1632.','09-3921985-8','09-3921985-8','310-297-259','16-742117298-3','Xcel Energy Inc',NULL,2,NULL,NULL,'Darin Rixie','09595349800'),(221,'Ludivina','Miguel','Collado',2,'7/11/1986',1,'5 11','115 kg.','Islam',1,'+63 486 200 8714','212-5109.','09-4142306-1','09-4142306-1','317-765-388','51-558401391-8','Kindred Healthcare Inc.',NULL,2,NULL,NULL,'Darin Bednarczyk','09470617452'),(222,'Melba','Marcos','Murillo',2,'10/5/1988',1,'5 11','83 kg.','Roman Catholic',1,'+63 663 178 1942','212-3266.','09-3892866-0','09-3892866-0','742-205-200','39-751717870-6','XO Communications Inc',NULL,3,NULL,NULL,'Valentine Requa','09720387034'),(223,'Danica','Rojo','Pozo',2,'3/20/1982',1,'5 11','96 kg.','Islam',1,'+63 719 440 8058','212-9505.','09-3038012-2','09-3038012-2','166-491-699','61-685376620-6','Jefferson-Pilot Co.',NULL,2,NULL,NULL,'Isiah Gruntz','09448333027'),(224,'Drew','Chacon','Dela Cruz',2,'1/3/1992',1,'5 11','89 kg.','Islam',1,'+63 968 743 8914','212-6836.','09-1656435-5','09-1656435-5','887-817-229','28-281438521-3','Winn Dixie Stores Inc',NULL,3,NULL,NULL,'Stewart Vilcheck','09435512672'),(225,'Viva','Escudero','Dela Cruz',2,'1/7/1994',1,'5 11','84 kg.','Islam',1,'+63 498 780 2683','212-7936.','09-9329657-8','09-9329657-8','408-871-260','41-354710030-3','Humana Inc.',NULL,3,NULL,NULL,'Bryce Deangelis','09317881980'),(226,'Kenna','Vela','Dela Cruz',2,'2/16/1995',1,'5 11','89 kg.','Roman Catholic',1,'+63 653 130 2951','212-7545.','09-1280014-5','09-1280014-5','397-981-509','34-396464883-5','SLM Corporation',NULL,2,NULL,NULL,'Isiah Eisnaugle','09210319427'),(227,'Sung','Guzman','Cuenca',2,'10/24/1994',1,'5 11','89 kg.','Roman Catholic',1,'+63 770 201 3690','212-8881.','09-9377706-2','09-9377706-2','781-961-344','78-303411920-2','Adelphia Communications Corporation',NULL,3,NULL,NULL,'Marcel Obar','09682638776'),(228,'Nella','Perez','Montoya',2,'8/15/1975',1,'5 11','111 kg.','Islam',1,'+63 787 633 2574','212-8292.','09-7675696-4','09-7675696-4','874-480-510','40-532705020-0','Mirant Corporation',NULL,3,NULL,NULL,'August Franchini','09831789485'),(229,'Martin','Bueno','Martos',2,'9/11/1973',1,'5 11','80 kg.','Islam',1,'+63 775 888 5608','212-1588.','09-8157314-7','09-8157314-7','773-897-174','94-293074737-2','Providian Financial Corp.',NULL,2,NULL,NULL,'Hobert Saas','09148019772'),(230,'Rosalba','Benito','Cuevas',2,'7/6/1976',1,'5 11','95 kg.','Protestant',1,'+63 696 677 5340','212-9818.','09-6071776-5','09-6071776-5','316-856-887','49-912602757-2','Willamette Industries Inc.',NULL,3,NULL,NULL,'Britt Stolar','09333438835'),(231,'Erline','Pinto','Marco',2,'4/19/1984',1,'5 11','84 kg.','Protestant',1,'+63 812 779 3042','212-1746.','09-3593233-6','09-3593233-6','379-647-672','39-168443374-2','Teradyne Inc',NULL,3,NULL,NULL,'Mel Daza','09281120918'),(232,'Delfina','Mendez','Barroso',2,'3/24/1974',1,'5 11','90 kg.','Protestant',1,'+63 799 448 5966','212-8700.','09-2335183-7','09-2335183-7','220-393-501','85-186248665-7','Murphy Oil Corporation',NULL,2,NULL,NULL,'Alan Bergey','09227937757'),(233,'Marylin','Mas','Ros',2,'10/8/1982',1,'5 11','96 kg.','Islam',1,'+63 345 721 7320','212-4117.','09-3080832-7','09-3080832-7','330-497-497','58-363483674-7','Black Hills Corporation',NULL,3,NULL,NULL,'Alfred Guccione','09947989760'),(234,'Franchesca','Burgos','Quesada',2,'4/9/1983',1,'5 11','115 kg.','Protestant',1,'+63 815 140 5981','212-7443.','09-5334099-2','09-5334099-2','572-771-859','80-654941641-6','Coventry Health Care Inc.',NULL,3,NULL,NULL,'Donnie Juanico','09445403104'),(235,'Armandina','Oliva','De',2,'11/22/1983',1,'5 11','94 kg.','Protestant',1,'+63 290 874 6290','212-3052.','09-8476104-7','09-8476104-7','634-836-847','36-162296029-5','Hasbro Inc.',NULL,3,NULL,NULL,'Reggie Kinnick','09675739890'),(236,'Dione','Galindo','La',2,'9/1/1986',1,'5 11','81 kg.','Islam',1,'+63 759 210 6881','212-5441.','09-5890501-6','09-5890501-6','752-308-221','32-653281524-8','Revlon Inc',NULL,2,NULL,NULL,'Derick Degregorio','09788690818'),(237,'Jane','Juan','Torre',2,'4/9/1993',1,'5 11','96 kg.','Protestant',1,'+63 334 358 1681','212-5104.','09-9602554-8','09-9602554-8','895-561-548','72-288422780-5','CVS Corp.',NULL,3,NULL,NULL,'Edmund Leah','09632540332'),(238,'Whitley','Gallardo','Barrera',2,'7/5/1995',1,'5 11','76 kg.','Islam',1,'+63 884 155 7973','212-2069.','09-3821913-7','09-3821913-7','511-787-959','98-212654744-0','Kellogg Company',NULL,2,NULL,NULL,'Elijah Reda','09915990161'),(239,'Tomas','Redondo','Agoncillo',2,'8/18/1975',1,'5 11','112 kg.','Protestant',1,'+63 482 812 7480','212-5621.','09-1823987-4','09-1823987-4','554-152-406','32-870271100-7','General Mills Inc',NULL,2,NULL,NULL,'Whitney Gilberti','09459542769'),(240,'Lynnette','Camilo','Gimeno',2,'6/21/1976',1,'5 11','105 kg.','Islam',1,'+63 703 630 8392','212-7601.','09-2972419-5','09-2972419-5','392-189-149','46-549919097-6','Ashland Inc.',NULL,3,NULL,NULL,'Vicente Crumwell','09574191832'),(241,'Kiley','Escribano','Corral',2,'9/12/1973',1,'5 11','97 kg.','Protestant',1,'+63 784 967 4292','212-7773.','09-4492099-8','09-4492099-8','378-616-954','12-465762514-1','Computer Associates International Inc.',NULL,3,NULL,NULL,'Hayden Sonders','09606075592'),(242,'Lulu','Blazquez','Alba',2,'9/1/1996',1,'5 11','104 kg.','Islam',1,'+63 453 575 4120','212-8008.','09-4568423-0','09-4568423-0','524-518-537','45-981243390-2','Massey Energy Company',NULL,2,NULL,NULL,'Brice Morera','09252138318'),(243,'Willette','Alonso','Puig',2,'6/26/1991',1,'5 11','105 kg.','Roman Catholic',1,'+63 868 187 3849','212-3417.','09-9377469-6','09-9377469-6','870-360-556','57-338183199-2','Manpower Inc.',NULL,3,NULL,NULL,'Cesar Mccutcheon','09305751268'),(244,'Yaeko','Carrillo','Cabello',2,'2/26/1988',1,'5 11','119 kg.','Roman Catholic',1,'+63 857 818 9774','212-4169.','09-4630961-2','09-4630961-2','163-417-793','36-617343534-4','Domino\'s Pizza LLC',NULL,2,NULL,NULL,'Devin Fishback','09971681572'),(245,'Lyndsey','Marco','Pulido',2,'2/25/1989',1,'5 11','76 kg.','Roman Catholic',1,'+63 913 264 8163','212-9681.','09-7047017-8','09-7047017-8','688-315-626','98-266068238-3','Alberto-Culver Company',NULL,3,NULL,NULL,'Joaquin Seryak','09757307764'),(246,'Shery','Salas','Rojo',2,'11/3/1978',1,'5 11','102 kg.','Roman Catholic',1,'+63 836 645 4310','212-9526.','09-7746464-2','09-7746464-2','514-768-173','83-697712628-7','Oshkosh Truck Corp',NULL,2,NULL,NULL,'Luigi Macafee','09488870956'),(247,'Clelia','Saavedra','Navas',2,'2/15/1995',1,'5 11','78 kg.','Islam',1,'+63 797 154 9017','212-5172.','09-1814766-7','09-1814766-7','707-596-817','43-825900971-7','American Electric Power Company, Inc.',NULL,3,NULL,NULL,'Zackary Coriell','09896557454'),(248,'Cecelia','Toledo','Saiz',2,'3/5/1976',1,'5 11','91 kg.','Protestant',1,'+63 320 842 8193','212-6683.','09-8006325-4','09-8006325-4','604-976-356','17-754937933-2','Pulte Homes Inc',NULL,3,NULL,NULL,'Efrain Costen','09370878937'),(249,'Fawn','Fernandez','Soria',2,'9/8/1992',1,'5 11','116 kg.','Protestant',1,'+63 402 955 1486','212-2623.','09-1448779-4','09-1448779-4','899-761-661','48-821637738-8','Advanced Micro Devices, Inc.',NULL,3,NULL,NULL,'Nickolas Lajeunesse','09802843241'),(250,'Teresia','Bermudez','Arenas',2,'5/10/1991',1,'5 11','82 kg.','Islam',1,'+63 249 997 4244','212-8763.','09-2846174-4','09-2846174-4','860-273-527','54-115586999-3','Atmos Energy Corporation',NULL,2,NULL,NULL,'Donte Pulsifer','09421424831'),(251,'Deneen','Caballero','Aguado',2,'2/15/1985',1,'5 11','95 kg.','Protestant',1,'+63 563 286 4779','212-1898.','09-3215821-8','09-3215821-8','633-394-194','69-682015001-8','Reader\'s Digest Association Inc.',NULL,3,NULL,NULL,'Hans Colosimo','09655972030'),(252,'Synthia','Cantero','Domingo',2,'6/13/1972',1,'5 11','105 kg.','Islam',1,'+63 874 817 6678','212-8242.','09-8149935-3','09-8149935-3','515-596-189','64-251638122-6','Kemet Corp.',NULL,2,NULL,NULL,'Titus Standfield','09727618474'),(253,'Stephania','Pastor','Galindo',2,'6/1/1996',1,'5 11','102 kg.','Roman Catholic',1,'+63 359 796 6467','212-6047.','09-9153030-4','09-9153030-4','491-410-284','15-382738013-8','Markel Corporation',NULL,3,NULL,NULL,'Mose Jungling','09957133564'),(254,'Anja','Rivera','Vallejo',2,'10/2/1985',1,'5 11','107 kg.','Protestant',1,'+63 531 387 4056','212-1331.','09-2605121-6','09-2605121-6','844-512-923','56-595380859-8','Lehman Brothers Holdings Inc.',NULL,3,NULL,NULL,'Garret Genter','09745620761'),(255,'Joannie','Rico','Mena',2,'2/7/1978',1,'5 11','109 kg.','Roman Catholic',1,'+63 468 659 5852','212-2855.','09-5143299-0','09-5143299-0','553-848-951','96-300342334-8','Cooper Tire & Rubber Co.',NULL,2,NULL,NULL,'Carmen Chadwell','09635746389'),(256,'Valarie','Serra','Escribano',2,'9/17/1981',1,'5 11','100 kg.','Roman Catholic',1,'+63 963 384 4465','212-7931.','09-1927040-5','09-1927040-5','870-849-494','40-145684182-1','Banknorth Group, Inc.',NULL,2,NULL,NULL,'Grady Mccooey','09541820304'),(257,'Tamala','Villanueva','Asensio',2,'7/17/1997',1,'5 11','89 kg.','Protestant',1,'+63 325 205 6582','212-2487.','09-6252554-0','09-6252554-0','276-132-955','31-596513525-4','Stewart & Stevenson Services Inc',NULL,3,NULL,NULL,'Calvin Nattiah','09264864045'),(258,'Debbi','Castellano','Ramon',2,'7/8/1988',1,'5 11','115 kg.','Islam',1,'+63 722 676 2928','212-5177.','09-2642060-2','09-2642060-2','420-612-285','35-360149269-3','Progressive Corporation',NULL,3,NULL,NULL,'Mervin Popham','09280794302'),(259,'Selma','Guerrero','Valencia',2,'10/24/1977',1,'5 11','100 kg.','Islam',1,'+63 378 110 5458','212-5757.','09-4532696-1','09-4532696-1','827-810-544','39-207383469-1','Micron Technology Inc.',NULL,3,NULL,NULL,'Jonathon Starghill','09521563175'),(260,'Danica','Rios','Lucas',2,'4/19/1992',1,'5 11','84 kg.','Islam',1,'+63 607 111 7513','212-8382.','09-5667373-1','09-5667373-1','199-605-474','67-598191690-6','Kemet Corp.',NULL,3,NULL,NULL,'Keenan Ohora','09111419762'),(261,'Voncile','Bustamante','Caro',2,'8/6/1985',1,'5 11','99 kg.','Roman Catholic',1,'+63 157 615 9551','212-5226.','09-1329094-5','09-1329094-5','239-831-954','73-906093869-0','Unocal Corporation',NULL,2,NULL,NULL,'Tanner Bokman','09195966921'),(262,'Valarie','Robles','Polo',2,'4/21/1989',1,'5 11','81 kg.','Islam',1,'+63 268 815 5714','212-6958.','09-1267915-3','09-1267915-3','785-841-675','73-624212590-5','Berkshire Hathaway Inc.',NULL,3,NULL,NULL,'Jamal Boundy','09267767115'),(263,'Juliet','Soria','Aguirre',2,'7/24/1989',1,'5 11','90 kg.','Protestant',1,'+63 420 945 7417','212-7621.','09-5663196-4','09-5663196-4','427-964-346','71-368874293-6','Sports Authority Inc',NULL,3,NULL,NULL,'Leopoldo Kizewski','09958126866'),(264,'Marina','Valero','Naranjo',2,'9/2/1973',1,'5 11','114 kg.','Protestant',1,'+63 508 730 9346','212-4417.','09-3919697-0','09-3919697-0','890-615-924','81-409618069-5','Pfizer Inc',NULL,2,NULL,NULL,'Russ Despain','09196956080'),(265,'Racheal','Barrios','Mata',2,'10/8/1979',1,'5 11','118 kg.','Roman Catholic',1,'+63 608 187 2568','212-2106.','09-9394654-3','09-9394654-3','709-255-909','82-616360797-7','Conectiv, Inc',NULL,3,NULL,NULL,'Lazaro Cullen','09482841218'),(266,'Selene','Linares','Villalba',2,'2/5/1978',1,'5 11','91 kg.','Roman Catholic',1,'+63 785 209 4206','212-4545.','09-4619141-8','09-4619141-8','830-150-809','13-450125331-6','Textron Inc',NULL,3,NULL,NULL,'Garret Dimuzio','09256451823'),(267,'Jacque','Diez','Reina',2,'9/4/1975',1,'5 11','113 kg.','Roman Catholic',1,'+63 737 243 9448','212-8518.','09-1229517-5','09-1229517-5','382-240-360','55-875258950-6','UnumProvident Corporation',NULL,2,NULL,NULL,'Matt Clam','09566145990'),(268,'Theodora','Dela Cruz','Paz',2,'2/26/1973',1,'5 11','108 kg.','Islam',1,'+63 762 647 8016','212-4756.','09-8720790-8','09-8720790-8','886-237-488','11-299906586-4','PepsiAmericas Inc.',NULL,3,NULL,NULL,'Damon Micek','09976808666'),(269,'Erma','Luis','Amador',2,'8/10/1975',1,'5 11','110 kg.','Roman Catholic',1,'+63 210 826 3170','212-6876.','09-6981369-2','09-6981369-2','208-859-745','35-755978346-0','Solutia Inc',NULL,2,NULL,NULL,'Grady Mccoach','09231120862'),(270,'Sherrell','Abad','Moran',2,'9/2/1989',1,'5 11','91 kg.','Islam',1,'+63 798 630 5832','212-6998.','09-6925709-0','09-6925709-0','498-849-956','88-983091435-1','Brightpoint, Inc.',NULL,3,NULL,NULL,'Morton Gius','09331154806'),(271,'Deborah','Palacios','Linares',2,'11/21/1979',1,'5 11','84 kg.','Islam',1,'+63 260 581 2597','212-8644.','09-8766240-4','09-8766240-4','635-616-298','60-839630685-3','Tektronix Inc',NULL,3,NULL,NULL,'Rodney Tablang','09661571118'),(272,'Eneida','Beltran','Ojeda',2,'9/27/1977',1,'5 11','84 kg.','Protestant',1,'+63 742 721 9606','212-3847.','09-5020850-1','09-5020850-1','997-875-203','71-213705523-7','Bausch & Lomb Incorporated',NULL,2,NULL,NULL,'Chang Koepke','09414607536'),(273,'Mirella','Molina','Leal',2,'9/27/1980',1,'5 11','78 kg.','Protestant',1,'+63 302 480 3587','212-1896.','09-3777727-6','09-3777727-6','710-794-207','21-376452275-0','Wal-Mart Stores Inc',NULL,3,NULL,NULL,'Ulysses Wyland','09692665713'),(274,'Carl','Perea','Burgos',2,'10/3/1991',1,'5 11','94 kg.','Islam',1,'+63 706 690 6120','212-2332.','09-7740376-5','09-7740376-5','702-371-509','36-957843079-5','Kohl\'s Corp.',NULL,2,NULL,NULL,'Lacy Capoccia','09626080491'),(275,'Carolee','Pons','Chen',2,'5/24/1979',1,'5 11','82 kg.','Islam',1,'+63 366 226 8496','212-8771.','09-6100430-0','09-6100430-0','530-491-295','39-564092370-5','Anheuser-Busch Companies, Inc.',NULL,2,NULL,NULL,'Grant Casivant','09438129592'),(276,'Daphine','Carrion','Oliver',2,'2/16/1981',1,'5 11','119 kg.','Roman Catholic',1,'+63 711 227 6836','212-6685.','09-7403384-8','09-7403384-8','336-325-173','75-162840044-8','Universal Corporation',NULL,3,NULL,NULL,'Delmer Creque','09467796365'),(277,'Ayana','Lorenzo','Carretero',2,'6/13/1996',1,'5 11','116 kg.','Protestant',1,'+63 949 281 5200','212-3830.','09-5601353-3','09-5601353-3','792-208-419','98-343110326-1','Staff Leasing Inc.',NULL,2,NULL,NULL,'Felton Timms','09529016381'),(278,'David','Arias','Bonilla',2,'2/2/1996',1,'5 11','111 kg.','Protestant',1,'+63 215 637 7206','212-3659.','09-9861842-4','09-9861842-4','524-525-168','76-966042277-8','Charter One Financial Inc.',NULL,2,NULL,NULL,'Gus Madonia','09786399476'),(279,'Carlene','Villegas','Sosa',2,'5/6/1990',1,'5 11','89 kg.','Islam',1,'+63 671 541 9161','212-6840.','09-6550089-3','09-6550089-3','934-505-492','55-166170483-3','National City Corp.',NULL,2,NULL,NULL,'Jeramy Veteto','09363867030'),(280,'Marianna','Cardenas','Roig',2,'9/4/1991',1,'5 11','111 kg.','Roman Catholic',1,'+63 885 236 5156','212-7700.','09-4680837-4','09-4680837-4','577-585-645','46-217170882-8','International Paper Co.',NULL,2,NULL,NULL,'Brock Trasport','09559766378'),(281,'Monet','Carballo','Aragon',2,'9/15/1994',1,'5 11','107 kg.','Islam',1,'+63 793 469 7697','212-4514.','09-9379676-3','09-9379676-3','863-135-951','54-333515666-0','VF Corporation',NULL,2,NULL,NULL,'Tanner Pazos','09608455251'),(282,'Aracelis','Barrera','Carrion',2,'9/1/1979',1,'5 11','92 kg.','Roman Catholic',1,'+63 186 285 8868','212-5701.','09-5361218-5','09-5361218-5','315-904-117','38-988695418-2','Seaboard Corp',NULL,2,NULL,NULL,'Domingo Yerhot','09774981283'),(283,'Louise','Montero','Clemente',2,'1/25/1997',1,'5 11','109 kg.','Roman Catholic',1,'+63 678 733 9826','212-3541.','09-6669329-8','09-6669329-8','347-227-937','88-878249151-4','Waste Management Inc',NULL,3,NULL,NULL,'Amado Labarbara','09134986416'),(284,'Kia','Zamora','Villa',2,'11/22/1975',1,'5 11','96 kg.','Islam',1,'+63 800 933 5242','212-5574.','09-9093133-2','09-9093133-2','384-951-654','86-677682641-0','Anheuser-Busch Companies, Inc.',NULL,2,NULL,NULL,'Sherman Tapper','09829754670'),(285,'Golden','Caro','Castellano',2,'2/18/1977',1,'5 11','102 kg.','Islam',1,'+63 659 599 1910','212-9461.','09-3908852-7','09-3908852-7','795-961-430','75-882862985-1','Louisiana-Pacific Corporation',NULL,3,NULL,NULL,'William Honer','09568003492'),(286,'Kathaleen','Plaza','Carrera',2,'11/25/1973',1,'5 11','119 kg.','Roman Catholic',1,'+63 398 459 9121','212-7624.','09-7586494-7','09-7586494-7','427-947-816','61-435632011-8','Walgreen Co',NULL,3,NULL,NULL,'Jonathon Salkeld','09304226028'),(287,'Pansy','Guillen','Hernando',2,'9/7/1986',1,'5 11','104 kg.','Roman Catholic',1,'+63 542 340 2845','212-6704.','09-8812526-7','09-8812526-7','717-222-201','69-476839971-8','NSTAR',NULL,2,NULL,NULL,'Coleman Sobol','09602823422'),(288,'Lida','Soler','Cordoba',2,'9/22/1982',1,'5 11','80 kg.','Roman Catholic',1,'+63 321 103 5754','212-4256.','09-2697130-7','09-2697130-7','238-294-163','60-202406832-3','Anthem, Inc.',NULL,2,NULL,NULL,'Delmar Heimlich','09122947537'),(289,'Jazmine','Miranda','Rosa',2,'8/5/1981',1,'5 11','78 kg.','Roman Catholic',1,'+63 152 122 7173','212-8073.','09-5800552-8','09-5800552-8','902-935-706','22-948169522-8','UAL Corporation',NULL,3,NULL,NULL,'Joel Brame','09984060856'),(290,'Cherilyn','Chen','Andreu',2,'3/14/1984',1,'5 11','93 kg.','Protestant',1,'+63 725 380 7948','212-3185.','09-8353712-6','09-8353712-6','931-787-773','58-885875305-8','Noble Energy Inc',NULL,2,NULL,NULL,'Gerry Widman','09337028430'),(291,'Gidget','Ferreira','Caceres',2,'11/4/1980',1,'5 11','103 kg.','Protestant',1,'+63 754 578 3440','212-8463.','09-2297437-5','09-2297437-5','783-790-935','41-133847653-4','Dollar General Corporation',NULL,3,NULL,NULL,'Duncan Vichi','09205186448'),(292,'Xiao','Vera','Calero',2,'9/11/1983',1,'5 11','101 kg.','Protestant',1,'+63 493 103 2822','212-4272.','09-6993960-1','09-6993960-1','460-913-155','12-177276220-7','Bank of America Corporation',NULL,3,NULL,NULL,'Ed Hadley','09414844278'),(293,'Ola','Guerra','Correa',2,'9/23/1988',1,'5 11','103 kg.','Islam',1,'+63 938 604 6961','212-3668.','09-1615924-0','09-1615924-0','717-541-326','57-551642497-6','Murphy Oil Corporation',NULL,2,NULL,NULL,'Norman Gromer','09133420696'),(294,'Addie','Serrano','Mohamed',2,'1/15/1973',1,'5 11','75 kg.','Protestant',1,'+63 354 983 4476','212-6150.','09-5295908-4','09-5295908-4','827-914-918','62-396202534-1','Comdisco Inc.',NULL,2,NULL,NULL,'Cory Tauras','09480658595'),(295,'Gene','Ros','Cobo',2,'8/10/1985',1,'5 11','75 kg.','Protestant',1,'+63 265 386 7550','212-6506.','09-8888468-6','09-8888468-6','296-483-133','96-625430334-7','Halliburton Co.',NULL,2,NULL,NULL,'Rupert Kerens','09758111240'),(296,'Edwina','Gimenez','Cardenas',2,'8/11/1976',1,'5 11','93 kg.','Roman Catholic',1,'+63 710 365 6383','212-3493.','09-4222469-3','09-4222469-3','491-335-950','31-511938443-6','Bausch & Lomb Incorporated',NULL,2,NULL,NULL,'Trey Nonamaker','09299180867'),(297,'Madaline','Navas','Ferreira',2,'7/14/1975',1,'5 11','111 kg.','Roman Catholic',1,'+63 387 653 2873','212-2316.','09-1412531-8','09-1412531-8','799-750-873','70-734643384-3','Dun & Bradstreet Inc.',NULL,2,NULL,NULL,'Chi Cross','09483919450'),(298,'Charline','Ramon','Alcaraz',2,'4/3/1974',1,'5 11','118 kg.','Roman Catholic',1,'+63 517 883 5476','212-1090.','09-5807183-1','09-5807183-1','742-795-458','98-372273267-4','Compass Bancshares Inc',NULL,3,NULL,NULL,'Walter Luman','09246965759'),(299,'Shaunda','Arenas','Juarez',2,'3/26/1994',1,'5 11','115 kg.','Islam',1,'+63 519 137 7714','212-1717.','09-7231265-4','09-7231265-4','334-866-161','71-858179933-2','National Oilwell Inc',NULL,3,NULL,NULL,'Rex Creedon','09638836136'),(300,'Yuette','Ortega','Velazquez',2,'3/14/1975',1,'5 11','102 kg.','Roman Catholic',1,'+63 942 776 3798','212-3037.','09-1408425-8','09-1408425-8','895-423-606','84-376926996-4','Legg Mason Inc.',NULL,3,NULL,NULL,'Rufus Gragson','09895157308'),(301,'Marcie','Puig','Domenech',2,'9/19/1992',1,'5 11','106 kg.','Roman Catholic',1,'+63 107 181 9657','212-8428.','09-7249507-1','09-7249507-1','752-864-373','84-924103900-3','Jack In The Box Inc.',NULL,3,NULL,NULL,'Shaun Solares','09330533124'),(302,'Elna','Benitez','Sola',2,'8/15/1982',1,'5 11','77 kg.','Protestant',1,'+63 742 940 4941','212-8187.','09-1296400-0','09-1296400-0','214-798-617','86-475954046-2','Southwest Gas Corp',NULL,2,NULL,NULL,'Virgil Rosner','09636881578'),(303,'Terrilyn','Arroyo','Chacon',2,'8/13/1989',1,'5 11','85 kg.','Protestant',1,'+63 953 947 9272','212-4848.','09-3294998-2','09-3294998-2','548-296-905','88-666992376-6','Hub Group Inc.',NULL,3,NULL,NULL,'Scotty Grinter','09233741346'),(304,'Ginette','Domingo','Riera',2,'4/7/1985',1,'5 11','92 kg.','Roman Catholic',1,'+63 795 422 1454','212-8605.','09-9541064-6','09-9541064-6','618-639-453','73-337793035-3','Home Depot Inc.',NULL,3,NULL,NULL,'Salvatore Kiko','09748588505'),(305,'Suellen','Rueda','Saavedra',2,'4/7/1974',1,'5 11','87 kg.','Protestant',1,'+63 839 684 7485','212-8815.','09-3372947-8','09-3372947-8','443-919-921','65-933951140-1','ITT Industries Inc.',NULL,3,NULL,NULL,'Ervin Litster','09542516762'),(306,'Abbey','Dela Cruz','Toledo',2,'9/7/1987',1,'5 11','75 kg.','Islam',1,'+63 728 529 3265','212-3691.','09-9017791-3','09-9017791-3','608-368-801','63-535063560-4','Perini Corp',NULL,3,NULL,NULL,'Howard Savala','09543591463'),(307,'Paulina','Galan','Llorente',2,'2/15/1980',1,'5 11','103 kg.','Islam',1,'+63 327 321 9209','212-7899.','09-6116762-5','09-6116762-5','398-719-852','23-766502873-0','Allergan, Inc.',NULL,2,NULL,NULL,'Micheal Marichalar','09421002113'),(308,'Sacha','Rubio','Zapata',2,'7/8/1989',1,'5 11','97 kg.','Roman Catholic',1,'+63 865 887 3523','212-6403.','09-6373719-0','09-6373719-0','224-810-806','87-127021031-6','Exide Technologies',NULL,3,NULL,NULL,'Marcos Kulick','09571626455'),(309,'Lavonne','Vega','Moral',2,'11/13/1979',1,'5 11','93 kg.','Roman Catholic',1,'+63 200 271 7919','212-9229.','09-3601252-5','09-3601252-5','232-432-964','62-827498996-8','R.J. Reynolds Tobacco Company',NULL,2,NULL,NULL,'Normand Basinski','09337887355'),(310,'Latrisha','Espinosa','Vela',2,'3/6/1979',1,'5 11','97 kg.','Islam',1,'+63 721 756 7692','212-8659.','09-7359364-1','09-7359364-1','310-266-150','73-344848019-2','Kelly Services Inc.',NULL,3,NULL,NULL,'Emil Roblodowski','09478793861'),(311,'Margery','Castro','Salgado',2,'8/13/1979',1,'5 11','78 kg.','Protestant',1,'+63 208 193 3660','212-4240.','09-2760056-3','09-2760056-3','865-454-874','94-137191082-0','Dreyer\'s Grand Ice Cream, Inc.',NULL,3,NULL,NULL,'Clarence Atchley','09875922737'),(312,'Joyce','Conde','Carbonell',2,'1/7/1974',1,'5 11','96 kg.','Islam',1,'+63 572 480 3344','212-3332.','09-3123496-5','09-3123496-5','919-416-471','45-447694292-4','Valspar Corporation',NULL,2,NULL,NULL,'Johnnie Catalli','09306371664'),(313,'Deon','Torre','Villegas',2,'9/25/1988',1,'5 11','91 kg.','Protestant',1,'+63 607 390 4993','212-2084.','09-2441232-6','09-2441232-6','462-826-607','26-442422743-3','Polo Ralph Lauren Corp',NULL,3,NULL,NULL,'Lonny Strandberg','09545789913'),(314,'Mozella','Ayala','Arribas',2,'8/10/1980',1,'5 11','78 kg.','Protestant',1,'+63 129 116 1613','212-6941.','09-7835788-7','09-7835788-7','384-675-825','92-381805218-1','Worthington Industries Inc',NULL,2,NULL,NULL,'Isidro Pierdon','09195768936'),(315,'Cami','Navarro','Prado',2,'4/19/1993',1,'5 11','109 kg.','Roman Catholic',1,'+63 121 418 8836','212-6724.','09-4388884-2','09-4388884-2','434-488-249','92-417134919-4','Mellon Financial Corporation',NULL,3,NULL,NULL,'Bobby Goelz','09525252896'),(316,'Melonie','Cuenca','Alfonso',2,'5/13/1985',1,'5 11','119 kg.','Protestant',1,'+63 160 405 5816','212-7738.','09-8820700-5','09-8820700-5','271-936-145','31-375157395-2','Swift Transportation, Co., Inc',NULL,2,NULL,NULL,'Gerry Leming','09854611223'),(317,'Olimpia','Cruz','Requena',2,'9/5/1989',1,'5 11','110 kg.','Roman Catholic',1,'+63 519 460 7089','212-9961.','09-2743686-1','09-2743686-1','381-677-177','43-794938658-0','Marsh & McLennan Companies Inc.',NULL,3,NULL,NULL,'Kim Contes','09173465393'),(318,'Antonetta','Valencia','Ayala',2,'11/6/1985',1,'5 11','78 kg.','Islam',1,'+63 127 392 3151','212-1426.','09-6600989-5','09-6600989-5','467-541-614','95-399373249-1','Thomas & Betts Corporation',NULL,3,NULL,NULL,'Dane Dorset','09320218655'),(319,'Detra','Sevilla','Pelaez',2,'5/8/1985',1,'5 11','83 kg.','Roman Catholic',1,'+63 376 977 4773','212-9009.','09-7072678-0','09-7072678-0','181-289-804','97-796435210-7','Frontier Oil Corp',NULL,3,NULL,NULL,'Jamaal Buckley','09515173638'),(320,'Joshua','Lucas','Sevilla',2,'2/25/1983',1,'5 11','87 kg.','Roman Catholic',1,'+63 768 286 6401','212-5950.','09-1214644-8','09-1214644-8','932-220-504','48-366780362-2','Alliant Energy Corporation',NULL,3,NULL,NULL,'Quintin Bundschuh','09953141307'),(321,'Karleen','Aguado','Font',2,'8/10/1977',1,'5 11','104 kg.','Roman Catholic',1,'+63 703 468 2562','212-8906.','09-2154538-3','09-2154538-3','685-380-458','50-550677508-8','Delphi Corp.',NULL,2,NULL,NULL,'Rudy Benischek','09269225247'),(322,'Babette','Sancho','Barrios',2,'11/4/1983',1,'5 11','77 kg.','Protestant',1,'+63 321 265 8486','212-8299.','09-5334944-4','09-5334944-4','459-816-263','12-570199745-8','AMC Entertainment Inc.',NULL,3,NULL,NULL,'Hassan Kalmbach','09450240041'),(323,'Magen','Millan','Luis',2,'3/23/1995',1,'5 11','104 kg.','Protestant',1,'+63 909 391 6937','212-8129.','09-1305917-0','09-1305917-0','751-572-424','57-515643788-2','First National of Nebraska Inc.',NULL,2,NULL,NULL,'Scotty Sebastian','09643792136'),(324,'Carrol','Mena','Carballo',2,'11/20/1975',1,'5 11','91 kg.','Islam',1,'+63 154 981 4289','212-3205.','09-8325953-6','09-8325953-6','845-159-663','46-616141053-8','Coca-Cola Enterprises Inc.',NULL,3,NULL,NULL,'Walter Berteau','09665715627'),(325,'Katheleen','Grau','Baginda',2,'11/26/1989',1,'5 11','88 kg.','Protestant',1,'+63 700 766 9863','212-6896.','09-6864984-2','09-6864984-2','969-301-409','14-863926042-2','Anixter International Inc.',NULL,3,NULL,NULL,'Milford Overmyer','09696061343'),(326,'Dennis','Aguilar','Olivares',2,'4/9/1983',1,'5 11','97 kg.','Islam',1,'+63 271 173 1878','212-3569.','09-5541211-0','09-5541211-0','485-559-126','51-198815313-1','Diebold Incorporated',NULL,3,NULL,NULL,'Terry Kurz','09890130807'),(327,'Marybelle','Luna','Esteve',2,'1/15/1993',1,'5 11','80 kg.','Roman Catholic',1,'+63 396 857 6728','212-8730.','09-9511520-3','09-9511520-3','380-617-257','69-619137014-0','Equity Office Properties Trust',NULL,3,NULL,NULL,'Loyd Balish','09765882444'),(328,'Karyn','Saiz','Marques',2,'3/6/1980',1,'5 11','101 kg.','Roman Catholic',1,'+63 652 656 9318','212-4002.','09-1199389-3','09-1199389-3','619-243-267','13-435249399-0','SLM Corporation',NULL,3,NULL,NULL,'Isidro Amons','09455724515'),(329,'Ludivina','Mateos','Da',2,'3/2/1991',1,'5 11','83 kg.','Roman Catholic',1,'+63 414 870 6073','212-3005.','09-5032351-0','09-5032351-0','875-262-967','40-180795115-0','Nordstrom Inc',NULL,2,NULL,NULL,'Thanh Warriner','09814361311'),(330,'Blondell','Clemente','Silva',2,'1/11/1985',1,'5 11','77 kg.','Roman Catholic',1,'+63 367 991 6262','212-3960.','09-5810194-0','09-5810194-0','825-754-247','71-750548270-5','Colgate-Palmolive Co.',NULL,3,NULL,NULL,'Yong Mensalvas','09853166963'),(331,'Caroll','Morales','Solis',2,'4/19/1972',1,'5 11','92 kg.','Roman Catholic',1,'+63 272 562 4722','212-4685.','09-8548674-5','09-8548674-5','416-606-714','46-540016232-3','Weyerhauser Company',NULL,3,NULL,NULL,'Lou Osendorf','09253385738'),(332,'Shavonne','Salazar','Pinto',2,'11/19/1996',1,'5 11','101 kg.','Islam',1,'+63 402 645 8866','212-6544.','09-4028486-1','09-4028486-1','335-768-879','79-709674692-7','Caterpillar Inc.',NULL,3,NULL,NULL,'Salvatore Linders','09148397820'),(333,'Despina','Gonzalez','Camara',2,'3/4/1975',1,'5 11','105 kg.','Islam',1,'+63 494 730 5937','212-3160.','09-1275785-0','09-1275785-0','836-455-892','90-459451468-4','ServiceMaster Co',NULL,2,NULL,NULL,'Gilbert Deist','09953303206'),(334,'Marquita','Aguirre','Grau',2,'5/6/1988',1,'5 11','119 kg.','Protestant',1,'+63 545 382 9668','212-7770.','09-5172158-3','09-5172158-3','894-788-277','32-324865760-2','Kellogg Company',NULL,3,NULL,NULL,'Chad Delcamp','09920919813'),(335,'Leana','Sierra','Quintero',2,'3/20/1986',1,'5 11','89 kg.','Roman Catholic',1,'+63 820 220 8882','212-6707.','09-7929774-2','09-7929774-2','232-134-729','13-801525280-0','TransMontaigne Inc',NULL,2,NULL,NULL,'Bradford Toles','09682068948'),(336,'Dwana','Lara','Salinas',2,'2/1/1991',1,'5 11','79 kg.','Protestant',1,'+63 637 281 6201','212-8788.','09-7209528-8','09-7209528-8','806-522-626','71-724728042-0','Adolph Coors Company',NULL,2,NULL,NULL,'Abdul Pritzel','09282344807'),(337,'Miguelina','La','Bosch',2,'9/12/1978',1,'5 11','80 kg.','Protestant',1,'+63 601 386 6171','212-7426.','09-3135460-8','09-3135460-8','562-481-701','88-769754221-1','Unified Western Grocers Inc',NULL,2,NULL,NULL,'Ken Barthel','09321834775'),(338,'Liz','Vargas','Perea',2,'4/8/1980',1,'5 11','101 kg.','Islam',1,'+63 522 486 5137','212-1524.','09-6203402-1','09-6203402-1','268-250-530','14-617944898-5','Terex Corp',NULL,3,NULL,NULL,'Buford Gelner','09508755093'),(339,'Virginia','Bermejo','Pineda',2,'11/18/1978',1,'5 11','112 kg.','Protestant',1,'+63 115 947 8961','212-2756.','09-6314311-2','09-6314311-2','878-915-539','84-873267031-0','Sempra Energy',NULL,2,NULL,NULL,'Frederick Eron','09784560013'),(340,'Tomika','Delgado','Cruz',2,'2/19/1988',1,'5 11','114 kg.','Roman Catholic',1,'+63 425 311 8003','212-3385.','09-7587076-7','09-7587076-7','234-244-479','82-884575828-8','Texas Industries Inc.',NULL,2,NULL,NULL,'Mervin Truchan','09965413573'),(341,'Roxana','Mesa','Marrero',2,'5/13/1994',1,'5 11','77 kg.','Protestant',1,'+63 475 341 7827','212-8016.','09-4638375-1','09-4638375-1','586-660-702','24-728910230-6','CellStar Corp.',NULL,2,NULL,NULL,'Nathanael Hitt','09337973863'),(342,'Matilde','Ferrer','Ballester',2,'4/16/1991',1,'5 11','93 kg.','Islam',1,'+63 260 798 6207','212-6242.','09-7328656-7','09-7328656-7','658-978-678','30-964574771-4','Forest Laboratories Inc.',NULL,2,NULL,NULL,'Brock Lukes','09652722855'),(343,'Leanora','Sanchez','Cantero',2,'9/14/1987',1,'5 11','76 kg.','Islam',1,'+63 803 694 7741','212-7602.','09-9564559-7','09-9564559-7','155-438-189','57-591188992-8','USA Interactive',NULL,3,NULL,NULL,'Carol Abdur','09635283893'),(344,'Shavon','Montes','Castilla',2,'8/7/1974',1,'5 11','90 kg.','Islam',1,'+63 573 625 2605','212-6133.','09-7521009-6','09-7521009-6','305-455-899','80-267442538-4','USA Interactive',NULL,2,NULL,NULL,'Rupert Emmerich','09282030251'),(345,'Erna','Ballester','Sanchis',2,'4/7/1992',1,'5 11','85 kg.','Roman Catholic',1,'+63 931 295 5549','212-9202.','09-3831176-8','09-3831176-8','157-511-209','89-300882249-3','Computer Associates International Inc.',NULL,3,NULL,NULL,'Lou Dillaman','09778440449'),(346,'Mercedes','Luque','Dela Cruz',2,'4/19/1972',1,'5 11','90 kg.','Islam',1,'+63 614 461 7485','212-1287.','09-5591246-3','09-5591246-3','763-202-811','86-780569864-4','Newell Rubbermaid Inc',NULL,3,NULL,NULL,'Normand Wogan','09562572247');
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
-- Table structure for table `holiday`
--

DROP TABLE IF EXISTS `holiday`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `holiday` (
  `hid` int(11) NOT NULL AUTO_INCREMENT,
  `datestart` varchar(45) DEFAULT NULL,
  `dateend` varchar(45) DEFAULT NULL,
  `type` int(1) DEFAULT NULL,
  `ds_MM` int(2) DEFAULT NULL,
  `ds_dd` int(2) DEFAULT NULL,
  `ds_yyyy` int(4) DEFAULT NULL,
  `de_MM` int(2) DEFAULT NULL,
  `de_dd` int(2) DEFAULT NULL,
  `de_yyyy` int(4) DEFAULT NULL,
  `desc` varchar(120) DEFAULT NULL,
  `status` int(1) DEFAULT '1',
  PRIMARY KEY (`hid`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `holiday`
--

LOCK TABLES `holiday` WRITE;
/*!40000 ALTER TABLE `holiday` DISABLE KEYS */;
/*!40000 ALTER TABLE `holiday` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `incidentreport`
--

LOCK TABLES `incidentreport` WRITE;
/*!40000 ALTER TABLE `incidentreport` DISABLE KEYS */;
/*!40000 ALTER TABLE `incidentreport` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `loginhistory`
--

DROP TABLE IF EXISTS `loginhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `loginhistory` (
  `lid` int(11) NOT NULL AUTO_INCREMENT,
  `uid` int(11) DEFAULT NULL,
  `logintime` datetime DEFAULT NULL,
  PRIMARY KEY (`lid`),
  KEY `fk_login_user_idx` (`uid`),
  CONSTRAINT `fk_login_user` FOREIGN KEY (`uid`) REFERENCES `account` (`accid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=209 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loginhistory`
--

LOCK TABLES `loginhistory` WRITE;
/*!40000 ALTER TABLE `loginhistory` DISABLE KEYS */;
INSERT INTO `loginhistory` VALUES (1,3,'2017-08-09 16:55:42'),(2,3,'2017-08-09 17:23:24'),(3,3,'2017-08-09 22:07:04'),(4,3,'2017-08-09 22:25:29'),(5,3,'2017-08-09 22:27:50'),(6,3,'2017-08-09 22:29:07'),(7,3,'2017-08-09 22:39:40'),(8,3,'2017-08-09 22:40:23'),(9,3,'2017-08-09 22:54:03'),(10,3,'2017-08-09 22:54:59'),(11,3,'2017-08-09 22:55:16'),(12,3,'2017-08-09 22:55:32'),(13,3,'2017-08-09 23:05:53'),(14,3,'2017-08-09 23:15:28'),(15,3,'2017-08-09 23:26:13'),(16,3,'2017-08-09 23:30:33'),(17,3,'2017-08-09 23:31:39'),(18,3,'2017-08-09 23:38:01'),(19,3,'2017-08-09 23:46:19'),(20,3,'2017-08-09 23:50:58'),(21,3,'2017-08-10 12:57:39'),(22,3,'2017-08-10 13:01:24'),(23,3,'2017-08-10 13:49:32'),(24,3,'2017-08-10 13:50:02'),(25,3,'2017-08-10 13:55:07'),(26,3,'2017-08-10 13:57:53'),(27,3,'2017-08-10 14:01:14'),(28,3,'2017-08-10 14:04:45'),(29,3,'2017-08-10 14:07:53'),(30,3,'2017-08-10 14:09:06'),(31,3,'2017-08-10 14:11:25'),(32,3,'2017-08-10 14:13:07'),(33,3,'2017-08-10 14:15:15'),(34,3,'2017-08-10 14:17:42'),(35,3,'2017-08-10 17:31:18'),(36,3,'2017-08-10 17:34:50'),(37,3,'2017-08-10 17:48:05'),(38,3,'2017-08-11 15:01:56'),(39,3,'2017-08-11 15:03:54'),(40,3,'2017-08-25 15:04:50'),(41,3,'2017-08-12 17:38:56'),(42,3,'2017-08-12 17:40:12'),(43,3,'2017-08-12 17:44:38'),(44,3,'2017-08-12 17:50:33'),(45,3,'2017-08-12 17:53:24'),(46,3,'2017-08-12 17:54:00'),(47,3,'2017-08-12 17:54:29'),(48,3,'2017-08-12 17:57:29'),(49,3,'2017-08-12 18:02:18'),(50,3,'2017-08-30 18:03:26'),(51,3,'2017-08-30 18:07:11'),(52,3,'2017-08-12 18:13:39'),(53,3,'2017-08-30 18:16:25'),(54,3,'2017-08-12 19:31:46'),(55,3,'2017-08-12 21:01:19'),(56,3,'2017-08-13 17:51:02'),(57,3,'2017-08-13 17:52:30'),(58,3,'2017-08-13 17:53:23'),(59,3,'2017-08-13 18:05:22'),(60,3,'2017-08-13 18:06:56'),(61,3,'2017-08-13 18:11:14'),(62,3,'2017-08-13 18:28:58'),(63,3,'2017-08-13 18:30:50'),(64,3,'2017-08-14 00:09:37'),(65,3,'2017-08-14 01:44:11'),(66,3,'2017-08-14 01:47:37'),(67,3,'2017-08-14 01:51:44'),(68,3,'2017-08-14 01:58:07'),(69,3,'2017-08-14 02:10:44'),(70,3,'2017-08-14 02:12:08'),(71,3,'2017-08-14 02:14:51'),(72,3,'2017-08-14 02:18:34'),(73,3,'2017-08-14 02:20:27'),(74,3,'2017-08-14 02:21:34'),(75,3,'2017-08-14 02:24:34'),(76,3,'2017-08-14 16:22:14'),(77,3,'2017-08-14 16:44:32'),(78,3,'2017-08-14 16:52:39'),(79,3,'2017-08-14 16:53:50'),(80,3,'2017-08-14 16:54:34'),(81,3,'2017-08-14 16:57:04'),(82,3,'2017-08-14 16:58:21'),(83,3,'2017-08-14 17:01:14'),(84,3,'2017-08-14 17:02:03'),(85,3,'2017-08-14 17:07:38'),(86,3,'2017-08-14 17:08:54'),(87,3,'2017-08-14 17:11:57'),(88,3,'2017-08-14 17:20:29'),(89,3,'2017-08-14 17:22:48'),(90,3,'2017-08-14 17:23:11'),(91,3,'2017-08-14 17:26:03'),(92,3,'2017-08-14 17:27:04'),(93,3,'2017-08-14 17:31:37'),(94,3,'2017-08-14 17:35:15'),(95,3,'2017-08-14 17:37:23'),(96,3,'2017-08-14 17:42:56'),(97,3,'2017-08-14 17:46:15'),(98,3,'2017-08-14 17:47:34'),(99,3,'2017-08-23 17:50:12'),(100,3,'2017-08-14 20:39:09'),(101,3,'2017-08-14 20:42:10'),(102,3,'2017-08-14 20:43:28'),(103,3,'2017-08-14 20:44:58'),(104,3,'2017-08-14 20:46:14'),(105,3,'2017-08-14 20:47:25'),(106,3,'2017-08-14 20:48:17'),(107,3,'2017-08-14 22:22:03'),(108,3,'2017-08-14 22:23:53'),(109,3,'2017-08-15 00:47:48'),(110,3,'2017-08-15 14:21:08'),(111,3,'2017-08-15 14:27:07'),(112,3,'2017-08-15 14:27:27'),(113,3,'2017-08-15 14:29:38'),(114,3,'2017-08-15 15:40:23'),(115,3,'2017-08-15 16:04:07'),(116,3,'2017-08-15 22:40:45'),(117,3,'2017-08-15 22:42:02'),(118,3,'2017-08-15 22:45:58'),(119,3,'2017-08-16 19:21:31'),(120,3,'2017-08-17 13:36:02'),(121,3,'2017-08-17 14:34:47'),(122,3,'2017-08-17 15:44:49'),(123,3,'2017-08-17 15:48:12'),(124,3,'2017-08-17 15:57:02'),(125,3,'2017-08-17 15:57:59'),(126,3,'2017-08-17 16:10:40'),(127,3,'2017-08-17 16:14:56'),(128,3,'2017-08-17 16:19:27'),(129,3,'2017-08-17 16:21:06'),(130,3,'2017-08-17 16:25:50'),(131,3,'2017-08-17 16:27:35'),(132,3,'2017-08-17 16:29:07'),(133,3,'2017-08-17 16:37:04'),(134,3,'2017-08-17 16:37:33'),(135,3,'2017-08-17 16:42:05'),(136,3,'2017-08-17 16:49:15'),(137,3,'2017-08-17 16:50:54'),(138,3,'2017-08-17 17:24:13'),(139,3,'2017-08-17 22:02:51'),(140,3,'2017-08-18 16:26:38'),(141,3,'2017-08-18 16:27:25'),(142,3,'2017-08-18 16:28:08'),(143,3,'2017-08-18 17:22:09'),(144,3,'2017-08-18 17:44:42'),(145,3,'2017-08-18 17:55:09'),(146,3,'2017-08-18 17:55:31'),(147,3,'2017-08-18 18:01:33'),(148,3,'2017-08-18 18:07:52'),(149,3,'2017-08-18 18:09:07'),(150,3,'2017-08-18 18:09:46'),(151,3,'2017-08-18 18:13:19'),(152,3,'2017-08-18 18:14:54'),(153,3,'2017-08-18 18:19:16'),(154,3,'2017-08-18 18:23:37'),(155,3,'2017-08-18 18:48:37'),(156,3,'2017-08-18 18:51:27'),(157,3,'2017-09-18 18:58:11'),(158,3,'2017-09-18 22:37:48'),(159,3,'2017-08-18 22:43:36'),(160,3,'2017-08-18 22:44:50'),(161,3,'2017-08-18 22:58:07'),(162,3,'2017-08-18 23:04:02'),(163,3,'2017-08-18 23:26:51'),(164,3,'2017-08-18 23:42:23'),(165,3,'2017-08-20 13:28:47'),(166,3,'2017-08-20 13:31:21'),(167,3,'2017-08-20 13:44:14'),(168,3,'2017-08-20 13:46:49'),(169,3,'2017-08-20 13:48:03'),(170,3,'2017-08-20 13:53:03'),(171,3,'2017-08-20 13:55:57'),(172,3,'2017-08-20 14:00:19'),(173,3,'2017-08-20 14:01:29'),(174,3,'2017-08-20 14:10:14'),(175,3,'2017-08-20 14:12:27'),(176,3,'2017-08-20 14:14:13'),(177,3,'2017-08-20 14:14:54'),(178,3,'2017-08-20 14:16:53'),(179,3,'2017-08-20 14:21:50'),(180,3,'2017-08-20 14:27:28'),(181,3,'2017-08-20 14:35:28'),(182,3,'2017-08-20 14:58:37'),(183,3,'2017-08-20 14:59:59'),(184,3,'2017-08-20 15:00:35'),(185,3,'2017-08-20 15:03:25'),(186,3,'2017-08-20 15:06:10'),(187,3,'2017-08-20 15:18:15'),(188,3,'2017-08-20 15:24:11'),(189,3,'2017-08-20 15:24:43'),(190,3,'2017-08-20 15:26:37'),(191,3,'2017-08-20 15:32:56'),(192,3,'2017-08-20 15:46:13'),(193,3,'2017-08-20 16:12:27'),(194,3,'2017-08-20 16:14:27'),(195,3,'2017-08-22 10:22:18'),(196,3,'2017-08-22 10:33:38'),(197,3,'2017-08-22 10:34:12'),(198,3,'2017-08-22 10:34:55'),(199,3,'2017-08-22 10:36:12'),(200,3,'2017-08-22 10:45:19'),(201,3,'2017-08-22 10:51:36'),(202,3,'2017-08-22 10:52:29'),(203,3,'2017-08-22 10:55:08'),(204,3,'2017-08-22 10:57:41'),(205,3,'2017-08-22 10:59:40'),(206,3,'2017-08-22 15:35:19'),(207,3,'2017-08-22 15:41:10'),(208,3,'2017-08-23 17:30:18');
/*!40000 ALTER TABLE `loginhistory` ENABLE KEYS */;
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
  `PID` int(11) NOT NULL AUTO_INCREMENT,
  `GID` int(11) DEFAULT NULL,
  `month` int(2) DEFAULT NULL,
  `period` int(2) DEFAULT NULL,
  `year` int(4) DEFAULT NULL,
  `rates_id` int(11) DEFAULT NULL,
  `cashbond` decimal(7,2) DEFAULT NULL,
  `thirteenth` decimal(7,2) DEFAULT NULL,
  `cola` decimal(7,2) DEFAULT NULL,
  `sss` decimal(7,2) DEFAULT NULL,
  `pagibig` decimal(7,2) DEFAULT NULL,
  `philhealth` decimal(7,2) DEFAULT NULL,
  `withtax` decimal(7,2) DEFAULT NULL,
  `cashadv` decimal(7,2) DEFAULT '0.00',
  `emergencyallowance` decimal(7,2) DEFAULT NULL,
  `totalsummary_serializable` blob,
  `hc_serializable` blob,
  `lastmodified` timestamp NULL DEFAULT NULL,
  `pstatus` int(1) DEFAULT NULL,
  `basicpayhourly` decimal(7,2) DEFAULT NULL,
  `approvedby` int(11) DEFAULT NULL,
  PRIMARY KEY (`PID`),
  UNIQUE KEY `py_unq_idx` (`GID`,`year`,`month`,`period`),
  KEY `Payroll-Guards_idx` (`GID`),
  CONSTRAINT `Payroll-Guards` FOREIGN KEY (`GID`) REFERENCES `guards` (`GID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payroll`
--

LOCK TABLES `payroll` WRITE;
/*!40000 ALTER TABLE `payroll` DISABLE KEYS */;
INSERT INTO `payroll` VALUES (1,161,8,2,2017,3,150.00,0.00,60.00,363.30,100.00,120.00,470.83,100.00,10000.00,'AAEAAAD/////AQAAAAAAAAAEAQAAAO8BU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuRGljdGlvbmFyeWAyW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtNU0FNSVNVc2VySW50ZXJmYWNlLkhvdXJDb3N0UGFpciwgcnlsZGIuc3FsdG9vbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsXV0EAAAAB1ZlcnNpb24IQ29tcGFyZXIISGFzaFNpemUNS2V5VmFsdWVQYWlycwADAAMIkgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5HZW5lcmljRXF1YWxpdHlDb21wYXJlcmAxW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQjzAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLktleVZhbHVlUGFpcmAyW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtNU0FNSVNVc2VySW50ZXJmYWNlLkhvdXJDb3N0UGFpciwgcnlsZGIuc3FsdG9vbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsXV1bXRQAAAAJAgAAABEAAAAJAwAAAAQCAAAAkgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5HZW5lcmljRXF1YWxpdHlDb21wYXJlcmAxW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQAAAAAHAwAAAAABAAAACgAAAAPxAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLktleVZhbHVlUGFpcmAyW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtNU0FNSVNVc2VySW50ZXJmYWNlLkhvdXJDb3N0UGFpciwgcnlsZGIuc3FsdG9vbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsXV0MBQAAAEVyeWxkYi5zcWx0b29scywgVmVyc2lvbj0xLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPW51bGwE/P////EBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuS2V5VmFsdWVQYWlyYDJbW1N5c3RlbS5TdHJpbmcsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV0sW01TQU1JU1VzZXJJbnRlcmZhY2UuSG91ckNvc3RQYWlyLCByeWxkYi5zcWx0b29scywgVmVyc2lvbj0xLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPW51bGxdXQIAAAADa2V5BXZhbHVlAQQgTVNBTUlTVXNlckludGVyZmFjZS5Ib3VyQ29zdFBhaXIFAAAABgYAAAAKbm9ybWFsX25zdQkHAAAAAfj////8////BgkAAAAKbm9ybWFsX3N1bgkKAAAAAfX////8////BgwAAAALcmVndWxhcl9uc3UJDQAAAAHy/////P///wYPAAAAC3JlZ3VsYXJfc3VuCRAAAAAB7/////z///8GEgAAAAtzcGVjaWFsX25zdQkTAAAAAez////8////BhUAAAALc3BlY2lhbF9zdW4JFgAAAAHp/////P///wYYAAAAB3NwZWNpYWwJGQAAAAHm/////P///wYbAAAABm5vcm1hbAkcAAAAAeP////8////Bh4AAAAHcmVndWxhcgkfAAAAAeD////8////BiEAAAAFdG90YWwJIgAAAAUHAAAAIE1TQU1JU1VzZXJJbnRlcmZhY2UuSG91ckNvc3RQYWlyAwAAAARob3VyBGNvc3QFdG90YWwAAAAGBgYFAAAAAAAAAAAAAAAAAAAAgJBzQAAAAAAAAAAAAQoAAAAHAAAAAAAAAAAAAADNzMzMDG95QAAAAAAAAAAAAQ0AAAAHAAAAAAAAAAAAAAAzMzMzIwiFQAAAAAAAAAAAARAAAAAHAAAAAAAAAAAAAADNzMzMDG+JQAAAAAAAAAAAARMAAAAHAAAAAAAAAAAAAAAAAAAAQBF4QAAAAAAAAAAAARYAAAAHAAAAAAAAAAAAAAAAAAAAwFh9QAAAAAAAAAAAARkAAAAHAAAAAAAAAAAAAAAAAAAAALWKQAAAAAAAAAAAARwAAAAHAAAAAAAAAAAAAABmZmZmxn+GQAAAAAAAAAAAAR8AAAAHAAAAAAAAAAAAAAAAAAAAmDuXQAAAAAAAAAAAASIAAAAHAAAAAAAAAAAAAACamZmZ/eqnQAAAAAAAAAAACw==','AAEAAAD/////AQAAAAAAAAAEAQAAAO8BU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuRGljdGlvbmFyeWAyW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtNU0FNSVNVc2VySW50ZXJmYWNlLkhvdXJDb3N0UGFpciwgcnlsZGIuc3FsdG9vbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsXV0EAAAAB1ZlcnNpb24IQ29tcGFyZXIISGFzaFNpemUNS2V5VmFsdWVQYWlycwADAAMIkgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5HZW5lcmljRXF1YWxpdHlDb21wYXJlcmAxW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQjzAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLktleVZhbHVlUGFpcmAyW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtNU0FNSVNVc2VySW50ZXJmYWNlLkhvdXJDb3N0UGFpciwgcnlsZGIuc3FsdG9vbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsXV1bXTAAAAAJAgAAACUAAAAJAwAAAAQCAAAAkgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5HZW5lcmljRXF1YWxpdHlDb21wYXJlcmAxW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQAAAAAHAwAAAAABAAAAGAAAAAPxAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLktleVZhbHVlUGFpcmAyW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtNU0FNSVNVc2VySW50ZXJmYWNlLkhvdXJDb3N0UGFpciwgcnlsZGIuc3FsdG9vbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsXV0MBQAAAEVyeWxkYi5zcWx0b29scywgVmVyc2lvbj0xLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPW51bGwE/P////EBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuS2V5VmFsdWVQYWlyYDJbW1N5c3RlbS5TdHJpbmcsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV0sW01TQU1JU1VzZXJJbnRlcmZhY2UuSG91ckNvc3RQYWlyLCByeWxkYi5zcWx0b29scywgVmVyc2lvbj0xLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPW51bGxdXQIAAAADa2V5BXZhbHVlAQQgTVNBTUlTVXNlckludGVyZmFjZS5Ib3VyQ29zdFBhaXIFAAAABgYAAAAVbnN1X3Byb3Blcl9kYXlfbm9ybWFsCQcAAAAB+P////z///8GCQAAABZuc3VfcHJvcGVyX2RheV9zcGVjaWFsCQoAAAAB9f////z///8GDAAAABZuc3VfcHJvcGVyX2RheV9yZWd1bGFyCQ0AAAAB8v////z///8GDwAAABduc3VfcHJvcGVyX25pZ2h0X25vcm1hbAkQAAAAAe/////8////BhIAAAAYbnN1X3Byb3Blcl9uaWdodF9zcGVjaWFsCRMAAAAB7P////z///8GFQAAABhuc3VfcHJvcGVyX25pZ2h0X3JlZ3VsYXIJFgAAAAHp/////P///wYYAAAAF25zdV9vdmVydGltZV9kYXlfbm9ybWFsCRkAAAAB5v////z///8GGwAAABhuc3Vfb3ZlcnRpbWVfZGF5X3NwZWNpYWwJHAAAAAHj/////P///wYeAAAAGG5zdV9vdmVydGltZV9kYXlfcmVndWxhcgkfAAAAAeD////8////BiEAAAAZbnN1X292ZXJ0aW1lX25pZ2h0X25vcm1hbAkiAAAAAd3////8////BiQAAAAabnN1X292ZXJ0aW1lX25pZ2h0X3NwZWNpYWwJJQAAAAHa/////P///wYnAAAAGm5zdV9vdmVydGltZV9uaWdodF9yZWd1bGFyCSgAAAAB1/////z///8GKgAAABVzdW5fcHJvcGVyX2RheV9ub3JtYWwJKwAAAAHU/////P///wYtAAAAFnN1bl9wcm9wZXJfZGF5X3NwZWNpYWwJLgAAAAHR/////P///wYwAAAAFnN1bl9wcm9wZXJfZGF5X3JlZ3VsYXIJMQAAAAHO/////P///wYzAAAAF3N1bl9wcm9wZXJfbmlnaHRfbm9ybWFsCTQAAAABy/////z///8GNgAAABhzdW5fcHJvcGVyX25pZ2h0X3NwZWNpYWwJNwAAAAHI/////P///wY5AAAAGHN1bl9wcm9wZXJfbmlnaHRfcmVndWxhcgk6AAAAAcX////8////BjwAAAAXc3VuX292ZXJ0aW1lX2RheV9ub3JtYWwJPQAAAAHC/////P///wY/AAAAGHN1bl9vdmVydGltZV9kYXlfc3BlY2lhbAlAAAAAAb/////8////BkIAAAAYc3VuX292ZXJ0aW1lX2RheV9yZWd1bGFyCUMAAAABvP////z///8GRQAAABlzdW5fb3ZlcnRpbWVfbmlnaHRfbm9ybWFsCUYAAAABuf////z///8GSAAAABpzdW5fb3ZlcnRpbWVfbmlnaHRfc3BlY2lhbAlJAAAAAbb////8////BksAAAAac3VuX292ZXJ0aW1lX25pZ2h0X3JlZ3VsYXIJTAAAAAUHAAAAIE1TQU1JU1VzZXJJbnRlcmZhY2UuSG91ckNvc3RQYWlyAwAAAARob3VyBGNvc3QFdG90YWwAAAAGBgYFAAAAAAAAAAAAAAAAAAAAAJBQQAAAAAAAAAAAAQoAAAAHAAAAAAAAAAAAAAAAAAAAAIhVQAAAAAAAAAAAAQ0AAAAHAAAAAAAAAAAAAAAAAAAAAM5hQAAAAAAAAAAAARAAAAAHAAAAAAAAAAAAAAAAAAAAADhSQAAAAAAAAAAAARMAAAAHAAAAAAAAAAAAAAAAAAAAADhSQAAAAAAAAAAAARYAAAAHAAAAAAAAAAAAAADNzMzMzJVjQAAAAAAAAAAAARkAAAAHAAAAAAAAAAAAAAAAAAAAALRUQAAAAAAAAAAAARwAAAAHAAAAAAAAAAAAAAAAAAAAAOpaQAAAAAAAAAAAAR8AAAAHAAAAAAAAAAAAAAAAAAAAgEFmQAAAAAAAAAAAASIAAAAHAAAAAAAAAAAAAAAAAAAAAMZWQAAAAAAAAAAAASUAAAAHAAAAAAAAAAAAAAAAAAAAAJtdQAAAAAAAAAAAASgAAAAHAAAAAAAAAAAAAAAAAAAAQHtoQAAAAAAAAAAAASsAAAAHAAAAAAAAAAAAAAAAAAAAAIhVQAAAAAAAAAAAAS4AAAAHAAAAAAAAAAAAAAAAAAAAANhYQAAAAAAAAAAAATEAAAAHAAAAAAAAAAAAAAAAAAAAAIhlQAAAAAAAAAAAATQAAAAHAAAAAAAAAAAAAAAzMzMzM69XQAAAAAAAAAAAATcAAAAHAAAAAAAAAAAAAAAAAAAAAFRbQAAAAAAAAAAAAToAAAAHAAAAAAAAAAAAAAAzMzMzM69nQAAAAAAAAAAAAT0AAAAHAAAAAAAAAAAAAAAAAAAAAOpaQAAAAAAAAAAAAUAAAAAHAAAAAAAAAAAAAAAAAAAAAA5fQAAAAAAAAAAAAUMAAAAHAAAAAAAAAAAAAAAAAAAAAOpqQAAAAAAAAAAAAUYAAAAHAAAAAAAAAAAAAAAAAAAAAJtdQAAAAAAAAAAAAUkAAAAHAAAAAAAAAAAAAAAAAAAAgBRhQAAAAAAAAAAAAUwAAAAHAAAAAAAAAAAAAAAAAAAAAJttQAAAAAAAAAAACw==',NULL,2,66.25,3);
/*!40000 ALTER TABLE `payroll` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `msadb`.`payroll_AFTER_INSERT` AFTER INSERT ON `payroll` FOR EACH ROW
BEGIN

		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 1, NOW(), NEW.cashbond);


		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 2, NOW(), NEW.cola);


		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 3, NOW(), NEW.cola); 

		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 4, NOW(), NEW.cashadv);	


		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 5, NOW(), NEW.emergencyallowance);    
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `msadb`.`payroll_BEFORE_UPDATE` 
BEFORE UPDATE ON `payroll` 
FOR EACH ROW
BEGIN
	IF NEW.cashbond <> OLD.cashbond THEN
		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 1, NOW(), NEW.cashbond);
        END IF;
	IF NEW.cola <> OLD.cola THEN
		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 2, NOW(), NEW.cola);
        END IF;
	IF NEW.thirteenth <> OLD.thirteenth THEN
		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 3, NOW(), NEW.thirteenth); 
        END IF;
	IF NEW.cashadv <> OLD.cashadv THEN
		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 4, NOW(), NEW.cashadv);	
        END IF;
	IF NEW.emergencyallowance <> OLD.emergencyallowance THEN
		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (NEW.pid, 5, NOW(), NEW.emergencyallowance);    
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `period`
--

DROP TABLE IF EXISTS `period`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `period` (
  `PID` int(11) NOT NULL AUTO_INCREMENT,
  `GID` int(11) DEFAULT NULL,
  `month` int(2) unsigned zerofill DEFAULT NULL,
  `period` int(1) unsigned zerofill DEFAULT NULL,
  `year` int(4) unsigned zerofill DEFAULT NULL,
  `certby` varchar(120) DEFAULT '',
  PRIMARY KEY (`PID`),
  UNIQUE KEY `unq` (`month`,`GID`,`period`,`year`),
  KEY `fk_period_guard_idx` (`GID`),
  CONSTRAINT `fk_period_guard` FOREIGN KEY (`GID`) REFERENCES `guards` (`GID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `period`
--

LOCK TABLES `period` WRITE;
/*!40000 ALTER TABLE `period` DISABLE KEYS */;
INSERT INTO `period` VALUES (1,161,08,2,2017,'');
/*!40000 ALTER TABLE `period` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `personsinvolved`
--

LOCK TABLES `personsinvolved` WRITE;
/*!40000 ALTER TABLE `personsinvolved` DISABLE KEYS */;
/*!40000 ALTER TABLE `personsinvolved` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rates`
--

DROP TABLE IF EXISTS `rates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rates` (
  `rates_id` int(11) NOT NULL AUTO_INCREMENT,
  `date_effective` datetime DEFAULT NULL,
  `date_dissolved` datetime DEFAULT NULL,
  `contrib_id` int(11) DEFAULT NULL,
  `ordinary_day` decimal(3,2) DEFAULT NULL,
  `special_holiday` decimal(3,2) DEFAULT NULL,
  `regular_holiday` decimal(3,2) DEFAULT NULL,
  `sunday_ordinary_day` decimal(3,2) DEFAULT NULL,
  `sunday_special_holiday` decimal(3,2) DEFAULT NULL,
  `sunday_regular_holiday` decimal(3,2) DEFAULT NULL,
  `nightdifferential` decimal(3,2) DEFAULT NULL,
  `overtime` decimal(3,2) DEFAULT NULL,
  `overtime_holiday` decimal(3,2) DEFAULT NULL,
  `status` int(1) DEFAULT NULL,
  PRIMARY KEY (`rates_id`),
  KEY `fk_contribdetails_rates_idx` (`contrib_id`),
  CONSTRAINT `fk_contribdetails_rates` FOREIGN KEY (`contrib_id`) REFERENCES `contribdetails` (`contrib_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rates`
--

LOCK TABLES `rates` WRITE;
/*!40000 ALTER TABLE `rates` DISABLE KEYS */;
INSERT INTO `rates` VALUES (1,'1970-01-01 00:00:00','2012-01-01 00:00:00',12,1.00,1.10,1.50,1.30,1.65,2.50,1.05,1.10,1.30,0),(2,'2012-01-01 00:00:00','2017-08-13 00:00:00',12,1.00,1.30,2.00,1.30,1.50,2.60,1.10,1.25,1.25,0),(3,'2017-08-13 00:00:00','9999-12-31 00:00:00',12,1.00,1.30,2.15,1.30,1.50,2.60,1.10,1.25,1.25,1),(4,'2100-02-24 00:00:00','9999-12-31 00:00:00',NULL,1.00,1.30,4.00,1.30,1.50,2.60,1.10,1.25,1.25,2),(5,'2100-11-24 00:00:00','9999-12-31 00:00:00',NULL,1.00,1.30,4.00,1.30,9.00,2.60,1.10,1.25,1.25,2);
/*!40000 ALTER TABLE `rates` ENABLE KEYS */;
UNLOCK TABLES;

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
  `ProcessedBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`RID`),
  KEY `fk_req_client_idx` (`CID`),
  CONSTRAINT `fk_req_client` FOREIGN KEY (`CID`) REFERENCES `client` (`CID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request`
--

LOCK TABLES `request` WRITE;
/*!40000 ALTER TABLE `request` DISABLE KEYS */;
INSERT INTO `request` VALUES (1,1,3,'2017-08-22',3,NULL);
/*!40000 ALTER TABLE `request` ENABLE KEYS */;
UNLOCK TABLES;

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
  PRIMARY KEY (`RAID`),
  KEY `rid_raid_idx` (`RID`),
  CONSTRAINT `rid_raid` FOREIGN KEY (`RID`) REFERENCES `request` (`RID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request_assign`
--

LOCK TABLES `request_assign` WRITE;
/*!40000 ALTER TABLE `request_assign` DISABLE KEYS */;
INSERT INTO `request_assign` VALUES (1,1,'2017-08-22 00:00:00','2017-08-30 00:00:00','1','1','1','1',1);
/*!40000 ALTER TABLE `request_assign` ENABLE KEYS */;
UNLOCK TABLES;

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
  `DateEffective` datetime DEFAULT NULL,
  PRIMARY KEY (`RDID`),
  KEY `fk_ru_idx` (`RID`),
  KEY `fk_ru2_idx` (`GID`),
  KEY `fk_ru3_idx` (`IID`),
  CONSTRAINT `fk_ru` FOREIGN KEY (`RID`) REFERENCES `request` (`RID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ru2` FOREIGN KEY (`GID`) REFERENCES `guards` (`GID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ru3` FOREIGN KEY (`IID`) REFERENCES `incidentreport` (`IID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request_unassign`
--

LOCK TABLES `request_unassign` WRITE;
/*!40000 ALTER TABLE `request_unassign` DISABLE KEYS */;
/*!40000 ALTER TABLE `request_unassign` ENABLE KEYS */;
UNLOCK TABLES;

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
  `AssignedOn` datetime DEFAULT NULL,
  `UnassignedOn` datetime DEFAULT NULL,
  `cid` int(11) DEFAULT NULL,
  PRIMARY KEY (`AID`),
  KEY `Assignment-Guard_idx` (`GID`),
  KEY `Assignment-Request_idx` (`RAID`),
  CONSTRAINT `Assignment-Guard` FOREIGN KEY (`GID`) REFERENCES `guards` (`GID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_sa` FOREIGN KEY (`RAID`) REFERENCES `request_assign` (`RAID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sduty_assignment`
--

LOCK TABLES `sduty_assignment` WRITE;
/*!40000 ALTER TABLE `sduty_assignment` DISABLE KEYS */;
INSERT INTO `sduty_assignment` VALUES (1,161,1,1,'2017-08-22 00:00:00',NULL,3);
/*!40000 ALTER TABLE `sduty_assignment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ssscontrib`
--

DROP TABLE IF EXISTS `ssscontrib`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ssscontrib` (
  `sssid` int(11) NOT NULL AUTO_INCREMENT,
  `range_start` decimal(7,2) DEFAULT NULL,
  `range_end` decimal(7,2) DEFAULT NULL,
  `ec` decimal(7,2) DEFAULT NULL,
  `contrib_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`sssid`),
  KEY `fk_sss_idx` (`contrib_id`),
  CONSTRAINT `fk_sss` FOREIGN KEY (`contrib_id`) REFERENCES `contribdetails` (`contrib_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=194 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ssscontrib`
--

LOCK TABLES `ssscontrib` WRITE;
/*!40000 ALTER TABLE `ssscontrib` DISABLE KEYS */;
INSERT INTO `ssscontrib` VALUES (1,0.00,1249.99,36.30,5),(2,1250.00,1749.99,54.50,5),(3,1750.00,2249.99,72.70,5),(4,2250.00,2749.99,90.80,5),(5,2750.00,3249.99,109.00,5),(6,3250.00,3749.99,127.20,5),(7,3750.00,4249.99,145.30,5),(8,4250.00,4749.99,163.50,5),(9,4750.00,5249.99,181.70,5),(10,5250.00,5749.99,199.80,5),(11,5750.00,6249.99,218.00,5),(12,6250.00,6749.99,236.20,5),(13,6750.00,7249.99,254.30,5),(14,7250.00,7749.99,272.50,5),(15,7750.00,8249.99,290.70,5),(16,8250.00,8749.99,308.80,5),(17,8750.00,9249.99,327.00,5),(18,9250.00,9749.99,345.20,5),(19,9750.00,10249.99,363.30,5),(20,10250.00,10749.99,381.50,5),(21,10750.00,11249.99,399.70,5),(22,11250.00,11749.99,417.80,5),(23,11750.00,12249.99,436.00,5),(24,12250.00,12749.99,454.20,5),(25,12750.00,13249.99,472.30,5),(26,13250.00,13749.99,490.50,5),(27,13750.00,14249.99,508.70,5),(28,14250.00,14749.99,526.80,5),(29,14750.00,15249.99,545.00,5),(30,15250.00,15749.99,563.20,5),(31,15750.00,99999.99,581.30,5),(125,0.00,1999.99,23.00,1),(126,2000.00,5999.99,35.00,1),(127,6000.00,99999.99,400.00,1),(128,0.00,1999.99,4000.00,3),(129,2000.00,5999.99,5000.00,3),(130,6000.00,8999.99,6000.00,3),(131,9000.00,99999.99,7000.00,3),(132,0.00,1211.11,36.30,15),(133,1250.00,1749.99,54.50,15),(134,1750.00,2249.99,72.70,15),(135,2250.00,2749.99,90.80,15),(136,2750.00,3249.99,109.00,15),(137,3250.00,3749.99,127.20,15),(138,3750.00,4249.99,145.30,15),(139,4250.00,4749.99,163.50,15),(140,4750.00,5249.99,181.70,15),(141,5250.00,5749.99,199.80,15),(142,5750.00,6249.99,218.00,15),(143,6250.00,6749.99,236.20,15),(144,6750.00,7249.99,254.30,15),(145,7250.00,7749.99,272.50,15),(146,7750.00,8249.99,290.70,15),(147,8250.00,8749.99,308.80,15),(148,8750.00,9249.99,327.00,15),(149,9250.00,9749.99,345.20,15),(150,9750.00,10249.99,363.30,15),(151,10250.00,10749.99,381.50,15),(152,10750.00,11249.99,399.70,15),(153,11250.00,11749.99,417.80,15),(154,11750.00,12249.99,436.00,15),(155,12250.00,12749.99,454.20,15),(156,12750.00,13249.99,472.30,15),(157,13250.00,13749.99,490.50,15),(158,13750.00,14249.99,508.70,15),(159,14250.00,14749.99,526.80,15),(160,14750.00,15249.99,545.00,15),(161,15250.00,15749.99,563.20,15),(162,15750.00,99999.99,581.30,15),(163,0.00,1211.11,36.30,16),(164,1250.00,1749.99,54.50,16),(165,1750.00,2249.99,72.70,16),(166,2250.00,2749.99,90.80,16),(167,2750.00,3249.99,109.00,16),(168,3250.00,3749.99,127.20,16),(169,3750.00,4249.99,145.30,16),(170,4250.00,4749.99,163.50,16),(171,4750.00,5249.99,181.70,16),(172,5250.00,5749.99,199.80,16),(173,5750.00,6249.99,218.00,16),(174,6250.00,6749.99,236.20,16),(175,6750.00,7249.99,254.30,16),(176,7250.00,7749.99,272.50,16),(177,7750.00,8249.99,290.70,16),(178,8250.00,8749.99,308.80,16),(179,8750.00,9249.99,327.00,16),(180,9250.00,9749.99,345.20,16),(181,9750.00,10249.99,363.30,16),(182,10250.00,10749.99,381.50,16),(183,10750.00,11249.99,399.70,16),(184,11250.00,11749.99,417.80,16),(185,11750.00,12249.99,436.00,16),(186,12250.00,12749.99,454.20,16),(187,12750.00,13249.99,472.30,16),(188,13250.00,13749.99,490.50,16),(189,13750.00,14249.99,508.70,16),(190,14250.00,14749.99,526.80,16),(191,14750.00,15249.99,545.00,16),(192,15250.00,15749.99,563.20,16),(193,15750.00,99999.99,590.00,16);
/*!40000 ALTER TABLE `ssscontrib` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `withtax_bracket`
--

DROP TABLE IF EXISTS `withtax_bracket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `withtax_bracket` (
  `wbid` int(11) NOT NULL AUTO_INCREMENT,
  `estatus` varchar(5) DEFAULT NULL,
  `bracket` decimal(7,2) DEFAULT '0.00',
  `bracket_end` decimal(7,2) DEFAULT '0.00',
  `taxid` int(11) DEFAULT NULL,
  `contrib_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`wbid`),
  KEY `fk_wb_idx` (`contrib_id`),
  KEY `fk_wb2_idx` (`taxid`),
  CONSTRAINT `fk_wb` FOREIGN KEY (`contrib_id`) REFERENCES `contribdetails` (`contrib_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_wb1` FOREIGN KEY (`taxid`) REFERENCES `withtax_value` (`wid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=97 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `withtax_bracket`
--

LOCK TABLES `withtax_bracket` WRITE;
/*!40000 ALTER TABLE `withtax_bracket` DISABLE KEYS */;
INSERT INTO `withtax_bracket` VALUES (1,'z',1.00,0.00,1,6),(2,'z',0.00,0.00,2,6),(3,'z',417.00,0.00,3,6),(4,'z',1250.00,0.00,4,6),(5,'z',2917.00,0.00,5,6),(6,'z',5833.00,0.00,6,6),(7,'z',10417.00,0.00,7,6),(8,'z',20833.00,0.00,8,6),(9,'s0me0',1.00,0.00,1,6),(10,'s0me0',2083.00,0.00,2,6),(11,'s0me0',2500.00,0.00,3,6),(12,'s0me0',3333.00,0.00,4,6),(13,'s0me0',5000.00,0.00,5,6),(14,'s0me0',7917.00,0.00,6,6),(15,'s0me0',12500.00,0.00,7,6),(16,'s0me0',22917.00,0.00,8,6),(17,'s1me1',1.00,0.00,1,6),(18,'s1me1',3125.00,0.00,2,6),(19,'s1me1',3542.00,0.00,3,6),(20,'s1me1',4375.00,0.00,4,6),(21,'s1me1',6042.00,0.00,5,6),(22,'s1me1',88958.00,0.00,6,6),(23,'s1me1',16542.00,0.00,7,6),(24,'s1me1',23958.00,0.00,8,6),(25,'s2me2',1.00,0.00,1,6),(26,'s2me2',4167.00,0.00,2,6),(27,'s2me2',4583.00,0.00,3,6),(28,'s2me2',5417.00,0.00,4,6),(29,'s2me2',7083.00,0.00,5,6),(30,'s2me2',10000.00,0.00,6,6),(31,'s2me2',14583.00,0.00,7,6),(32,'s2me2',25000.00,0.00,8,6),(33,'s3me3',1.00,0.00,1,6),(34,'s3me3',5208.00,0.00,2,6),(35,'s3me3',5625.00,0.00,3,6),(36,'s3me3',6458.00,0.00,4,6),(37,'s3me3',8125.00,0.00,5,6),(38,'s3me3',11042.00,0.00,6,6),(39,'s3me3',15625.00,0.00,7,6),(40,'s3me3',26042.00,0.00,8,6),(41,'s4me4',1.00,0.00,1,6),(42,'s4me4',6250.00,0.00,2,6),(43,'s4me4',6667.00,0.00,3,6),(44,'s4me4',7500.00,0.00,4,6),(45,'s4me4',9167.00,0.00,5,6),(46,'s4me4',12083.00,0.00,6,6),(47,'s4me4',16667.00,0.00,7,6),(48,'s4me4',27083.00,0.00,8,6),(49,'Z',1.00,0.00,9,14),(50,'S0ME0',1.00,0.00,9,14),(51,'S1ME1',1.00,0.00,9,14),(52,'S2ME2',1.00,0.00,9,14),(53,'S3ME3',1.00,0.00,9,14),(54,'S4ME4',1.00,0.00,9,14),(55,'Z',0.00,0.00,10,14),(56,'S0ME0',2083.00,0.00,10,14),(57,'S1ME1',3125.00,0.00,10,14),(58,'S2ME2',4167.00,0.00,10,14),(59,'S3ME3',5208.00,0.00,10,14),(60,'S4ME4',6250.00,0.00,10,14),(61,'Z',417.00,0.00,11,14),(62,'S0ME0',2500.00,0.00,11,14),(63,'S1ME1',3542.00,0.00,11,14),(64,'S2ME2',4583.00,0.00,11,14),(65,'S3ME3',5625.00,0.00,11,14),(66,'S4ME4',6667.00,0.00,11,14),(67,'Z',1250.00,0.00,12,14),(68,'S0ME0',3333.00,0.00,12,14),(69,'S1ME1',4375.00,0.00,12,14),(70,'S2ME2',5417.00,0.00,12,14),(71,'S3ME3',6458.00,0.00,12,14),(72,'S4ME4',7500.00,0.00,12,14),(73,'Z',345.00,0.00,13,14),(74,'S0ME0',5000.00,0.00,13,14),(75,'S1ME1',6042.00,0.00,13,14),(76,'S2ME2',7083.00,0.00,13,14),(77,'S3ME3',8125.00,0.00,13,14),(78,'S4ME4',9167.00,0.00,13,14),(79,'Z',5833.00,0.00,14,14),(80,'S0ME0',7917.00,0.00,14,14),(81,'S1ME1',88958.00,0.00,14,14),(82,'S2ME2',10000.00,0.00,14,14),(83,'S3ME3',11042.00,0.00,14,14),(84,'S4ME4',12083.00,0.00,14,14),(85,'Z',10417.00,0.00,15,14),(86,'S0ME0',12500.00,0.00,15,14),(87,'S1ME1',16542.00,0.00,15,14),(88,'S2ME2',14583.00,0.00,15,14),(89,'S3ME3',15625.00,0.00,15,14),(90,'S4ME4',16667.00,0.00,15,14),(91,'Z',20833.00,0.00,16,14),(92,'S0ME0',22917.00,0.00,16,14),(93,'S1ME1',23958.00,0.00,16,14),(94,'S2ME2',25000.00,0.00,16,14),(95,'S3ME3',26042.00,0.00,16,14),(96,'S4ME4',27083.00,0.00,16,14);
/*!40000 ALTER TABLE `withtax_bracket` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `withtax_value`
--

DROP TABLE IF EXISTS `withtax_value`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `withtax_value` (
  `wid` int(11) NOT NULL AUTO_INCREMENT,
  `value` decimal(7,2) DEFAULT NULL,
  `excessmult` int(2) DEFAULT NULL,
  `INT` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`wid`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `withtax_value`
--

LOCK TABLES `withtax_value` WRITE;
/*!40000 ALTER TABLE `withtax_value` DISABLE KEYS */;
INSERT INTO `withtax_value` VALUES (1,0.00,0,NULL),(2,0.00,5,NULL),(3,20.83,10,NULL),(4,104.17,15,NULL),(5,354.17,20,NULL),(6,937.50,25,NULL),(7,2083.33,30,NULL),(8,5208.33,32,NULL),(9,0.00,0,NULL),(10,0.00,5,NULL),(11,20.83,10,NULL),(12,104.17,15,NULL),(13,354.17,20,NULL),(14,937.50,25,NULL),(15,2083.33,30,NULL),(16,5208.33,32,NULL);
/*!40000 ALTER TABLE `withtax_value` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'msadb'
--
/*!50003 DROP PROCEDURE IF EXISTS `archive_guard` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `archive_guard`(IN agid INT(11))
BEGIN
	
INSERT INTO msadbarchive.guards
		SELECT msadb.guards.*, NOW()
		FROM msadb.guards
		WHERE gid = 161;
	-- DEL STATEMENT.
	
    INSERT INTO msadbarchive.address
		select msadb.address.*
        from msadb.address
        where gid=161;
	-- DEL STATMENT
    
    INSERT INTO msadbarchive.dependents
		select msadb.dependents.*
        from msadb.dependents
        where gid=161;
	-- DEL STATMENT
    

    INSERT INTO msadbarchive.sduty_assignment
		SELECT aid, gid, assignedon, unassignedon, msadb.client.cid, concat(streetno, ', ', streetname, ', ', brgy, ', ', city) as Location FROM msadb.sduty_assignment
		left join msadb.request_assign on msadb.request_assign.RAID = msadb.sduty_assignment.RAID
		left join msadb.request on msadb.request.RID = msadb.request_assign.RID
		left join msadb.client on msadb.client.cid = msadb.request.CID
        where gid=161;
	-- DEL STATMENT
    
			INSERT INTO msadbarchive.dutydetails
					select msadb.dutydetails.*
                    from msadb.dutydetails 
                    where msadb.dutydetails.aid
                    in (SELECT  msadbarchive.sduty_assignment.aid
						FROM msadbarchive.sduty_assignment
						where msadbarchive.sduty_assignment.gid=161);
    
    INSERT INTO msadbarchive.payroll
		SELECT msadb.payroll.*
        from msadb.payroll
        where gid=161;
	-- DEL STATEMENT
    
    INSERT INTO msadbarchive.period
		(`PID`, `GID`, `month`, `period`, `year`, `certby`)
		SELECT msadb.period.*
        from msadb.period
        where gid=161;
	-- DEL STATEMENT
    
	INSERT INTO msadbarchive.attendance 
    (`AtID`, `DID`, `PID`, `Date`, `TimeIn`, `TimeOut`) 
		select msadb.attendance.*
		from msadb.attendance 
		where msadb.attendance.pid
		in (select msadbarchive.period.pid
			from msadbarchive.period
			where msadbarchive.period.gid = 161);
	-- DEL STATEMENT
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `debug_deleteallrecords` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `debug_deleteallrecords`()
BEGIN
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

        delete from msadb.incidentreport;
        alter table msadb.incidentreport auto_increment = 1;

        delete from msadb.adjustment_log;
        alter table msadb.adjustment_log auto_increment = 1;

        delete from msadb.payroll;
        alter table msadb.payroll auto_increment = 1;

        DELETE FROM msadb.period; 
        alter table msadb.period auto_increment = 1;

        delete from mysql.event;

		-- RESET ALL GUARDS TO INACTIEF
		update msadb.guards set gstatus=2;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `init_checkdate_all` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `init_checkdate_all`()
BEGIN

	-- MODULE 4
	call init_checkdate_basicpay();
    call init_checkdate_contribs();
    call init_checkdate_rates();
    
    -- MODULE 3
    call init_checkdate_assignmentstatus();
    call init_checkdate_unactivateassignments();
    call init_status_clientstatus();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `init_checkdate_assignments` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `init_checkdate_assignments`()
BEGIN
	-- MODULE 3
    call init_checkdate_assignmentstatus();
    call init_checkdate_unactivateassignments();
    call init_status_clientstatus();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `init_checkdate_assignmentstatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `init_checkdate_assignmentstatus`()
BEGIN
	UPDATE sduty_assignment
		left join request_assign on request_assign.RAID = sduty_assignment.RAID
    SET 
    astatus='1'
	WHERE 
		ContractStart < Now() 
        AND Now() < ContractEnd
        AND UnassignedOn IS NULL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `init_checkdate_basicpay` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `init_checkdate_basicpay`()
BEGIN
	SET @cw = (select count(*) from basicpay where start<NOW() and `end`>NOW());
-- get ONLY the next pending basic pay
SET @de = (select start from basicpay where start<NOW() and `end`>NOW() and status=2 order by start desc limit 1);
	UPDATE msadb.basicpay
	set `end` = (case when (status=1 and @cw>1) then (@de)
    when (status=2 and @cw>1) then `end` 
    when (status=1 and @cw=1) then `end`
    when (status=2 and @cw=1) then `end` end),
    status = (case 	when (status=1 and (@cw)>1) then 0 
						when (status=2 and (@cw)>1) then 1 
                        when (status=1 and (@cw)=1) then status
						when (status=2 and (@cw)=1) then status end)
	where start<NOW() and `end`>NOW();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `init_checkdate_contribs` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `init_checkdate_contribs`()
BEGIN
	SET @t1 = (select count(*) from contribdetails where date_effective<NOW() and `date_dissolved`>NOW() and type=1);
	SET @t2 = (select count(*) from contribdetails where date_effective<NOW() and `date_dissolved`>NOW() and type=2);
	SET @t3 = (select count(*) from contribdetails where date_effective<NOW() and `date_dissolved`>NOW() and type=3);

	-- get ONLY the next pending basic pay
			SET @de1 = (select date_effective from contribdetails where date_effective < NOW() and `date_dissolved`> NOW() and status = 2 and type = 1 order by date_effective desc limit 1);
			SET @de2 = (select date_effective from contribdetails where date_effective < NOW() and `date_dissolved`> NOW() and status = 2 and type = 2 order by date_effective desc limit 1);
			SET @de3 = (select date_effective from contribdetails where date_effective < NOW() and `date_dissolved`> NOW() and status = 2 and type = 3 order by date_effective desc limit 1);

	UPDATE msadb.contribdetails
			set `date_dissolved` = (case 
				-- Type 1
					when (status=1 and @t1>1 and type=1) then (@de1)
					when (status=2 and @t1>1 and type=1) then date_dissolved
					when (status=1 and @t1=1 and type=1) then date_dissolved
					when (status=2 and @t1=1 and type=1) then date_dissolved
					
				-- Type 2
					when(status = 1 and @t2 > 1 and type = 2) then(@de2)      
					when(status = 2 and @t2 > 1 and type = 2) then `date_dissolved` 
					when(status = 1 and @t2 = 1 and type = 2) then `date_dissolved`
					when(status = 2 and @t2 = 1 and type = 2) then `date_dissolved` 
					when(status = 0 and @t1 = 1 and type=2) then `date_dissolved`
			-- Type 3
					when(status = 1 and @t3 > 1 and type = 3) then(@de3)                 
					when(status = 2 and @t3 > 1 and type = 3) then `date_dissolved` 
					when(status = 1 and @t3 = 1 and type = 3) then `date_dissolved`
					when(status = 2 and @t3 = 1 and type = 3) then `date_dissolved`    
					when(status = 0 and @t3 = 1 and type = 3) then `date_dissolved`     
			end),
			
			status = (case 	
					when (status=1 and (@t1)>1 and type=1) then 0 
					when (status=2 and (@t1)>1 and type=1) then 1 
					when (status=1 and (@t1)=1 and type=1) then status
					when (status=2 and (@t1)=1 and type=1) then status 
					
					when (status=1 and (@t2)>1 and type = 2) then 0 
					when (status=2 and (@t2)>1 and type = 2) then 1 
					when (status=1 and (@t2)=1 and type = 2) then status
					when (status=2 and (@t2)=1 and type = 2) then status 
					
					when (status=1 and (@t3)>1 and type = 3) then 0 
					when (status=2 and (@t3)>1 and type = 3) then 1 
					when (status=1 and (@t3)=1 and type = 3) then status
					when (status=2 and (@t3)=1 and type = 3) then status 
					end)
	where date_effective<NOW() and `date_dissolved`>NOW();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `init_checkdate_rates` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `init_checkdate_rates`()
BEGIN
		SET @cw = (select count(*) from rates where date_effective<NOW() and `date_dissolved`>NOW());
-- get ONLY the next pending basic pay
SET @de = (select date_effective from rates where date_effective<NOW() and `date_dissolved`>NOW() and status=2 order by date_effective desc limit 1);
	UPDATE msadb.rates
	set `date_dissolved` = (case when (status=1 and @cw>1) then (@de)
    when (status=2 and @cw>1) then `date_dissolved` 
    when (status=1 and @cw=1) then `date_dissolved`
    when (status=2 and @cw=1) then `date_dissolved` end),
    status = (case 	when (status=1 and (@cw)>1) then 0 
						when (status=2 and (@cw)>1) then 1 
                        when (status=1 and (@cw)=1) then status
						when (status=2 and (@cw)=1) then status end)
	where date_effective<NOW() and `date_dissolved`>NOW();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `init_checkdate_unactivateassignments` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `init_checkdate_unactivateassignments`()
BEGIN
	UPDATE sduty_assignment
		left join request_assign on request_assign.RAID = sduty_assignment.RAID
    SET `UnassignedOn`= (`contractend`),
    astatus='2'
	WHERE request_assign.`RAID` IN
    (SELECT request_assign.raid FROM msadb.request_assign where contractend<NOW()) 
    AND UnassignedOn IS NOT NULL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `init_status_clientstatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `init_status_clientstatus`()
BEGIN
	UPDATE `msadb`.`client` SET `CStatus`='1' WHERE `CID` IN
    (select cid from sduty_assignment where astatus=1 group by cid);
    UPDATE `msadb`.`client` SET `CStatus`='0' WHERE `CID` NOT IN
    (select cid from sduty_assignment where astatus=1 group by cid) and cstatus=1;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `guardslist`
--

/*!50001 DROP VIEW IF EXISTS `guardslist`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = latin1 */;
/*!50001 SET character_set_results     = latin1 */;
/*!50001 SET collation_connection      = latin1_swedish_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `guardslist` AS select 1 AS `gid`,1 AS `name`,1 AS `contactno`,1 AS `gstatus` */;
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
/*!50001 SET character_set_client      = latin1 */;
/*!50001 SET character_set_results     = latin1 */;
/*!50001 SET collation_connection      = latin1_swedish_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `new_view` AS select 1 AS `gid`,1 AS `name`,1 AS `contactno`,1 AS `gstatus` */;
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

-- Dump completed on 2017-08-23 17:32:30
CREATE DATABASE  IF NOT EXISTS `msadbarchive` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `msadbarchive`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
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
  `AID` int(11) NOT NULL AUTO_INCREMENT,
  `GID` int(11) DEFAULT NULL,
  `AType` int(11) DEFAULT NULL,
  `Country` varchar(45) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `StreetNo` varchar(45) DEFAULT NULL,
  `Brgy` varchar(45) DEFAULT NULL,
  `Street` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`AID`)
) ENGINE=InnoDB AUTO_INCREMENT=854 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address`
--

LOCK TABLES `address` WRITE;
/*!40000 ALTER TABLE `address` DISABLE KEYS */;
INSERT INTO `address` VALUES (161,161,1,'China','Tangdong','5','Autumn Leaf','Golf'),(507,161,2,'Laos','Xaysetha','8313','Eastlawn','Park Meadow'),(853,161,3,'Philippines','Cabugao','22','Graceland','Bartelt');
/*!40000 ALTER TABLE `address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `adjustment_log`
--

DROP TABLE IF EXISTS `adjustment_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `adjustment_log` (
  `AdjID` int(11) NOT NULL AUTO_INCREMENT,
  `AdjType` int(11) DEFAULT NULL,
  `AdjDate` timestamp NULL DEFAULT NULL,
  `Value` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`AdjID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adjustment_log`
--

LOCK TABLES `adjustment_log` WRITE;
/*!40000 ALTER TABLE `adjustment_log` DISABLE KEYS */;
/*!40000 ALTER TABLE `adjustment_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attendance`
--

DROP TABLE IF EXISTS `attendance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `attendance` (
  `AtID` int(11) NOT NULL AUTO_INCREMENT,
  `DID` int(11) DEFAULT NULL,
  `PID` int(11) DEFAULT NULL,
  `Date` varchar(45) DEFAULT NULL,
  `TimeIn` varchar(45) DEFAULT '12:00 AM',
  `TimeOut` varchar(45) DEFAULT '12:00 AM',
  `normal_day` varchar(7) DEFAULT '00:00',
  `normal_night` varchar(7) DEFAULT '00:00',
  `holiday_day` varchar(7) DEFAULT '00:00',
  `holiday_night` varchar(7) DEFAULT '00:00',
  `total` varchar(7) DEFAULT '00:00',
  `attendancecol` varchar(45) DEFAULT '00:00',
  PRIMARY KEY (`AtID`),
  UNIQUE KEY `unique_index` (`Date`,`DID`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance`
--

LOCK TABLES `attendance` WRITE;
/*!40000 ALTER TABLE `attendance` DISABLE KEYS */;
INSERT INTO `attendance` VALUES (1,1,1,'2017-08-21 00:00:00','01:00 AM','09:00 AM','03:00','05:00','00:00','00:00','08:00','00:00'),(2,1,1,'2017-08-28 00:00:00','01:00 AM','09:00 AM','03:00','05:00','00:00','00:00','08:00','00:00'),(3,1,1,'2017-08-22 00:00:00','01:00 AM','09:00 AM','03:00','05:00','00:00','00:00','08:00','00:00'),(4,1,1,'2017-08-29 00:00:00','01:00 AM','09:00 AM','03:00','05:00','00:00','00:00','08:00','00:00'),(5,1,1,'2017-08-16 00:00:00','01:00 AM','09:00 AM','03:00','05:00','00:00','00:00','08:00','00:00'),(6,1,1,'2017-08-23 00:00:00','01:00 AM','09:00 AM','03:00','05:00','00:00','00:00','08:00','00:00'),(7,1,1,'2017-08-30 00:00:00','01:00 AM','09:00 AM','03:00','05:00','00:00','00:00','08:00','00:00');
/*!40000 ALTER TABLE `attendance` ENABLE KEYS */;
UNLOCK TABLES;

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
  PRIMARY KEY (`DeID`)
) ENGINE=InnoDB AUTO_INCREMENT=1587 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dependents`
--

LOCK TABLES `dependents` WRITE;
/*!40000 ALTER TABLE `dependents` DISABLE KEYS */;
INSERT INTO `dependents` VALUES (783,4,'Danille','Fineran','Sharps',161),(784,5,'Ahmad','Kahal','Citroni',161),(785,6,'Mickey','Whiddon','Vitek',161),(786,2,'Napoleon','Newburn','Sterns',161),(787,2,'Scottie','Belnap','Arriaga',161),(788,2,'Pete','Okel','Hauber',161);
/*!40000 ALTER TABLE `dependents` ENABLE KEYS */;
UNLOCK TABLES;

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
  PRIMARY KEY (`DID`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dutydetails`
--

LOCK TABLES `dutydetails` WRITE;
/*!40000 ALTER TABLE `dutydetails` DISABLE KEYS */;
INSERT INTO `dutydetails` VALUES (1,1,01,00,'AM',10,00,'AM',1,1,1,0,0,0,0,1);
/*!40000 ALTER TABLE `dutydetails` ENABLE KEYS */;
UNLOCK TABLES;

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
  `archivedon` datetime DEFAULT NULL,
  PRIMARY KEY (`GID`)
) ENGINE=InnoDB AUTO_INCREMENT=347 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `guards`
--

LOCK TABLES `guards` WRITE;
/*!40000 ALTER TABLE `guards` DISABLE KEYS */;
INSERT INTO `guards` VALUES (161,'Margie','Rodrigo','Abad',1,'2/5/1985',2,'5 11','87 kg.','Protestant',1,'+63 603 364 1300','212-4964.','09-2306385-6','09-2306385-6','726-849-298','63-609612327-5','Kohl\'s Corp.',NULL,2,NULL,NULL,'Daryl Hossfeld','09510047990','2017-08-20 16:14:55');
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
-- Table structure for table `holiday`
--

DROP TABLE IF EXISTS `holiday`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `holiday` (
  `hid` int(11) NOT NULL AUTO_INCREMENT,
  `datestart` varchar(45) DEFAULT NULL,
  `dateend` varchar(45) DEFAULT NULL,
  `type` int(1) DEFAULT NULL,
  `ds_MM` int(2) DEFAULT NULL,
  `ds_dd` int(2) DEFAULT NULL,
  `ds_yyyy` int(4) DEFAULT NULL,
  `de_MM` int(2) DEFAULT NULL,
  `de_dd` int(2) DEFAULT NULL,
  `de_yyyy` int(4) DEFAULT NULL,
  `desc` varchar(120) DEFAULT NULL,
  `status` int(1) DEFAULT '1',
  PRIMARY KEY (`hid`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `holiday`
--

LOCK TABLES `holiday` WRITE;
/*!40000 ALTER TABLE `holiday` DISABLE KEYS */;
/*!40000 ALTER TABLE `holiday` ENABLE KEYS */;
UNLOCK TABLES;

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
  `PID` int(11) NOT NULL AUTO_INCREMENT,
  `GID` int(11) DEFAULT NULL,
  `month` int(2) DEFAULT NULL,
  `period` int(2) DEFAULT NULL,
  `year` int(4) DEFAULT NULL,
  `rates_id` int(11) DEFAULT NULL,
  `cashbond` decimal(7,2) DEFAULT NULL,
  `thirteenth` decimal(7,2) DEFAULT NULL,
  `cola` decimal(7,2) DEFAULT NULL,
  `sss` decimal(7,2) DEFAULT NULL,
  `pagibig` decimal(7,2) DEFAULT NULL,
  `philhealth` decimal(7,2) DEFAULT NULL,
  `withtax` decimal(7,2) DEFAULT NULL,
  `cashadv` decimal(7,2) DEFAULT '0.00',
  `emergencyallowance` decimal(7,2) DEFAULT NULL,
  `totalsummary_serializable` blob,
  `hc_serializable` blob,
  `lastmodified` timestamp NULL DEFAULT NULL,
  `pstatus` int(1) DEFAULT NULL,
  `basicpayhourly` decimal(7,2) DEFAULT NULL,
  PRIMARY KEY (`PID`),
  KEY `Payroll-Guards_idx` (`GID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payroll`
--

LOCK TABLES `payroll` WRITE;
/*!40000 ALTER TABLE `payroll` DISABLE KEYS */;
INSERT INTO `payroll` VALUES (1,161,8,2,2017,3,150.00,0.00,60.00,163.50,100.00,120.00,0.00,0.00,100.00,'AAEAAAD/////AQAAAAAAAAAEAQAAAO8BU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuRGljdGlvbmFyeWAyW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtNU0FNSVNVc2VySW50ZXJmYWNlLkhvdXJDb3N0UGFpciwgcnlsZGIuc3FsdG9vbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsXV0EAAAAB1ZlcnNpb24IQ29tcGFyZXIISGFzaFNpemUNS2V5VmFsdWVQYWlycwADAAMIkgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5HZW5lcmljRXF1YWxpdHlDb21wYXJlcmAxW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQjzAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLktleVZhbHVlUGFpcmAyW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtNU0FNSVNVc2VySW50ZXJmYWNlLkhvdXJDb3N0UGFpciwgcnlsZGIuc3FsdG9vbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsXV1bXRQAAAAJAgAAABEAAAAJAwAAAAQCAAAAkgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5HZW5lcmljRXF1YWxpdHlDb21wYXJlcmAxW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQAAAAAHAwAAAAABAAAACgAAAAPxAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLktleVZhbHVlUGFpcmAyW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtNU0FNSVNVc2VySW50ZXJmYWNlLkhvdXJDb3N0UGFpciwgcnlsZGIuc3FsdG9vbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsXV0MBQAAAEVyeWxkYi5zcWx0b29scywgVmVyc2lvbj0xLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPW51bGwE/P////EBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuS2V5VmFsdWVQYWlyYDJbW1N5c3RlbS5TdHJpbmcsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV0sW01TQU1JU1VzZXJJbnRlcmZhY2UuSG91ckNvc3RQYWlyLCByeWxkYi5zcWx0b29scywgVmVyc2lvbj0xLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPW51bGxdXQIAAAADa2V5BXZhbHVlAQQgTVNBTUlTVXNlckludGVyZmFjZS5Ib3VyQ29zdFBhaXIFAAAABgYAAAAKbm9ybWFsX25zdQkHAAAAAfj////8////BgkAAAAKbm9ybWFsX3N1bgkKAAAAAfX////8////BgwAAAALcmVndWxhcl9uc3UJDQAAAAHy/////P///wYPAAAAC3JlZ3VsYXJfc3VuCRAAAAAB7/////z///8GEgAAAAtzcGVjaWFsX25zdQkTAAAAAez////8////BhUAAAALc3BlY2lhbF9zdW4JFgAAAAHp/////P///wYYAAAAB3NwZWNpYWwJGQAAAAHm/////P///wYbAAAABm5vcm1hbAkcAAAAAeP////8////Bh4AAAAHcmVndWxhcgkfAAAAAeD////8////BiEAAAAFdG90YWwJIgAAAAUHAAAAIE1TQU1JU1VzZXJJbnRlcmZhY2UuSG91ckNvc3RQYWlyAwAAAARob3VyBGNvc3QFdG90YWwAAAAGBgYFAAAAAAAAAAAATEAAAAAAgJBzQAAAAADAy65AAQoAAAAHAAAAAAAAAAAAAADNzMzMDG95QAAAAAAAAAAAAQ0AAAAHAAAAAAAAAAAAAAAzMzMzIwiFQAAAAAAAAAAAARAAAAAHAAAAAAAAAAAAAADNzMzMDG+JQAAAAAAAAAAAARMAAAAHAAAAAAAAAAAAAAAAAAAAQBF4QAAAAAAAAAAAARYAAAAHAAAAAAAAAAAAAAAAAAAAwFh9QAAAAAAAAAAAARkAAAAHAAAAAAAAAAAAAAAAAAAAALWKQAAAAAAAAAAAARwAAAAHAAAAAAAAAAAATEBmZmZmxn+GQAAAAADAy65AAR8AAAAHAAAAAAAAAAAAAAAAAAAAmDuXQAAAAAAAAAAAASIAAAAHAAAAAAAAAAAATECamZmZ/eqnQAAAAADAy65ACw==','AAEAAAD/////AQAAAAAAAAAEAQAAAO8BU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuRGljdGlvbmFyeWAyW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtNU0FNSVNVc2VySW50ZXJmYWNlLkhvdXJDb3N0UGFpciwgcnlsZGIuc3FsdG9vbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsXV0EAAAAB1ZlcnNpb24IQ29tcGFyZXIISGFzaFNpemUNS2V5VmFsdWVQYWlycwADAAMIkgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5HZW5lcmljRXF1YWxpdHlDb21wYXJlcmAxW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQjzAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLktleVZhbHVlUGFpcmAyW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtNU0FNSVNVc2VySW50ZXJmYWNlLkhvdXJDb3N0UGFpciwgcnlsZGIuc3FsdG9vbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsXV1bXTAAAAAJAgAAACUAAAAJAwAAAAQCAAAAkgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5HZW5lcmljRXF1YWxpdHlDb21wYXJlcmAxW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQAAAAAHAwAAAAABAAAAGAAAAAPxAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLktleVZhbHVlUGFpcmAyW1tTeXN0ZW0uU3RyaW5nLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtNU0FNSVNVc2VySW50ZXJmYWNlLkhvdXJDb3N0UGFpciwgcnlsZGIuc3FsdG9vbHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsXV0MBQAAAEVyeWxkYi5zcWx0b29scywgVmVyc2lvbj0xLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPW51bGwE/P////EBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuS2V5VmFsdWVQYWlyYDJbW1N5c3RlbS5TdHJpbmcsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV0sW01TQU1JU1VzZXJJbnRlcmZhY2UuSG91ckNvc3RQYWlyLCByeWxkYi5zcWx0b29scywgVmVyc2lvbj0xLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPW51bGxdXQIAAAADa2V5BXZhbHVlAQQgTVNBTUlTVXNlckludGVyZmFjZS5Ib3VyQ29zdFBhaXIFAAAABgYAAAAVbnN1X3Byb3Blcl9kYXlfbm9ybWFsCQcAAAAB+P////z///8GCQAAABZuc3VfcHJvcGVyX2RheV9zcGVjaWFsCQoAAAAB9f////z///8GDAAAABZuc3VfcHJvcGVyX2RheV9yZWd1bGFyCQ0AAAAB8v////z///8GDwAAABduc3VfcHJvcGVyX25pZ2h0X25vcm1hbAkQAAAAAe/////8////BhIAAAAYbnN1X3Byb3Blcl9uaWdodF9zcGVjaWFsCRMAAAAB7P////z///8GFQAAABhuc3VfcHJvcGVyX25pZ2h0X3JlZ3VsYXIJFgAAAAHp/////P///wYYAAAAF25zdV9vdmVydGltZV9kYXlfbm9ybWFsCRkAAAAB5v////z///8GGwAAABhuc3Vfb3ZlcnRpbWVfZGF5X3NwZWNpYWwJHAAAAAHj/////P///wYeAAAAGG5zdV9vdmVydGltZV9kYXlfcmVndWxhcgkfAAAAAeD////8////BiEAAAAZbnN1X292ZXJ0aW1lX25pZ2h0X25vcm1hbAkiAAAAAd3////8////BiQAAAAabnN1X292ZXJ0aW1lX25pZ2h0X3NwZWNpYWwJJQAAAAHa/////P///wYnAAAAGm5zdV9vdmVydGltZV9uaWdodF9yZWd1bGFyCSgAAAAB1/////z///8GKgAAABVzdW5fcHJvcGVyX2RheV9ub3JtYWwJKwAAAAHU/////P///wYtAAAAFnN1bl9wcm9wZXJfZGF5X3NwZWNpYWwJLgAAAAHR/////P///wYwAAAAFnN1bl9wcm9wZXJfZGF5X3JlZ3VsYXIJMQAAAAHO/////P///wYzAAAAF3N1bl9wcm9wZXJfbmlnaHRfbm9ybWFsCTQAAAABy/////z///8GNgAAABhzdW5fcHJvcGVyX25pZ2h0X3NwZWNpYWwJNwAAAAHI/////P///wY5AAAAGHN1bl9wcm9wZXJfbmlnaHRfcmVndWxhcgk6AAAAAcX////8////BjwAAAAXc3VuX292ZXJ0aW1lX2RheV9ub3JtYWwJPQAAAAHC/////P///wY/AAAAGHN1bl9vdmVydGltZV9kYXlfc3BlY2lhbAlAAAAAAb/////8////BkIAAAAYc3VuX292ZXJ0aW1lX2RheV9yZWd1bGFyCUMAAAABvP////z///8GRQAAABlzdW5fb3ZlcnRpbWVfbmlnaHRfbm9ybWFsCUYAAAABuf////z///8GSAAAABpzdW5fb3ZlcnRpbWVfbmlnaHRfc3BlY2lhbAlJAAAAAbb////8////BksAAAAac3VuX292ZXJ0aW1lX25pZ2h0X3JlZ3VsYXIJTAAAAAUHAAAAIE1TQU1JU1VzZXJJbnRlcmZhY2UuSG91ckNvc3RQYWlyAwAAAARob3VyBGNvc3QFdG90YWwAAAAGBgYFAAAAAAAAAAAANUAAAAAAAJBQQAAAAAAAvZVAAQoAAAAHAAAAAAAAAAAAAAAAAAAAAIhVQAAAAAAAAAAAAQ0AAAAHAAAAAAAAAAAAAAAAAAAAAM5hQAAAAAAAAAAAARAAAAAHAAAAAAAAAACAQUAAAAAAADhSQAAAAABA7aNAARMAAAAHAAAAAAAAAAAAAAAAAAAAADhSQAAAAAAAAAAAARYAAAAHAAAAAAAAAAAAAADNzMzMzJVjQAAAAAAAAAAAARkAAAAHAAAAAAAAAAAAAAAAAAAAALRUQAAAAAAAAAAAARwAAAAHAAAAAAAAAAAAAAAAAAAAAOpaQAAAAAAAAAAAAR8AAAAHAAAAAAAAAAAAAAAAAAAAgEFmQAAAAAAAAAAAASIAAAAHAAAAAAAAAAAAAAAAAAAAAMZWQAAAAAAAAAAAASUAAAAHAAAAAAAAAAAAAAAAAAAAAJtdQAAAAAAAAAAAASgAAAAHAAAAAAAAAAAAAAAAAAAAQHtoQAAAAAAAAAAAASsAAAAHAAAAAAAAAAAAAAAAAAAAAIhVQAAAAAAAAAAAAS4AAAAHAAAAAAAAAAAAAAAAAAAAANhYQAAAAAAAAAAAATEAAAAHAAAAAAAAAAAAAAAAAAAAAIhlQAAAAAAAAAAAATQAAAAHAAAAAAAAAAAAAAAzMzMzM69XQAAAAAAAAAAAATcAAAAHAAAAAAAAAAAAAAAAAAAAAFRbQAAAAAAAAAAAAToAAAAHAAAAAAAAAAAAAAAzMzMzM69nQAAAAAAAAAAAAT0AAAAHAAAAAAAAAAAAAAAAAAAAAOpaQAAAAAAAAAAAAUAAAAAHAAAAAAAAAAAAAAAAAAAAAA5fQAAAAAAAAAAAAUMAAAAHAAAAAAAAAAAAAAAAAAAAAOpqQAAAAAAAAAAAAUYAAAAHAAAAAAAAAAAAAAAAAAAAAJtdQAAAAAAAAAAAAUkAAAAHAAAAAAAAAAAAAAAAAAAAgBRhQAAAAAAAAAAAAUwAAAAHAAAAAAAAAAAAAAAAAAAAAJttQAAAAAAAAAAACw==',NULL,2,66.25);
/*!40000 ALTER TABLE `payroll` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `period`
--

DROP TABLE IF EXISTS `period`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `period` (
  `PID` int(11) NOT NULL AUTO_INCREMENT,
  `GID` int(11) DEFAULT NULL,
  `month` int(2) unsigned zerofill DEFAULT NULL,
  `period` int(1) unsigned zerofill DEFAULT NULL,
  `year` int(4) unsigned zerofill DEFAULT NULL,
  `certby` varchar(120) DEFAULT '',
  `holiday_day` varchar(7) DEFAULT NULL,
  `holiday_night` varchar(7) DEFAULT NULL,
  `normal_day` varchar(7) DEFAULT NULL,
  `normal_night` varchar(7) DEFAULT NULL,
  `total` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`PID`),
  UNIQUE KEY `unq` (`month`,`GID`,`period`,`year`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `period`
--

LOCK TABLES `period` WRITE;
/*!40000 ALTER TABLE `period` DISABLE KEYS */;
INSERT INTO `period` VALUES (1,161,08,2,2017,'ASD','00:00','00:00','21:00','35:00','56:00');
/*!40000 ALTER TABLE `period` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `request`
--

LOCK TABLES `request` WRITE;
/*!40000 ALTER TABLE `request` DISABLE KEYS */;
/*!40000 ALTER TABLE `request` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `request_assign`
--

LOCK TABLES `request_assign` WRITE;
/*!40000 ALTER TABLE `request_assign` DISABLE KEYS */;
/*!40000 ALTER TABLE `request_assign` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `request_unassign`
--

LOCK TABLES `request_unassign` WRITE;
/*!40000 ALTER TABLE `request_unassign` DISABLE KEYS */;
/*!40000 ALTER TABLE `request_unassign` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sduty_assignment`
--

DROP TABLE IF EXISTS `sduty_assignment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sduty_assignment` (
  `AID` int(11) NOT NULL AUTO_INCREMENT,
  `GID` int(11) DEFAULT NULL,
  `AssignedOn` datetime DEFAULT NULL,
  `UnassignedOn` datetime DEFAULT NULL,
  `CID` int(11) DEFAULT NULL,
  `Address` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`AID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sduty_assignment`
--

LOCK TABLES `sduty_assignment` WRITE;
/*!40000 ALTER TABLE `sduty_assignment` DISABLE KEYS */;
INSERT INTO `sduty_assignment` VALUES (1,161,'2017-08-20 00:00:00',NULL,2,'1, 1, 1, 1');
/*!40000 ALTER TABLE `sduty_assignment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'msadbarchive'
--
/*!50003 DROP PROCEDURE IF EXISTS `debug_deleteallrecords` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `debug_deleteallrecords`()
BEGIN
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

        delete from msadb.incidentreport;
        alter table msadb.incidentreport auto_increment = 1;

        delete from msadb.adjustment_log;
        alter table msadb.adjustment_log auto_increment = 1;

        delete from msadb.payroll;
        alter table msadb.payroll auto_increment = 1;

        DELETE FROM msadb.period; 
        alter table msadb.period auto_increment = 1;

        delete from mysql.event;

		-- RESET ALL GUARDS TO INACTIEF
		update msadb.guards set gstatus=2;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `init_checkdate_all` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `init_checkdate_all`()
BEGIN
	call init_checkdate_basicpay();
    call init_checkdate_contribs();
    call init_checkdate_rates();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `init_checkdate_basicpay` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `init_checkdate_basicpay`()
BEGIN
	SET @cw = (select count(*) from basicpay where start<NOW() and `end`>NOW());
-- get ONLY the next pending basic pay
SET @de = (select start from basicpay where start<NOW() and `end`>NOW() and status=2 order by start desc limit 1);
	UPDATE msadb.basicpay
	set `end` = (case when (status=1 and @cw>1) then (@de)
    when (status=2 and @cw>1) then `end` 
    when (status=1 and @cw=1) then `end`
    when (status=2 and @cw=1) then `end` end),
    status = (case 	when (status=1 and (@cw)>1) then 0 
						when (status=2 and (@cw)>1) then 1 
                        when (status=1 and (@cw)=1) then status
						when (status=2 and (@cw)=1) then status end)
	where start<NOW() and `end`>NOW();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `init_checkdate_contribs` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `init_checkdate_contribs`()
BEGIN
	SET @t1 = (select count(*) from contribdetails where date_effective<NOW() and `date_dissolved`>NOW() and type=1);
	SET @t2 = (select count(*) from contribdetails where date_effective<NOW() and `date_dissolved`>NOW() and type=2);
	SET @t3 = (select count(*) from contribdetails where date_effective<NOW() and `date_dissolved`>NOW() and type=3);

	-- get ONLY the next pending basic pay
			SET @de1 = (select date_effective from contribdetails where date_effective < NOW() and `date_dissolved`> NOW() and status = 2 and type = 1 order by date_effective desc limit 1);
			SET @de2 = (select date_effective from contribdetails where date_effective < NOW() and `date_dissolved`> NOW() and status = 2 and type = 2 order by date_effective desc limit 1);
			SET @de3 = (select date_effective from contribdetails where date_effective < NOW() and `date_dissolved`> NOW() and status = 2 and type = 3 order by date_effective desc limit 1);

	UPDATE msadb.contribdetails
			set `date_dissolved` = (case 
				-- Type 1
					when (status=1 and @t1>1 and type=1) then (@de1)
					when (status=2 and @t1>1 and type=1) then date_dissolved
					when (status=1 and @t1=1 and type=1) then date_dissolved
					when (status=2 and @t1=1 and type=1) then date_dissolved
					
				-- Type 2
					when(status = 1 and @t2 > 1 and type = 2) then(@de2)      
					when(status = 2 and @t2 > 1 and type = 2) then `date_dissolved` 
					when(status = 1 and @t2 = 1 and type = 2) then `date_dissolved`
					when(status = 2 and @t2 = 1 and type = 2) then `date_dissolved` 
					when(status = 0 and @t1 = 1 and type=2) then `date_dissolved`
			-- Type 3
					when(status = 1 and @t3 > 1 and type = 3) then(@de3)                 
					when(status = 2 and @t3 > 1 and type = 3) then `date_dissolved` 
					when(status = 1 and @t3 = 1 and type = 3) then `date_dissolved`
					when(status = 2 and @t3 = 1 and type = 3) then `date_dissolved`    
					when(status = 0 and @t3 = 1 and type = 3) then `date_dissolved`     
			end),
			
			status = (case 	
					when (status=1 and (@t1)>1 and type=1) then 0 
					when (status=2 and (@t1)>1 and type=1) then 1 
					when (status=1 and (@t1)=1 and type=1) then status
					when (status=2 and (@t1)=1 and type=1) then status 
					
					when (status=1 and (@t2)>1 and type = 2) then 0 
					when (status=2 and (@t2)>1 and type = 2) then 1 
					when (status=1 and (@t2)=1 and type = 2) then status
					when (status=2 and (@t2)=1 and type = 2) then status 
					
					when (status=1 and (@t3)>1 and type = 3) then 0 
					when (status=2 and (@t3)>1 and type = 3) then 1 
					when (status=1 and (@t3)=1 and type = 3) then status
					when (status=2 and (@t3)=1 and type = 3) then status 
					end)
	where date_effective<NOW() and `date_dissolved`>NOW();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `init_checkdate_rates` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `init_checkdate_rates`()
BEGIN
		SET @cw = (select count(*) from rates where date_effective<NOW() and `date_dissolved`>NOW());
-- get ONLY the next pending basic pay
SET @de = (select date_effective from rates where date_effective<NOW() and `date_dissolved`>NOW() and status=2 order by date_effective desc limit 1);
	UPDATE msadb.rates
	set `date_dissolved` = (case when (status=1 and @cw>1) then (@de)
    when (status=2 and @cw>1) then `date_dissolved` 
    when (status=1 and @cw=1) then `date_dissolved`
    when (status=2 and @cw=1) then `date_dissolved` end),
    status = (case 	when (status=1 and (@cw)>1) then 0 
						when (status=2 and (@cw)>1) then 1 
                        when (status=1 and (@cw)=1) then status
						when (status=2 and (@cw)=1) then status end)
	where date_effective<NOW() and `date_dissolved`>NOW();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `guardslist`
--

/*!50001 DROP VIEW IF EXISTS `guardslist`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = latin1 */;
/*!50001 SET character_set_results     = latin1 */;
/*!50001 SET collation_connection      = latin1_swedish_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `guardslist` AS select 1 AS `gid`,1 AS `name`,1 AS `contactno`,1 AS `gstatus` */;
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
/*!50001 SET character_set_client      = latin1 */;
/*!50001 SET character_set_results     = latin1 */;
/*!50001 SET collation_connection      = latin1_swedish_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `new_view` AS select 1 AS `gid`,1 AS `name`,1 AS `contactno`,1 AS `gstatus` */;
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

-- Dump completed on 2017-08-23 17:32:31
