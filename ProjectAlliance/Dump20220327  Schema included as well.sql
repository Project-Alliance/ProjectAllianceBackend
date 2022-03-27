CREATE DATABASE  IF NOT EXISTS `projetalliance` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `projetalliance`;
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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20220116200740_initial','3.1.22');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `company` (
  `id` int NOT NULL AUTO_INCREMENT,
  `companyName` varchar(30) DEFAULT NULL,
  `createdBy` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` VALUES (1,'codistan','rehan05@codistan.pa.com'),(2,'uiit','as1265513@uiit.pa.com'),(3,'codistankhan','mrrehan105@codistankhan.pa.com'),(4,'codistanISB','Rehan12345@codistanisb.pa.com');
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projects`
--

DROP TABLE IF EXISTS `projects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `projects` (
  `pid` int NOT NULL AUTO_INCREMENT,
  `ProjectTitle` text,
  `projectDescription` text,
  `status` text,
  `progress` text,
  `CreateAt` varbinary(4000) DEFAULT NULL,
  `companyProject` text,
  `startDate` varbinary(4000) DEFAULT NULL,
  `endDate` varbinary(4000) DEFAULT NULL,
  PRIMARY KEY (`pid`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projects`
--

LOCK TABLES `projects` WRITE;
/*!40000 ALTER TABLE `projects` DISABLE KEYS */;
INSERT INTO `projects` VALUES (1,'rehan','dsdsd','On Track','0',NULL,'1',NULL,NULL),(2,'','','On Track','0',NULL,'1',NULL,NULL),(3,'rehan','sdsd','On Track','0',NULL,'1',NULL,NULL),(4,'rehan','sdsd','On Track','0',NULL,'1',NULL,NULL),(5,'rehan','fghg','On Track','0',NULL,'1',NULL,NULL),(6,'Rehan\'Project','All the project schedule will be display here.','On Track','0',_binary '2022-03-10 14:10:36.775797','2',_binary '2022-03-24 00:00:00',_binary '2022-03-10 00:00:00'),(7,'Rehan\'s Project','project will divided into 3 parts.','On Track','0',_binary '2022-03-11 16:53:24.672545','3',_binary '2022-03-23 00:00:00',_binary '2022-03-23 00:00:00'),(8,'Rehan','Project is here','On Track','0',_binary '2022-03-18 16:45:43.639103','4',_binary '2022-03-19 00:00:00',_binary '2022-03-22 00:00:00'),(9,'Rehan','Project is here','On Track','0',_binary '2022-03-18 16:45:51.702455','4',_binary '2022-03-19 00:00:00',_binary '2022-03-22 00:00:00'),(10,'Rehan','Project is here','On Track','0',_binary '2022-03-18 16:46:05.142466','4',_binary '2022-03-19 00:00:00',_binary '2022-03-22 00:00:00'),(11,'Rehangg','Project is here','On Track','0',_binary '2022-03-18 16:46:26.522965','4',_binary '2022-03-19 00:00:00',_binary '2022-03-22 00:00:00'),(12,'Rehangg','Project is here','On Track','0',_binary '2022-03-18 16:46:30.040141','4',_binary '2022-03-19 00:00:00',_binary '2022-03-22 00:00:00'),(13,'Rehangg','Project is here','On Track','0',_binary '2022-03-18 16:47:19.446985','4',_binary '2022-03-09 00:00:00',_binary '2022-04-26 00:00:00'),(14,'Prject Allican','fjdfj','On Track','0',_binary '2022-03-18 16:59:40.258309','4',_binary '2022-03-02 00:00:00',_binary '2022-03-31 00:00:00');
/*!40000 ALTER TABLE `projects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subtasks`
--

DROP TABLE IF EXISTS `subtasks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subtasks` (
  `taskid` int NOT NULL AUTO_INCREMENT,
  `taskTitle` text,
  `startDate` varbinary(4000) DEFAULT NULL,
  `endDate` varbinary(4000) DEFAULT NULL,
  `description` text,
  PRIMARY KEY (`taskid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subtasks`
--

LOCK TABLES `subtasks` WRITE;
/*!40000 ALTER TABLE `subtasks` DISABLE KEYS */;
/*!40000 ALTER TABLE `subtasks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tasks`
--

DROP TABLE IF EXISTS `tasks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tasks` (
  `tid` int NOT NULL AUTO_INCREMENT,
  `TaskTitle` text,
  `ProjectId` int NOT NULL,
  PRIMARY KEY (`tid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tasks`
--

LOCK TABLES `tasks` WRITE;
/*!40000 ALTER TABLE `tasks` DISABLE KEYS */;
/*!40000 ALTER TABLE `tasks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) DEFAULT NULL,
  `password` text,
  `userName` text,
  `email` text,
  `profilePic` text,
  `phone` text,
  `Lastlogin` varbinary(4000) DEFAULT NULL,
  `role` text,
  `onlineStatus` text,
  `companyId` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Rehan','$2a$11$BhHTGpqfolv095GuHl4k0OYpAucyua8A7yuDxkWRe57el.PR8Vc9O','rehan05@codistan.pa.com','rehan05@gmail.com',NULL,'923167829691',NULL,'admin',NULL,'1'),(2,'Azeem','$2a$11$fkE0KLqeSjgiplOEJD.dnecURkdkaE3N2Jk/5nj/TbDBSoSvcAVRe','as1265513@uiit.pa.com','as12@gmail.com',NULL,'923809238222',_binary '0001-01-01 00:00:00','admin',NULL,'2'),(3,'Rehan','$2a$11$l0DrpUNrowHJC55qWtqQ3.97TsLGK5Y3eoO6xJIRNIhxOnxkPI7/W','Rehan105@uiit.pa.com','rehangoaya05@gmail.com',NULL,'923167829691',_binary '0001-01-01 00:00:00','Member',NULL,'2'),(4,'Qasim','$2a$11$aemYwEo7fSZBI8Wyffkp4.A0Ic30rSzoCU5kbNtVs5ej8mcV8Kbpy','Qasim105@uiit.pa.com','Qasimali@gmail.com',NULL,'13192989238',_binary '0001-01-01 00:00:00','Member',NULL,'2'),(5,'MrRehan','$2a$11$sSAAqpXkPgupq8TaD203DuDYuvrXrqF5ZoUdXSOYoKF99hgs1AODO','mrrehan105@codistankhan.pa.com','codistankhan@gmail.com',NULL,'923167829691',_binary '0001-01-01 00:00:00','admin',NULL,'3'),(6,'Rehan','$2a$11$BVBMMBeXiW9j7ylUJpQbIO1y0f1HZDVOIX/WaHhPx0kmsQ8OyjHpq','Rehan12345@codistanisb.pa.com','rehangoraya12345@gmail.com',NULL,'9043849384',_binary '0001-01-01 00:00:00','admin',NULL,'4');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-27 14:35:54
