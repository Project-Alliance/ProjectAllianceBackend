-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: projetalliance
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `schedule`
--

DROP TABLE IF EXISTS `schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `schedule` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `start` datetime NOT NULL,
  `end` datetime NOT NULL,
  `dependancies` text,
  `AssignTo` int NOT NULL,
  `progress` int NOT NULL,
  `ProjectId` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_Schedule_ProjectId` (`ProjectId`),
  CONSTRAINT `FK_Schedule_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `projects` (`pid`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedule`
--

LOCK TABLES `schedule` WRITE;
/*!40000 ALTER TABLE `schedule` DISABLE KEYS */;
INSERT INTO `schedule` VALUES (11,'Requirement Elicitation','2022-04-15 00:00:00','2022-04-23 00:00:00','',1,90,1),(12,'Design','2022-04-21 00:00:00','2022-04-23 00:00:00','',1,30,1),(13,'Coding','2022-04-29 00:00:00','2022-05-02 00:00:00','12',1,50,1),(18,'testing','2022-04-22 00:00:00','2022-04-30 00:00:00','2',1,0,1),(19,'rehan work','2022-04-19 00:00:00','2022-04-29 00:00:00','',1,0,1),(20,'FYP Class','2022-04-18 00:00:00','2022-04-27 00:00:00','',1,0,1),(23,'New task','2022-04-10 00:00:00','2022-04-27 00:00:00','4',1,0,1),(25,'hkdsf','2022-04-12 00:00:00','2022-04-27 00:00:00','2',1,0,1),(26,'cgfhgfh','2022-04-10 00:00:00','2022-04-30 00:00:00','11',1,0,1),(27,'fdsfsd','2022-04-21 00:00:00','2022-04-26 00:00:00','43',1,0,1),(28,'cdcsdcc','2022-04-19 00:00:00','2022-04-28 00:00:00','13',1,0,1);
/*!40000 ALTER TABLE `schedule` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-04-22 19:38:44
